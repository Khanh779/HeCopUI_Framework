using HeCopUI_Framework.Win32.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HeCopUI_Framework.Win32.Struct
{
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
        public ABEs uEdge;
        public RECT rc;
        public int lParam;
    }
}
