using HeCopUI_Framework.Win32.Enums;

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
