namespace HeCopUI_Framework.Win32.Enums
{
#pragma warning disable CS3009 // Base type is not CLS-compliant
    public enum SystemCommands : uint
#pragma warning restore CS3009 // Base type is not CLS-compliant
    {
        SC_CLOSE = 0xF060,
        SC_MAXIMIZE = 0xF030,
        SC_MINIMIZE = 0xF020,
        SC_RESTORE = 0xF120,
        SC_CONTEXTHELP = 0xF180,
        SC_DEFAULT = 0xF160,
        SC_HOTKEY = 0xF150,
        SC_HSCROLL = 0xF080,
        SC_MOVE = 0xF010,
    }
}
