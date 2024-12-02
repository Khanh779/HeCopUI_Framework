using HeCopUI_Framework.Win32.Struct;
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace HeCopUI_Framework.Win32
{

    public class Gdi32
    {
        [DllImport("gdi32.dll")]
        public static extern int GetRgnBox(IntPtr hrgn, out RECT lprc);

        public const int RGN_AND = 1;

        public const int RGN_OR = 2;

        public const int RGN_XOR = 3;

        public const int RGN_DIFF = 4;

        public const int RGN_COPY = 5;

        //[DllImport("Gdi32.dll")]
        //public static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);


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

        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject([In] IntPtr hObject);



        [DllImport("gdi32.dll", CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
        internal static extern int BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, uint dwRop);

        [DllImport("gdi32.dll")]
        internal static extern bool LPtoDP(IntPtr hdc, [In][Out] POINT[] lpPoints, int nCount);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
        internal static extern bool GetViewportOrgEx(IntPtr hDC, ref POINT point);

        [DllImport("GDI32.dll")]
        internal static extern int ExtSelectClipRgn(IntPtr hdc, IntPtr hrgn, int mode);

        [DllImport("GDI32.dll")]
        internal static extern int RestoreDC(IntPtr hdc, int savedDC);

        [DllImport("GDI32.dll")]
        internal static extern int SaveDC(IntPtr hdc);

        [DllImport("GDI32.dll")]
        public static extern int GetClipRgn(IntPtr hdc, IntPtr hrgn);

        [DllImport("GDI32.dll")]
        public static extern int SelectClipRgn(IntPtr hdc, IntPtr hrgn);

        public enum PenStyle
        {
            PS_SOLID = 0,
            PS_DASH = 1,
            PS_DOT = 2,
            PS_DASHDOT = 3,
            PS_DASHDOTDOT = 4,
            PS_NULL = 5,
            PS_INSIDEFRAME = 6,
            PS_USERSTYLE = 7,
            PS_ALTERNATE = 8,
            PS_STYLE_MASK = 15,
            PS_ENDCAP_ROUND = 0,
            PS_ENDCAP_SQUARE = 256,
            PS_ENDCAP_FLAT = 512,
            PS_ENDCAP_MASK = 3840,
            PS_JOIN_ROUND = 0,
            PS_JOIN_BEVEL = 4096,
            PS_JOIN_MITER = 8192,
            PS_JOIN_MASK = 61440,
            PS_COSMETIC = 0,
            PS_GEOMETRIC = 65536,
            PS_TYPE_MASK = 983040
        }

        [DllImport("gdi32.dll")]
#pragma warning disable CS3001 // Argument type is not CLS-compliant

        public static extern IntPtr CreatePen(PenStyle fnPenStyle, int nWidth, uint crColor);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

        public static IntPtr CreateRectRgn(Rectangle rect)
        {
            return CreateRectRgn(rect.Left, rect.Top, rect.Right, rect.Bottom);
        }

        [DllImport("GDI32.dll")]
        internal static extern int CombineRgn(IntPtr hrgnDest, IntPtr hrgnSrc1, IntPtr hrgnSrc2, int fnCombineMode);

        [DllImport("gdi32.dll")]
#pragma warning disable CS3002 // Return type is not CLS-compliant
        public static extern uint SetBkColor(IntPtr hdc, int crColor);
#pragma warning restore CS3002 // Return type is not CLS-compliant

        [DllImport("gdi32.dll")]
        internal static extern int ExcludeClipRect(IntPtr hdc, int x1, int y1, int x2, int y2);

        [DllImport("gdi32.dll")]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
        public static extern IntPtr CreateSolidBrush([In] uint color);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

        [DllImport("gdi32.dll")]
        public static extern bool Rectangle(IntPtr hdc, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern IntPtr SelectObject([In] IntPtr hdc, [In] IntPtr hgdiobj);

        [DllImport("gdi32.dll")]
        internal static extern bool StretchBlt(IntPtr hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest, int nHeightDest, IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc, uint dwRop);

        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern IntPtr CreateCompatibleDC([In] IntPtr hdc);

        [DllImport("gdi32.dll")]
        public static extern bool DeleteDC([In] IntPtr hdc);
    }
}