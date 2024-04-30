using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;
using HeCopUI_Framework.Enums;
using HeCopUI_Framework.Win32.Enums;

namespace HeCopUI_Framework.Win32
{
    public class Win32
    {
    	[Flags]
    	internal enum AnimationFlags
    	{
    		Roll = 0,
    		HorizontalPositive = 1,
    		HorizontalNegative = 2,
    		VerticalPositive = 4,
    		VerticalNegative = 8,
    		Center = 0x10,
    		Hide = 0x10000,
    		Activate = 0x20000,
    		Slide = 0x40000,
    		Blend = 0x80000,
    		Mask = 0xFFFFF
    	}

    	internal struct MINMAXINFO
    	{
#pragma warning disable
            public Point reserved;

    		public Size maxSize;

    		public Point maxPosition;

    		public Size minTrackSize;

    		public Size maxTrackSize;
    	}

    	public enum ACCENT_STATE
    	{
    		ACCENT_DISABLED,
    		ACCENT_ENABLE_GRADIENT,
    		ACCENT_ENABLE_TRANSPARENTGRADIENT,
    		ACCENT_ENABLE_BLURBEHIND,
    		ACCENT_ENABLE_ACRYLICBLURBEHIND,
    		ACCENT_INVALID_STATE
    	}

    	public enum WINCOMPATTR
    	{
    		WCA_UNDEFINED,
    		WCA_NCRENDERING_ENABLED,
    		WCA_NCRENDERING_POLICY,
    		WCA_TRANSITIONS_FORCEDISABLED,
    		WCA_ALLOW_NCPAINT,
    		WCA_CAPTION_BUTTON_BOUNDS,
    		WCA_NONCLIENT_RTL_LAYOUT,
    		WCA_FORCE_ICONIC_REPRESENTATION,
    		WCA_EXTENDED_FRAME_BOUNDS,
    		WCA_HAS_ICONIC_BITMAP,
    		WCA_THEME_ATTRIBUTES,
    		WCA_NCRENDERING_EXILED,
    		WCA_NCADORNMENTINFO,
    		WCA_EXCLUDED_FROM_LIVEPREVIEW,
    		WCA_VIDEO_OVERLAY_ACTIVE,
    		WCA_FORCE_ACTIVEWINDOW_APPEARANCE,
    		WCA_DISALLOW_PEEK,
    		WCA_CLOAK,
    		WCA_CLOAKED,
    		WCA_ACCENT_POLICY,
    		WCA_FREEZE_REPRESENTATION,
    		WCA_EVER_UNCLOAKED,
    		WCA_VISUAL_OWNER,
    		WCA_HOLOGRAPHIC,
    		WCA_EXCLUDED_FROM_DDA,
    		WCA_PASSIVEUPDATEMODE,
    		WCA_USEDARKMODECOLORS,
    		WCA_CORNER_STYLE,
    		WCA_PART_COLOR,
    		WCA_DISABLE_MOVESIZE_FEEDBACK,
    		WCA_LAST
    	}

    	public enum WS
    	{
    		MAXIMIZEBOX = 0x10000,
    		MINIMIZEBOX = 0x20000,
    		SIZEBOX = 0x40000,
    		SYSMENU = 0x80000
    	}

