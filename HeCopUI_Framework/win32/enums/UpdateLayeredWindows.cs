using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeCopUI_Framework.Win32.Enums
{
    public enum UpdateLayeredWindows : int
    {
        ULW_COLORKEY = 0x00000001,
        ULW_ALPHA = 0x00000002,
        ULW_OPAQUE = 0x00000004,
        ULW_EX_NORESIZE = 0x00000008,
        ULW_EX_LARGERECT = 0x00000010,
        ULW_FRAME = 0x00000020,
        ULW_ALL = 0x0000003F
    }
}
