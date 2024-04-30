﻿using Microsoft.Win32;
using System;
using System.CodeDom;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace HeCopUI_Framework.Forms
{
    public class HFormFlat : Form
    {
        private Color headerColor1 = Color.FromArgb(70, 70, 70);
        private Color headerColor2 = Color.FromArgb(50, 50, 50);
        private Color closeColor = Color.FromArgb(241, 53, 53);
        private Color minimizeColor = Color.Green;
        private Color maximizeColor = Color.CornflowerBlue;
        private Color borderColor1 = Global.PrimaryColors.ProgressBarColor2;
        private Color borderColor2 = Global.PrimaryColors.ProgressBarColor2;

        /// <summary>
        /// The background color for the form's header.
        /// </summary>
        [Description("The background color 1 for the form's header.")]
        public Color HeaderColor1
        {
            get { return headerColor1; }
            set { headerColor1 = value; Invalidate(); }
        }

        /// <summary>
        /// The background color for the form's header.
        /// </summary>
        [Description("The background color 2 for the form's header.")]
        public Color HeaderColor2
        {
            get { return headerColor2; }
            set { headerColor2 = value; Invalidate(); }
        }

        /// <summary>
        /// The foreground color for the form's close button.
        /// </summary>
        [Description("The foreground color for the form's close button.")]
        public Color CloseColor
        {
            get { return closeColor; }
            set { closeColor = value; Invalidate(); }
        }

        /// <summary>
        /// The foreground color for the form's minimize button.
        /// </summary>
        [Description("The foreground color for the form's minimize button.")]
        public Color MinimizeColor
        {
            get { return minimizeColor; }
            set { minimizeColor = value; Invalidate(); }
        }

        /// <summary>
        /// The foreground color for the form's maximize button.
        /// </summary>
        [Description("The foreground color for the form's maximize button.")]
        public Color MaximizeColor
        {
            get { return maximizeColor; }
            set { maximizeColor = value; Invalidate(); }
        }

        /// <summary>
        /// The background color for the form's border.
        /// </summary>
        [Description("The background color 1 for the form's border.")]
        public Color BorderColor1
        {
            get { return borderColor1; }
            set { borderColor1 = value; Invalidate(); }
        }

        /// <summary>
        /// The background color for the form's border.
        /// </summary>
        [Description("The background color 1 for the form's border.")]
        public Color BorderColor2
        {
            get { return borderColor2; }
            set { borderColor2 = value; Invalidate(); }
        }


        private RectangleF left, topLeft, bottomLeft,
            right, topRight, bottomRight,
            top, bottom,
            close,
            minimize,
            maximize;

        int headerHeight = 30,
            resizeBorder = 6;

        /// <summary>
        /// Gets or sets the height of the form's header.
        /// </summary>
        public int HeaderHeight
        {
            get { return headerHeight; }
            set
            {
                headerHeight = value;
                Invalidate();
            }
        }

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (FormBorderStyle == FormBorderStyle.Sizable)
            {
                if ((left.Contains(e.Location) || right.Contains(e.Location)))
                    Cursor = Cursors.SizeWE;
                else if ((top.Contains(e.Location) || bottom.Contains(e.Location)))
                    Cursor = Cursors.SizeNS;
                else if ((topLeft.Contains(e.Location) || bottomRight.Contains(e.Location)))
                    Cursor = Cursors.SizeNWSE;
                else if ((topRight.Contains(e.Location) || bottomLeft.Contains(e.Location)))
                    Cursor = Cursors.SizeNESW;
                else if (close.Contains(e.Location) ||
                    (minimize.Contains(e.Location) && MinimizeBox) ||
                    (MinimizeBox && MaximizeBox && maximize.Contains(e.Location)))
                    Cursor = Cursors.Hand;
                else Cursor = Cursors.Default;
            }
            //ChangeBoolControl(e.Location);

            Invalidate();
        }

        bool hoveredClose = false, hoveredMinimize = false, hoveredMaximize = false;

        protected override void OnTextChanged(EventArgs e)
        {
            Invalidate();
            base.OnTextChanged(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (close.Contains(e.Location))
                    Close();
                else if (minimize.Contains(e.Location) && MinimizeBox)
                    WindowState = FormWindowState.Minimized;
                else if (maximize.Contains(e.Location) && MinimizeBox && MaximizeBox)
                {
                    WindowState = WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
                }

            }
            base.OnMouseClick(e);
        }


        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mo = e.Location;
                #region Mouse Resize
                if (left.Contains(mo) && FormBorderStyle == FormBorderStyle.Sizable)
                {
                    ReleaseCapture();
                    SendMessage(Handle, 161, 10, 0);
                }
                else if (right.Contains(mo) && FormBorderStyle == FormBorderStyle.Sizable)
                {
                    ReleaseCapture();
                    SendMessage(Handle, 161, 11, 0);
                }
                else if (top.Contains(mo) && FormBorderStyle == FormBorderStyle.Sizable)
                {
                    ReleaseCapture();
                    SendMessage(Handle, 161, 12, 0);
                }
                else if (bottom.Contains(mo) && FormBorderStyle == FormBorderStyle.Sizable)
                {
                    ReleaseCapture();
                    SendMessage(Handle, 161, 15, 0);
                }
                else if (topLeft.Contains(mo) && FormBorderStyle == FormBorderStyle.Sizable)
                {
                    ReleaseCapture();
                    SendMessage(Handle, 161, 13, 0);
                }
                else if (topRight.Contains(mo) && FormBorderStyle == FormBorderStyle.Sizable)
                {
                    ReleaseCapture();
                    SendMessage(Handle, 161, 14, 0);
                }
                else if (bottomLeft.Contains(mo) && FormBorderStyle == FormBorderStyle.Sizable)
                {
                    ReleaseCapture();
                    SendMessage(Handle, 161, 16, 0);
                }
                else if (bottomRight.Contains(mo) && FormBorderStyle == FormBorderStyle.Sizable)
                {
                    ReleaseCapture();
                    SendMessage(Handle, 161, 17, 0);
                } 
                else
                if (mo.X >= resizeBorder && mo.X <= (MinimizeBox ? minimize.X : MaximizeBox ? maximize.X : close.X) - resizeBorder * 2 &&
                        mo.Y >= resizeBorder && mo.Y <= headerHeight + (resizeBorder * 2))
                {
                    ReleaseCapture();
                    //SendMessage(Handle, 161, 2, 0);
                    SendMessage(this.Handle, 0x112, 0xf012, 0);
                }
                else if (mo.X >= 0 && mo.X <= (MinimizeBox ? minimize.X : MaximizeBox ? maximize.X : close.X) - resizeBorder * 2 &&
                    mo.Y >= 0 && mo.Y <= headerHeight)
                {
                    ReleaseCapture();
                    //SendMessage(Handle, 161, 2, 0);
                    SendMessage(this.Handle, 0x112, 0xf012, 0);
                }
                #endregion
            }
            base.OnMouseDown(e);

        }

        float offyCenter = 0; int iconControlBoxHeight = 22;

        /// <summary>
        /// Gets or sets the size of the control box icons.
        /// </summary>
        public int IconControlBoxHeight
        {
            get { return iconControlBoxHeight; }
            set
            {
                iconControlBoxHeight = value;
                Invalidate();
            }
        }

        Font titleFont = new Font("Segoe UI", 10.0f);
        /// <summary>
        /// Gets or sets the font of the form's title.
        /// </summary>
        public Font TitleFont
        {
            get { return titleFont; }
            set
            {
                titleFont = value; Invalidate();
            }

        }

        Color titleColor = Color.FromArgb(200, 200, 200);
        /// <summary>
        /// Gets or sets the color of the form's title.
        /// </summary>
        public Color TitleForeColor
        {
            get { return titleColor; }
            set
            {
                titleColor = value; Invalidate();
            }
        }

        LinearGradientMode titleLinearGradientMode = LinearGradientMode.Horizontal;

        /// <summary>
        /// Gets or sets the linear gradient mode of the form's title.
        /// </summary>
        public LinearGradientMode TitleLinearGradientMode
        {
            get { return titleLinearGradientMode; }
            set
            {
                titleLinearGradientMode = value; Invalidate();
            }
        }

        LinearGradientMode borderLinear = LinearGradientMode.Vertical;

        /// <summary>
        /// Gets or sets the linear gradient mode of the form's border.
        /// </summary>
        /// <param name="e"></param>
        public LinearGradientMode BorderLinearGradientMode
        {
            get { return borderLinear; }
            set
            {
                borderLinear = value;Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.None;
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            topLeft = new Rectangle(0, 0, resizeBorder, resizeBorder);
            top = new Rectangle(resizeBorder, 0, Width - (resizeBorder * 2), resizeBorder);
            topRight = new Rectangle(Width - resizeBorder, 0, resizeBorder, resizeBorder);
            left = new Rectangle(0, resizeBorder, resizeBorder, Height - (resizeBorder * 2));
            right = new Rectangle(Width - resizeBorder, resizeBorder, resizeBorder, Height - (resizeBorder * 2));
            bottomLeft = new Rectangle(0, Height - resizeBorder, resizeBorder, resizeBorder);
            bottom = new Rectangle(resizeBorder, Height - resizeBorder, Width - (resizeBorder * 2), resizeBorder);
            bottomRight = new Rectangle(Width - resizeBorder, Height - resizeBorder, resizeBorder, resizeBorder);

            if (FormBorderStyle != FormBorderStyle.None)
            {
                offyCenter = (float)((HeaderHeight - iconControlBoxHeight) / 2);

                RectangleF text = new RectangleF(resizeBorder + 2, (headerHeight + resizeBorder) / 2 - titleFont.Height / 2, Width - resizeBorder - iconControlBoxHeight, iconControlBoxHeight);

                e.Graphics.FillRectangle(new LinearGradientBrush(ClientRectangle, headerColor1, headerColor2, titleLinearGradientMode), 0, 0, Width, headerHeight + resizeBorder);

                if (ShowIcon)
                {
                    text.X += iconControlBoxHeight + 2;
                    text.Width -= iconControlBoxHeight;
                }
                if (ShowIcon) e.Graphics.DrawImage(Icon.ToBitmap(), new RectangleF(resizeBorder, resizeBorder / 2 + offyCenter, iconControlBoxHeight, iconControlBoxHeight));
                // draw title text
                e.Graphics.DrawString(Text, titleFont, new SolidBrush(titleColor), text, new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center });

                if (MinimizeBox) text.Width -= iconControlBoxHeight;
                if (MaximizeBox && FormBorderStyle == FormBorderStyle.Sizable) text.Width -= iconControlBoxHeight;

                Point mouse = PointToClient(MousePosition);

                close = new RectangleF(Width - iconControlBoxHeight - 5 - resizeBorder, resizeBorder / 2 + offyCenter, iconControlBoxHeight, iconControlBoxHeight);
                hoveredClose = close.Contains(mouse);

                e.Graphics.FillRectangle(new SolidBrush(hoveredClose ? Color.FromArgb(20, Color.White) : Color.Transparent),
                    close.X, close.Y, close.Width, close.Height);

                e.Graphics.DrawLine(new Pen(hoveredClose ? closeColor : ForeColor, 1.0f), new PointF(close.X + 6, close.Y + 6), new PointF(close.X + close.Width - 6, close.Y + close.Height - 6));
                e.Graphics.DrawLine(new Pen(hoveredClose ? closeColor : ForeColor, 1.0f), new PointF(close.X + close.Width - 6, close.Y + 6), new PointF(close.X + 6, close.Y + close.Height - 6));

                if (MinimizeBox)
                {
                    minimize = new RectangleF(close.X - iconControlBoxHeight - 5, close.Y, iconControlBoxHeight, iconControlBoxHeight);
                    hoveredMinimize = minimize.Contains(mouse);
                    e.Graphics.FillRectangle(new SolidBrush(hoveredMinimize ? Color.FromArgb(20, Color.White) : Color.Transparent),
                    minimize.X, minimize.Y, minimize.Width, minimize.Height);
                    if (MaximizeBox)
                    {
                        maximize = new RectangleF(close.X - iconControlBoxHeight - 5, minimize.Y, iconControlBoxHeight, iconControlBoxHeight);
                        minimize = new RectangleF(maximize.X - iconControlBoxHeight - 5, maximize.Y, iconControlBoxHeight, iconControlBoxHeight);
                        hoveredMaximize = maximize.Contains(mouse); hoveredMinimize = minimize.Contains(mouse);

                        e.Graphics.FillRectangle(new SolidBrush(hoveredMinimize ? Color.FromArgb(20, Color.White) : Color.Transparent), minimize.X, minimize.Y, minimize.Width, minimize.Height);
                        e.Graphics.FillRectangle(new SolidBrush(hoveredMaximize ? Color.FromArgb(20, Color.White) : Color.Transparent), maximize.X, maximize.Y, maximize.Width, maximize.Height);

                        if (WindowState == FormWindowState.Maximized)
                        {

                            e.Graphics.DrawLine(new Pen(hoveredMaximize ? maximizeColor : ForeColor, 1.0f),
                                new PointF(maximize.X + 6, maximize.Y + 8),
                                new PointF(maximize.X + 6, maximize.Y + maximize.Height - 6));
                            e.Graphics.DrawLine(new Pen(hoveredMaximize ? maximizeColor : ForeColor, 1.0f),
                                new PointF(maximize.X + 6, maximize.Y + maximize.Height - 6),
                                new PointF(maximize.X + maximize.Width - 8, maximize.Y + maximize.Height - 6));
                            e.Graphics.DrawLine(new Pen(hoveredMaximize ? maximizeColor : ForeColor, 1.0f),
                                new PointF(maximize.X + maximize.Width - 8, maximize.Y + maximize.Height - 6),
                                new PointF(maximize.X + maximize.Width - 8, maximize.Y + 8));
                            e.Graphics.DrawLine(new Pen(hoveredMaximize ? maximizeColor : ForeColor, 1.0f),
                                new PointF(maximize.X + maximize.Width - 8, maximize.Y + 8),
                                new PointF(maximize.X + 6, maximize.Y + 8));

                            e.Graphics.DrawLine(new Pen(hoveredMaximize ? maximizeColor : ForeColor, 1.0f),
                                new PointF(maximize.X + 8, maximize.Y + 8),
                                new PointF(maximize.X + 8, maximize.Y + 6));
                            e.Graphics.DrawLine(new Pen(hoveredMaximize ? maximizeColor : ForeColor, 1.0f),
                                new PointF(maximize.X + 8, maximize.Y + 6),
                                new PointF(maximize.X + maximize.Width - 6, maximize.Y + 6));
                            e.Graphics.DrawLine(new Pen(hoveredMaximize ? maximizeColor : ForeColor, 1.0f),
                                new PointF(maximize.X + maximize.Width - 6, maximize.Y + 6),
                                new PointF(maximize.X + maximize.Width - 6, maximize.Y + maximize.Height - 8));
                            e.Graphics.DrawLine(new Pen(hoveredMaximize ? maximizeColor : ForeColor, 1.0f),
                                new PointF(maximize.X + maximize.Width - 6, maximize.Y + maximize.Height - 8),
                                new PointF(maximize.X + maximize.Width - 8, maximize.Y + maximize.Height - 8));
                        }
                        else if (WindowState == FormWindowState.Normal)
                        {
                            e.Graphics.DrawLine(new Pen(hoveredMaximize ? maximizeColor : ForeColor, 1.0f),
                                new PointF(maximize.X + 6, maximize.Y + 6),
                                new PointF(maximize.X + 6, maximize.Y + maximize.Height - 6));
                            e.Graphics.DrawLine(new Pen(hoveredMaximize ? maximizeColor : ForeColor, 1.0f),
                                new PointF(maximize.X + 6, maximize.Y + maximize.Height - 6),
                                new PointF(maximize.X + maximize.Width - 6, maximize.Y + maximize.Height - 6));
                            e.Graphics.DrawLine(new Pen(hoveredMaximize ? maximizeColor : ForeColor, 1.0f),
                                new PointF(maximize.X + maximize.Width - 6, maximize.Y + maximize.Height - 6),
                                new PointF(maximize.X + maximize.Width - 6, maximize.Y + 6));
                            e.Graphics.DrawLine(new Pen(hoveredMaximize ? maximizeColor : ForeColor, 1.0f),
                                new PointF(maximize.X + maximize.Width - 6, maximize.Y + 6),
                                new PointF(maximize.X + 6, maximize.Y + 6));
                        }
                    }

                    e.Graphics.DrawLine(new Pen(hoveredMinimize ? minimizeColor : ForeColor, 1.0f), new PointF(minimize.X + 6, minimize.Y + (minimize.Width / 2) + 1),
                        new PointF(minimize.X + minimize.Width - 6, minimize.Y + (minimize.Width / 2) + 1));

                }
            }
            LinearGradientBrush linearBorder = new LinearGradientBrush(ClientRectangle, borderColor1, borderColor2, borderLinear);
            e.Graphics.DrawRectangle(new Pen(linearBorder, 1.0f), 0, 0, Width - 1, Height - 1);

        }

        public bool MaximizeFullScreen { get; set; } = false;

        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);

            if (FormBorderStyle == FormBorderStyle.Sizable && WindowState== FormWindowState.Normal)
            {
                int screenY = Screen.FromPoint(Location).Bounds.Location.Y;
                int screenX = Screen.FromPoint(Location).Bounds.Location.X;
                int screenX2 = Screen.FromPoint(Location).Bounds.Location.X + Screen.FromPoint(Location).Bounds.Size.Width;
                bool wndSnap = Location.Y <= screenY + 6 && Location.Y >= screenY;
                bool mouseSnap = MousePosition.Y <= screenY + 6 && MousePosition.Y >= screenY;
                if (wndSnap || mouseSnap) WindowState = FormWindowState.Maximized;

            }

            int minWidth = (int)(CreateGraphics().MeasureString(Text, titleFont).ToSize().Width + iconControlBoxHeight + 20 + (MinimizeBox ? minimize.Width + 10 : 0) +
                         (MaximizeBox ? maximize.Width + 10 : 0) + close.Width);
            if (Size.Width < minWidth)
                Size = new Size(minWidth, Size.Height);
            if (Size.Height < headerHeight + resizeBorder)
                Size = new Size(Size.Width, headerHeight + resizeBorder);

        }

        public HFormFlat()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                    ControlStyles.ResizeRedraw |
                    ControlStyles.OptimizedDoubleBuffer, true);

            BackColor = Color.FromArgb(25, 25, 25);
            ForeColor = Color.FromArgb(200, 200, 200);

            //SetWindowLong(this.Handle, GWL_STYLE, SetWindowLong(this.Handle, GWL_STYLE, 0) & ~WS_CAPTION);
         
        }



        #region Custom Drop-Shadow

        [StructLayout(LayoutKind.Sequential)]
        public struct MARGINS
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }

        [DllImport("dwmapi.dll")]
        private static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hWnd, int attr, ref int attrValue, int attrSize);

        [DllImport("dwmapi.dll")]
        private static extern int DwmIsCompositionEnabled(ref int pfEnabled);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);


        const int WM_NCPAINT = 0x85, WM_NCCALCSIZE = 0x83, WM_NCHITTEST = 0x84, HTCAPTION = 0x2, WS_SIZEBOX = 0x40000, WS_THICKFRAME = 0x00040000,
        WS_CAPTION = 0x00C00000, WS_BORDE = 0x800000, WS_SYSMENU = 0x80000, WS_MAXIMIZEBOX = 0x10000, WS_MINIMIZE = 0x20000000, WS_MAXIMIZE = 0x1000000,
        HTCLIENT = 0x1, WM_MOUSEMOVE = 0x0200, WS_EX_COMPOSITED = 0x02000000, WM_NCLBUTTONDOWN = 0xA1,
        WM_NCACTIVATE = 0x86,
        WM_ERASEBKGND = 0x14,
        CS_HREDRAW = 0x0002,
        CS_VREDRAW = 0x0001,
        CS_DBLCLKS = 0x8,
        GWL_STYLE = -16,
        WM_GETMINMAXINFO=0x0024;
        const int HTLEFT = 10;  //Left border of a window, allows resize horizontally to the left
        const int HTRIGHT = 11; //Right border of a window, allows resize horizontally to the right
        const int HTTOP = 12;   //Upper-horizontal border of a window, allows resize vertically up
        const int HTTOPLEFT = 13;//Upper-left corner of a window border, allows resize diagonally to the left
        const int HTTOPRIGHT = 14;//Upper-right corner of a window border, allows resize diagonally to the right
        const int HTBOTTOM = 15; //Lower-horizontal border of a window, allows resize vertically down
        const int HTBOTTOMLEFT = 16;//Lower-left corner of a window border, allows resize diagonally to the left
        const int HTBOTTOMRIGHT = 17;//Lower-right corner of a window border, allows resize diagonally to the right  

        [StructLayout(LayoutKind.Sequential)]
        public struct MINMAXINFO
        {
            public POINT ptReserved;  // Điểm dự phòng (không sử dụng)
            public POINT ptMaxSize;  // Kích thước tối đa mà cửa sổ có thể đạt được
            public POINT ptMaxPosition;  // Vị trí tối đa của cửa sổ khi phóng to
            public POINT ptMinTrackSize;  // Kích thước tối thiểu của cửa sổ khi kéo
            public POINT ptMaxTrackSize;  // Kích thước tối đa của cửa sổ khi kéo
        }

        // Định nghĩa struct POINT
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;  // Giá trị tọa độ x
            public int y;  // Giá trị tọa độ y

            public POINT(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                if (FormBorderStyle != FormBorderStyle.None)
                {
                    cp.Style &= ~WS_CAPTION;
                    cp.Style &= ~WS_THICKFRAME;
                    
                }
                if(!DesignMode && FormBorderStyle== FormBorderStyle.Sizable)
                {
                    cp.Style &= WS_SIZEBOX;
                }    

                return cp;
            }
        }


        void SetAeroEffect()
        {
            int a = 0;
            MARGINS margins = new MARGINS
            {
                leftWidth = a,
                rightWidth = a,
                topHeight = 1,
                bottomHeight = a,
            };

            DwmExtendFrameIntoClientArea(this.Handle, ref margins); // Mở rộng vùng trong suốt
        }

        #endregion

        protected override void WndProc(ref Message m)
        {
           
            switch (m.Msg)
            {
                //case WM_NCPAINT:
                //    var v = 2;
                //    //DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
                //    //SetAeroEffect();
                //    break;
                //case WM_MOUSEMOVE:

                //    break;
                //case WM_NCLBUTTONDOWN:

                //    break;
                case WM_NCCALCSIZE:
                 
                    break;
                case WM_GETMINMAXINFO:
                    MINMAXINFO mmi = (MINMAXINFO)Marshal.PtrToStructure(m.LParam, typeof(MINMAXINFO));
                    // Thiết lập kích thước tối đa mong muốn
                    int desiredWidth = (int)(Screen.PrimaryScreen.WorkingArea.Width);
                    int desiredHeight = (int)(Screen.PrimaryScreen.WorkingArea.Height);

                    mmi.ptMaxSize.x = desiredWidth;
                    mmi.ptMaxSize.y = desiredHeight;
                    mmi.ptMaxTrackSize.x = desiredWidth;
                    mmi.ptMaxTrackSize.y = desiredHeight;

                    Marshal.StructureToPtr(mmi, m.LParam, true);  // Cập nhật cấu trúc MINMAXINFO

                    break;

                case WM_NCHITTEST:
                    if (FormBorderStyle != FormBorderStyle.None)
                    {
                        Point mos = PointToClient(MousePosition);
                        if (mos.X > resizeBorder && mos.X < (MinimizeBox ? minimize.X : MaximizeBox ? maximize.X : close.X) - resizeBorder * 2 &&
                            (mos.Y > resizeBorder && mos.Y < headerHeight))
                            m.Result = (IntPtr)HTCAPTION;

                    }

                    //if (FormBorderStyle== FormBorderStyle.Sizable && (int)m.Result == HTCLIENT && WindowState == FormWindowState.Normal)
                    //{
                    //    Point screenPoint = new Point(m.LParam.ToInt32()); //Gets screen point coordinates(X and Y coordinate of the pointer)                           
                    //    Point clientPoint = this.PointToClient(screenPoint); //Computes the location of the screen point into client coordinates                          
                    //    if (clientPoint.Y <= resizeBorder)//If the pointer is at the top of the form (within the resize area- X coordinate)
                    //    {
                    //        if (clientPoint.X <= resizeBorder) //If the pointer is at the coordinate X=0 or less than the resizing area(X=10) in 
                    //            m.Result = (IntPtr)HTTOPLEFT; //Resize diagonally to the left
                    //        else if (clientPoint.X < (this.Size.Width - resizeBorder))//If the pointer is at the coordinate X=11 or less than the width of the form(X=Form.Width-resizeArea)
                    //            m.Result = (IntPtr)HTTOP; //Resize vertically up
                    //        else //Resize diagonally to the right
                    //            m.Result = (IntPtr)HTTOPRIGHT;
                    //    }
                    //    else if (clientPoint.Y <= (this.Size.Height - resizeBorder)) //If the pointer is inside the form at the Y coordinate(discounting the resize area size)
                    //    {
                    //        if (clientPoint.X <= resizeBorder)//Resize horizontally to the left
                    //            m.Result = (IntPtr)HTLEFT;
                    //        else if (clientPoint.X > (this.Width - resizeBorder))//Resize horizontally to the right
                    //            m.Result = (IntPtr)HTRIGHT;
                    //    }
                    //    else
                    //    {
                    //        if (clientPoint.X <= resizeBorder)//Resize diagonally to the left
                    //            m.Result = (IntPtr)HTBOTTOMLEFT;
                    //        else if (clientPoint.X < (this.Size.Width - resizeBorder)) //Resize vertically down
                    //            m.Result = (IntPtr)HTBOTTOM;
                    //        else //Resize diagonally to the right
                    //            m.Result = (IntPtr)HTBOTTOMRIGHT;
                    //    }
                    //}
                    break;

            }

            base.WndProc(ref m); // Đảm bảo các xử lý cơ bản của Form
        }
    }
}
