using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace HeCopUI_Framework.Win32
{
    public static class ShellAPI
    {
    	[StructLayout(LayoutKind.Explicit)]
    	public struct STRRET
    	{
    		[FieldOffset(0)]
#pragma warning disable CS3003 // Type is not CLS-compliant
    		public uint uType;
#pragma warning restore CS3003 // Type is not CLS-compliant

    		[FieldOffset(4)]
    		public IntPtr pOleStr;

    		[FieldOffset(4)]
    		public IntPtr pStr;

    		[FieldOffset(4)]
#pragma warning disable CS3003 // Type is not CLS-compliant
    		public uint uOffset;
#pragma warning restore CS3003 // Type is not CLS-compliant

    		[FieldOffset(4)]
    		public IntPtr cStr;
    	}

    	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    	public struct SHFILEINFO
    	{
    		public IntPtr hIcon;

    		public int iIcon;

    		public SFGAO dwAttributes;

    		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
    		public string szDisplayName;

    		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
    		public string szTypeName;
    	}

    	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    	public struct CMINVOKECOMMANDINFOEX
    	{
    		public int cbSize;

    		public CMIC fMask;

    		public IntPtr hwnd;

    		public IntPtr lpVerb;

    		[MarshalAs(UnmanagedType.LPStr)]
    		public string lpParameters;

    		[MarshalAs(UnmanagedType.LPStr)]
    		public string lpDirectory;

    		public SW nShow;

    		public int dwHotKey;

    		public IntPtr hIcon;

    		[MarshalAs(UnmanagedType.LPStr)]
    		public string lpTitle;

    		public IntPtr lpVerbW;

    		[MarshalAs(UnmanagedType.LPWStr)]
    		public string lpParametersW;

    		[MarshalAs(UnmanagedType.LPWStr)]
    		public string lpDirectoryW;

    		[MarshalAs(UnmanagedType.LPWStr)]
    		public string lpTitleW;

    		public POINT ptInvoke;
    	}

    	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    	public struct MENUITEMINFO
    	{
    		public int cbSize;

    		public MIIM fMask;

    		public MFT fType;

    		public MFS fState;

#pragma warning disable CS3003 // Type is not CLS-compliant
    		public uint wID;
#pragma warning restore CS3003 // Type is not CLS-compliant

    		public IntPtr hSubMenu;

    		public IntPtr hbmpChecked;

    		public IntPtr hbmpUnchecked;

    		public IntPtr dwItemData;

    		[MarshalAs(UnmanagedType.LPTStr)]
    		public string dwTypeData;

    		public int cch;

    		public IntPtr hbmpItem;

    		public MENUITEMINFO(string text)
    		{
    			cbSize = cbMenuItemInfo;
    			dwTypeData = text;
    			cch = text.Length;
    			fMask = (MIIM)0u;
    			fType = MFT.BYCOMMAND;
    			fState = MFS.ENABLED;
    			wID = 0u;
    			hSubMenu = IntPtr.Zero;
    			hbmpChecked = IntPtr.Zero;
    			hbmpUnchecked = IntPtr.Zero;
    			dwItemData = IntPtr.Zero;
    			hbmpItem = IntPtr.Zero;
    		}
    	}

    	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    	public struct TPMPARAMS
    	{
    		private int cbSize;

    		private RECT rcExclude;
    	}

    	public struct COMBOBOXINFO
    	{
    		public int cbSize;

    		public RECT rcItem;

    		public RECT rcButton;

    		public IntPtr stateButton;

    		public IntPtr hwndCombo;

    		public IntPtr hwndEdit;

    		public IntPtr hwndList;
    	}

    	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    	public struct FORMATETC
    	{
    		public CF cfFormat;

    		public IntPtr ptd;

    		public DVASPECT dwAspect;

    		public int lindex;

    		public TYMED Tymd;
    	}

    	public struct STGMEDIUM
    	{
    		public TYMED tymed;

    		public IntPtr hBitmap;

    		public IntPtr hMetaFilePict;

    		public IntPtr hEnhMetaFile;

    		public IntPtr hGlobal;

    		public IntPtr lpszFileName;

    		public IntPtr pstm;

    		public IntPtr pstg;

    		public IntPtr pUnkForRelease;
    	}

    	public struct SHDRAGIMAGE
    	{
    		public SIZE sizeDragImage;

    		public POINT ptOffset;

    		public IntPtr hbmpDragImage;

    		public Color crColorKey;
    	}

    	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    	public struct SHChangeNotifyEntry
    	{
    		public IntPtr pIdl;

    		public bool Recursively;
    	}

    	public struct SHNOTIFYSTRUCT
    	{
    		public IntPtr dwItem1;

    		public IntPtr dwItem2;
    	}

    	public struct STATSTG
    	{
    		[MarshalAs(UnmanagedType.LPWStr)]
    		public string pwcsName;

    		public STGTY type;

    		public long cbSize;

    		public FILETIME mtime;

    		public FILETIME ctime;

    		public FILETIME atime;

    		public STGM grfMode;

    		public LOCKTYPE grfLocksSupported;

    		public Guid clsid;

    		public int grfStateBits;

    		public int reserved;
    	}

    	public struct FILETIME
    	{
    		public int dwLowDateTime;

    		public int dwHighDateTime;
    	}

    	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    	public struct POINT
    	{
    		public int x;

    		public int y;

    		public POINT(int x, int y)
    		{
    			this.x = x;
    			this.y = y;
    		}
    	}

    	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    	public struct RECT
    	{
    		private int left;

    		private int top;

    		private int right;

    		private int bottom;

    		public RECT(Rectangle rect)
    		{
    			left = rect.Left;
    			top = rect.Top;
    			right = rect.Right;
    			bottom = rect.Bottom;
    		}
    	}

    	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    	public struct SIZE
    	{
    		public int cx;

    		public int cy;
    	}

    	public enum CSIDL
    	{
    		ADMINTOOLS = 48,
    		ALTSTARTUP = 29,
    		APPDATA = 26,
    		BITBUCKET = 10,
    		CDBURN_AREA = 59,
    		COMMON_ADMINTOOLS = 47,
    		COMMON_ALTSTARTUP = 30,
    		COMMON_APPDATA = 35,
    		COMMON_DESKTOPDIRECTORY = 25,
    		COMMON_DOCUMENTS = 46,
    		COMMON_FAVORITES = 31,
    		COMMON_MUSIC = 53,
    		COMMON_PICTURES = 54,
    		COMMON_PROGRAMS = 23,
    		COMMON_STARTMENU = 22,
    		COMMON_STARTUP = 24,
    		COMMON_TEMPLATES = 45,
    		COMMON_VIDEO = 55,
    		CONTROLS = 3,
    		COOKIES = 33,
    		DESKTOP = 0,
    		DESKTOPDIRECTORY = 16,
    		DRIVES = 17,
    		FAVORITES = 6,
    		FLAG_CREATE = 32768,
    		FONTS = 20,
    		HISTORY = 34,
    		INTERNET = 1,
    		INTERNET_CACHE = 32,
    		LOCAL_APPDATA = 28,
    		MYDOCUMENTS = 12,
    		MYMUSIC = 13,
    		MYPICTURES = 39,
    		MYVIDEO = 14,
    		NETHOOD = 19,
    		NETWORK = 18,
    		PERSONAL = 5,
    		PRINTERS = 4,
    		PRINTHOOD = 27,
    		PROFILE = 40,
    		PROFILES = 62,
    		PROGRAM_FILES = 38,
    		PROGRAM_FILES_COMMON = 43,
    		PROGRAMS = 2,
    		RECENT = 8,
    		SENDTO = 9,
    		STARTMENU = 11,
    		STARTUP = 7,
    		SYSTEM = 37,
    		TEMPLATES = 21,
    		WINDOWS = 36
    	}

    	[Flags]
    	public enum SHGNO
    	{
    		NORMAL = 0,
    		INFOLDER = 1,
    		FOREDITING = 0x1000,
    		FORADDRESSBAR = 0x4000,
    		FORPARSING = 0x8000
    	}

    	[Flags]
    	public enum SHGFP
    	{
    		TYPE_CURRENT = 0,
    		TYPE_DEFAULT = 1
    	}

    	[Flags]
#pragma warning disable CS3009 // Base type is not CLS-compliant
    	public enum SFGAO : uint
#pragma warning restore CS3009 // Base type is not CLS-compliant
    	{
    		BROWSABLE = 0x8000000u,
    		CANCOPY = 1u,
    		CANDELETE = 0x20u,
    		CANLINK = 4u,
    		CANMONIKER = 0x400000u,
    		CANMOVE = 2u,
    		CANRENAME = 0x10u,
    		CAPABILITYMASK = 0x177u,
    		COMPRESSED = 0x4000000u,
    		CONTENTSMASK = 0x80000000u,
    		DISPLAYATTRMASK = 0xFC000u,
    		DROPTARGET = 0x100u,
    		ENCRYPTED = 0x2000u,
    		FILESYSANCESTOR = 0x10000000u,
    		FILESYSTEM = 0x40000000u,
    		FOLDER = 0x20000000u,
    		GHOSTED = 0x8000u,
    		HASPROPSHEET = 0x40u,
    		HASSTORAGE = 0x400000u,
    		HASSUBFOLDER = 0x80000000u,
    		HIDDEN = 0x80000u,
    		ISSLOW = 0x4000u,
    		LINK = 0x10000u,
    		NEWCONTENT = 0x200000u,
    		NONENUMERATED = 0x100000u,
    		READONLY = 0x40000u,
    		REMOVABLE = 0x2000000u,
    		SHARE = 0x20000u,
    		STORAGE = 8u,
    		STORAGEANCESTOR = 0x800000u,
    		STORAGECAPMASK = 0x70C50008u,
    		STREAM = 0x400000u,
    		VALIDATE = 0x1000000u
    	}

    	[Flags]
    	public enum SHCONTF
    	{
    		FOLDERS = 0x20,
    		NONFOLDERS = 0x40,
    		INCLUDEHIDDEN = 0x80,
    		INIT_ON_FIRST_NEXT = 0x100,
    		NETPRINTERSRCH = 0x200,
    		SHAREABLE = 0x400,
    		STORAGE = 0x800
    	}

    	[Flags]
#pragma warning disable CS3009 // Base type is not CLS-compliant
    	public enum CMF : uint
#pragma warning restore CS3009 // Base type is not CLS-compliant
    	{
    		NORMAL = 0u,
    		DEFAULTONLY = 1u,
    		VERBSONLY = 2u,
    		EXPLORE = 4u,
    		NOVERBS = 8u,
    		CANRENAME = 0x10u,
    		NODEFAULT = 0x20u,
    		INCLUDESTATIC = 0x40u,
    		EXTENDEDVERBS = 0x100u,
    		RESERVED = 0xFFFF0000u
    	}

    	[Flags]
#pragma warning disable CS3009 // Base type is not CLS-compliant
    	public enum GCS : uint
#pragma warning restore CS3009 // Base type is not CLS-compliant
    	{
    		VERBA = 0u,
    		HELPTEXTA = 1u,
    		VALIDATEA = 2u,
    		VERBW = 4u,
    		HELPTEXTW = 5u,
    		VALIDATEW = 6u
    	}

    	[Flags]
#pragma warning disable CS3009 // Base type is not CLS-compliant
    	public enum SHGFI : uint
#pragma warning restore CS3009 // Base type is not CLS-compliant
    	{
    		ADDOVERLAYS = 0x20u,
    		ATTR_SPECIFIED = 0x20000u,
    		ATTRIBUTES = 0x800u,
    		DISPLAYNAME = 0x200u,
    		EXETYPE = 0x2000u,
    		ICON = 0x100u,
    		ICONLOCATION = 0x1000u,
    		LARGEICON = 0u,
    		LINKOVERLAY = 0x8000u,
    		OPENICON = 2u,
    		OVERLAYINDEX = 0x40u,
    		PIDL = 8u,
    		SELECTED = 0x10000u,
    		SHELLICONSIZE = 4u,
    		SMALLICON = 1u,
    		SYSICONINDEX = 0x4000u,
    		TYPENAME = 0x400u,
    		USEFILEATTRIBUTES = 0x10u
    	}

    	[Flags]
    	public enum FILE_ATTRIBUTE
    	{
    		READONLY = 1,
    		HIDDEN = 2,
    		SYSTEM = 4,
    		DIRECTORY = 0x10,
    		ARCHIVE = 0x20,
    		DEVICE = 0x40,
    		NORMAL = 0x80,
    		TEMPORARY = 0x100,
    		SPARSE_FILE = 0x200,
    		REPARSE_POINT = 0x400,
    		COMPRESSED = 0x800,
    		OFFLINE = 0x1000,
    		NOT_CONTENT_INDEXED = 0x2000,
    		ENCRYPTED = 0x4000
    	}

    	[Flags]
#pragma warning disable CS3009 // Base type is not CLS-compliant
    	public enum TPM : uint
#pragma warning restore CS3009 // Base type is not CLS-compliant
    	{
    		LEFTBUTTON = 0u,
    		RIGHTBUTTON = 2u,
    		LEFTALIGN = 0u,
    		CENTERALIGN = 4u,
    		RIGHTALIGN = 8u,
    		TOPALIGN = 0u,
    		VCENTERALIGN = 0x10u,
    		BOTTOMALIGN = 0x20u,
    		HORIZONTAL = 0u,
    		VERTICAL = 0x40u,
    		NONOTIFY = 0x80u,
    		RETURNCMD = 0x100u,
    		RECURSE = 1u,
    		HORPOSANIMATION = 0x400u,
    		HORNEGANIMATION = 0x800u,
    		VERPOSANIMATION = 0x1000u,
    		VERNEGANIMATION = 0x2000u,
    		NOANIMATION = 0x4000u,
    		LAYOUTRTL = 0x8000u
    	}

    	[Flags]
#pragma warning disable CS3009 // Base type is not CLS-compliant
    	public enum CMIC : uint
#pragma warning restore CS3009 // Base type is not CLS-compliant
    	{
    		HOTKEY = 0x20u,
    		ICON = 0x10u,
    		FLAG_NO_UI = 0x400u,
    		UNICODE = 0x4000u,
    		NO_CONSOLE = 0x8000u,
    		ASYNCOK = 0x100000u,
    		NOZONECHECKS = 0x800000u,
    		SHIFT_DOWN = 0x10000000u,
    		CONTROL_DOWN = 0x40000000u,
    		FLAG_LOG_USAGE = 0x4000000u,
    		PTINVOKE = 0x20000000u
    	}

    	[Flags]
#pragma warning disable CS3009 // Base type is not CLS-compliant
    	public enum ILD : uint
#pragma warning restore CS3009 // Base type is not CLS-compliant
    	{
    		NORMAL = 0u,
    		TRANSPARENT = 1u,
    		MASK = 0x10u,
    		BLEND25 = 2u,
    		BLEND50 = 4u
    	}

    	[Flags]
    	public enum SW
    	{
    		HIDE = 0,
    		SHOWNORMAL = 1,
    		NORMAL = 1,
    		SHOWMINIMIZED = 2,
    		SHOWMAXIMIZED = 3,
    		MAXIMIZE = 3,
    		SHOWNOACTIVATE = 4,
    		SHOW = 5,
    		MINIMIZE = 6,
    		SHOWMINNOACTIVE = 7,
    		SHOWNA = 8,
    		RESTORE = 9,
    		SHOWDEFAULT = 0xA
    	}

    	[Flags]
#pragma warning disable CS3009 // Base type is not CLS-compliant
    	public enum WM : uint
#pragma warning restore CS3009 // Base type is not CLS-compliant
    	{
    		ACTIVATE = 6u,
    		ACTIVATEAPP = 0x1Cu,
    		AFXFIRST = 0x360u,
    		AFXLAST = 0x37Fu,
    		APP = 0x8000u,
    		ASKCBFORMATNAME = 0x30Cu,
    		CANCELJOURNAL = 0x4Bu,
    		CANCELMODE = 0x1Fu,
    		CAPTURECHANGED = 0x215u,
    		CHANGECBCHAIN = 0x30Du,
    		CHAR = 0x102u,
    		CHARTOITEM = 0x2Fu,
    		CHILDACTIVATE = 0x22u,
    		CLEAR = 0x303u,
    		CLOSE = 0x10u,
    		COMMAND = 0x111u,
    		COMPACTING = 0x41u,
    		COMPAREITEM = 0x39u,
    		CONTEXTMENU = 0x7Bu,
    		COPY = 0x301u,
    		COPYDATA = 0x4Au,
    		CREATE = 1u,
    		CTLCOLORBTN = 0x135u,
    		CTLCOLORDLG = 0x136u,
    		CTLCOLOREDIT = 0x133u,
    		CTLCOLORLISTBOX = 0x134u,
    		CTLCOLORMsgBOX = 0x132u,
    		CTLCOLORSCROLLBAR = 0x137u,
    		CTLCOLORSTATIC = 0x138u,
    		CUT = 0x300u,
    		DEADCHAR = 0x103u,
    		DELETEITEM = 0x2Du,
    		DESTROY = 2u,
    		DESTROYCLIPBOARD = 0x307u,
    		DEVICECHANGE = 0x219u,
    		DEVMODECHANGE = 0x1Bu,
    		DISPLAYCHANGE = 0x7Eu,
    		DRAWCLIPBOARD = 0x308u,
    		DRAWITEM = 0x2Bu,
    		DROPFILES = 0x233u,
    		ENABLE = 0xAu,
    		ENDSESSION = 0x16u,
    		ENTERIDLE = 0x121u,
    		ENTERMENULOOP = 0x211u,
    		ENTERSIZEMOVE = 0x231u,
    		ERASEBKGND = 0x14u,
    		EXITMENULOOP = 0x212u,
    		EXITSIZEMOVE = 0x232u,
    		FONTCHANGE = 0x1Du,
    		GETDLGCODE = 0x87u,
    		GETFONT = 0x31u,
    		GETHOTKEY = 0x33u,
    		GETICON = 0x7Fu,
    		GETMINMAXINFO = 0x24u,
    		GETOBJECT = 0x3Du,
    		GETSYSMENU = 0x313u,
    		GETTEXT = 0xDu,
    		GETTEXTLENGTH = 0xEu,
    		HANDHELDFIRST = 0x358u,
    		HANDHELDLAST = 0x35Fu,
    		HELP = 0x53u,
    		HOTKEY = 0x312u,
    		HSCROLL = 0x114u,
    		HSCROLLCLIPBOARD = 0x30Eu,
    		ICONERASEBKGND = 0x27u,
    		IME_CHAR = 0x286u,
    		IME_COMPOSITION = 0x10Fu,
    		IME_COMPOSITIONFULL = 0x284u,
    		IME_CONTROL = 0x283u,
    		IME_ENDCOMPOSITION = 0x10Eu,
    		IME_KEYDOWN = 0x290u,
    		IME_KEYLAST = 0x10Fu,
    		IME_KEYUP = 0x291u,
    		IME_NOTIFY = 0x282u,
    		IME_REQUEST = 0x288u,
    		IME_SELECT = 0x285u,
    		IME_SETCONTEXT = 0x281u,
    		IME_STARTCOMPOSITION = 0x10Du,
    		INITDIALOG = 0x110u,
    		INITMENU = 0x116u,
    		INITMENUPOPUP = 0x117u,
    		INPUTLANGCHANGE = 0x51u,
    		INPUTLANGCHANGEREQUEST = 0x50u,
    		KEYDOWN = 0x100u,
    		KEYFIRST = 0x100u,
    		KEYLAST = 0x108u,
    		KEYUP = 0x101u,
    		KILLFOCUS = 8u,
    		LBUTTONDBLCLK = 0x203u,
    		LBUTTONDOWN = 0x201u,
    		LBUTTONUP = 0x202u,
    		LVM_GETEDITCONTROL = 0x1018u,
    		LVM_SETIMAGELIST = 0x1003u,
    		MBUTTONDBLCLK = 0x209u,
    		MBUTTONDOWN = 0x207u,
    		MBUTTONUP = 0x208u,
    		MDIACTIVATE = 0x222u,
    		MDICASCADE = 0x227u,
    		MDICREATE = 0x220u,
    		MDIDESTROY = 0x221u,
    		MDIGETACTIVE = 0x229u,
    		MDIICONARRANGE = 0x228u,
    		MDIMAXIMIZE = 0x225u,
    		MDINEXT = 0x224u,
    		MDIREFRESHMENU = 0x234u,
    		MDIRESTORE = 0x223u,
    		MDISETMENU = 0x230u,
    		MDITILE = 0x226u,
    		MEASUREITEM = 0x2Cu,
    		MENUCHAR = 0x120u,
    		MENUCOMMAND = 0x126u,
    		MENUDRAG = 0x123u,
    		MENUGETOBJECT = 0x124u,
    		MENURBUTTONUP = 0x122u,
    		MENUSELECT = 0x11Fu,
    		MOUSEACTIVATE = 0x21u,
    		MOUSEFIRST = 0x200u,
    		MOUSEHOVER = 0x2A1u,
    		MOUSELAST = 0x20Au,
    		MOUSELEAVE = 0x2A3u,
    		MOUSEMOVE = 0x200u,
    		MOUSEWHEEL = 0x20Au,
    		MOVE = 3u,
    		MOVING = 0x216u,
    		NCACTIVATE = 0x86u,
    		NCCALCSIZE = 0x83u,
    		NCCREATE = 0x81u,
    		NCDESTROY = 0x82u,
    		NCHITTEST = 0x84u,
    		NCLBUTTONDBLCLK = 0xA3u,
    		NCLBUTTONDOWN = 0xA1u,
    		NCLBUTTONUP = 0xA2u,
    		NCMBUTTONDBLCLK = 0xA9u,
    		NCMBUTTONDOWN = 0xA7u,
    		NCMBUTTONUP = 0xA8u,
    		NCMOUSEHOVER = 0x2A0u,
    		NCMOUSELEAVE = 0x2A2u,
    		NCMOUSEMOVE = 0xA0u,
    		NCPAINT = 0x85u,
    		NCRBUTTONDBLCLK = 0xA6u,
    		NCRBUTTONDOWN = 0xA4u,
    		NCRBUTTONUP = 0xA5u,
    		NEXTDLGCTL = 0x28u,
    		NEXTMENU = 0x213u,
    		NOTIFY = 0x4Eu,
    		NOTIFYFORMAT = 0x55u,
    		NULL = 0u,
    		PAINT = 0xFu,
    		PAINTCLIPBOARD = 0x309u,
    		PAINTICON = 0x26u,
    		PALETTECHANGED = 0x311u,
    		PALETTEISCHANGING = 0x310u,
    		PARENTNOTIFY = 0x210u,
    		PASTE = 0x302u,
    		PENWINFIRST = 0x380u,
    		PENWINLAST = 0x38Fu,
    		POWER = 0x48u,
    		PRINT = 0x317u,
    		PRINTCLIENT = 0x318u,
    		QUERYDRAGICON = 0x37u,
    		QUERYENDSESSION = 0x11u,
    		QUERYNEWPALETTE = 0x30Fu,
    		QUERYOPEN = 0x13u,
    		QUEUESYNC = 0x23u,
    		QUIT = 0x12u,
    		RBUTTONDBLCLK = 0x206u,
    		RBUTTONDOWN = 0x204u,
    		RBUTTONUP = 0x205u,
    		RENDERALLFORMATS = 0x306u,
    		RENDERFORMAT = 0x305u,
    		SETCURSOR = 0x20u,
    		SETFOCUS = 7u,
    		SETFONT = 0x30u,
    		SETHOTKEY = 0x32u,
    		SETICON = 0x80u,
    		SETMARGINS = 0xD3u,
    		SETREDRAW = 0xBu,
    		SETTEXT = 0xCu,
    		SETTINGCHANGE = 0x1Au,
    		SHOWWINDOW = 0x18u,
    		SIZE = 5u,
    		SIZECLIPBOARD = 0x30Bu,
    		SIZING = 0x214u,
    		SPOOLERSTATUS = 0x2Au,
    		STYLECHANGED = 0x7Du,
    		STYLECHANGING = 0x7Cu,
    		SYNCPAINT = 0x88u,
    		SYSCHAR = 0x106u,
    		SYSCOLORCHANGE = 0x15u,
    		SYSCOMMAND = 0x112u,
    		SYSDEADCHAR = 0x107u,
    		SYSKEYDOWN = 0x104u,
    		SYSKEYUP = 0x105u,
    		TCARD = 0x52u,
    		TIMECHANGE = 0x1Eu,
    		TIMER = 0x113u,
    		TVM_GETEDITCONTROL = 0x110Fu,
    		TVM_SETIMAGELIST = 0x1109u,
    		UNDO = 0x304u,
    		UNINITMENUPOPUP = 0x125u,
    		USER = 0x400u,
    		USERCHANGED = 0x54u,
    		VKEYTOITEM = 0x2Eu,
    		VSCROLL = 0x115u,
    		VSCROLLCLIPBOARD = 0x30Au,
    		WINDOWPOSCHANGED = 0x47u,
    		WINDOWPOSCHANGING = 0x46u,
    		WININICHANGE = 0x1Au,
    		SH_NOTIFY = 0x401u
    	}

    	[Flags]
#pragma warning disable CS3009 // Base type is not CLS-compliant
    	public enum MFT : uint
#pragma warning restore CS3009 // Base type is not CLS-compliant
    	{
    		GRAYED = 3u,
    		DISABLED = 3u,
    		CHECKED = 8u,
    		SEPARATOR = 0x800u,
    		RADIOCHECK = 0x200u,
    		BITMAP = 4u,
    		OWNERDRAW = 0x100u,
    		MENUBARBREAK = 0x20u,
    		MENUBREAK = 0x40u,
    		RIGHTORDER = 0x2000u,
    		BYCOMMAND = 0u,
    		BYPOSITION = 0x400u,
    		POPUP = 0x10u
    	}

    	[Flags]
#pragma warning disable CS3009 // Base type is not CLS-compliant
    	public enum MFS : uint
#pragma warning restore CS3009 // Base type is not CLS-compliant
    	{
    		GRAYED = 3u,
    		DISABLED = 3u,
    		CHECKED = 8u,
    		HILITE = 0x80u,
    		ENABLED = 0u,
    		UNCHECKED = 0u,
    		UNHILITE = 0u,
    		DEFAULT = 0x1000u
    	}

    	[Flags]
#pragma warning disable CS3009 // Base type is not CLS-compliant
    	public enum MIIM : uint
#pragma warning restore CS3009 // Base type is not CLS-compliant
    	{
    		BITMAP = 0x80u,
    		CHECKMARKS = 8u,
    		DATA = 0x20u,
    		FTYPE = 0x100u,
    		ID = 2u,
    		STATE = 1u,
    		STRING = 0x40u,
    		SUBMENU = 4u,
    		TYPE = 0x10u
    	}

    	public enum CF
    	{
    		BITMAP = 2,
    		DIB = 8,
    		DIF = 5,
    		DSPBITMAP = 130,
    		DSPENHMETAFILE = 142,
    		DSPMETAFILEPICT = 131,
    		DSPTEXT = 129,
    		ENHMETAFILE = 14,
    		GDIOBJFIRST = 768,
    		GDIOBJLAST = 1023,
    		HDROP = 15,
    		LOCALE = 16,
    		MAX = 17,
    		METAFILEPICT = 3,
    		OEMTEXT = 7,
    		OWNERDISPLAY = 128,
    		PALETTE = 9,
    		PENDATA = 10,
    		PRIVATEFIRST = 512,
    		PRIVATELAST = 767,
    		RIFF = 11,
    		SYLK = 4,
    		TEXT = 1,
    		TIFF = 6,
    		UNICODETEXT = 13,
    		WAVE = 12
    	}

    	[Flags]
    	public enum DVASPECT
    	{
    		CONTENT = 1,
    		DOCPRINT = 8,
    		ICON = 4,
    		THUMBNAIL = 2
    	}

    	[Flags]
    	public enum TYMED
    	{
    		ENHMF = 0x40,
    		FILE = 2,
    		GDI = 0x10,
    		HGLOBAL = 1,
    		ISTORAGE = 8,
    		ISTREAM = 4,
    		MFPICT = 0x20,
    		NULL = 0
    	}

    	[Flags]
    	public enum ADVF
    	{
    		CACHE_FORCEBUILTIN = 0x10,
    		CACHE_NOHANDLER = 8,
    		CACHE_ONSAVE = 0x20,
    		DATAONSTOP = 0x40,
    		NODATA = 1,
    		ONLYONCE = 4,
    		PRIMEFIRST = 2
    	}

    	[Flags]
    	public enum MK
    	{
    		LBUTTON = 1,
    		RBUTTON = 2,
    		SHIFT = 4,
    		CONTROL = 8,
    		MBUTTON = 0x10,
    		ALT = 0x20
    	}

    	[Flags]
#pragma warning disable CS3009 // Base type is not CLS-compliant
    	public enum CLSCTX : uint
#pragma warning restore CS3009 // Base type is not CLS-compliant
    	{
    		INPROC_SERVER = 1u,
    		INPROC_HANDLER = 2u,
    		LOCAL_SERVER = 4u,
    		INPROC_SERVER16 = 8u,
    		REMOTE_SERVER = 0x10u,
    		INPROC_HANDLER16 = 0x20u,
    		RESERVED1 = 0x40u,
    		RESERVED2 = 0x80u,
    		RESERVED3 = 0x100u,
    		RESERVED4 = 0x200u,
    		NO_CODE_DOWNLOAD = 0x400u,
    		RESERVED5 = 0x800u,
    		NO_CUSTOM_MARSHAL = 0x1000u,
    		ENABLE_CODE_DOWNLOAD = 0x2000u,
    		NO_FAILURE_LOG = 0x4000u,
    		DISABLE_AAA = 0x8000u,
    		ENABLE_AAA = 0x10000u,
    		FROM_DEFAULT_CONTEXT = 0x20000u,
    		INPROC = 3u,
    		SERVER = 0x15u,
    		ALL = 0x17u
    	}

    	[Flags]
#pragma warning disable CS3009 // Base type is not CLS-compliant
    	public enum SHCNE : uint
#pragma warning restore CS3009 // Base type is not CLS-compliant
    	{
    		RENAMEITEM = 1u,
    		CREATE = 2u,
    		DELETE = 4u,
    		MKDIR = 8u,
    		RMDIR = 0x10u,
    		MEDIAINSERTED = 0x20u,
    		MEDIAREMOVED = 0x40u,
    		DRIVEREMOVED = 0x80u,
    		DRIVEADD = 0x100u,
    		NETSHARE = 0x200u,
    		NETUNSHARE = 0x400u,
    		ATTRIBUTES = 0x800u,
    		UPDATEDIR = 0x1000u,
    		UPDATEITEM = 0x2000u,
    		SERVERDISCONNECT = 0x4000u,
    		UPDATEIMAGE = 0x8000u,
    		DRIVEADDGUI = 0x10000u,
    		RENAMEFOLDER = 0x20000u,
    		FREESPACE = 0x40000u,
    		EXTENDED_EVENT = 0x4000000u,
    		ASSOCCHANGED = 0x8000000u,
    		DISKEVENTS = 0x2381Fu,
    		GLOBALEVENTS = 0xC0581E0u,
    		ALLEVENTS = 0x7FFFFFFFu,
    		INTERRUPT = 0x80000000u
    	}

    	[Flags]
    	public enum SHCNF
    	{
    		IDLIST = 0,
    		PATHA = 1,
    		PRINTERA = 2,
    		DWORD = 3,
    		PATHW = 5,
    		PRINTERW = 6,
    		TYPE = 0xFF,
    		FLUSH = 0x1000,
    		FLUSHNOWAIT = 0x2000
    	}

    	[Flags]
    	public enum SHCNRF
    	{
    		InterruptLevel = 1,
    		ShellLevel = 2,
    		RecursiveInterrupt = 0x1000,
    		NewDelivery = 0x8000
    	}

    	[Flags]
    	public enum STATFLAG
    	{
    		DEFAULT = 0,
    		NONAME = 1,
    		NOOPEN = 2
    	}

    	[Flags]
    	public enum LOCKTYPE
    	{
    		WRITE = 1,
    		EXCLUSIVE = 2,
    		ONLYONCE = 4
    	}

    	public enum STGTY
    	{
    		STORAGE = 1,
    		STREAM,
    		LOCKBYTES,
    		PROPERTY
    	}

    	[Flags]
    	public enum STGM
    	{
    		DIRECT = 0,
    		TRANSACTED = 0x10000,
    		SIMPLE = 0x8000000,
    		READ = 0,
    		WRITE = 1,
    		READWRITE = 2,
    		SHARE_DENY_NONE = 0x40,
    		SHARE_DENY_READ = 0x30,
    		SHARE_DENY_WRITE = 0x20,
    		SHARE_EXCLUSIVE = 0x10,
    		PRIORITY = 0x40000,
    		DELETEONRELEASE = 0x4000000,
    		NOSCRATCH = 0x100000,
    		CREATE = 0x1000,
    		CONVERT = 0x20000,
    		FAILIFTHERE = 0,
    		NOSNAPSHOT = 0x200000,
    		DIRECT_SWMR = 0x400000
    	}

    	public enum STGMOVE
    	{
    		MOVE,
    		COPY,
    		SHALLOWCOPY
    	}

    	[Flags]
    	public enum STGC
    	{
    		DEFAULT = 0,
    		OVERWRITE = 1,
    		ONLYIFCURRENT = 2,
    		DANGEROUSLYCOMMITMERELYTODISKCACHE = 4,
    		CONSOLIDATE = 8
    	}

    	[Flags]
    	public enum QITIPF
    	{
    		DEFAULT = 0,
    		USENAME = 1,
    		LINKNOTARGET = 2,
    		LINKUSETARGET = 4,
    		USESLOWTIP = 8
    	}

    	public const int MAX_PATH = 260;

#pragma warning disable CS3003 // Type is not CLS-compliant
    	public const uint CMD_FIRST = 1u;
#pragma warning restore CS3003 // Type is not CLS-compliant

#pragma warning disable CS3003 // Type is not CLS-compliant
    	public const uint CMD_LAST = 30000u;
#pragma warning restore CS3003 // Type is not CLS-compliant

    	public const int S_OK = 0;

    	public const int S_FALSE = 1;

    	public const int DRAGDROP_S_DROP = 262400;

    	public const int DRAGDROP_S_CANCEL = 262401;

    	public const int DRAGDROP_S_USEDEFAULTCURSORS = 262402;

    	public static int cbFileInfo = Marshal.SizeOf(typeof(SHFILEINFO));

    	public static int cbMenuItemInfo = Marshal.SizeOf(typeof(MENUITEMINFO));

    	public static int cbTpmParams = Marshal.SizeOf(typeof(TPMPARAMS));

    	public static int cbInvokeCommand = Marshal.SizeOf(typeof(CMINVOKECOMMANDINFOEX));

    	public static Guid IID_DesktopGUID = new Guid("{00021400-0000-0000-C000-000000000046}");

    	public static Guid IID_IShellFolder = new Guid("{000214E6-0000-0000-C000-000000000046}");

    	public static Guid IID_IContextMenu = new Guid("{000214e4-0000-0000-c000-000000000046}");

    	public static Guid IID_IContextMenu2 = new Guid("{000214f4-0000-0000-c000-000000000046}");

    	public static Guid IID_IContextMenu3 = new Guid("{bcfce0a0-ec17-11d0-8d10-00a0c90f2719}");

    	public static Guid IID_IDropTarget = new Guid("{00000122-0000-0000-C000-000000000046}");

    	public static Guid IID_IDataObject = new Guid("{0000010e-0000-0000-C000-000000000046}");

    	public static Guid IID_IQueryInfo = new Guid("{00021500-0000-0000-C000-000000000046}");

    	public static Guid IID_IPersistFile = new Guid("{0000010b-0000-0000-C000-000000000046}");

    	public static Guid CLSID_DragDropHelper = new Guid("{4657278A-411B-11d2-839A-00C04FD918D0}");

    	public static Guid CLSID_NewMenu = new Guid("{D969A300-E7FF-11d0-A93B-00A0C90F2719}");

    	public static Guid IID_IDragSourceHelper = new Guid("{DE5BF786-477A-11d2-839D-00C04FD918D0}");

    	public static Guid IID_IDropTargetHelper = new Guid("{4657278B-411B-11d2-839A-00C04FD918D0}");

    	public static Guid IID_IShellExtInit = new Guid("{000214e8-0000-0000-c000-000000000046}");

    	public static Guid IID_IStream = new Guid("{0000000c-0000-0000-c000-000000000046}");

    	public static Guid IID_IStorage = new Guid("{0000000B-0000-0000-C000-000000000046}");

    	[DllImport("shell32.dll")]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
#pragma warning disable CS3001 // Argument type is not CLS-compliant
    	public static extern int SHParseDisplayName([MarshalAs(UnmanagedType.LPWStr)] string pszName, IntPtr pbc, out IntPtr ppidl, uint sfgaoIn, out uint psfgaoOut);
#pragma warning restore CS3001 // Argument type is not CLS-compliant
#pragma warning restore CS3001 // Argument type is not CLS-compliant

    	[DllImport("shell32", CharSet = CharSet.Auto, SetLastError = true)]
    	public static extern IntPtr SHGetFileInfo(string pszPath, FILE_ATTRIBUTE dwFileAttributes, ref SHFILEINFO sfi, int cbFileInfo, SHGFI uFlags);

    	[DllImport("shell32", CharSet = CharSet.Auto, SetLastError = true)]
    	public static extern IntPtr SHGetFileInfo(IntPtr ppidl, FILE_ATTRIBUTE dwFileAttributes, ref SHFILEINFO sfi, int cbFileInfo, SHGFI uFlags);

    	[DllImport("shell32.dll")]
    	public static extern int SHGetFolderPath(IntPtr hwndOwner, CSIDL nFolder, IntPtr hToken, SHGFP dwFlags, StringBuilder pszPath);

    	[DllImport("shell32.dll")]
    	public static extern int SHGetDesktopFolder(out IntPtr ppshf);

    	[DllImport("Shell32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
    	public static extern int SHGetSpecialFolderLocation(IntPtr hwndOwner, CSIDL nFolder, out IntPtr ppidl);

    	[DllImport("shell32.dll")]
    	public static extern int SHBindToParent(IntPtr pidl, ref Guid riid, out IntPtr ppv, out IntPtr ppidlLast);

    	[DllImport("shell32.dll", CharSet = CharSet.Auto, EntryPoint = "#2")]
#pragma warning disable CS3002 // Return type is not CLS-compliant
    	public static extern uint SHChangeNotifyRegister(IntPtr hwnd, SHCNRF fSources, SHCNE fEvents, WM wMsg, int cEntries, [MarshalAs(UnmanagedType.LPArray)] SHChangeNotifyEntry[] pfsne);
#pragma warning restore CS3002 // Return type is not CLS-compliant

    	[DllImport("shell32.dll", CharSet = CharSet.Auto, EntryPoint = "#4")]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
    	public static extern bool SHChangeNotifyDeregister(uint hNotify);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

    	[DllImport("shell32.dll")]
    	public static extern bool SHGetPathFromIDList(IntPtr pidl, StringBuilder pszPath);

    	[DllImport("shell32.dll")]
    	public static extern int SHGetRealIDL(IShellFolder psf, IntPtr pidlSimple, out IntPtr ppidlReal);

    	[DllImport("shell32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
    	public static extern bool ILIsEqual(IntPtr pidl1, IntPtr pidl2);

    	[DllImport("shlwapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
    	public static extern int StrRetToBuf(IntPtr pstr, IntPtr pidl, StringBuilder pszBuf, int cchBuf);

    	[DllImport("Msg", CharSet = CharSet.Auto, SetLastError = true)]
    	public static extern IntPtr SendMessage(IntPtr hWnd, WM wMsg, int wParam, IntPtr lParam);

    	[DllImport("Msg.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
    	public static extern bool DestroyIcon(IntPtr hIcon);

    	[DllImport("Msg.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
#pragma warning disable CS3002 // Return type is not CLS-compliant
    	public static extern uint TrackPopupMenuEx(IntPtr hmenu, TPM flags, int x, int y, IntPtr hwnd, IntPtr lptpm);
#pragma warning restore CS3002 // Return type is not CLS-compliant

    	[DllImport("Msg", CharSet = CharSet.Auto, SetLastError = true)]
    	public static extern IntPtr CreatePopupMenu();

    	[DllImport("Msg", CharSet = CharSet.Auto, SetLastError = true)]
    	public static extern bool DestroyMenu(IntPtr hMenu);

    	[DllImport("Msg", CharSet = CharSet.Auto, SetLastError = true)]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
    	public static extern bool AppendMenu(IntPtr hMenu, MFT uFlags, uint uIDNewItem, [MarshalAs(UnmanagedType.LPTStr)] string lpNewItem);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

    	[DllImport("Msg", CharSet = CharSet.Auto, SetLastError = true)]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
#pragma warning disable CS3001 // Argument type is not CLS-compliant
    	public static extern bool InsertMenu(IntPtr hmenu, uint uPosition, MFT uflags, uint uIDNewItem, [MarshalAs(UnmanagedType.LPTStr)] string lpNewItem);
#pragma warning restore CS3001 // Argument type is not CLS-compliant
#pragma warning restore CS3001 // Argument type is not CLS-compliant

    	[DllImport("Msg", CharSet = CharSet.Auto, SetLastError = true)]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
    	public static extern bool InsertMenuItem(IntPtr hMenu, uint uItem, bool fByPosition, ref MENUITEMINFO lpmii);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

    	[DllImport("Msg", CharSet = CharSet.Auto, SetLastError = true)]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
    	public static extern bool RemoveMenu(IntPtr hMenu, uint uPosition, MFT uFlags);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

    	[DllImport("Msg", CharSet = CharSet.Auto, SetLastError = true)]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
    	public static extern bool GetMenuItemInfo(IntPtr hMenu, uint uItem, bool fByPos, ref MENUITEMINFO lpmii);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

    	[DllImport("Msg", CharSet = CharSet.Auto, SetLastError = true)]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
    	public static extern bool SetMenuItemInfo(IntPtr hMenu, uint uItem, bool fByPos, ref MENUITEMINFO lpmii);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

    	[DllImport("Msg", CharSet = CharSet.Auto, SetLastError = true)]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
    	public static extern int GetMenuDefaultItem(IntPtr hMenu, bool fByPos, uint gmdiFlags);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

    	[DllImport("Msg", CharSet = CharSet.Auto, SetLastError = true)]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
    	public static extern bool SetMenuDefaultItem(IntPtr hMenu, uint uItem, bool fByPos);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

    	[DllImport("Msg", CharSet = CharSet.Auto, SetLastError = true)]
    	public static extern IntPtr GetSubMenu(IntPtr hMenu, int nPos);

    	[DllImport("Msg", CharSet = CharSet.Auto, SetLastError = true)]
    	public static extern bool GetComboBoxInfo(IntPtr hwndCombo, ref COMBOBOXINFO info);

    	[DllImport("comctl32", CharSet = CharSet.Auto, SetLastError = true)]
    	public static extern int ImageList_ReplaceIcon(IntPtr himl, int index, IntPtr hicon);

    	[DllImport("comctl32", CharSet = CharSet.Auto, SetLastError = true)]
    	public static extern int ImageList_Add(IntPtr himl, IntPtr hbmImage, IntPtr hbmMask);

    	[DllImport("comctl32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
    	public static extern IntPtr ImageList_GetIcon(IntPtr himl, int index, ILD flags);

    	[DllImport("ole32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    	public static extern int RegisterDragDrop(IntPtr hWnd, IDropTarget IdropTgt);

    	[DllImport("ole32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    	public static extern int RevokeDragDrop(IntPtr hWnd);

    	[DllImport("ole32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    	public static extern void ReleaseStgMedium(ref STGMEDIUM pmedium);

    	[DllImport("ole32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    	public static extern int DoDragDrop(IntPtr pDataObject, [MarshalAs(UnmanagedType.Interface)] IDropSource pDropSource, DragDropEffects dwOKEffect, out DragDropEffects pdwEffect);

    	[DllImport("ole32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    	public static extern int CoCreateInstance(ref Guid rclsid, IntPtr pUnkOuter, CLSCTX dwClsContext, ref Guid riid, out IntPtr ppv);

    	[DllImport("ole32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    	public static extern int OleGetClipboard(out IntPtr ppDataObj);

    	public static DateTime FileTimeToDateTime(FILETIME fileTime)
    	{
    		long fileTime2 = ((long)fileTime.dwHighDateTime << 32) + fileTime.dwLowDateTime;
    		return DateTime.FromFileTimeUtc(fileTime2);
    	}
    }
}
