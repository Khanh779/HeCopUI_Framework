using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HeCopUI_Framework.Helper
{
    public class GraphicsHelper
    {
        public static Bitmap SetBitmapTransparentDesktop(Control control)
        {
            Bitmap aBmp = null;
            IntPtr screenDC = HeCopUI_Framework.Win32.User32.GetDC(IntPtr.Zero);
            IntPtr memDC = HeCopUI_Framework.Win32.Gdi32.CreateCompatibleDC(screenDC);
            IntPtr hBitmap = IntPtr.Zero;
            IntPtr oldBitmap = IntPtr.Zero;
            try
            {
                hBitmap = aBmp.GetHbitmap(Color.FromArgb(0));
                oldBitmap = HeCopUI_Framework.Win32.Gdi32.SelectObject(memDC, hBitmap);

                Size size = new
                     Size(aBmp.Width, aBmp.Height);

                Point pointSource = new
                    Point(0, 0);

                Point topPos = new
                    Point(control.Left, control.Top);

                HeCopUI_Framework.Win32.Struct.BLENDFUNCTION blend = new HeCopUI_Framework.Win32.Struct.BLENDFUNCTION
                {
                    BlendOp = (byte)HeCopUI_Framework.Win32.Bitmap.Enums.AlphaBlend.AC_SRC_OVER,
                    BlendFlags = 0,
                    SourceConstantAlpha = 255,
                    AlphaFormat = (byte)HeCopUI_Framework.Win32.Bitmap.Enums.AlphaBlend.AC_SRC_ALPHA
                };
                HeCopUI_Framework.Win32.User32.UpdateLayeredWindow(control.Handle, screenDC, ref topPos, ref size, memDC, ref pointSource, 0, ref blend, (int)HeCopUI_Framework.Win32.Enums.UpdateLayeredWindows.ULW_ALPHA);
            }
            catch
            {
            }
            finally
            {
                HeCopUI_Framework.Win32.User32.ReleaseDC(IntPtr.Zero, screenDC);
                if (hBitmap != IntPtr.Zero)
                {
                    HeCopUI_Framework.Win32.Gdi32.SelectObject(memDC, oldBitmap);
                    HeCopUI_Framework.Win32.Gdi32.DeleteObject(hBitmap);
                }
                HeCopUI_Framework.Win32.Gdi32.DeleteDC(memDC);
            }
            return aBmp;
        }


        public static void SetHightGraphics(Graphics g)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

        }

        public static void MakeTransparent(Control control, Graphics g)
        {
            Control parent = control.Parent;
            if (parent != null)
            {
                Rectangle rectangle = control.Bounds;
                Control.ControlCollection controls = parent.Controls;
                int index = controls.IndexOf(control);
                Bitmap bitmap = null;
                for (int i = controls.Count - 1; i > index; i--)
                {
                    Control control3 = controls[i];
                    if (control3.Bounds.IntersectsWith(rectangle))
                    {
                        if (bitmap == null)
                        {
                            bitmap = new Bitmap(control.Parent.ClientSize.Width, control.Parent.ClientSize.Height);
                            bitmap.MakeTransparent();
                        }
                        control3.DrawToBitmap(bitmap, control3.Bounds);
                    }
                }
                if (bitmap != null)
                {
                    g.DrawImage(bitmap, control.ClientRectangle, rectangle, GraphicsUnit.Pixel);
                    bitmap.Dispose();
                }
            }
        }




        public static GraphicsPath GetRoundPath(RectangleF Rect, float radius, float width = 0)
        {
            //Fix radius to rect size
            radius = (int)Math.Max(
                     (Math.Min(radius,
                     Math.Min(Rect.Width, Rect.Height)) - width), 1) * 2;
            //radius *= 2;
            var r2 = (radius / 2f);
            var w2 = (width / 2f);
            GraphicsPath GraphPath = new GraphicsPath();

            if (radius != 0)
            {
                //Top-Left Arc  
                GraphPath.AddArc(Rect.X + w2, Rect.Y + w2, radius, radius, 180, 90);

                //Top-Right Arc 
                GraphPath.AddArc(Rect.X + Rect.Width - radius - w2, Rect.Y + w2, radius,
                                 radius, 270, 90);

                //Bottom-Right Arc 
                GraphPath.AddArc(Rect.X + Rect.Width - w2 - radius,
                            Rect.Y + Rect.Height - w2 - radius, radius, radius, 0, 90);

                //Bottom-Left Arc
                GraphPath.AddArc(Rect.X + w2, Rect.Y - w2 + Rect.Height - radius, radius,
                                 radius, 90, 90);

                //Close line ( Left)  
                GraphPath.AddLine(Rect.X + w2, Rect.Y + Rect.Height - r2 - w2, Rect.X +
                w2, Rect.Y + r2 + w2);


            }
            if (radius == 0) GraphPath.AddRectangle(new RectangleF(Rect.X + w2, Rect.Y + w2, Rect.Width - w2, Rect.Height - w2));
            return GraphPath;
        }



        public static Bitmap DrawBitmapShadow(RectangleF rectf, Color color, float radius, float size = 8)
        {
            if (rectf == null) return null;

            Bitmap bmp = new Bitmap((int)rectf.Width, (int)rectf.Height);
            bmp.MakeTransparent();

            var gp = GetRoundPath(rectf, radius);

            using (PathGradientBrush pathGradientBrush = new PathGradientBrush(gp))
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                ColorBlend colorBlend = new ColorBlend
                {
                    Colors = new Color[] { Color.Transparent, color },
                    Positions = new float[] { 0, 1 }
                };
                pathGradientBrush.InterpolationColors = colorBlend;

                //pathGradientBrush.CenterColor = color;
                //pathGradientBrush.SurroundColors = new Color[] { Color.Transparent };

                g.FillPath(pathGradientBrush, gp);
                //using (Pen pen = new Pen(pathGradientBrush, radius+ size))
                //{
                //    g.DrawPath(pen, gp);
                //}
            }

            return bmp;

        }



    }
}