    	public enum WM
    	{
    		NULL = 0,
    		CREATE = 1,
    		DESTROY = 2,
    		MOVE = 3,
    		SIZE = 5,
    		ACTIVATE = 6,
    		SETFOCUS = 7,
    		KILLFOCUS = 8,
    		ENABLE = 10,
    		SETREDRAW = 11,
    		SETTEXT = 12,
    		GETTEXT = 13,
    		GETTEXTLENGTH = 14,
    		PAINT = 15,
    		CLOSE = 16,
    		QUERYENDSESSION = 17,
    		QUIT = 18,
    		QUERYOPEN = 19,
    		ERASEBKGND = 20,
    		SYSCOLORCHANGE = 21,
    		SHOWWINDOW = 24,
    		CTLCOLOR = 25,
    		WININICHANGE = 26,
    		SETTINGCHANGE = 26,
    		ACTIVATEAPP = 28,
    		SETCURSOR = 32,
    		MOUSEACTIVATE = 33,
    		CHILDACTIVATE = 34,
    		QUEUESYNC = 35,
    		GETMINMAXINFO = 36,
    		MEASUREITEM = 44,
    		WINDOWPOSCHANGING = 70,
    		WINDOWPOSCHANGED = 71,
    		CONTEXTMENU = 123,
    		STYLECHANGING = 124,
    		STYLECHANGED = 125,
    		DISPLAYCHANGE = 126,
    		GETICON = 127,
    		SETICON = 128,
    		NCCREATE = 129,
    		NCDESTROY = 130,
    		NCCALCSIZE = 131,
    		NCHITTEST = 132,
    		NCPAINT = 133,
    		NCACTIVATE = 134,
    		GETDLGCODE = 135,
    		SYNCPAINT = 136,
    		NCMOUSEMOVE = 160,
    		NCLBUTTONDOWN = 161,
    		NCLBUTTONUP = 162,
    		NCLBUTTONDBLCLK = 163,
    		NCRBUTTONDOWN = 164,
    		NCRBUTTONUP = 165,
    		NCRBUTTONDBLCLK = 166,
    		NCMBUTTONDOWN = 167,
    		NCMBUTTONUP = 168,
    		NCMBUTTONDBLCLK = 169,
    		SYSKEYDOWN = 260,
    		SYSKEYUP = 261,
    		SYSCHAR = 262,
    		SYSDEADCHAR = 263,
    		COMMAND = 273,
    		SYSCOMMAND = 274,
    		MOUSEMOVE = 512,
    		LBUTTONDOWN = 513,
    		LBUTTONUP = 514,
    		LBUTTONDBLCLK = 515,
    		RBUTTONDOWN = 516,
    		RBUTTONUP = 517,
    		RBUTTONDBLCLK = 518,
    		MBUTTONDOWN = 519,
    		MBUTTONUP = 520,
    		MBUTTONDBLCLK = 521,
    		MOUSEWHEEL = 522,
    		XBUTTONDOWN = 523,
    		XBUTTONUP = 524,
    		XBUTTONDBLCLK = 525,
    		MOUSEHWHEEL = 526,
    		PARENTNOTIFY = 528,
    		CAPTURECHANGED = 533,
    		POWERBROADCAST = 536,
    		DEVICECHANGE = 537,
    		ENTERSIZEMOVE = 561,
    		EXITSIZEMOVE = 562,
    		IME_SETCONTEXT = 641,
    		IME_NOTIFY = 642,
    		IME_CONTROL = 643,
    		IME_COMPOSITIONFULL = 644,
    		IME_SELECT = 645,
    		IME_CHAR = 646,
    		IME_REQUEST = 648,
    		IME_KEYDOWN = 656,
    		IME_KEYUP = 657,
    		NCMOUSELEAVE = 674,
    		TABLET_DEFBASE = 704,
    		TABLET_ADDED = 712,
    		TABLET_DELETED = 713,
    		TABLET_FLICK = 715,
    		TABLET_QUERYSYSTEMGESTURESTATUS = 716,
    		CUT = 768,
    		COPY = 769,
    		PASTE = 770,
    		CLEAR = 771,
    		UNDO = 772,
    		RENDERFORMAT = 773,
    		RENDERALLFORMATS = 774,
    		DESTROYCLIPBOARD = 775,
    		DRAWCLIPBOARD = 776,
    		PAINTCLIPBOARD = 777,
    		VSCROLLCLIPBOARD = 778,
    		SIZECLIPBOARD = 779,
    		ASKCBFORMATNAME = 780,
    		CHANGECBCHAIN = 781,
    		HSCROLLCLIPBOARD = 782,
    		QUERYNEWPALETTE = 783,
    		PALETTEISCHANGING = 784,
    		PALETTECHANGED = 785,
    		HOTKEY = 786,
    		PRINT = 791,
    		PRINTCLIENT = 792,
    		APPCOMMAND = 793,
    		THEMECHANGED = 794,
    		DWMCOMPOSITIONCHANGED = 798,
    		DWMNCRENDERINGCHANGED = 799,
    		DWMCOLORIZATIONCOLORCHANGED = 800,
    		DWMWINDOWMAXIMIZEDCHANGE = 801,
    		GETTITLEBARINFOEX = 831,
    		DWMSENDICONICTHUMBNAIL = 803,
    		DWMSENDICONICLIVEPREVIEWBITMAP = 806,
    		USER = 1024,
    		TRAYMOUSEMESSAGE = 2048,
    		APP = 32768
    	}

    	public struct ACCENT_POLICY
    	{
    		public ACCENT_STATE AccentState;

#pragma warning disable CS3003 // Type is not CLS-compliant
    		public uint AccentFlags;
#pragma warning restore CS3003 // Type is not CLS-compliant

#pragma warning disable CS3003 // Type is not CLS-compliant
    		public uint GradientColor;
#pragma warning restore CS3003 // Type is not CLS-compliant

#pragma warning disable CS3003 // Type is not CLS-compliant
    		public uint AnimationId;
#pragma warning restore CS3003 // Type is not CLS-compliant
    	}

    	public struct WINCOMPATTRDATA
    	{
    		public WINCOMPATTR Attribute;

    		public IntPtr Data;

    		public int SizeOfData;
    	}

    	public struct TCHITTESTINFO
    	{
    		private readonly Point _point;

    		public readonly TabControlHitTest flags;

    		private TCHITTESTINFO(TabControlHitTest hitTest)
    		{
    			this = default(TCHITTESTINFO);
    			flags = hitTest;
    		}

    		public TCHITTESTINFO(Point point, TabControlHitTest hitTest)
    			: this(hitTest)
    		{
    			_point = point;
    		}

    		public TCHITTESTINFO(int x, int y, TabControlHitTest hitTest)
    			: this(hitTest)
    		{
    			Point point = new Point(x, y);
    		}
    	}

#pragma warning disable CS3009 // Base type is not CLS-compliant
    	public enum AnimateWindowFlags : uint
#pragma warning restore CS3009 // Base type is not CLS-compliant
    	{
    		AW_HOR_POSITIVE = 1u,
    		AW_HOR_NEGATIVE = 2u,
    		AW_VER_POSITIVE = 4u,
    		AW_VER_NEGATIVE = 8u,
    		AW_CENTER = 0x10u,
    		AW_HIDE = 0x10000u,
    		AW_ACTIVATE = 0x20000u,
    		AW_SLIDE = 0x40000u,
    		AW_BLEND = 0x80000u
    	}

    	[Flags]
    	public enum TabControlHitTest
    	{
    		TCHT_NOWHERE = 1,
    		TCHT_ONITEMICON = 2,
    		TCHT_ONITEMLABEL = 4,
    		TCHT_ONITEM = 6
    	}

    	public const int WM_NCHITTEST = 132;

    	public const int WM_NCACTIVATE = 134;

    	public const int WS_EX_TRANSPARENT = 32;

    	public const int WS_EX_TOOLWINDOW = 128;

    	public const int WS_EX_LAYERED = 524288;

    	public const int WS_EX_NOACTIVATE = 134217728;

    	public const int HTTRANSPARENT = -1;

    	public const int HTLEFT = 10;

    	public const int HTRIGHT = 11;

    	public const int HTTOP = 12;

    	public const int HTTOPLEFT = 13;

    	public const int HTTOPRIGHT = 14;

