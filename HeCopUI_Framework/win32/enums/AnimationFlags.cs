using System;

namespace HeCopUI_Framework.Win32.Enums
{
    [Flags]
    internal enum AnimationFlags
    {
        Roll = 0,
        HorizontalPositive = 1,
        HorizontalNegative = 2,
        VerticalPositive = 4,
        VerticalNegative = 8,
        Center = 0x10,
        Hide = 0x10000,
        Activate = 0x20000,
        Slide = 0x40000,
        Blend = 0x80000,
        Mask = 0xFFFFF
    }
}
