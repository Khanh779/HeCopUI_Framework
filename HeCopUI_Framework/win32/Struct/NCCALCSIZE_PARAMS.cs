using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HeCopUI_Framework.Win32.Struct
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NCCALCSIZE_PARAMS
    {
        public RECT rcOldWindow;
        public RECT rcNewWindow;
        public RECT rcClient;
        //public RECT rectProposed;
        public IntPtr lppos;

    }
}