    	public const int HTBOTTOM = 15;

    	public const int HTBOTTOMLEFT = 16;

    	public const int HTBOTTOMRIGHT = 17;

    	public const int WM_PRINT = 791;

    	public const int WM_USER = 1024;

    	public const int WM_REFLECT = 8192;

    	public const int WM_COMMAND = 273;

    	public const int CBN_DROPDOWN = 7;

    	public const int WM_GETMINMAXINFO = 36;

    	public const int SW_RESTORE = 9;

    	public const int HWND_BROADCAST = 65535;

    	public const int SW_SHOWNORMAL = 1;

    	private static bool? _isRunningOnMono;

    	private static HandleRef HWND_TOPMOST = new HandleRef(null, new IntPtr(-1));

#pragma warning disable CS3008 // Identifier is not CLS-compliant
    	public const byte _AC_SRC_OVER = 0;
#pragma warning restore CS3008 // Identifier is not CLS-compliant

#pragma warning disable CS3008 // Identifier is not CLS-compliant
    	public const byte _AC_SRC_ALPHA = 1;
#pragma warning restore CS3008 // Identifier is not CLS-compliant

#pragma warning disable CS3008 // Identifier is not CLS-compliant
    	public const int _LWA_ALPHA = 2;
#pragma warning restore CS3008 // Identifier is not CLS-compliant

#pragma warning disable CS3008 // Identifier is not CLS-compliant
    	public const int _PAT_INVERT = 5898313;
#pragma warning restore CS3008 // Identifier is not CLS-compliant

#pragma warning disable CS3008 // Identifier is not CLS-compliant
    	public const int _HT_CAPTION = 2;
#pragma warning restore CS3008 // Identifier is not CLS-compliant

#pragma warning disable CS3008 // Identifier is not CLS-compliant
    	public const int _HT_TRANSPARENT = -1;
#pragma warning restore CS3008 // Identifier is not CLS-compliant

#pragma warning disable CS3008 // Identifier is not CLS-compliant
    	public const int _TCM_HITTEST = 4877;
#pragma warning restore CS3008 // Identifier is not CLS-compliant

#pragma warning disable CS3008 // Identifier is not CLS-compliant
    	public const int _WM_NCHITTEST = 132;
#pragma warning restore CS3008 // Identifier is not CLS-compliant

#pragma warning disable CS3008 // Identifier is not CLS-compliant
    	public const int _HTCLIENT = 1;
#pragma warning restore CS3008 // Identifier is not CLS-compliant

#pragma warning disable CS3008 // Identifier is not CLS-compliant
    	public const int _HTCAPTION = 2;
#pragma warning restore CS3008 // Identifier is not CLS-compliant

#pragma warning disable CS3008 // Identifier is not CLS-compliant
    	public const int _SRC_COPY = 13369376;
#pragma warning restore CS3008 // Identifier is not CLS-compliant

#pragma warning disable CS3008 // Identifier is not CLS-compliant
    	public const int _CS_DROPSHADOW = 131072;
#pragma warning restore CS3008 // Identifier is not CLS-compliant

#pragma warning disable CS3008 // Identifier is not CLS-compliant
    	public const int _TCM_ADJUSTRECT = 4904;
#pragma warning restore CS3008 // Identifier is not CLS-compliant

#pragma warning disable CS3008 // Identifier is not CLS-compliant
    	public const int _TCN_FIRST = -550;
#pragma warning restore CS3008 // Identifier is not CLS-compliant

#pragma warning disable CS3008 // Identifier is not CLS-compliant
    	public const int _TCN_SELCHANGE = -551;
#pragma warning restore CS3008 // Identifier is not CLS-compliant

#pragma warning disable CS3008 // Identifier is not CLS-compliant
    	public const int _TCN_SELCHANGING = -552;
#pragma warning restore CS3008 // Identifier is not CLS-compliant

    	public const int WM_SETCURSOR = 32;

    	public const int IDC_HAND = 32649;

    	public static bool IsRunningOnMono
    	{
    		get
    		{
    			if (!_isRunningOnMono.HasValue)
    			{
    				_isRunningOnMono = Type.GetType("Mono.Runtime") != null;
    			}
    			return _isRunningOnMono.Value;
    		}
    	}

    	public AnimateWindowFlags AW_HIDE { get; set; }

    	[DllImport("User32.dll")]
    	public static extern bool AnimateWindow(IntPtr handle, int msec, int flags);

    	[DllImport("User32.dll")]
    	public static extern int ShowCaret(IntPtr hwnd);

    	[DllImport("User32.dll")]
    	public static extern int HideCaret(IntPtr hwnd);

    	[DllImport("User32.dll", SetLastError = true)]
    	public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

    	[DllImport("User32.dll")]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
#pragma warning disable CS3001 // Argument type is not CLS-compliant
    	public static extern bool SetWindowPos(uint hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
#pragma warning restore CS3001 // Argument type is not CLS-compliant
#pragma warning restore CS3001 // Argument type is not CLS-compliant

    	[DllImport("User32.dll", ExactSpelling = true, SetLastError = true)]
    	public static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pprSrc, int crKey, ref BLENDFUNCTION pblend, int dwFlags);

    	[DllImport("User32.dll", ExactSpelling = true, SetLastError = true)]
    	public static extern GetAppResources.WinApi.Bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref POINT pptDst, ref SIZE psize, IntPtr hdcSrc, ref POINT pprSrc, int crKey, ref BLENDFUNCTION pblend, int dwFlags);

    	[DllImport("User32.dll")]
    	public static extern bool IsIconic(IntPtr handle);

    	public static int RegisterWindowMessage(string format, params object[] args)
    	{
    		string lpString = string.Format(format, args);
    		return RegisterWindowMessage(lpString);
    	}

