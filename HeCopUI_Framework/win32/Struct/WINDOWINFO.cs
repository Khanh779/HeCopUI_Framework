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
    public struct WINDOWINFO
    {
#pragma warning disable CS3003 // Base type is not CLS-compliant
        public uint cbSize;

        public RECT rcWindow;
        public RECT rcClient;
        public WindowStyles dwStyle;
        public WindowStyles dwExStyle;
        public uint dwWindowStatus;
        public uint cxWindowBorders;
        public uint cyWindowBorders;
        public ushort atomWindowType;
        public ushort wCreatorVersion;
#pragma warning restore CS300 // Base type is not CLS-compliant

        // ReSharper disable once UnusedParameter.Local
        public WINDOWINFO(Boolean? filler) : this()
        {
            // Allows automatic initialization of "cbSize" with "new WINDOWINFO(null/true/false)".
            cbSize = (UInt32)(Marshal.SizeOf(typeof(WINDOWINFO)));
        }
    }

}
