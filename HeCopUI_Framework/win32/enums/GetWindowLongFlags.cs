﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeCopUI_Framework.Win32.Enums
{
    public enum GetWindowLongFlags : int
    {
        GWL_WNDPROC = -4,
        GWL_HINSTANCE = -6,
        GWL_HWNDPARENT = -8,
        GWL_STYLE = -16,
        GWL_EXSTYLE = -20,
        GWL_USERDATA = -21,
        GWL_ID = -12
    }
}
