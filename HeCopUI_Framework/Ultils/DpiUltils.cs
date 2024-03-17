using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HeCopUI_Framework.Ultils
{
    public static class DpiUtils
    {
        private enum MonitorOptions : uint
        {
            DefaultToNull = 0,
            DefaultToPrimary = 1,
            DefaultToNearest = 2
        }

        private enum DpiType
        {
            Effective = 0,
            Angular = 1,
            Raw = 2,
        }

        private struct SuggestedBoundsRect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        private const int WM_DPICHANGED = 0x02E0;

        [DllImport("Msg.dll")]
        private static extern IntPtr MonitorFromPoint(Point pt, MonitorOptions dwFlags);

        [DllImport("Msg.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, IntPtr lParam);

        [DllImport("Shcore.dll")]
        private static extern IntPtr GetDpiForMonitor([In] IntPtr hmonitor, [In] DpiType dpiType, [Out] out uint dpiX, [Out] out uint dpiY);

        private static int GetPerMonitorDpiForControl(Control c)
        {
            var dpi = 96;

            try
            {
                var p = c.PointToScreen(new Point(c.Bounds.X + c.Bounds.Width / 2, c.Bounds.Y + c.Bounds.Height / 2));
                var monitorHandle = MonitorFromPoint(p, MonitorOptions.DefaultToNearest);
                uint dpiX, dpiY;
                GetDpiForMonitor(monitorHandle, DpiType.Effective, out dpiX, out dpiY);
                dpi = (int)dpiX;
            }
            catch (Exception e)
            {
                Trace.WriteLine($"Exception when getting screen DPI: {e}");
            }

            return dpi;
        }

        public static void InitPerMonitorDpi(Form form)
        {
            var reportedDpi = form.DeviceDpi;
            var trueDpi = GetPerMonitorDpiForControl(form);

            if (reportedDpi == trueDpi)
                return;

            var wParam = (trueDpi << 16) | (trueDpi & 0xffff);
            var dpiRatio = trueDpi / (double)reportedDpi;
            var suggestedBounds = new SuggestedBoundsRect
            {
                Left = form.Location.X,
                Top = form.Location.Y,
                Right = form.Location.X + (int)(form.Width * dpiRatio),
                Bottom = form.Location.Y + (int)(form.Height * dpiRatio)
            };

            try
            {
                var ptr = Marshal.AllocHGlobal(Marshal.SizeOf(suggestedBounds));
                Marshal.StructureToPtr(suggestedBounds, ptr, false);
                SendMessage(form.Handle, WM_DPICHANGED, wParam, ptr);
                Marshal.FreeHGlobal(ptr);
            }
            catch (Exception e)
            {
                Trace.WriteLine($"Exception when initialising per-monitor DPI: {e}");
            }
        }
    }
}