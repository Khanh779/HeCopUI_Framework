using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeCopUI_Framework.Win32.Enums
{
    [Flags]
    public enum TabControlHitTest
    {
        TCHT_NOWHERE = 1,
        TCHT_ONITEMICON = 2,
        TCHT_ONITEMLABEL = 4,
        TCHT_ONITEM = 6
    }
}
