using HeCopUI_Framework.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HeCopUI_Framework
{
    public partial class GetAppResources
    {
        #region WinAPI
        public class WinApi
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct POINT
            {
                public Int32 x;
                public Int32 y;

                public POINT(Int32 x, Int32 y) { this.x = x; this.y = y; }
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct SIZE
            {
                public Int32 cx;
                public Int32 cy;

                public SIZE(Int32 cx, Int32 cy) { this.cx = cx; this.cy = cy; }
            }

            [StructLayout(LayoutKind.Sequential, Pack = 1)]
            public struct ARGB
            {
                public byte Blue;
                public byte Green;
                public byte Red;
                public byte Alpha;
            }

            [StructLayout(LayoutKind.Sequential, Pack = 1)]
            public struct BLENDFUNCTION
            {
                public byte BlendOp;
                public byte BlendFlags;
                public byte SourceConstantAlpha;
                public byte AlphaFormat;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct TCHITTESTINFO
            {
                public System.Drawing.Point pt;
#pragma warning disable CS3003 // Type is not CLS-compliant
                public uint flags;
#pragma warning restore CS3003 // Type is not CLS-compliant
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct RECT
            {
                public RECT(Rectangle rc)
                {
                    this.Left = rc.Left;
                    this.Top = rc.Top;
                    this.Right = rc.Right;
                    this.Bottom = rc.Bottom;
                }

                public int Left;
                public int Top;
                public int Right;
                public int Bottom;

                public Rectangle ToRectangle()
                {
                    return Rectangle.FromLTRB(Left, Top, Right, Bottom);
                }
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct NCCALCSIZE_PARAMS
            {
                public RECT rect0;
                public RECT rect1;
                public RECT rect2;
                public IntPtr lppos;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct MINMAXINFO
            {
                public POINT ptReserved;
                public POINT ptMaxSize;
                public POINT ptMaxPosition;
                public POINT ptMinTrackSize;
                public POINT ptMaxTrackSize;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct APPBARDATA
            {
#pragma warning disable CS3003 // Type is not CLS-compliant
                public uint cbSize;
#pragma warning restore CS3003 // Type is not CLS-compliant
                public IntPtr hWnd;
#pragma warning disable CS3003 // Type is not CLS-compliant
                public uint uCallbackMessage;
#pragma warning restore CS3003 // Type is not CLS-compliant
                public ABE uEdge;
                public RECT rc;
                public int lParam;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct WindowPos
            {
                public int hwnd;
                public int hWndInsertAfter;
                public int x;
                public int y;
                public int cx;
                public int cy;
                public int flags;
            }



            #region Enums

#pragma warning disable CS3009 // Base type is not CLS-compliant
            public enum ABM : uint
#pragma warning restore CS3009 // Base type is not CLS-compliant
            {
                New = 0x00000000,
                Remove = 0x00000001,
                QueryPos = 0x00000002,
                SetPos = 0x00000003,
                GetState = 0x00000004,
                GetTaskbarPos = 0x00000005,
                Activate = 0x00000006,
                GetAutoHideBar = 0x00000007,
                SetAutoHideBar = 0x00000008,
                WindowPosChanged = 0x00000009,
                SetState = 0x0000000A,
            }

#pragma warning disable CS3009 // Base type is not CLS-compliant
            public enum ABE : uint
#pragma warning restore CS3009 // Base type is not CLS-compliant
            {
                Left = 0,
                Top = 1,
                Right = 2,
                Bottom = 3
            }

            public enum ScrollBar
            {
                SB_HORZ = 0,
                SB_VERT = 1,
                SB_CTL = 2,
                SB_BOTH = 3,
            }

            public enum HitTest
            {
                HTNOWHERE = 0,
                HTCLIENT = 1,
                HTCAPTION = 2,
                HTGROWBOX = 4,
                HTSIZE = HTGROWBOX,
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
                HTREDUCE = HTMINBUTTON,
                HTZOOM = HTMAXBUTTON,
                HTSIZEFIRST = HTLEFT,
                HTSIZELAST = HTBOTTOMRIGHT,
                HTTRANSPARENT = -1
            }

            public enum TabControlHitTest
            {
                TCHT_NOWHERE = 1,
            }

#pragma warning disable CS3009 // Base type is not CLS-compliant
            public enum Messages : uint
#pragma warning restore CS3009 // Base type is not CLS-compliant
            {
                WM_NULL = 0x0,
                WM_CREATE = 0x1,
                WM_DESTROY = 0x2,
                WM_MOVE = 0x3,
                WM_SIZE = 0x5,
                WM_ACTIVATE = 0x6,
                WM_SETFOCUS = 0x7,
                WM_KILLFOCUS = 0x8,
                WM_ENABLE = 0xa,
                WM_SETREDRAW = 0xb,
                WM_SETTEXT = 0xc,
                WM_GETTEXT = 0xd,
                WM_GETTEXTLENGTH = 0xe,
                WM_PAINT = 0xf,
                WM_CLOSE = 0x10,
                WM_QUERYENDSESSION = 0x11,
                WM_QUERYOPEN = 0x13,
                WM_ENDSESSION = 0x16,
                WM_QUIT = 0x12,
                WM_ERASEBKGND = 0x14,
                WM_SYSCOLORCHANGE = 0x15,
                WM_SHOWWINDOW = 0x18,
                WM_WININICHANGE = 0x1a,
                WM_SETTINGCHANGE = WM_WININICHANGE,
                WM_DEVMODECHANGE = 0x1b,
                WM_ACTIVATEAPP = 0x1c,
                WM_FONTCHANGE = 0x1d,
                WM_TIMECHANGE = 0x1e,
                WM_CANCELMODE = 0x1f,
                WM_SETCURSOR = 0x20,
                WM_MOUSEACTIVATE = 0x21,
                WM_CHILDACTIVATE = 0x22,
                WM_QUEUESYNC = 0x23,
                WM_GETMINMAXINFO = 0x24,
                WM_PAINTICON = 0x26,
                WM_ICONERASEBKGND = 0x27,
                WM_NEXTDLGCTL = 0x28,
                WM_SPOOLERSTATUS = 0x2a,
                WM_DRAWITEM = 0x2b,
                WM_MEASUREITEM = 0x2c,
                WM_DELETEITEM = 0x2d,
                WM_VKEYTOITEM = 0x2e,
                WM_CHARTOITEM = 0x2f,
                WM_SETFONT = 0x30,
                WM_GETFONT = 0x31,
                WM_SETHOTKEY = 0x32,
                WM_GETHOTKEY = 0x33,
                WM_QUERYDRAGICON = 0x37,
                WM_COMPAREITEM = 0x39,
                WM_GETOBJECT = 0x3d,
                WM_COMPACTING = 0x41,
                WM_COMMNOTIFY = 0x44,
                WM_WINDOWPOSCHANGING = 0x46,
                WM_WINDOWPOSCHANGED = 0x47,
                WM_POWER = 0x48,
                WM_COPYDATA = 0x4a,
                WM_CANCELJOURNAL = 0x4b,
                WM_NOTIFY = 0x4e,
                WM_INPUTLANGCHANGEREQUEST = 0x50,
                WM_INPUTLANGCHANGE = 0x51,
                WM_TCARD = 0x52,
                WM_HELP = 0x53,
                WM_USERCHANGED = 0x54,
                WM_NOTIFYFORMAT = 0x55,
                WM_CONTEXTMENU = 0x7b,
                WM_STYLECHANGING = 0x7c,
                WM_STYLECHANGED = 0x7d,
                WM_DISPLAYCHANGE = 0x7e,
                WM_GETICON = 0x7f,
                WM_SETICON = 0x80,
                WM_NCCREATE = 0x81,
                WM_NCDESTROY = 0x82,
                WM_NCCALCSIZE = 0x83,
                WM_NCHITTEST = 0x84,
                WM_NCPAINT = 0x85,
                WM_NCACTIVATE = 0x86,
                WM_GETDLGCODE = 0x87,
                WM_SYNCPAINT = 0x88,
                WM_NCMOUSEMOVE = 0xa0,
                WM_NCLBUTTONDOWN = 0xa1,
                WM_NCLBUTTONUP = 0xa2,
                WM_NCLBUTTONDBLCLK = 0xa3,
                WM_NCRBUTTONDOWN = 0xa4,
                WM_NCRBUTTONUP = 0xa5,
                WM_NCRBUTTONDBLCLK = 0xa6,
                WM_NCMBUTTONDOWN = 0xa7,
                WM_NCMBUTTONUP = 0xa8,
                WM_NCMBUTTONDBLCLK = 0xa9,
                WM_NCXBUTTONDOWN = 0xab,
                WM_NCXBUTTONUP = 0xac,
                WM_NCXBUTTONDBLCLK = 0xad,
                WM_INPUT = 0xff,
                WM_KEYFIRST = 0x100,
                WM_KEYDOWN = 0x100,
                WM_KEYUP = 0x101,
                WM_CHAR = 0x102,
                WM_DEADCHAR = 0x103,
                WM_SYSKEYDOWN = 0x104,
                WM_SYSKEYUP = 0x105,
                WM_SYSCHAR = 0x106,
                WM_SYSDEADCHAR = 0x107,
                WM_UNICHAR = 0x109,
                WM_KEYLAST = 0x108,
                WM_IME_STARTCOMPOSITION = 0x10d,
                WM_IME_ENDCOMPOSITION = 0x10e,
                WM_IME_COMPOSITION = 0x10f,
                WM_IME_KEYLAST = 0x10f,
                WM_INITDIALOG = 0x110,
                WM_COMMAND = 0x111,
                WM_SYSCOMMAND = 0x112,
                WM_TIMER = 0x113,
                WM_HSCROLL = 0x114,
                WM_VSCROLL = 0x115,
                WM_INITMENU = 0x116,
                WM_INITMENUPOPUP = 0x117,
                WM_MENUSELECT = 0x11f,
                WM_MENUCHAR = 0x120,
                WM_ENTERIDLE = 0x121,
                WM_MENURBUTTONUP = 0x122,
                WM_MENUDRAG = 0x123,
                WM_MENUGETOBJECT = 0x124,
                WM_UNINITMENUPOPUP = 0x125,
                WM_MENUCOMMAND = 0x126,
                WM_CHANGEUISTATE = 0x127,
                WM_UPDATEUISTATE = 0x128,
                WM_QUERYUISTATE = 0x129,
                WM_CTLCOLOR = 0x19,
                WM_CTLCOLORWin32BOX = 0x132,
                WM_CTLCOLOREDIT = 0x133,
                WM_CTLCOLORLISTBOX = 0x134,
                WM_CTLCOLORBTN = 0x135,
                WM_CTLCOLORDLG = 0x136,
                WM_CTLCOLORSCROLLBAR = 0x137,
                WM_CTLCOLORSTATIC = 0x138,
                WM_MOUSEFIRST = 0x200,
                WM_MOUSEMOVE = 0x200,
                WM_LBUTTONDOWN = 0x201,
                WM_LBUTTONUP = 0x202,
                WM_LBUTTONDBLCLK = 0x203,
                WM_RBUTTONDOWN = 0x204,
                WM_RBUTTONUP = 0x205,
                WM_RBUTTONDBLCLK = 0x206,
                WM_MBUTTONDOWN = 0x207,
                WM_MBUTTONUP = 0x208,
                WM_MBUTTONDBLCLK = 0x209,
                WM_MOUSEWHEEL = 0x20a,
                WM_XBUTTONDOWN = 0x20b,
                WM_XBUTTONUP = 0x20c,
                WM_XBUTTONDBLCLK = 0x20d,
                WM_MOUSELAST = 0x20d,
                WM_PARENTNOTIFY = 0x210,
                WM_ENTERMENULOOP = 0x211,
                WM_EXITMENULOOP = 0x212,
                WM_NEXTMENU = 0x213,
                WM_SIZING = 0x214,
                WM_CAPTURECHANGED = 0x215,
                WM_MOVING = 0x216,
                WM_POWERBROADCAST = 0x218,
                WM_DEVICECHANGE = 0x219,
                WM_MDICREATE = 0x220,
                WM_MDIDESTROY = 0x221,
                WM_MDIACTIVATE = 0x222,
                WM_MDIRESTORE = 0x223,
                WM_MDINEXT = 0x224,
                WM_MDIMAXIMIZE = 0x225,
                WM_MDITILE = 0x226,
                WM_MDICASCADE = 0x227,
                WM_MDIICONARRANGE = 0x228,
                WM_MDIGETACTIVE = 0x229,
                WM_MDISETMENU = 0x230,
                WM_ENTERSIZEMOVE = 0x231,
                WM_EXITSIZEMOVE = 0x232,
                WM_DROPFILES = 0x233,
                WM_MDIREFRESHMENU = 0x234,
                WM_IME_SETCONTEXT = 0x281,
                WM_IME_NOTIFY = 0x282,
                WM_IME_CONTROL = 0x283,
                WM_IME_COMPOSITIONFULL = 0x284,
                WM_IME_SELECT = 0x285,
                WM_IME_CHAR = 0x286,
                WM_IME_REQUEST = 0x288,
                WM_IME_KEYDOWN = 0x290,
                WM_IME_KEYUP = 0x291,
                WM_MOUSEHOVER = 0x2a1,
                WM_MOUSELEAVE = 0x2a3,
                WM_NCMOUSELEAVE = 0x2a2,
                WM_WTSSESSION_CHANGE = 0x2b1,
                WM_TABLET_FIRST = 0x2c0,
                WM_TABLET_LAST = 0x2df,
                WM_CUT = 0x300,
                WM_COPY = 0x301,
                WM_PASTE = 0x302,
                WM_CLEAR = 0x303,
                WM_UNDO = 0x304,
                WM_RENDERFORMAT = 0x305,
                WM_RENDERALLFORMATS = 0x306,
                WM_DESTROYCLIPBOARD = 0x307,
                WM_DRAWCLIPBOARD = 0x308,
                WM_PAINTCLIPBOARD = 0x309,
                WM_VSCROLLCLIPBOARD = 0x30a,
                WM_SIZECLIPBOARD = 0x30b,
                WM_ASKCBFORMATNAME = 0x30c,
                WM_CHANGECBCHAIN = 0x30d,
                WM_HSCROLLCLIPBOARD = 0x30e,
                WM_QUERYNEWPALETTE = 0x30f,
                WM_PALETTEISCHANGING = 0x310,
                WM_PALETTECHANGED = 0x311,
                WM_HOTKEY = 0x312,
                WM_PRINT = 0x317,
                WM_PRINTCLIENT = 0x318,
                WM_APPCOMMAND = 0x319,
                WM_THEMECHANGED = 0x31a,
                WM_HANDHELDFIRST = 0x358,
                WM_HANDHELDLAST = 0x35f,
                WM_AFXFIRST = 0x360,
                WM_AFXLAST = 0x37f,
                WM_PENWINFIRST = 0x380,
                WM_PENWINLAST = 0x38f,
                WM_USER = 0x400,
                WM_REFLECT = 0x2000,
                WM_APP = 0x8000,
                WM_DWMCOMPOSITIONCHANGED = 0x031E,

                SC_MOVE = 0xF010,
                SC_MINIMIZE = 0XF020,
                SC_MAXIMIZE = 0xF030,
                SC_RESTORE = 0xF120
            }

            public enum Bool
            {
                False = 0,
                True
            };

            #endregion

            #region Fields

            public const int Autohide = 0x0000001;
            public const int AlwaysOnTop = 0x0000002;

            public const Int32 MfByposition = 0x400;
            public const Int32 MfRemove = 0x1000;

            public const int TCM_HITTEST = 0x1313;

            public const Int32 ULW_COLORKEY = 0x00000001;
            public const Int32 ULW_ALPHA = 0x00000002;
            public const Int32 ULW_OPAQUE = 0x00000004;

            public const byte AC_SRC_OVER = 0x00;
            public const byte AC_SRC_ALPHA = 0x01;

            // GetWindow() constants
            public const int GW_HWNDFIRST = 0;
            public const int GW_HWNDLAST = 1;
            public const int GW_HWNDNEXT = 2;
            public const int GW_HWNDPREV = 3;
            public const int GW_OWNER = 4;
            public const int GW_CHILD = 5;
            public const int HC_ACTION = 0;
            public const int WH_CALLWNDPROC = 4;
            public const int GWL_WNDPROC = -4;

            #endregion

            #region API Calls



            #endregion

            #region Helper Methods

            public static int LoWord(int dwValue)
            {
                return dwValue & 0xffff;
            }

            public static int HiWord(int dwValue)
            {
                return (dwValue >> 16) & 0xffff;
            }

            #endregion

        }

        public class Win32
        {
            public class HParams
            {
                #region constants

                public const int WM_NCACTIVATE = 0x86;
                public const int WM_NCPAINT = 0x85;
                public const int WM_NCLBUTTONDOWN = 0xA1;
                public const int WM_NCRBUTTONDOWN = 0x00A4;
                public const int WM_NCRBUTTONUP = 0x00A5;
                public const int WM_NCMOUSEMOVE = 0x00A0;
                public const int WM_NCLBUTTONUP = 0x00A2;
                public const int WM_NCCALCSIZE = 0x0083;
                public const int WM_NCMOUSEHOVER = 0x02A0;
                public const int WM_NCMOUSELEAVE = 0x02A2;
                public const int WM_NCHITTEST = 0x0084;
                public const int WM_NCCREATE = 0x0081;
                //const int WM_RBUTTONUP = 0x0205;

                public const int WM_LBUTTONDOWN = 0x0201;
                public const int WM_CAPTURECHANGED = 0x0215;
                public const int WM_LBUTTONUP = 0x0202;
                public const int WM_SETCURSOR = 0x0020;
                public const int WM_CLOSE = 0x0010;
                public const int WM_SYSCOMMAND = 0x0112;
                public const int WM_MOUSEMOVE = 0x0200;
                public const int WM_SIZE = 0x0005;
                public const int WM_SIZING = 0x0214;
                public const int WM_GETMINMAXINFO = 0x0024;
                public const int WM_ENTERSIZEMOVE = 0x0231;
                const int WM_WINDOWPOSCHANGING = 0x0046;


                // FOR WM_SIZING Win32 WPARAM
                public const int WMSZ_BOTTOM = 6;
                public const int WMSZ_BOTTOMLEFT = 7;
                public const int WMSZ_BOTTOMRIGHT = 8;
                public const int WMSZ_LEFT = 1;
                public const int WMSZ_RIGHT = 2;
                public const int WMSZ_TOP = 3;
                public const int WMSZ_TOPLEFT = 4;
                public const int WMSZ_TOPRIGHT = 5;

                // left mouse button is down.
                public const int MK_LBUTTON = 0x0001;

                public const int SC_CLOSE = 0xF060;
                public const int SC_MAXIMIZE = 0xF030;
                public const int SC_MINIMIZE = 0xF020;
                public const int SC_RESTORE = 0xF120;
                public const int SC_CONTEXTHELP = 0xF180;

                public const int HTCAPTION = 2;
                public const int HTCLOSE = 20;
                public const int HTHELP = 21;
                public const int HTMAXBUTTON = 9;
                public const int HTMINBUTTON = 8;
                public const int HTTOP = 12;
                public const int SM_CYBORDER = 6;
                public const int SM_CXBORDER = 5;
                public const int SM_CYCAPTION = 4;

                public const int CS_DropSHADOW = 0x20000;
                const int GCL_STYLE = (-26);

                #endregion

                public const int WS_EX_TOOLWIN = 0x80;
                public const int WS_EX_TOPMOST = 0x8;
                public const int WS_EX_LAYERED = 0x80000;
                public const int WS_POPUP = 0x8000000;
                public const int WS_EX_TRANSPARENT = 0x20;
                public const int WS_EX_TRANSPARENT1 = 32;
                public const int WS_EX_LAYERED1 = 524288;
                public const int WS_EX_NOACTIVATE = 134217728;
                public const int WS_EX_NOACTIVATE1 = 0x8000000;
                public const int WS_EX_COMPOSITED = 0x02000000;   // WS_EX_COMPOSITED
#pragma warning disable CS3005 // Identifier differing only in case is not CLS-compliant
                public const int CS_DROPSHADOW = 0x20000;
#pragma warning restore CS3005 // Identifier differing only in case is not CLS-compliant
                public const int WS_MINIMIZEBOX = 0x20000;
                public const int HTCLIENT = 0x1;

                public const int CS_DBLCLKS = 0x8;
                public const int CS_DROPSHADOW1 = 0x00020000;
                public const int WM_ACTIVATEAPP = 0x001C;
                private const UInt32 LVM_FIRST = 0x1000;
                private const UInt32 LVM_SCROLL = (LVM_FIRST + 20);
                private const int WM_HSCROLL = 0x114;
                private const int WM_VSCROLL = 0x115;

                private const int WM_MOUSEWHEEL = 0x020A;
                public const int SWP_NOACTIVATE = 0x0010;
                public const int SWP_NOZORDER = 0x4;
                public const int WS_RESIZE_FORM_BORDERLESS = 0xC00000;

                /*
                 * GetWindow() Constants
                 */
                public const int GW_HWNDFIRST = 0;
                public const int GW_HWNDLAST = 1;
                public const int GW_HWNDNEXT = 2;
                public const int GW_HWNDPREV = 3;
                public const int GW_OWNER = 4;
                public const int GW_CHILD = 5;


                public const int WM_PAINT = 0xF;
                public const int WM_CREATE = 0x1;

                public const int WM_PRINT = 0x317;
                public const int WM_DESTROY = 0x2;
                public const int WM_SHOWWINDOW = 0x18;
                public const int WM_SHARED_MENU = 0x1E2;
                public const int HC_ACTION = 0;
                public const int WH_CALLWNDPROC = 4;
                public const int GWL_WNDPROC = -4;
            }



            [StructLayout(LayoutKind.Sequential)]
            public struct RECT
            {
                public int Left;
                public int Top;
                public int Right;
                public int Bottom;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct WINDOWPOS
            {
                public IntPtr hwnd;
                public IntPtr hwndAfter;
                public int x;
                public int y;
                public int cx;
                public int cy;
#pragma warning disable CS3003 // Type is not CLS-compliant
                public uint flags;
#pragma warning restore CS3003 // Type is not CLS-compliant
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct NCCALCSIZE_PARAMS
            {
                public RECT rgc;
                public WINDOWPOS wndpos;
            }




            [DllImport("rstrtmgr.dll", CharSet = CharSet.Unicode)]
            static extern int RmRegisterResources(uint pSessionHandle,
                                           UInt32 nFiles,
                                           string[] rgsFilenames,
                                           UInt32 nApplications,
                                           [In] RM_UNIQUE_PROCESS[] rgApplications,
                                           UInt32 nServices,
                                           string[] rgsServiceNames);

            [DllImport("rstrtmgr.dll", CharSet = CharSet.Auto)]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
            public static extern int RmStartSession(out uint pSessionHandle, int dwSessionFlags, string strSessionKey);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

            [DllImport("rstrtmgr.dll")]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
            public static extern int RmEndSession(uint pSessionHandle);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

            [DllImport("rstrtmgr.dll")]
            static extern int RmGetList(uint dwSessionHandle,
                                        out uint pnProcInfoNeeded,
                                        ref uint pnProcInfo,
                                        [In, Out] RM_PROCESS_INFO[] rgAffectedApps,
                                        ref uint lpdwRebootReasons);



            public enum Bool
            {
                False = 0,
                True
            };

            public const Int32 ULW_COLORKEY = 0x00000001;
            public const Int32 ULW_ALPHA = 0x00000002;
            public const Int32 ULW_OPAQUE = 0x00000004;

            public const byte AC_SRC_OVER = 0x00;
            public const byte AC_SRC_ALPHA = 0x01;



            [StructLayout(LayoutKind.Sequential)]
            public struct Point
            {
                public Int32 x;
                public Int32 y;

                public Point(Int32 x, Int32 y)
                {
                    this.x = x;
                    this.y = y;
                }
            }


            [StructLayout(LayoutKind.Sequential)]
            public struct Size
            {
                public Int32 cx;
                public Int32 cy;

                public Size(Int32 cx, Int32 cy)
                {
                    this.cx = cx;
                    this.cy = cy;
                }
            }


        }
        #endregion

        #region Run Instance
        public static void ShowInstanceProcess(Form MainForm, string ApplicationName, bool BringWindowToFront)
        {
            Mutex mutext = new Mutex(true, ApplicationName, out bool CreaN);
            if (CreaN == true)
                Application.Run(MainForm);
            else
            {
                if (BringWindowToFront == true)
                {
                    Process currentProcess = Process.GetCurrentProcess();
                    // Check with other process already running   
                    foreach (var p in Process.GetProcesses())
                    {
                        if (p.Id != currentProcess.Id && p.ProcessName.Equals(currentProcess.ProcessName) == true) // Check running process   
                        {
                            IntPtr hFound = p.MainWindowHandle;
                            if (HeCopUI_Framework.Win32.Win32.IsIconic(hFound)) // If application is in ICONIC mode then  
                                HeCopUI_Framework.Win32.Win32.ShowWindow(hFound, HeCopUI_Framework.Win32.Win32.SW_RESTORE);
                            HeCopUI_Framework.Win32.Win32.SetForegroundWindow(hFound); // Activate the window, if process is already running  
                        }
                    }
                }
            }
            mutext.ReleaseMutex();
        }

        #endregion

        #region AssemblyGuid
        public static string AssemblyGuid
        {
            get
            {
                object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(System.Runtime.InteropServices.GuidAttribute), false);
                if (attributes.Length == 0)
                {
                    return String.Empty;
                }
                return ((System.Runtime.InteropServices.GuidAttribute)attributes[0]).Value;
            }
        }
        #endregion

        #region Effect Animation

        public enum Effect { Roll, Slide, Center, Blend }

        public static void Animate(Control ctl, Effect effect, int msec, int angle)
        {
            int flags = effmap[(int)effect];
            if (ctl.Visible) { flags |= 0x10000; angle += 180; }
            else
            {
                if (ctl.TopLevelControl == ctl) flags |= 0x20000;
                else if (effect == Effect.Blend) throw new ArgumentException();
            }
            flags |= dirmap[(angle % 360) / 45];
            bool ok = HeCopUI_Framework.Win32.Win32.AnimateWindow(ctl.Handle, msec, flags);
            if (!ok) throw new Exception("Animation failed");
            ctl.Visible = !ctl.Visible;
        }


        private static int[] dirmap = { 1, 5, 4, 6, 2, 10, 8, 9 };
        private static int[] effmap = { 0, 0x40000, 0x10, 0x80000 };

        #endregion

        #region Order
        /// <summary>
        /// 
        /// </summary>
        /// <param name="num1">Number 1 is Padding 1 of controls.</param>
        /// <param name="num2">Number 2 is Padding 2 of controls.</param>
        /// <param name="num3">Number 3 is Padding 3 of controls.</param>
        /// <param name="num4">Number 4 is Padding 4 of controls.</param>
        /// <returns></returns>
        public int SizeGetMaxPad(int num1, int num2, int num3, int num4)
        {
            //int re = 0;
            //if (Math.Max(num1, num2) > num2) re = num1;
            //else if (Math.Max(num1, num2) < num2) re = num2;
            //else if (Math.Max(num1, num3) > num3) re = num1;
            //else if (Math.Max(num1, num3) < num3) re = num3;
            //else if (Math.Max(num1, num4) > num4) re = num1;
            //else if (Math.Max(num1, num4) < num4) re = num4;

            //if (Math.Max(num2, num3) > num3) re = num2;
            //else if (Math.Max(num2, num3) < num3) re = num3;
            //if (Math.Max(num2, num4) > num4) re = num2;
            //else if (Math.Max(num2, num4) < num4) re = num4;
            //if (Math.Max(num3, num4) > num4) re = num3;
            //else if (Math.Max(num3, num4) < num4) re = num4;
            //return re;
            return new int[] { num1, num2, num3, num4 }.Max();

        }
        #endregion

        public static Bitmap SetBitmapTransparentDesktop(Control control)
        {
            Bitmap aBmp = null;
            IntPtr screenDC = HeCopUI_Framework.Win32.Win32.GetDC(IntPtr.Zero);
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

                HeCopUI_Framework.Win32.Enums.BLENDFUNCTION blend = new HeCopUI_Framework.Win32.Enums.BLENDFUNCTION();
                blend.BlendOp = HeCopUI_Framework.GetAppResources.Win32.AC_SRC_OVER;
                blend.BlendFlags = 0;
                blend.SourceConstantAlpha = 255;
                blend.AlphaFormat = HeCopUI_Framework.GetAppResources.Win32.AC_SRC_ALPHA;
                HeCopUI_Framework.Win32.Win32.UpdateLayeredWindow(control.Handle, screenDC, ref topPos, ref size, memDC, ref pointSource, 0, ref blend, HeCopUI_Framework.GetAppResources.Win32.ULW_ALPHA);
            }
            catch
            {
            }
            finally
            {
                HeCopUI_Framework.Win32.Win32.ReleaseDC(IntPtr.Zero, screenDC);
                if (hBitmap != IntPtr.Zero)
                {
                    HeCopUI_Framework.Win32.Gdi32.SelectObject(memDC, oldBitmap);
                    HeCopUI_Framework.Win32.Gdi32.DeleteObject(hBitmap);
                }
                HeCopUI_Framework.Win32.Gdi32.DeleteDC(memDC);
            }
            return aBmp;
        }

        #region Effect Control

        public static ControlStyles SetControlStyles()
        {
            ControlStyles CS =
                     ControlStyles.OptimizedDoubleBuffer| ControlStyles.SupportsTransparentBackColor| ControlStyles.UserPaint| ControlStyles.AllPaintingInWmPaint|
                     ControlStyles.ResizeRedraw;
            return CS;
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
                        }
                        control3.DrawToBitmap(bitmap, control3.Bounds);
                    }
                }
                if (bitmap != null)
                {
                    g.DrawImage((Image)bitmap, control.ClientRectangle, rectangle, (GraphicsUnit)GraphicsUnit.Pixel);
                    bitmap.Dispose();
                }
            }
        }


        public static Graphics GetControlGraphicsEffect(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            return g;
        }

        public static System.Drawing.Text.TextRenderingHint SetTextRender()
        {
            return System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn
        (
        int nLeftRect, // x-coordinate of upper-left corner
        int nTopRect, // y-coordinate of upper-left corner
        int nRightRect, // x-coordinate of lower-right corner
        int nBottomRect, // y-coordinate of lower-right corner
        int nWidthEllipse, // height of ellipse
        int nHeightEllipse // width of ellipse
        );

        public static void GetStringAlign(StringFormat stringFormat, ContentAlignment contentAlignment)
        {
            switch (contentAlignment)
            {
                case ContentAlignment.TopLeft:
                    stringFormat.Alignment = StringAlignment.Near;
                    stringFormat.LineAlignment = StringAlignment.Near;
                    break;
                case ContentAlignment.TopCenter:
                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.LineAlignment = StringAlignment.Near;
                    break;
                case ContentAlignment.TopRight:
                    stringFormat.Alignment = StringAlignment.Far;
                    stringFormat.LineAlignment = StringAlignment.Near;
                    break;
                case ContentAlignment.MiddleLeft:
                    stringFormat.Alignment = StringAlignment.Near;
                    stringFormat.LineAlignment = StringAlignment.Center;
                    break;
                case ContentAlignment.MiddleCenter:
                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.LineAlignment = StringAlignment.Center;
                    break;
                case ContentAlignment.MiddleRight:
                    stringFormat.Alignment = StringAlignment.Far;
                    stringFormat.LineAlignment = StringAlignment.Center;
                    break;
                case ContentAlignment.BottomLeft:
                    stringFormat.Alignment = StringAlignment.Near;
                    stringFormat.LineAlignment = StringAlignment.Far;
                    break;
                case ContentAlignment.BottomCenter:
                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.LineAlignment = StringAlignment.Far;
                    break;
                case ContentAlignment.BottomRight:
                    stringFormat.Alignment = StringAlignment.Far;
                    stringFormat.LineAlignment = StringAlignment.Far;
                    break;
            }
        }

  
        #endregion

        #region Read .Ini File
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filepath);
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filepath);
        string EXE = Assembly.GetExecutingAssembly().GetName().Name;
        public static string READINIFILE(string filePath, string Section, string Key)
        {
            StringBuilder tmp = new StringBuilder(255);
            long i = GetPrivateProfileString(Section, Key, "", tmp, 255, filePath);
            return tmp.ToString();
        }
        public static void WRITEINIFILE(string filePath, string Section, string Key, string szData)
        {
            WritePrivateProfileString(Section, Key, szData, filePath);
        }
        public void DeleteSection(string filePath, string Section = null)
        {
            WRITEINIFILE(filePath, Section ?? EXE, null, null);
        }

        public void DeleteKey(string filePath, string Key, string Section = null)
        {
            WRITEINIFILE(filePath, Key, null, Section ?? EXE);
        }

        public bool KeyExists(string filePath, string Key, string Section = null)
        {
            return READINIFILE(filePath, Key, Section).Length > 0;
        }
        #endregion

        #region Get Encoder File
        public static string GetMD5File(string filePath)
        {
            using (var MD5File = MD5.Create())
            {
                using (FileStream FS = File.OpenRead(filePath))
                {
                    return BitConverter.ToString(MD5File.ComputeHash(FS)).Replace("-", "");
                }
            }
        }

        public static string GetSHA1(string filePath)
        {
            using (var MD5File = SHA1.Create())
            {
                using (FileStream FS = File.OpenRead(filePath))
                {
                    return BitConverter.ToString(MD5File.ComputeHash(FS)).Replace("-", "");
                }
            }
        }

        #endregion

        #region Read .Xml File
        static string XmlText;
        public static string ReadDataXml(string filePath, string tableName, string dataName)
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(filePath);
            DataTable dt = new DataTable();
            dt = dataSet.Tables[tableName];
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                XmlText = dr[dataName].ToString();
                i += 1; i++;
            }
            return XmlText;
        }

        public static void WriteDataXml(string filePath, string rootElement, string table, string tableName, string tableData, string dataName, string data)
        {
            XDocument testXML = XDocument.Load(filePath);
            XElement newStudent = new XElement(table,
            new XElement(dataName, data));
            newStudent.SetAttributeValue(tableName, tableData);
            testXML.Element(rootElement).Add(newStudent);
            testXML.Save(filePath);
        }

        public static void DeleteDataXml(string filePath, string table, string dataName, string data)
        {
            XDocument testXML = XDocument.Load(filePath);
            XElement cStudent = testXML.Descendants(table).Where(c => c.Attribute(dataName).Value.Equals(data)).FirstOrDefault();
            cStudent.Remove();

            testXML.Save(filePath);

        }
        #endregion

        #region Gets bytes size 

        public static string StringSizeOfFile(long bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            double len = bytes;
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }
            return String.Format("{0:0.##} {1}", len, sizes[order]);
        }

        public static float LongSizeOfFile(long bytes)
        {
            double len = bytes;
            int order = 0;
            while (len >= 1024)
            {
                order++;
                len = len / 1024;
            }
            return (int)len;
        }

        public string BytesToReadableValue(long number)
        {
            List<string> suffixes = new List<string>() { " B", " KB", " MB", " GB", " TB", " PB" };

            for (int i = 0; i < suffixes.Count; i++)
            {
                long temp = number / (int)Math.Pow(1024, i + 1);

                if (temp == 0)
                {
                    return (number / (int)Math.Pow(1024, i)) + suffixes[i];
                }
            }

            return number.ToString();
        }

        #endregion

        #region Process

        public static string ProcessExecutablePath(Process process)
        {
            try
            {
                return process.MainModule.FileName;
            }
            catch
            {
                string query = "SELECT ExecutablePath, ProcessID FROM Win32_Process";
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);

                foreach (ManagementObject item in searcher.Get())
                {
                    object id = item["ProcessID"];
                    object path = item["ExecutablePath"];

                    if (path != null && id.ToString() == process.Id.ToString())
                    {
                        return path.ToString();
                    }
                }
            }

            return "";
        }

        [StructLayout(LayoutKind.Sequential)]
        struct RM_UNIQUE_PROCESS
        {
            public int dwProcessId;
            public System.Runtime.InteropServices.ComTypes.FILETIME ProcessStartTime;
        }

        const int RmRebootReasonNone = 0;
        const int CCH_RM_MAX_APP_NAME = 255;
        const int CCH_RM_MAX_SVC_NAME = 63;

        enum RM_APP_TYPE
        {
            RmUnknownApp = 0,
            RmMainWindow = 1,
            RmOtherWindow = 2,
            RmService = 3,
            RmExplorer = 4,
            RmConsole = 5,
            RmCritical = 1000
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        struct RM_PROCESS_INFO
        {
            public RM_UNIQUE_PROCESS Process;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCH_RM_MAX_APP_NAME + 1)]
            public string strAppName;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCH_RM_MAX_SVC_NAME + 1)]
            public string strServiceShortName;

            public RM_APP_TYPE ApplicationType;
            public uint AppStatus;
            public uint TSSessionId;
            [MarshalAs(UnmanagedType.Bool)]
            public bool bRestartable;
        }

        [DllImport("rstrtmgr.dll", CharSet = CharSet.Unicode)]
        static extern int RmRegisterResources(uint pSessionHandle,
                                              UInt32 nFiles,
                                              string[] rgsFilenames,
                                              UInt32 nApplications,
                                              [In] RM_UNIQUE_PROCESS[] rgApplications,
                                              UInt32 nServices,
                                              string[] rgsServiceNames);

        [DllImport("rstrtmgr.dll", CharSet = CharSet.Auto)]
        static extern int RmStartSession(out uint pSessionHandle, int dwSessionFlags, string strSessionKey);

        [DllImport("rstrtmgr.dll")]
        static extern int RmEndSession(uint pSessionHandle);

        [DllImport("rstrtmgr.dll")]
        static extern int RmGetList(uint dwSessionHandle,
                                    out uint pnProcInfoNeeded,
                                    ref uint pnProcInfo,
                                    [In, Out] RM_PROCESS_INFO[] rgAffectedApps,
                                    ref uint lpdwRebootReasons);

        /// <summary>
        /// Find out what process(es) have a lock on the specified file.
        /// </summary>
        /// <param name="path">Path of the file.</param>
        /// <returns>Processes locking the file</returns>
        /// <remarks>See also:
        /// http://msdn.microsoft.com/en-us/library/windows/desktop/aa373661(v=vs.85).aspx
        /// http://wyupdate.googlecode.com/svn-history/r401/trunk/frmFilesInUse.cs (no copyright in code at time of viewing)
        /// 
        /// </remarks>
        static public List<Process> WhoIsLocking(string path)
        {
            uint handle;
            string key = Guid.NewGuid().ToString();
            List<Process> processes = new List<Process>();

            int res = RmStartSession(out handle, 0, key);
            if (res != 0) throw new Exception("Could not begin restart session.  Unable to determine file locker.");

            try
            {
                const int ERROR_MORE_DATA = 234;
                uint pnProcInfoNeeded = 0,
                     pnProcInfo = 0,
                     lpdwRebootReasons = RmRebootReasonNone;

                string[] resources = new string[] { path }; // Just checking on one resource.

                res = RmRegisterResources(handle, (uint)resources.Length, resources, 0, null, 0, null);

                if (res != 0) throw new Exception("Could not register resource.");

                //Note: there's a race condition here -- the first call to RmGetList() returns
                //      the total number of process. However, when we call RmGetList() again to get
                //      the actual processes this number may have increased.
                res = RmGetList(handle, out pnProcInfoNeeded, ref pnProcInfo, null, ref lpdwRebootReasons);

                if (res == ERROR_MORE_DATA)
                {
                    // Create an array to store the process results
                    RM_PROCESS_INFO[] processInfo = new RM_PROCESS_INFO[pnProcInfoNeeded];
                    pnProcInfo = pnProcInfoNeeded;

                    // Get the list
                    res = RmGetList(handle, out pnProcInfoNeeded, ref pnProcInfo, processInfo, ref lpdwRebootReasons);
                    if (res == 0)
                    {
                        processes = new List<Process>((int)pnProcInfo);

                        // Enumerate all of the results and add them to the 
                        // list to be returned
                        for (int i = 0; i < pnProcInfo; i++)
                        {
                            try
                            {
                                processes.Add(Process.GetProcessById(processInfo[i].Process.dwProcessId));
                            }
                            // catch the error -- in case the process is no longer running
                            catch (ArgumentException) { }
                        }
                    }
                    else throw new Exception("Could not list processes locking resource.");
                }
                else if (res != 0) throw new Exception("Could not list processes locking resource. Failed to get size of result.");
            }
            finally
            {
                RmEndSession(handle);
            }

            return processes;
        }

        public static void KillProcessesAssociatedToFile(string file)
        {
            GetProcessesAssociatedToFile(file).ForEach(x =>
            {
                x.Kill();
                x.WaitForExit(10000);
            });
        }

        public static List<Process> GetProcessesAssociatedToFile(string file)
        {
            return Process.GetProcesses()
                .Where(x => !x.HasExited
                    && x.Modules.Cast<ProcessModule>().ToList()
                        .Exists(y => y.FileName.ToLowerInvariant() == file.ToLowerInvariant())
                    ).ToList();
        }

        public static List<Process> GetProcessesLockingFile(string path)
        {
            uint handle;
            string key = Guid.NewGuid().ToString();
            int res = RmStartSession(out handle, 0, key);

            if (res != 0) throw new Exception("Could not begin restart session.  Unable to determine file locker.");

            try
            {
                const int MORE_DATA = 234;
                uint pnProcInfoNeeded, pnProcInfo = 0, lpdwRebootReasons = RmRebootReasonNone;

                string[] resources = { path }; // Just checking on one resource.

                res = RmRegisterResources(handle, (uint)resources.Length, resources, 0, null, 0, null);

                if (res != 0) throw new Exception("Could not register resource.");

                //Note: there's a race condition here -- the first call to RmGetList() returns
                //      the total number of process. However, when we call RmGetList() again to get
                //      the actual processes this number may have increased.
                res = RmGetList(handle, out pnProcInfoNeeded, ref pnProcInfo, null, ref lpdwRebootReasons);

                if (res == MORE_DATA)
                {
                    return EnumerateProcesses(pnProcInfoNeeded, handle, lpdwRebootReasons);
                }
                else if (res != 0) throw new Exception("Could not list processes locking resource. Failed to get size of result.");
            }
            finally
            {
                RmEndSession(handle);
            }

            return new List<Process>();
        }


        private static List<Process> EnumerateProcesses(uint pnProcInfoNeeded, uint handle, uint lpdwRebootReasons)
        {
            var processes = new List<Process>(10);
            // Create an array to store the process results
            var processInfo = new RM_PROCESS_INFO[pnProcInfoNeeded];
            var pnProcInfo = pnProcInfoNeeded;

            // Get the list
            var res = RmGetList(handle, out pnProcInfoNeeded, ref pnProcInfo, processInfo, ref lpdwRebootReasons);

            if (res != 0) throw new Exception("Could not list processes locking resource.");
            for (int i = 0; i < pnProcInfo; i++)
            {
                try
                {
                    processes.Add(Process.GetProcessById(processInfo[i].Process.dwProcessId));
                }
                catch (ArgumentException) { } // catch the error -- in case the process is no longer running
            }
            return processes;
        }

        public static Process GetProcessesStarted()
        {
            ManagementEventWatcher startWatch = new ManagementEventWatcher(new WqlEventQuery("SELECT * FROM Win32_ProcessStartTrace"));
            Process sd = null;
            startWatch.EventArrived += (s, e) =>
            {
                foreach (Process pro in Process.GetProcessesByName(e.NewEvent.Properties["ProcessName"].Value.ToString()))
                    sd = pro;
            };
            startWatch.Start();
            return sd;
        }

        public static Process GetProcessesStopped()
        {
            ManagementEventWatcher stopWatch = new ManagementEventWatcher(
             new WqlEventQuery("SELECT * FROM Win32_ProcessStopTrace"));
            Process sd = null;
            stopWatch.EventArrived += (s, e) =>
            {
                foreach (Process pro in Process.GetProcessesByName(e.NewEvent.Properties["ProcessName"].Value.ToString()))
                    sd = pro;
            };
            stopWatch.Start();
            return sd;
        }
        #endregion

    }

}