    	[DllImport("User32.dll")]
    	public static extern bool PostMessage(IntPtr hwnd, int User32, IntPtr wparam, IntPtr lparam);

    	public static void ShowToFront(IntPtr window)
    	{
    		ShowWindow(window, 1);
    		SetForegroundWindow(window);
    	}

    	internal static int HIWORD(int n)
    	{
    		return (short)((n >> 16) & 0xFFFF);
    	}

    	internal static int LOWORD(int n)
    	{
    		return (short)(n & 0xFFFF);
    	}

    	[DllImport("User32.dll", ExactSpelling = true, SetLastError = true)]
    	public static extern IntPtr GetDC(IntPtr hWnd);

    	[DllImport("User32.dll", SetLastError = true)]
#pragma warning disable CS3002 // Return type is not CLS-compliant
    	public static extern uint GetWindowLong(IntPtr hWnd, int nIndex);
#pragma warning restore CS3002 // Return type is not CLS-compliant

    	[DllImport("User32.dll")]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
    	public static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

    	[DllImport("User32.dll")]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
    	public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int W, int H, uint uFlags);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

    	[DllImport("User32.dll")]
    	public static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

    	[DllImport("User32.dll")]
    	public static extern int GetMenuItemCount(IntPtr hMenu);

    	[DllImport("User32.dll")]
    	public static extern bool DrawMenuBar(IntPtr hWnd);

    	[DllImport("User32.dll")]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
#pragma warning disable CS3001 // Argument type is not CLS-compliant
    	public static extern bool RemoveMenu(IntPtr hMenu, uint uPosition, uint uFlags);
