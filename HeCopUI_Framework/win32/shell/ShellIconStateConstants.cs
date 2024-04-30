using System;

namespace HeCopUI_Framework.Win32
{
    [Flags]
    public enum ShellIconStateConstants
    {
    	ShellIconStateNormal = 0,
    	ShellIconStateLinkOverlay = 0x8000,
    	ShellIconStateSelected = 0x10000,
    	ShellIconStateOpen = 2,
    	ShellIconAddOverlays = 0x20
    }
}
