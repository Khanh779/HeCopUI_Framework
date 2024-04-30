using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HeCopUI_Framework.Win32.Enums
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct BLENDFUNCTION
    {
        public byte BlendOp;

        public byte BlendFlags;

        public byte SourceConstantAlpha;

        public byte AlphaFormat;
    }

    public struct MARGINS
    {
        public int leftWidth;

        public int rightWidth;

        public int topHeight;

        public int bottomHeight;
    }


    public struct POINT
    {
        public int x;

        public int y;

        public POINT(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public POINT(Point point)
        {
            x = point.X;
            y = point.Y;
        }

        public override string ToString()
        {
            return $"x:{x} y:{y}";
        }
    }

    public struct RECT
    {
        public int left;

        public int top;

        public int right;

        public int bottom;

#pragma warning disable CS3005 // Identifier differing only in case is not CLS-compliant
        public int Left
#pragma warning restore CS3005 // Identifier differing only in case is not CLS-compliant
        {
            get
            {
                return left;
            }
            set
            {
                left = value;
            }
        }

#pragma warning disable CS3005 // Identifier differing only in case is not CLS-compliant
        public int Right
#pragma warning restore CS3005 // Identifier differing only in case is not CLS-compliant
        {
            get
            {
                return right;
            }
            set
            {
                right = value;
            }
        }

#pragma warning disable CS3005 // Identifier differing only in case is not CLS-compliant
        public int Top
#pragma warning restore CS3005 // Identifier differing only in case is not CLS-compliant
        {
            get
            {
                return top;
            }
            set
            {
                top = value;
            }
        }

#pragma warning disable CS3005 // Identifier differing only in case is not CLS-compliant
        public int Bottom
#pragma warning restore CS3005 // Identifier differing only in case is not CLS-compliant
        {
            get
            {
                return bottom;
            }
            set
            {
                bottom = value;
            }
        }

        public POINT Location
        {
            get
            {
                return new POINT(left, top);
            }
            set
            {
                right -= left - value.x;
                bottom -= bottom - value.y;
                left = value.x;
                top = value.y;
            }
        }

        public int Width
        {
            get
            {
                return Math.Abs(right - left);
            }
            set
            {
                right = left + value;
            }
        }

        public int Height
        {
            get
            {
                return Math.Abs(bottom - top);
            }
            set
            {
                bottom = top + value;
            }
        }

        public RECT(int left, int top, int width, int height)
        {
            this.left = left;
            this.top = top;
            right = this.left + width;
            bottom = this.top + height;
        }

        public RECT(Rectangle r)
        {
            left = r.Left;
            top = r.Top;
            right = r.Right;
            bottom = r.Bottom;
        }

        public Rectangle ToRectangle()
        {
            return Rectangle.FromLTRB(Left, Top, Right, Bottom);
        }

        public void Inflate(int width, int height)
        {
            Left -= width;
            Top -= height;
            Right += width;
            Bottom += height;
        }

        public override string ToString()
        {
            return $"x:{Left},y:{Top},width:{Right - Left},height:{Bottom - Top}";
        }

        public static explicit operator Rectangle(RECT rect)
        {
            return new Rectangle(rect.left, rect.top, rect.right - rect.left, rect.bottom - rect.top);
        }
    }

    public struct SIZE
    {
        public int cx;

        public int cy;

        public SIZE(int cx, int cy)
        {
            this.cx = cx;
            this.cy = cy;
        }
    }

    [Flags]
    public enum WindowStyles : long
    {
        WS_OVERLAPPED = 0L, WS_POPUP = 0x80000000L, WS_CHILD = 0x40000000L, WS_MINIMIZE = 0x20000000L, WS_VISIBLE = 0x10000000L, WS_DISABLED = 0x8000000L, WS_CLIPSIBLINGS = 0x4000000L, WS_CLIPCHILDREN = 0x2000000L, WS_MAXIMIZE = 0x1000000L, WS_CAPTION = 0xC00000L, WS_BORDER = 0x800000L, WS_DLGFRAME = 0x400000L, WS_VSCROLL = 0x200000L, WS_HSCROLL = 0x100000L, WS_SYSMENU = 0x80000L, WS_THICKFRAME = 0x40000L, WS_GROUP = 0x20000L, WS_TABSTOP = 0x10000L, WS_MINIMIZEBOX = 0x20000L, WS_MAXIMIZEBOX = 0x10000L, WS_TILED = 0L, WS_ICONIC = 0x20000000L, WS_SIZEBOX = 0x40000L, WS_POPUPWINDOW = 0x80880000L, WS_OVERLAPPEDWINDOW = 0xCF0000L, WS_TILEDWINDOW = 0xCF0000L, WS_CHILDWINDOW = 0x40000000L
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WNDCLASS
    {
#pragma warning disable
        public uint style;

        public IntPtr lpfnWndProc;

        public int cbClsExtra;

        public int cbWndExtra;

        public IntPtr hInstance;

        public IntPtr hIcon;

        public IntPtr hCursor;

        public IntPtr hbrBackground;

        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszMenuName;

        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszClassName;
    }



    public enum SystemMetricFlags
    {
        SM_ARRANGE = 56,
        SM_CLEANBOOT = 67,
        SM_CMONITORS = 80,
        SM_CMOUSEBUTTONS = 43,
        SM_CXBORDER = 5,
        SM_CXCURSOR = 13,
        SM_CXDLGFRAME = 7,
        SM_CXDOUBLECLK = 36,
        SM_CXDRAG = 68,
        SM_CXEDGE = 45,
        SM_CXFIXEDFRAME = 7,
        SM_CXFOCUSBORDER = 83,
        SM_CXFRAME = 32,
        SM_CXFULLSCREEN = 16,
        SM_CXHSCROLL = 21,
        SM_CXHTHUMB = 10,
        SM_CXICON = 11,
        SM_CXICONSPACING = 38,
        SM_CXMAXIMIZED = 61,
        SM_CXMAXTRACK = 59,
        SM_CXMENUCHECK = 71,
        SM_CXMENUSIZE = 54,
        SM_CXMIN = 28,
        SM_CXMINIMIZED = 57,
        SM_CXMINSPACING = 47,
        SM_CXMINTRACK = 34,
        SM_CXPADDEDBORDER = 92,
        SM_CXSCREEN = 0,
        SM_CXSIZE = 30,
        SM_CXSIZEFRAME = 32,
        SM_CXSMICON = 49,
        SM_CXSMSIZE = 52,
        SM_CXVIRTUALSCREEN = 78,
        SM_CXVSCROLL = 2,
        SM_CYBORDER = 6,
        SM_CYCAPTION = 4,
        SM_CYCURSOR = 14,
        SM_CYDLGFRAME = 8,
        SM_CYDOUBLECLK = 37,
        SM_CYDRAG = 69,
        SM_CYEDGE = 46,
        SM_CYFIXEDFRAME = 8,
        SM_CYFOCUSBORDER = 84,
        SM_CYFRAME = 33,
        SM_CYFULLSCREEN = 17,
        SM_CYHSCROLL = 3,
        SM_CYICON = 12,
        SM_CYICONSPACING = 39,
        SM_CYKANJIWINDOW = 18,
        SM_CYMAXIMIZED = 62,
        SM_CYMAXTRACK = 60,
        SM_CYMENU = 15,
        SM_CYMENUCHECK = 72,
        SM_CYMENUSIZE = 55,
        SM_CYMIN = 29,
        SM_CYMINIMIZED = 58,
        SM_CYMINSPACING = 48,
        SM_CYMINTRACK = 35,
        SM_CYSCREEN = 1,
        SM_CYSIZE = 31,
        SM_CYSIZEFRAME = 33,
        SM_CYSMCAPTION = 51,
        SM_CYSMICON = 50,
        SM_CYSMSIZE = 53,
        SM_CYVIRTUALSCREEN = 79,
        SM_CYVSCROLL = 20,
        SM_CYVTHUMB = 9,
        SM_DBCSENABLED = 42,
        SM_DEBUG = 22,
        SM_DIGITIZER = 94,
        SM_IMMENABLED = 82,
        SM_MAXIMUMTOUCHES = 95,
        SM_MEDIACENTER = 87,
        SM_MENUDROPALIGNMENT = 40,
        SM_MIDEASTENABLED = 74,
        SM_MOUSEPRESENT = 19,
        SM_MOUSEHORIZONTALWHEELPRESENT = 91,
        SM_MOUSEWHEELPRESENT = 75,
        SM_NETWORK = 63,
        SM_PENWINDOWS = 41,
        SM_REMOTECONTROL = 8193,
        SM_REMOTESESSION = 4096,
        SM_SAMEDISPLAYFORMAT = 81,
        SM_SECURE = 44,
        SM_SERVERR2 = 89,
        SM_SHOWSOUNDS = 70,
        SM_SHUTTINGDOWN = 8192,
        SM_SLOWMACHINE = 73,
        SM_STARTER = 88,
        SM_SWAPBUTTON = 23,
        SM_TABLETPC = 86,
        SM_XVIRTUALSCREEN = 76,
        SM_YVIRTUALSCREEN = 77
    }

    public enum SetWindowPosFlags
    {
        SWP_NOSIZE = 1,
        SWP_NOMOVE = 2,
        SWP_NOZORDER = 4,
        SWP_NOREDRAW = 8,
        SWP_NOACTIVATE = 16,
        SWP_FRAMECHANGED = 32,
        SWP_SHOWWINDOW = 64,
        SWP_HIDEWINDOW = 128,
        SWP_NOCOPYBITS = 256,
        SWP_NOOWNERZORDER = 512,
        SWP_NOSENDCHANGING = 1024,
        SWP_DRAWFRAME = 32,
        SWP_NOREPOSITION = 512,
        SWP_DEFERERASE = 8192,
        SWP_ASYNCWINDOWPOS = 16384
    }

    public enum ShowWindowStyles : short
    {
        SW_HIDE = 0,
        SW_SHOWNORMAL = 1,
        SW_NORMAL = 1,
        SW_SHOWMINIMIZED = 2,
        SW_SHOWMAXIMIZED = 3,
        SW_MAXIMIZE = 3,
        SW_SHOWNOACTIVATE = 4,
        SW_SHOW = 5,
        SW_MINIMIZE = 6,
        SW_SHOWMINNOACTIVE = 7,
        SW_SHOWNA = 8,
        SW_RESTORE = 9,
        SW_SHOWDEFAULT = 10,
        SW_FORCEMINIMIZE = 11,
        SW_MAX = 11
    }

    public enum HitTest
    {
        HTERROR = -2,
        HTTRANSPARENT = -1,
        HTNOWHERE = 0,
        HTCLIENT = 1,
        HTCAPTION = 2,
        HTSYSMENU = 3,
        HTGROWBOX = 4,
        HTSIZE = 4,
        HTMENU = 5,
        HTHSCROLL = 6,
        HTVSCROLL = 7,
        HTMINBUTTON = 8,
        HTMAXBUTTON = 9,
        HTLEFT = 10,
        HTRIGHT = 11,
        HTTOP = 12,
        HTTOPLEFT = 13,
        HTTOPRIGHT = 14,
        HTBOTTOM = 15,
        HTBOTTOMLEFT = 16,
        HTBOTTOMRIGHT = 17,
        HTBORDER = 18,
        HTREDUCE = 8,
        HTZOOM = 9,
        HTSIZEFIRST = 10,
        HTSIZELAST = 17,
        HTOBJECT = 19,
        HTCLOSE = 20,
        HTHELP = 21
    }

    public enum GetWindowLongFlags
    {
        GWL_WNDPROC = -4,
        GWL_HINSTANCE = -6,
        GWL_HWNDPARENT = -8,
        GWL_STYLE = -16,
        GWL_EXSTYLE = -20,
        GWL_USERDATA = -21,
        GWL_ID = -12
    }

    public class Win32Enums
	{
		internal static readonly IntPtr TRUE = new IntPtr(1);

		internal static readonly IntPtr FALSE = new IntPtr(0);

		internal static readonly IntPtr MESSAGE_HANDLED = new IntPtr(1);

		internal static readonly IntPtr MESSAGE_PROCESS = new IntPtr(0);

		internal static int CornerAreaSize = SystemInformation.FrameBorderSize.Width / 2;

		internal static IntPtr MakeParam(IntPtr l, IntPtr h)
		{
			return (IntPtr)((l.ToInt32() & 0xFFFF) | (h.ToInt32() << 16));
		}

		internal static int Loword(int dwValue)
		{
			return dwValue & 0xFFFF;
		}

		internal static int Hiword(int dwValue)
		{
			return (dwValue >> 16) & 0xFFFF;
		}

		internal static POINT GetPostionFromPtr(IntPtr lparam)
		{
			int num = (int)Win32.LoWord(lparam);
			int num2 = (int)Win32.HiWord(lparam);
			int x = num;
			int y = num2;
			return new POINT(x, y);
		}

		internal static HitTest GetSizeMode(POINT point, int width, int height)
		{
			HitTest result = HitTest.HTCLIENT;
			int x = point.x;
			int y = point.y;
			if ((x < CornerAreaSize) & (y < CornerAreaSize))
			{
				result = HitTest.HTTOPLEFT;
			}
			else if ((x < CornerAreaSize) & (y + CornerAreaSize > height - CornerAreaSize))
			{
				result = HitTest.HTBOTTOMLEFT;
			}
			else if ((x + CornerAreaSize > width - CornerAreaSize) & (y + CornerAreaSize > height - CornerAreaSize))
			{
				result = HitTest.HTBOTTOMRIGHT;
			}
			else if ((x + CornerAreaSize > width - CornerAreaSize) & (y < CornerAreaSize))
			{
				result = HitTest.HTTOPRIGHT;
			}
			else if (x < CornerAreaSize)
			{
				result = HitTest.HTLEFT;
			}
			else if (x + CornerAreaSize > width - CornerAreaSize)
			{
				result = HitTest.HTRIGHT;
			}
			else if (y < CornerAreaSize)
			{
				result = HitTest.HTTOP;
			}
			else if (y + CornerAreaSize > height - CornerAreaSize)
			{
				result = HitTest.HTBOTTOM;
			}
			return result;
		}
	}
}