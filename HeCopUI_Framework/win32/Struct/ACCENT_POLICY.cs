using HeCopUI_Framework.Win32.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HeCopUI_Framework.Win32.User32;

namespace HeCopUI_Framework.Win32.Struct
{
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
}
