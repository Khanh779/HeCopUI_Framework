using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HeCopUI_Framework.Win32.Struct;

namespace HecopUI_Test.Forms
{
    public partial class FormFa : Form
    {
        public FormFa()
        {

        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= (int)(HeCopUI_Framework.Win32.Enums.WindowStyles.WS_VISIBLE | HeCopUI_Framework.Win32.Enums.WindowStyles.WS_SIZEBOX | HeCopUI_Framework.Win32.Enums.WindowStyles.WS_MINIMIZEBOX);
                cp.ExStyle |= 0;


                return cp;
            }
        }


        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case (int)HeCopUI_Framework.Win32.Enums.WindowMessages.WM_NCHITTEST:
                    base.WndProc(ref m);

                    //if (m.Result.ToInt32() == (int)HeCopUI_Framework.Win32.Enums.HitTests.HTCLIENT)
                    //    m.Result = new IntPtr((int)HeCopUI_Framework.Win32.Enums.HitTests.HTCAPTION);

                    break;

                //case (int)HeCopUI_Framework.Win32.Enums.WindowMessages.WM_NCCALCSIZE:
                //    base.WndProc(ref m);

                //    HeCopUI_Framework.Win32.Struct.NCCALCSIZE_PARAMS cp = new HeCopUI_Framework.Win32.Struct.NCCALCSIZE_PARAMS();
                //    cp = (HeCopUI_Framework.Win32.Struct.NCCALCSIZE_PARAMS)Marshal.PtrToStructure(m.LParam, typeof(HeCopUI_Framework.Win32.Struct.NCCALCSIZE_PARAMS));

                //    int cyframe = HeCopUI_Framework.Win32.User32.GetSystemMetrics(HeCopUI_Framework.Win32.Enums.SystemMetricFlags.SM_CYFRAME);
                //    int padding = HeCopUI_Framework.Win32.User32.GetSystemMetrics(HeCopUI_Framework.Win32.Enums.SystemMetricFlags.SM_CXPADDEDBORDER);
                //    int cycaption = HeCopUI_Framework.Win32.User32.GetSystemMetrics(HeCopUI_Framework.Win32.Enums.SystemMetricFlags.SM_CYCAPTION);

                //    int caption = cyframe + cycaption + padding;

                //    cp.rcOldWindow.Top -= caption;

                //    Marshal.StructureToPtr(cp, m.LParam, false);

                //    m.Result = IntPtr.Zero;
                //    return;

                case (int)HeCopUI_Framework.Win32.Enums.WindowMessages.WM_PAINT:

                    using (Graphics g = Graphics.FromHwnd(this.Handle))
                    {
                        g.FillRectangle(new SolidBrush(Color.Aquamarine), new Rectangle(20, 20, Width - 30, Height - 30));
                    }
                    m.Result = IntPtr.Zero;

                    break;

                ////case (int)HeCopUI_Framework.Win32.Enums.WindowMessages.WM_CLOSE:
                ////    Application.Exit();
                ////    break;

                //case (int)HeCopUI_Framework.Win32.Enums.WindowMessages.WM_GETMINMAXINFO:
                //    if (!DesignMode)
                //    {
                //        // allows the window to be maximized at the size of the working area instead of the whole screen size
                //        OnGetMinMaxInfo(ref m, 0);
                //        //Return Zero
                //        m.Result = IntPtr.Zero;
                //    }
                //    return;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        private void OnGetMinMaxInfo(ref Message m, int offSet = 0)
        {
            MINMAXINFO _lastMinMaxInfo = (MINMAXINFO)Marshal.PtrToStructure(m.LParam, typeof(MINMAXINFO));
            var s = Screen.FromHandle(Handle);
            _lastMinMaxInfo.maxPosition.X = Math.Abs(s.WorkingArea.Left - s.Bounds.Left) + offSet;
            _lastMinMaxInfo.maxPosition.Y = Math.Abs(s.WorkingArea.Top - s.Bounds.Top) + offSet;
            _lastMinMaxInfo.maxSize.Width = s.WorkingArea.Width - offSet * 2;
            _lastMinMaxInfo.maxSize.Height = s.WorkingArea.Height - offSet * 2;
            Marshal.StructureToPtr(_lastMinMaxInfo, m.LParam, true);
        }
    }
}