#pragma warning restore CS3001 // Argument type is not CLS-compliant
#pragma warning restore CS3001 // Argument type is not CLS-compliant

    	[DllImport("User32.dll")]
    	public static extern bool ReleaseCapture();

    	[DllImport("User32.dll")]
    	public static extern IntPtr SetCapture(IntPtr hWnd);

    	[DllImport("User32.dll", CharSet = CharSet.Auto)]
    	[SuppressUnmanagedCodeSecurity]
    	private static extern int AnimateWindow(HandleRef windowHandle, int time, AnimationFlags flags);

    	internal static void AnimateWindow(Control control, int time, AnimationFlags flags)
    	{
    		try
    		{
    			SecurityPermission securityPermission = new SecurityPermission(SecurityPermissionFlag.UnmanagedCode);
    			securityPermission.Demand();
    			AnimateWindow(new HandleRef(control, control.Handle), time, flags);
    		}
    		catch (SecurityException)
    		{
    		}
    	}

    	[DllImport("User32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
    	[SuppressUnmanagedCodeSecurity]
    	private static extern bool SetWindowPos(HandleRef hWnd, HandleRef hWndInsertAfter, int x, int y, int cx, int cy, int flags);

    	internal static void SetTopMost(Control control)
    	{
    		try
    		{
    			SecurityPermission securityPermission = new SecurityPermission(SecurityPermissionFlag.UnmanagedCode);
    			securityPermission.Demand();
    			SetWindowPos(new HandleRef(control, control.Handle), HWND_TOPMOST, 0, 0, 0, 0, 19);
    		}
    		catch (SecurityException)
    		{
    		}
    	}

    	[DllImport("User32.dll")]
    	public static extern int SendMessage(IntPtr hWnd, int User32, int wParam, int lParam);

    	[DllImport("User32.dll")]
    	public static extern int SendMessage(IntPtr wnd, int User32, bool param, int lparam);

    	[DllImport("User32.dll", SetLastError = true)]
    	public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    	[DllImport("User32.dll")]
    	public static extern bool SetForegroundWindow(IntPtr hWnd);

    	[DllImport("User32.dll")]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
    	public static extern IntPtr GetDCEx(IntPtr hwnd, IntPtr hrgnclip, uint fdwOptions);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

    	[DllImport("User32.dll")]
    	public static extern bool ShowScrollBar(IntPtr hWnd, int bar, int cmd);

    	[DllImport("User32.dll", CharSet = CharSet.Auto)]
    	public static extern IntPtr GetWindowDC(IntPtr handle);

    	[DllImport("User32.dll", CharSet = CharSet.Auto)]
    	public static extern IntPtr ReleaseDC(IntPtr handle, IntPtr hDC);

    	[DllImport("User32.dll", CharSet = CharSet.Auto)]
    	public static extern int GetClassName(IntPtr hwnd, char[] className, int maxCount);

    	[DllImport("User32.dll", CharSet = CharSet.Auto)]
    	public static extern IntPtr GetWindow(IntPtr hwnd, int uCmd);

    	[DllImport("User32.dll", CharSet = CharSet.Auto)]
    	public static extern bool IsWindowVisible(IntPtr hwnd);

    	[DllImport("User32.dll", CharSet = CharSet.Auto)]
    	public static extern int GetClientRect(IntPtr hwnd, ref RECT lpRect);

    	[DllImport("User32.dll", CharSet = CharSet.Auto)]
    	public static extern int GetClientRect(IntPtr hwnd, [In][Out] ref Rectangle rect);

    	[DllImport("User32.dll", CharSet = CharSet.Auto)]
    	public static extern bool MoveWindow(IntPtr hwnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

    	[DllImport("User32.dll", CharSet = CharSet.Auto)]
    	public static extern bool UpdateWindow(IntPtr hwnd);

    	[DllImport("User32.dll", CharSet = CharSet.Auto)]
    	public static extern bool InvalidateRect(IntPtr hwnd, ref Rectangle rect, bool bErase);

    	[DllImport("User32.dll", CharSet = CharSet.Auto)]
    	public static extern bool ValidateRect(IntPtr hwnd, ref Rectangle rect);

    	[DllImport("User32.dll", CharSet = CharSet.Auto)]
    	internal static extern bool GetWindowRect(IntPtr hWnd, [In][Out] ref Rectangle rect);

    	[DllImport("User32.dll", CharSet = CharSet.Auto)]
    	public static extern IntPtr SendMessage(IntPtr hWnd, int User32, int wParam, string lParam);

    	[DllImport("User32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    	public static extern IntPtr LoadCursor(IntPtr hInstance, int lpCursorName);

    	[DllImport("User32.dll")]
    	public static extern bool AnimateWindow(IntPtr hwnd, int time, AnimateWindowFlags flags);

    	public void AnimateWindow(IntPtr handle, int v, object p)
    	{
    	}

    	[DllImport("User32.dll", CharSet = CharSet.Auto)]
    	public static extern int SetWindowCompositionAttribute(IntPtr hWnd, ref WINCOMPATTRDATA data);

    	[DllImport("User32.dll", CharSet = CharSet.Auto)]
    	public static extern bool SetForegroundWindow(HandleRef hWnd);

    	[DllImport("User32.dll", CharSet = CharSet.Auto)]
    	public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

    	[DllImport("User32.dll", CharSet = CharSet.Auto)]
    	public static extern int SendMessage(IntPtr hWnd, int wUser32, IntPtr wParam, IntPtr lParam);

    	[DllImport("User32.dll", CharSet = CharSet.Auto)]
    	public static extern bool PostMessage(HandleRef hWnd, WM User32, IntPtr wParam, IntPtr lParam);

    	[DllImport("User32.dll", CharSet = CharSet.Auto)]
    	public static extern IntPtr DefWindowProc(IntPtr hWnd, int User32, IntPtr wParam, IntPtr lParam);

    	[DllImport("User32.dll", CharSet = CharSet.Auto)]
    	public static extern int RegisterWindowMessage(string lpString);

        public struct TRACKMOUSEEVENTS
        {
#pragma warning disable 
            public uint cbSize;

            public uint dwFlags;

            public IntPtr hWnd;

            public uint dwHoverTime;
        }

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
    	internal static extern bool TrackMouseEvent(ref TRACKMOUSEEVENTS tme);

    	[DllImport("User32.dll")]
    	internal static extern IntPtr GetParent(IntPtr hWnd);

    	[DllImport("User32.dll")]
    	internal static extern IntPtr GetTopWindow(IntPtr hWnd);

    	[DllImport("User32.dll")]
    	internal static extern IntPtr GetWindow(IntPtr hWnd, uint wCmd);

    	[DllImport("User32.dll")]
    	internal static extern IntPtr TrackPopupMenu(IntPtr menuHandle, int uFlags, int x, int y, int nReserved, IntPtr hwnd, IntPtr par);

        

    	[DllImport("User32.dll", CharSet = CharSet.Auto)]
    	internal static extern void AdjustWindowRectEx(ref RECT rect, int dwStyle, bool hasMenu, int dwExSytle);

    	[DllImport("User32.dll")]
    	public static extern int SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool bRedraw);

        public enum WindowsMessages
        {
            WM_NULL = 0,
            WM_CREATE = 1,
            WM_DESTROY = 2,
            WM_MOVE = 3,
            WM_SIZE = 5,
            WM_ACTIVATE = 6,
            WM_SETFOCUS = 7,
            WM_KILLFOCUS = 8,
            WM_ENABLE = 10,
            WM_SETREDRAW = 11,
            WM_SETTEXT = 12,
            WM_GETTEXT = 13,
            WM_GETTEXTLENGTH = 14,
            WM_PAINT = 15,
            WM_CLOSE = 16,
            WM_QUERYENDSESSION = 17,
            WM_QUIT = 18,
            WM_QUERYOPEN = 19,
            WM_ERASEBKGND = 20,
            WM_SYSCOLORCHANGE = 21,
            WM_ENDSESSION = 22,
            WM_SHOWWINDOW = 24,
            WM_WININICHANGE = 26,
            WM_SETTINGCHANGE = 26,
            WM_DEVMODECHANGE = 27,
            WM_ACTIVATEAPP = 28,
            WM_FONTCHANGE = 29,
            WM_TIMECHANGE = 30,
            WM_CANCELMODE = 31,
            WM_SETCURSOR = 32,
            WM_MOUSEACTIVATE = 33,
            WM_CHILDACTIVATE = 34,
            WM_QUEUESYNC = 35,
            WM_GETMINMAXINFO = 36,
            WM_PAINTICON = 38,
            WM_ICONERASEBKGND = 39,
            WM_NEXTDLGCTL = 40,
            WM_SPOOLERSTATUS = 42,
            WM_DRAWITEM = 43,
            WM_MEASUREITEM = 44,
            WM_DELETEITEM = 45,
            WM_VKEYTOITEM = 46,
            WM_CHARTOITEM = 47,
            WM_SETFONT = 48,
            WM_GETFONT = 49,
            WM_SETHOTKEY = 50,
            WM_GETHOTKEY = 51,
            WM_QUERYDRAGICON = 55,
            WM_COMPAREITEM = 57,
            WM_GETOBJECT = 61,
            WM_COMPACTING = 65,
            WM_COMMNOTIFY = 68,
            WM_WINDOWPOSCHANGING = 70,
            WM_WINDOWPOSCHANGED = 71,
            WM_POWER = 72,
            WM_COPYDATA = 74,
            WM_CANCELJOURNAL = 75,
            WM_NOTIFY = 78,
            WM_INPUTLANGCHANGEREQUEST = 80,
            WM_INPUTLANGCHANGE = 81,
            WM_TCARD = 82,
            WM_HELP = 83,
            WM_USERCHANGED = 84,
            WM_NOTIFYFORMAT = 85,
            WM_CONTEXTMENU = 123,
            WM_STYLECHANGING = 124,
            WM_STYLECHANGED = 125,
            WM_DISPLAYCHANGE = 126,
            WM_GETICON = 127,
            WM_SETICON = 128,
            WM_NCCREATE = 129,
            WM_NCDESTROY = 130,
            WM_NCCALCSIZE = 131,
            WM_NCHITTEST = 132,
            WM_NCPAINT = 133,
            WM_NCACTIVATE = 134,
            WM_GETDLGCODE = 135,
            WM_SYNCPAINT = 136,
            WM_NCMOUSEMOVE = 160,
            WM_NCLBUTTONDOWN = 161,
            WM_NCLBUTTONUP = 162,
            WM_NCLBUTTONDBLCLK = 163,
            WM_NCRBUTTONDOWN = 164,
            WM_NCRBUTTONUP = 165,
            WM_NCRBUTTONDBLCLK = 166,
            WM_NCMBUTTONDOWN = 167,
            WM_NCMBUTTONUP = 168,
            WM_NCMBUTTONDBLCLK = 169,
            WM_NCXBUTTONDOWN = 171,
            WM_NCXBUTTONUP = 172,
            WM_KEYDOWN = 256,
            WM_KEYUP = 257,
            WM_CHAR = 258,
            WM_DEADCHAR = 259,
            WM_SYSKEYDOWN = 260,
            WM_SYSKEYUP = 261,
            WM_SYSCHAR = 262,
            WM_SYSDEADCHAR = 263,
            WM_KEYLAST = 264,
            WM_IME_STARTCOMPOSITION = 269,
            WM_IME_ENDCOMPOSITION = 270,
            WM_IME_COMPOSITION = 271,
            WM_IME_KEYLAST = 271,
            WM_INITDIALOG = 272,
            WM_COMMAND = 273,
            WM_SYSCOMMAND = 274,
            WM_TIMER = 275,
            WM_HSCROLL = 276,
            WM_VSCROLL = 277,
            WM_INITMENU = 278,
            WM_INITMENUPOPUP = 279,
            WM_MENUSELECT = 287,
            WM_MENUCHAR = 288,
            WM_ENTERIDLE = 289,
            WM_MENURBUTTONUP = 290,
            WM_MENUDRAG = 291,
            WM_MENUGETOBJECT = 292,
            WM_UNINITMENUPOPUP = 293,
            WM_MENUCOMMAND = 294,
            WM_CTLCOLORUser32BOX = 306,
            WM_CTLCOLOREDIT = 307,
            WM_CTLCOLORLISTBOX = 308,
            WM_CTLCOLORBTN = 309,
            WM_CTLCOLORDLG = 310,
            WM_CTLCOLORSCROLLBAR = 311,
            WM_CTLCOLORSTATIC = 312,
            WM_MOUSEMOVE = 512,
            WM_LBUTTONDOWN = 513,
            WM_LBUTTONUP = 514,
            WM_LBUTTONDBLCLK = 515,
            WM_RBUTTONDOWN = 516,
            WM_RBUTTONUP = 517,
            WM_RBUTTONDBLCLK = 518,
            WM_MBUTTONDOWN = 519,
            WM_MBUTTONUP = 520,
            WM_MBUTTONDBLCLK = 521,
            WM_MOUSEWHEEL = 522,
            WM_NCMOUSELEAVE = 674,
            WM_XBUTTONDOWN = 523,
            WM_XBUTTONUP = 524,
            WM_XBUTTONDBLCLK = 525,
            WM_PARENTNOTIFY = 528,
            WM_ENTERMENULOOP = 529,
            WM_EXITMENULOOP = 530,
            WM_NEXTMENU = 531,
            WM_SIZING = 532,
            WM_CAPTURECHANGED = 533,
            WM_MOVING = 534,
            WM_DEVICECHANGE = 537,
            WM_MDICREATE = 544,
            WM_MDIDESTROY = 545,
            WM_MDIACTIVATE = 546,
            WM_MDIRESTORE = 547,
            WM_MDINEXT = 548,
            WM_MDIMAXIMIZE = 549,
            WM_MDITILE = 550,
            WM_MDICASCADE = 551,
            WM_MDIICONARRANGE = 552,
            WM_MDIGETACTIVE = 553,
            WM_MDISETMENU = 560,
            WM_ENTERSIZEMOVE = 561,
            WM_EXITSIZEMOVE = 562,
            WM_DROPFILES = 563,
            WM_MDIREFRESHMENU = 564,
            WM_IME_SETCONTEXT = 641,
            WM_IME_NOTIFY = 642,
            WM_IME_CONTROL = 643,
            WM_IME_COMPOSITIONFULL = 644,
            WM_IME_SELECT = 645,
            WM_IME_CHAR = 646,
            WM_IME_REQUEST = 648,
            WM_IME_KEYDOWN = 656,
            WM_IME_KEYUP = 657,
            WM_MOUSEHOVER = 673,
            WM_MOUSELEAVE = 675,
            WM_CUT = 768,
            WM_COPY = 769,
            WM_PASTE = 770,
            WM_CLEAR = 771,
            WM_UNDO = 772,
            WM_RENDERFORMAT = 773,
            WM_RENDERALLFORMATS = 774,
            WM_DESTROYCLIPBOARD = 775,
            WM_DRAWCLIPBOARD = 776,
            WM_PAINTCLIPBOARD = 777,
            WM_VSCROLLCLIPBOARD = 778,
            WM_SIZECLIPBOARD = 779,
            WM_ASKCBFORMATNAME = 780,
            WM_CHANGECBCHAIN = 781,
            WM_HSCROLLCLIPBOARD = 782,
            WM_QUERYNEWPALETTE = 783,
            WM_PALETTEISCHANGING = 784,
            WM_PALETTECHANGED = 785,
            WM_HOTKEY = 786,
            WM_PRINT = 791,
            WM_PRINTCLIENT = 792,
            WM_HANDHELDFIRST = 856,
            WM_HANDHELDLAST = 863,
            WM_AFXFIRST = 864,
            WM_AFXLAST = 895,
            WM_PENWINFIRST = 896,
            WM_PENWINLAST = 911,
            WM_APP = 32768,
            WM_USER = 1024,
            WM_THEMECHANGED = 794,
            NIN_BALLOONSHOW = 1026,
            NIN_BALLOONHIDE = 1027,
            NIN_BALLOONTIMEOUT = 1028,
            NIN_BALLOONUSERCLICK = 1029,
            WM_REFLECT = 8192,
            SC_MOVE = 61456,
            SC_SIZE = 61440,
            WM_NCUAHDRAWCAPTION = 174,
            WM_NCUAHDRAWFRAME = 175,
            WM_UNKNOWN_GHOST = 49596,
            WM_DPICHANGED = 736
        }

        [DllImport("User32.dll")]
    	public static extern IntPtr DefWindowProc(IntPtr hWnd, WindowsMessages uUser32, IntPtr wParam, IntPtr lParam);

    	[DllImport("User32.dll")]
    	public static extern bool IsZoomed(IntPtr hwnd);

        public enum MonitorDpiType
        {
            MDT_EFFECTIVE_DPI = 0,
            MDT_ANGULAR_DPI = 1,
            MDT_RAW_DPI = 2,
            MDT_DEFAULT = 0
        }

        public static float GetOriginalDeviceScaleFactor(IntPtr hWnd)
    	{
    		IntPtr hMonitor = MonitorFromWindow(hWnd, 2u);
    		try
    		{
    			GetDpiForMonitor(hMonitor, MonitorDpiType.MDT_EFFECTIVE_DPI, out var dpiX, out var _);
    			return (float)dpiX / 96f;
    		}
    		catch
    		{
    			return 1f;
    		}
    	}

    	public static int GetOriginalDeviceDpi(IntPtr hWnd)
    	{
    		IntPtr hMonitor = MonitorFromWindow(hWnd, 2u);
    		try
    		{
    			GetDpiForMonitor(hMonitor, MonitorDpiType.MDT_EFFECTIVE_DPI, out var dpiX, out var _);
    			return dpiX;
    		}
    		catch
    		{
    			return 96;
    		}
    	}

    	[DllImport("Shcore.dll")]
    	public static extern int GetDpiForMonitor(IntPtr hMonitor, MonitorDpiType dpiType, out int dpiX, out int dpiY);

    	[DllImport("User32.dll")]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
    	public static extern IntPtr MonitorFromWindow(IntPtr hWnd, uint dwFlags);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

        public enum DeviceScaleFactor
        {
            SCALE_100_PERCENT = 100,
            SCALE_120_PERCENT = 120,
            SCALE_140_PERCENT = 140,
            SCALE_150_PERCENT = 150,
            SCALE_160_PERCENT = 160,
            SCALE_180_PERCENT = 180,
            SCALE_225_PERCENT = 225
        }

        [DllImport("Shcore.dll")]
    	public static extern int GetScaleFactorForMonitor(IntPtr hMonitor, ref DeviceScaleFactor pScale);

    	[DllImport("Shcore.dll")]
    	public static extern int GetScaleFactorForMonitor(IntPtr hMonitor, ref int pScale);

    	[DllImport("User32.dll")]
    	public static extern int FillRect(IntPtr hDC, [In] ref RECT lprc, IntPtr hbr);

    	[DllImport("User32.dll")]
    	public static extern bool InflateRect(ref RECT lprc, int dx, int dy);

    	[DllImport("User32.dll")]
    	public static extern int GetSystemMetrics(SystemMetricFlags smIndex);

    	[DllImport("User32.dll")]
    	public static extern IntPtr GetDCEx(IntPtr hwnd, IntPtr hrgnclip, int fdwOptions);

    	[DllImport("User32.dll")]
    	public static extern void DisableProcessWindowsGhosting();

    	[DllImport("User32.dll")]
    	[return: MarshalAs(UnmanagedType.Bool)]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
    	public static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, uint flags);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

    	public static void InvalidateWindow(IntPtr hWnd)
    	{
    		RedrawWindow(hWnd, IntPtr.Zero, IntPtr.Zero, 1285u);
    	}

    	public static void SendFrameChanged(IntPtr hWnd)
    	{
    		SetWindowPos(hWnd, IntPtr.Zero, 0, 0, 0, 0, (SetWindowPosFlags)1847);
    	}

    	[DllImport("User32.dll")]
    	public static extern int OffsetRect(ref RECT lpRect, int x, int y);

    	[DllImport("User32.dll", CharSet = CharSet.Auto)]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
    	public static extern bool SetWindowPos(int hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

    	[DllImport("User32.dll", CharSet = CharSet.Auto)]
    	public static extern int SetWindowPos(IntPtr hWnd, IntPtr hWndAfter, int x, int y, int width, int height, SetWindowPosFlags flags);

    	[DllImport("User32.dll", CharSet = CharSet.Auto)]
    	public static extern bool ShowWindow(int hWnd, int nCmdShow);

    	[DllImport("User32.dll")]
    	public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    	[DllImport("User32.dll", CharSet = CharSet.Auto)]
    	public static extern int ShowWindow(IntPtr hWnd, short cmdShow);

    	[DllImport("User32.dll", SetLastError = true)]
    	public static extern int CloseWindow(IntPtr hWnd);

    	[DllImport("User32.dll")]
    	public static extern int SetParent(int hWndChild, int hWndParent);

    	[DllImport("User32.dll", CharSet = CharSet.Auto)]
    	public static extern int SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

    	[DllImport("User32.dll")]
    	[return: MarshalAs(UnmanagedType.Bool)]
    	public static extern bool DestroyWindow(IntPtr hWnd);

    	[DllImport("User32.dll", SetLastError = true)]
#pragma warning disable CS3002 // Return type is not CLS-compliant
    	public static extern ushort RegisterClassW([In] ref WNDCLASS lpWndClass);
#pragma warning restore CS3002 // Return type is not CLS-compliant

    	[DllImport("User32.dll", SetLastError = true)]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
#pragma warning disable CS3001 // Argument type is not CLS-compliant
    	public static extern IntPtr CreateWindowExW(uint dwExStyle, [MarshalAs(UnmanagedType.LPWStr)] string lpClassName, [MarshalAs(UnmanagedType.LPWStr)] string lpWindowName, uint dwStyle, int x, int y, int nWidth, int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);
#pragma warning restore CS3001 // Argument type is not CLS-compliant
#pragma warning restore CS3001 // Argument type is not CLS-compliant

    	[DllImport("User32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    	internal static extern IntPtr CreateWindowEx(int dwExStyle, IntPtr classAtom, string lpWindowName, int dwStyle, int x, int y, int nWidth, int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);

    	[DllImport("User32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    	internal static extern IntPtr CreateWindowEx(long dwExStyle, IntPtr classAtom, string lpWindowName, long dwStyle, int x, int y, int nWidth, int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);

    	[DllImport("User32.dll", CharSet = CharSet.Auto)]
#pragma warning disable CS3002 // Return type is not CLS-compliant
    	public static extern uint GetWindowLong(IntPtr hWnd, GetWindowLongFlags nIndex);
#pragma warning restore CS3002 // Return type is not CLS-compliant

    	[DllImport("User32.dll", CharSet = CharSet.Auto)]
    	public static extern int SetWindowLong(IntPtr hWnd, GetWindowLongFlags nIndex, IntPtr newLong);

    	[DllImport("User32.dll", CharSet = CharSet.Auto)]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
    	public static extern int SetWindowLong(IntPtr hWnd, GetWindowLongFlags nIndex, uint newLong);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

    	[DllImport("User32.dll", SetLastError = true)]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
    	public static extern IntPtr DefWindowProcW(IntPtr hWnd, uint User32, IntPtr wParam, IntPtr lParam);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

    	[DllImport("User32.dll", CharSet = CharSet.Auto)]
    	public static extern bool GetWindowRect(IntPtr hWnd, ref RECT rect);

    	[DllImport("User32.dll", CharSet = CharSet.Auto)]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
    	public static extern IntPtr LoadCursor(IntPtr hInstance, uint cursor);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

    	[DllImport("User32.dll", CharSet = CharSet.Auto)]
    	public static extern IntPtr SetCursor(IntPtr hCursor);

    	[DllImport("User32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    	public static extern int GetCursorPos(ref POINT lpPoint);

    	[DllImport("User32.dll", CharSet = CharSet.Auto)]
    	public static extern bool ScreenToClient(IntPtr hWnd, ref POINT pt);

    	[DllImport("User32.dll", CharSet = CharSet.Auto)]
    	public static extern bool ClientToScreen(IntPtr hWnd, ref POINT lpPoint);

    	[DllImport("User32.dll", CharSet = CharSet.Auto)]
    	public static extern int ShowWindow(IntPtr hWnd, ShowWindowStyles cmdShow);

    	[DllImport("User32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    	public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

    	[DllImport("User32.dll")]
    	public static extern IntPtr GetActiveWindow();

    	[DllImport("User32.dll")]
    	public static extern IntPtr GetForegroundWindow();

    	[DllImport("User32.dll", CharSet = CharSet.Auto)]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
    	public static extern IntPtr SendMessage(IntPtr hWnd, uint User32, IntPtr wParam, IntPtr lParam);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

    	[DllImport("User32.dll")]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
    	public static extern int TrackPopupMenu(IntPtr hMenu, uint uFlags, int x, int y, int nReserved, IntPtr hWnd, IntPtr prcRect);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

#pragma warning disable CS3002 // Return type is not CLS-compliant
    	public static uint LOWORD(IntPtr ptr)
#pragma warning restore CS3002 // Return type is not CLS-compliant
    	{
    		return LoWord(ptr);
    	}

#pragma warning disable CS3002 // Return type is not CLS-compliant
    	public static uint HIWORD(IntPtr ptr)
#pragma warning restore CS3002 // Return type is not CLS-compliant
    	{
    		return HiWord(ptr);
    	}

#pragma warning disable CS3002 // Return type is not CLS-compliant
#pragma warning disable CS3005 // Identifier differing only in case is not CLS-compliant
    	public static uint HiWord(IntPtr ptr)
#pragma warning restore CS3005 // Identifier differing only in case is not CLS-compliant
#pragma warning restore CS3002 // Return type is not CLS-compliant
    	{
    		if (((int)ptr & int.MinValue) == int.MinValue)
    		{
    			return (uint)(int)ptr >> 16;
    		}
    		return ((uint)(int)ptr >> 16) & 0xFFFFu;
    	}

#pragma warning disable CS3005 // Identifier differing only in case is not CLS-compliant
#pragma warning disable CS3002 // Return type is not CLS-compliant
    	public static uint LoWord(IntPtr ptr)
#pragma warning restore CS3002 // Return type is not CLS-compliant
#pragma warning restore CS3005 // Identifier differing only in case is not CLS-compliant
    	{
    		return (uint)ptr.ToInt32() & 0xFFFFu;
    	}

    	public static void SendMessage(IntPtr handle, WM nCLBUTTONDOWN, IntPtr cAPTION, IntPtr zero)
    	{
    		throw new NotImplementedException();
    	}
    }
}
