using HeCopUI_Framework.Struct;
using Microsoft.Win32;
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
using System.Windows.Media.Media3D;
using static HeCopUI_Framework.GetAppResources;
using static HeCopUI_Framework.GetAppResources.Win32;
using static HeCopUI_Framework.Win32.ShellAPI;
using static System.Net.WebRequestMethods;
using Point = System.Drawing.Point;
using Size = System.Drawing.Size;

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


        bool hoveredClose = false, hoveredMinimize = false, hoveredMaximize = false;

        protected override void OnTextChanged(EventArgs e)
        {
            Invalidate();
            base.OnTextChanged(e);
        }

       

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                IsResize();
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

            #region Draw Resize Border
            //DrawPaint(e);

            #endregion
            //LinearGradientBrush linearBorder = new LinearGradientBrush(ClientRectangle, borderColor1, borderColor2, borderLinear);
            //e.Graphics.DrawRectangle(new Pen(linearBorder, 1.0f), 0, 0, Width - 1, Height - 1);

        }

        void DrawPaint(Graphics g)
        {
            if (FormBorderStyle != FormBorderStyle.None)
            {
                offyCenter = (float)((HeaderHeight - iconControlBoxHeight) / 2);

                RectangleF text = new RectangleF(resizeBorder + 2, (headerHeight + resizeBorder) / 2 - titleFont.Height / 2, Width - resizeBorder - iconControlBoxHeight, iconControlBoxHeight);

                g.FillRectangle(new LinearGradientBrush(ClientRectangle, headerColor1, headerColor2, titleLinearGradientMode), 0, 0, Width, headerHeight + resizeBorder);

                if (ShowIcon)
                {
                    text.X += iconControlBoxHeight + 2;
                    text.Width -= iconControlBoxHeight;
                }
                if (ShowIcon) g.DrawImage(Icon.ToBitmap(), new RectangleF(resizeBorder, resizeBorder / 2 + offyCenter, iconControlBoxHeight, iconControlBoxHeight));
                // draw title text
                g.DrawString(Text, titleFont, new SolidBrush(titleColor), text, new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center });

                if (MinimizeBox) text.Width -= iconControlBoxHeight;
                if (MaximizeBox && FormBorderStyle == FormBorderStyle.Sizable) text.Width -= iconControlBoxHeight;

                close = new RectangleF(Width - iconControlBoxHeight - 5 - resizeBorder, resizeBorder / 2 + offyCenter, iconControlBoxHeight, iconControlBoxHeight);
              
                g.FillRectangle(new SolidBrush(hoveredClose ? Color.FromArgb(20, Color.White) : Color.Transparent),
                    close.X, close.Y, close.Width, close.Height);

                g.DrawLine(new Pen(hoveredClose ? closeColor : ForeColor, 1.0f), new PointF(close.X + 6, close.Y + 6), new PointF(close.X + close.Width - 6, close.Y + close.Height - 6));
                g.DrawLine(new Pen(hoveredClose ? closeColor : ForeColor, 1.0f), new PointF(close.X + close.Width - 6, close.Y + 6), new PointF(close.X + 6, close.Y + close.Height - 6));
                hoveredClose = close.Contains(pointT);
               
                if (MinimizeBox)
                {
                    minimize = new RectangleF(close.X - iconControlBoxHeight - 5, close.Y, iconControlBoxHeight, iconControlBoxHeight);
                    g.FillRectangle(new SolidBrush(hoveredMinimize ? Color.FromArgb(20, Color.White) : Color.Transparent),
                    minimize.X, minimize.Y, minimize.Width, minimize.Height);
                    hoveredMinimize = minimize.Contains(pointT);
                    if (MaximizeBox)
                    {
                        maximize = new RectangleF(close.X - iconControlBoxHeight - 5, minimize.Y, iconControlBoxHeight, iconControlBoxHeight);
                        minimize = new RectangleF(maximize.X - iconControlBoxHeight - 5, maximize.Y, iconControlBoxHeight, iconControlBoxHeight);
                        hoveredMinimize = minimize.Contains(pointT);
                        hoveredMaximize = maximize.Contains(pointT);
                        g.FillRectangle(new SolidBrush(hoveredMinimize ? Color.FromArgb(20, Color.White) : Color.Transparent), minimize.X, minimize.Y, minimize.Width, minimize.Height);
                        g.FillRectangle(new SolidBrush(hoveredMaximize ? Color.FromArgb(20, Color.White) : Color.Transparent), maximize.X, maximize.Y, maximize.Width, maximize.Height);

                        if (WindowState == FormWindowState.Maximized)
                        {

                            g.DrawLine(new Pen(hoveredMaximize ? maximizeColor : ForeColor, 1.0f),
                                new PointF(maximize.X + 6, maximize.Y + 8),
                                new PointF(maximize.X + 6, maximize.Y + maximize.Height - 6));
                            g.DrawLine(new Pen(hoveredMaximize ? maximizeColor : ForeColor, 1.0f),
                                new PointF(maximize.X + 6, maximize.Y + maximize.Height - 6),
                                new PointF(maximize.X + maximize.Width - 8, maximize.Y + maximize.Height - 6));
                            g.DrawLine(new Pen(hoveredMaximize ? maximizeColor : ForeColor, 1.0f),
                                new PointF(maximize.X + maximize.Width - 8, maximize.Y + maximize.Height - 6),
                                new PointF(maximize.X + maximize.Width - 8, maximize.Y + 8));
                            g.DrawLine(new Pen(hoveredMaximize ? maximizeColor : ForeColor, 1.0f),
                                new PointF(maximize.X + maximize.Width - 8, maximize.Y + 8),
                                new PointF(maximize.X + 6, maximize.Y + 8));

                            g.DrawLine(new Pen(hoveredMaximize ? maximizeColor : ForeColor, 1.0f),
                                new PointF(maximize.X + 8, maximize.Y + 8),
                                new PointF(maximize.X + 8, maximize.Y + 6));
                            g.DrawLine(new Pen(hoveredMaximize ? maximizeColor : ForeColor, 1.0f),
                                new PointF(maximize.X + 8, maximize.Y + 6),
                                new PointF(maximize.X + maximize.Width - 6, maximize.Y + 6));
                            g.DrawLine(new Pen(hoveredMaximize ? maximizeColor : ForeColor, 1.0f),
                                new PointF(maximize.X + maximize.Width - 6, maximize.Y + 6),
                                new PointF(maximize.X + maximize.Width - 6, maximize.Y + maximize.Height - 8));
                            g.DrawLine(new Pen(hoveredMaximize ? maximizeColor : ForeColor, 1.0f),
                                new PointF(maximize.X + maximize.Width - 6, maximize.Y + maximize.Height - 8),
                                new PointF(maximize.X + maximize.Width - 8, maximize.Y + maximize.Height - 8));
                        }
                        else if (WindowState == FormWindowState.Normal)
                        {
                            g.DrawLine(new Pen(hoveredMaximize ? maximizeColor : ForeColor, 1.0f),
                                new PointF(maximize.X + 6, maximize.Y + 6),
                                new PointF(maximize.X + 6, maximize.Y + maximize.Height - 6));
                            g.DrawLine(new Pen(hoveredMaximize ? maximizeColor : ForeColor, 1.0f),
                                new PointF(maximize.X + 6, maximize.Y + maximize.Height - 6),
                                new PointF(maximize.X + maximize.Width - 6, maximize.Y + maximize.Height - 6));
                            g.DrawLine(new Pen(hoveredMaximize ? maximizeColor : ForeColor, 1.0f),
                                new PointF(maximize.X + maximize.Width - 6, maximize.Y + maximize.Height - 6),
                                new PointF(maximize.X + maximize.Width - 6, maximize.Y + 6));
                            g.DrawLine(new Pen(hoveredMaximize ? maximizeColor : ForeColor, 1.0f),
                                new PointF(maximize.X + maximize.Width - 6, maximize.Y + 6),
                                new PointF(maximize.X + 6, maximize.Y + 6));
                        }
                    }

                    g .DrawLine(new Pen(hoveredMinimize ? minimizeColor : ForeColor, 1.0f), new PointF(minimize.X + 6, minimize.Y + (minimize.Width / 2) + 1),
                        new PointF(minimize.X + minimize.Width - 6, minimize.Y + (minimize.Width / 2) + 1));

                }
            }
        }

        public bool MaximizeFullScreen { get; set; } = false;

        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);


            if (FormBorderStyle == FormBorderStyle.Sizable && MaximizeBox && WindowState== FormWindowState.Normal)
            {
                int screenY = Screen.FromPoint(Location).Bounds.Location.Y;
                int screenX = Screen.FromPoint(Location).Bounds.Location.X;
                int screenX2 = Screen.FromPoint(Location).Bounds.Location.X + Screen.FromPoint(Location).Bounds.Size.Width;
                bool wndSnap = Location.Y <= screenY + 6 && Location.Y >= screenY;
                bool mouseSnap = MousePosition.Y <= screenY + 6 && MousePosition.Y >= screenY;
                if (wndSnap || mouseSnap) WindowState = FormWindowState.Maximized;

            }

            MinSizeResize();
        }

        public HFormFlat()
        {
            SetStyle(ControlStyles.ResizeRedraw| ControlStyles.AllPaintingInWmPaint| ControlStyles.UserPaint |ControlStyles.OptimizedDoubleBuffer, true);
            BackColor = Color.FromArgb(25, 25, 25);
            ForeColor = Color.FromArgb(200, 200, 200);
           
            //SetAeroEffect();
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
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool TrackPopupMenu(IntPtr hMenu,int uFlags,int x,int y,int nReserved,IntPtr hWnd,IntPtr lpRect);

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd,IntPtr hWndInsertAfter,int x,int y,int cx,int cy,uint uFlags);

        [DllImport("User32.dll")]
        public static extern bool PostMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        #region
        const int WM_NCPAINT = 0x85, WM_NCCALCSIZE = 0x83, WM_NCHITTEST = 0x84, HTCAPTION = 0x2, WS_SIZEBOX = 0x40000, WS_THICKFRAME = 0x00040000,
        WS_CAPTION = 0x00C00000, WS_BORDE = 0x800000, WS_SYSMENU = 0x80000, WS_MAXIMIZEBOX = 0x10000, WS_MINIMIZE = 0x20000000, WS_MAXIMIZE = 0x1000000,
        HTCLIENT = 0x1, WS_EX_COMPOSITED = 0x02000000, WM_NCLBUTTONDOWN = 0x00A1, WM_LBUTTONDOWN = 0x0201, WM_LBUTTONDBLCLK = 0x0203, WM_NCLBUTTONUP = 0x00A2,

        WM_LBUTTONUP = 0x0202,
        WM_NCACTIVATE = 0x86, GWL_EXSTYLE = -20, WM_NCBUTTONDBLCLK = 0x00A6, WM_NCLBUTTONDBLCLK = 0x00A3, WM_NCRBUTTONDBLCLK = 0x00A7,
        WM_ERASEBKGND = 0x14,
        CS_HREDRAW = 0x0002,
        CS_VREDRAW = 0x0001,
        CS_DBLCLKS = 0x8,
        GWL_STYLE = -16,
        WM_GETMINMAXINFO = 0x0024,
        WM_SIZING = 0x0214,
        WM_NCMOUSEMOVE = 0x00A0, WM_NCRBUTTONUP = 0x00A5, WM_RBUTTONDOWN = 0x0204,
        WM_MOUSEMOVE = 0x0200, WM_RBUTTONUP = 0x0205, WM_NCRBUTTONDOWN = 0x00A4,
        WM_COMMAND = 0x0111, WM_SYSCOMMAND = 0x112, SC_MINIMIZE = 0xF020, SC_MAXIMIZE = 0xF030, SC_CLOSE = 0xF060, SC_RESTORE = 0xF120, SC_SIZE = 0xF000, SC_MOVE = 0xF010, SC_MOVE1 = 0xF012,
        TPM_LEFTBUTTON = 0x0000, TPM_RIGHTBUTTON = 0x0002, TPM_RETURNCMD = 0x0100,
        SIZE_RESTORED = 0, SIZE_MINIMIZED = 1, SIZE_MAXIMIZED = 2, SIZE_MAXSHOW = 3, SIZE_MAXHIDE = 4, WM_SIZE = 0x0005, WS_MINIMIZEBOX = 0x20000, WS_CONTROLBOX = 0x00080000;

        private const int RDW_INVALIDATE = 0x0001;
        private const int RDW_FRAME = 0x0400;
        private const int RDW_UPDATENOW = 0x0100;
        private const int RDW_ALLCHILDREN = 0x0080; public const int SWP_NOACTIVATE = 0x0010;


        const int HTLEFT = 10;  //Left border of a window, allows resize horizontally to the left
        const int HTRIGHT = 11; //Right border of a window, allows resize horizontally to the right
        const int HTTOP = 12;   //Upper-horizontal border of a window, allows resize vertically up
        const int HTTOPLEFT = 13;//Upper-left corner of a window border, allows resize diagonally to the left
        const int HTTOPRIGHT = 14;//Upper-right corner of a window border, allows resize diagonally to the right
        const int HTBOTTOM = 15; //Lower-horizontal border of a window, allows resize vertically down
        const int HTBOTTOMLEFT = 16;//Lower-left corner of a window border, allows resize diagonally to the left
        const int HTBOTTOMRIGHT = 17;//Lower-right corner of a window border, allows resize diagonally to the right  

        private const int SWP_FRAMECHANGED = 0x0020;
        private const int HWND_TOP = 0;

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

        [DllImport("user32.dll")]
        public static extern IntPtr BeginPaint(IntPtr hwnd, out PAINTSTRUCT lpPaint);

        [DllImport("user32.dll")]
        public static extern bool EndPaint(IntPtr hWnd, [In] ref PAINTSTRUCT lpPaint);

        // Hàm RedrawWindow để gọi API Windows
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, int flags);
        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, out GetAppResources.WinApi. RECT lpRect);



        #endregion

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                if (FormBorderStyle != FormBorderStyle.None)
                {
                    //cp.Style &= ~WS_CAPTION;
                    //cp.Style &= ~WS_THICKFRAME;
                    cp.Style &= ~WS_MINIMIZEBOX;
                    cp.Style &= ~WS_MAXIMIZEBOX;
                    cp.Style &= ~WS_CONTROLBOX;
                    cp.Style |= WS_SYSMENU ;

                }
                if (!DesignMode && FormBorderStyle == FormBorderStyle.Sizable || FormBorderStyle == FormBorderStyle.SizableToolWindow)
                {
                    //cp.Style |= WS_SIZEBOX;
                }

                cp.ExStyle |= WS_EX_COMPOSITED;
               

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
                topHeight = a,
                bottomHeight = a,
            };

           DwmExtendFrameIntoClientArea(this.Handle, ref margins); // Mở rộng vùng trong suốt
        }

        bool PositionContainHeader()
        {
            System.Drawing.Point mpo = PointToClient(MousePosition);
            if (resizeBorder <= mpo.X && mpo.X <= (MinimizeBox ? minimize.X : MaximizeBox ? maximize.X : close.X) - resizeBorder * 2 && mpo.Y >= resizeBorder && mpo.Y <= headerHeight + (resizeBorder * 2))
                return true;
            else if (0 <= mpo.X && mpo.X <= (MinimizeBox ? minimize.X : MaximizeBox ? maximize.X : close.X) - resizeBorder * 2 && mpo.Y >= 0 && mpo.Y <= headerHeight)
                return true;
            return false;
        }

        bool PositionContainHeaderMess(ref Message m)
        {
            Point mpo = new Point((int)m.LParam);
            if (resizeBorder <= mpo.X && mpo.X <= (MinimizeBox ? minimize.X : MaximizeBox ? maximize.X : close.X) - resizeBorder * 2 && mpo.Y >= resizeBorder && mpo.Y <= headerHeight + (resizeBorder * 2))
                return true;
            else if (0 <= mpo.X && mpo.X <= (MinimizeBox ? minimize.X : MaximizeBox ? maximize.X : close.X) - resizeBorder * 2 && mpo.Y >= 0 && mpo.Y <= headerHeight)
                return true;
            return false;
        }

        void IsResize(int msg=161)
        {
            if(FormBorderStyle== FormBorderStyle.Sizable || FormBorderStyle== FormBorderStyle.SizableToolWindow)
            {
                System.Drawing.Point mo = PointToClient(MousePosition);
                if (left.Contains(mo))
                {
                    ReleaseCapture();
                    SendMessage(Handle, msg, 10, 0);
                }
                else if (right.Contains(mo))
                {
                    ReleaseCapture();
                    SendMessage(Handle, msg, 11, 0);
                }
                else if (top.Contains(mo))
                {
                    ReleaseCapture();
                    SendMessage(Handle, msg, 12, 0);
                }
                else if (bottom.Contains(mo))
                {
                    ReleaseCapture();
                    SendMessage(Handle, msg, 15, 0);
                }
                else if (topLeft.Contains(mo))
                {
                    ReleaseCapture();
                    SendMessage(Handle, msg, 13, 0);
                }
                else if (topRight.Contains(mo))
                {
                    ReleaseCapture();
                    SendMessage(Handle, msg, 14, 0);
                }
                else if (bottomLeft.Contains(mo))
                {
                    ReleaseCapture();
                    SendMessage(Handle, msg, 16, 0);
                }
                else if (bottomRight.Contains(mo))
                {
                    ReleaseCapture();
                    SendMessage(Handle, msg, 17, 0);
                }
            }    
        }

        Size GetSizeHeaderExcludeControlBox => 
             new Size((int)(MinimizeBox ? minimize.X : MaximizeBox ? maximize.X : close.X) - resizeBorder * 2, HeaderHeight); 

        void hoveredResize()
        {
            Point point = PointToClient(MousePosition);
            if (FormBorderStyle == FormBorderStyle.Sizable || FormBorderStyle == FormBorderStyle.SizableToolWindow)
            {
                if ((left.Contains(point) || right.Contains(point)))
                    Cursor = Cursors.SizeWE;
                else if ((top.Contains(point) || bottom.Contains(point)))
                    Cursor = Cursors.SizeNS;
                else if ((topLeft.Contains(point) || bottomRight.Contains(point)))
                    Cursor = Cursors.SizeNWSE;
                else if ((topRight.Contains(point) || bottomLeft.Contains(point)))
                    Cursor = Cursors.SizeNESW;
                else if (close.Contains(point) ||
                    (minimize.Contains(point) && MinimizeBox) ||
                    (MinimizeBox && MaximizeBox && maximize.Contains(point)))
                    Cursor = Cursors.Hand;
                else Cursor = Cursors.Default;
            }
        }

        #endregion

        // Đây là một hàm mới để xử lý các thao tác liên quan đến vùng header
        private bool IsMouseOverHeader(int x, int y)
        {
            return x <= GetSizeHeaderExcludeControlBox.Width && y <= GetSizeHeaderExcludeControlBox.Height;
        }

        private void InvalidateNonClient()
        {
            RedrawWindow(this.Handle, IntPtr.Zero, IntPtr.Zero,
                RDW_INVALIDATE | RDW_FRAME | RDW_UPDATENOW);
        }

        protected override void WndProc(ref Message m)
        {
            var point = Point.Empty;
            if (m.Msg== WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
            {
                var nccalcsize = (NCCALCSIZE_PARAMS)Marshal.PtrToStructure(m.LParam, typeof(NCCALCSIZE_PARAMS));
                // Ví dụ: Ẩn viền cửa sổ để tạo giao diện không viền
                nccalcsize.rgc.Top += headerHeight + resizeBorder; // Ẩn thanh tiêu đề mặc định
                m.Result = IntPtr.Zero;
                Marshal.StructureToPtr(nccalcsize, m.LParam, false);
                //SetMinMaxInfo(ref m);
              
                ResizeForm(ref m);
                DrawCustomHeader(ref m);
            }
            else if(m.Msg== WM_NCPAINT)
            {
                DrawCustomHeader(ref m);
            }
            else if (m.Msg== WM_NCHITTEST)
            {
                if (FormBorderStyle != FormBorderStyle.None)
                {
                    if (m.Result == (IntPtr)1) // Nếu hittest trả về vùng client
                    {
                        point = PointToClient(MousePosition);
                        if (point.Y < headerHeight) // Nếu ở vùng thanh tiêu đề tùy chỉnh
                        {
                            m.Result = (IntPtr)2; // HTCAPTION để cho phép di chuyển
                        }
                    }
                }
                base.WndProc(ref m);
                if (FormBorderStyle == FormBorderStyle.Sizable || FormBorderStyle == FormBorderStyle.SizableToolWindow)
                    OnResizeFormR(ref m);
            }
            else if (m.Msg== WM_NCLBUTTONDOWN)
            {
                ReleaseCapture();
                SendMessage(Handle, 0x0112, 0xF012, 0); // Di chuyển form
            }
            else if (m.Msg== WM_NCRBUTTONDOWN)
            {
                if (IsMouseOverHeader(point.X, point.Y))
                {
                    IntPtr hMenu = GetSystemMenu(this.Handle, false);
                    TrackPopupMenu(hMenu, TPM_LEFTBUTTON | TPM_RETURNCMD, Cursor.Position.X, Cursor.Position.Y, 0, this.Handle, IntPtr.Zero);
                }
            }
            else if (m.Msg== WM_NCMOUSEMOVE)
            {
                point = PointToClient(MousePosition); point.Y = headerHeight + point.Y;
                if (point.X <= Width && close != Rectangle.Empty || minimize != Rectangle.Empty || maximize != Rectangle.Empty)
                    pointT = point;
                DrawCustomHeader(ref m);
            }
            else if(m.Msg== WM_MOUSEMOVE)
            {
                IsResize();
            }    
            else if (m.Msg== WM_NCLBUTTONUP)
            {
                if (hoveredClose)
                {
                    // Đóng form
                    PostMessage(this.Handle, 0x0112, 0xF060, 0);
                }
                else if (hoveredMaximize && MinimizeBox && MaximizeBox)
                {
                    if (WindowState == FormWindowState.Maximized)
                    {
                        PostMessage(this.Handle, 0x0112, 0xF120, 0);
                    }
                    else
                    {
                        PostMessage(this.Handle, 0x0112, 0xF030, 0);
                    }
                }
                else if (hoveredMinimize && MinimizeBox)
                {
                    PostMessage(this.Handle, 0x0112, 0xF020, 0);
                }
                ReleaseCapture();
                DrawCustomHeader(ref m);
            }
            else if (m.Msg== WM_NCLBUTTONDBLCLK)
            {
                HandleDoubleClick();
                ReleaseCapture();
                //ReleaseCapture();
                base.WndProc(ref m);
            }
            else if (m.Msg== WM_COMMAND)
            {
                HandleSystemCommand(ref m);
            }
            else
            {
                base.WndProc(ref m);
            }

        }

        Rectangle GetSizeFormNonClient()
        {
            GetAppResources.WinApi.RECT a = new WinApi.RECT();
            GetWindowRect(Handle, out  a);

            return a.ToRectangle();
        }

        private int LOWORD(int value) => value & 0xFFFF;
        private int HIWORD(int value) => (value >> 16) & 0xFFFF;

        private void DrawCustomHeader(ref Message m)
        {
            IntPtr hDC = GetWindowDC(m.HWnd);
            var a = GetSizeFormNonClient();
            using (Graphics g = Graphics.FromHdc(hDC))
            {
                DrawPaint(g);
                LinearGradientBrush linearBorder = new LinearGradientBrush(ClientRectangle, borderColor1, borderColor2, borderLinear);
                
                g.DrawRectangle(new Pen(linearBorder, 2), 0,0, a.Width, a.Height);
            } 
            ReleaseDC(m.HWnd, hDC);
        }

        Point pointT= Point.Empty;
        private void HandleDoubleClick()
        {
            if (PositionContainHeader() && MaximizeBox)
            {
                WindowState = WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
            }
        }

        private void SetMinMaxInfo(ref Message m)
        {
            MINMAXINFO mmi = (MINMAXINFO)Marshal.PtrToStructure(m.LParam, typeof(MINMAXINFO));
            int desiredWidth = (int)(Screen.PrimaryScreen.WorkingArea.Width);
            int desiredHeight = (int)(Screen.PrimaryScreen.WorkingArea.Height);
            mmi.ptMaxSize.x = desiredWidth;
            mmi.ptMaxSize.y = desiredHeight;
            mmi.ptMaxTrackSize.x = desiredWidth;
            mmi.ptMaxTrackSize.y = desiredHeight;

            Marshal.StructureToPtr(mmi, m.LParam, true); // Cập nhật MINMAXINFO
        }

        private void HandleSystemCommand(ref Message m)
        {
            int cmd = m.WParam.ToInt32();
            switch (cmd)
            {
                case SC_MINIMIZE:
                    WindowState = FormWindowState.Minimized;
                    break;
                case SC_MAXIMIZE:
                    WindowState = FormWindowState.Maximized;
                    break;
                case SC_RESTORE:
                    WindowState = FormWindowState.Normal;
                    break;
                case SC_CLOSE:
                    Close();
                    break;
            }
        }

        private void ResizeForm(ref Message message)
        {
            //if (FormBorderStyle != FormBorderStyle.Sizable || FormBorderStyle != FormBorderStyle.FixedToolWindow)
            //    return;
            var x = (int)(message.LParam.ToInt64() & 65535);
            var y = (int)((message.LParam.ToInt64() & -65536) >> 0x10);
            var point = PointToClient(new Point(x, y));

            #region  From Corners  

            if (point.Y >= Height - 0x10)
            {
                if (point.X >= Width - 0x10)
                {
                    message.Result = (IntPtr)(IsMirrored ? 0x10 : 0x11);
                    return;
                }

                if (point.X <= 0x10)
                {
                    message.Result = (IntPtr)(IsMirrored ? 0x11 : 0x10);
                    return;
                }
            }
            else if (point.Y <= 0x10)
            {
                if (point.X <= 0x10)
                {
                    message.Result = (IntPtr)(IsMirrored ? 0xe : 0xd);
                    return;
                }

                if (point.X >= Width - 0x10)
                {
                    message.Result = (IntPtr)(IsMirrored ? 0xd : 0xe);
                    return;
                }
            }

            #endregion

            #region From Sides

            if (point.Y <= 0x10)
            {
                message.Result = (IntPtr)0xc;
                return;
            }

            if (point.Y >= Height - 0x10)
            {
                message.Result = (IntPtr)0xf;
                return;
            }

            if (point.X <= 0x10)
            {
                message.Result = (IntPtr)0xa;
                return;
            }

            if (point.X >= Width - 0x10)
            {
                message.Result = (IntPtr)0xb;
            }

            #endregion
        }

        void OnResizeFormR(ref Message m)
        {
            if ((FormBorderStyle == FormBorderStyle.Sizable || FormBorderStyle == FormBorderStyle.SizableToolWindow) && (int)m.Result == HTCLIENT && WindowState == FormWindowState.Normal)
            {
                Point screenPoint = new Point(m.LParam.ToInt32()); //Gets screen point coordinates(X and Y coordinate of the pointer)                           
                Point clientPoint = this.PointToClient(screenPoint); //Computes the location of the screen point into client coordinates                          
                if (clientPoint.Y <= resizeBorder)//If the pointer is at the top of the form (within the resize area- X coordinate)
                {
                    if (clientPoint.X <= resizeBorder) //If the pointer is at the coordinate X=0 or less than the resizing area(X=10) in 
                        m.Result = (IntPtr)HTTOPLEFT; //Resize diagonally to the left
                    else if (clientPoint.X < (this.Size.Width - resizeBorder))//If the pointer is at the coordinate X=11 or less than the width of the form(X=Form.Width-resizeArea)
                        m.Result = (IntPtr)HTTOP; //Resize vertically up
                    else //Resize diagonally to the right
                        m.Result = (IntPtr)HTTOPRIGHT;
                }
                else if (clientPoint.Y <= (this.Size.Height - resizeBorder)) //If the pointer is inside the form at the Y coordinate(discounting the resize area size)
                {
                    if (clientPoint.X <= resizeBorder)//Resize horizontally to the left
                        m.Result = (IntPtr)HTLEFT;
                    else if (clientPoint.X > (this.Width - resizeBorder))//Resize horizontally to the right
                        m.Result = (IntPtr)HTRIGHT;
                }
                else
                {
                    if (clientPoint.X <= resizeBorder)//Resize diagonally to the left
                        m.Result = (IntPtr)HTBOTTOMLEFT;
                    else if (clientPoint.X < (this.Size.Width - resizeBorder)) //Resize vertically down
                        m.Result = (IntPtr)HTBOTTOM;
                    else //Resize diagonally to the right
                        m.Result = (IntPtr)HTBOTTOMRIGHT;
                }
            }
        }

        void MinSizeResize()
        {
            int minWidth = (int)(CreateGraphics().MeasureString(Text, titleFont).ToSize().Width + iconControlBoxHeight + 20 + (MinimizeBox ? minimize.Width + 10 : 0) +
            (MaximizeBox ? maximize.Width + 10 : 0) + close.Width);
            if (Size.Width < minWidth) Size = new Size(minWidth, Size.Height);
            if (Size.Height < headerHeight + resizeBorder) Size = new Size(Size.Width, headerHeight + resizeBorder);
        }

    }
}
