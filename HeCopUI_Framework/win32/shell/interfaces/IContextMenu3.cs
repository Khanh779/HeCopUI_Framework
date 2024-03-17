using System;
using System.Runtime.InteropServices;
using System.Text;

namespace HeCopUI_Framework.Win32
{
    [ComImport]
    [Guid("bcfce0a0-ec17-11d0-8d10-00a0c90f2719")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IContextMenu3
    {
    	[PreserveSig]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
#pragma warning disable CS3001 // Argument type is not CLS-compliant
#pragma warning disable CS3001 // Argument type is not CLS-compliant
    	int QueryContextMenu(IntPtr hmenu, uint iMenu, uint idCmdFirst, uint idCmdLast, ShellAPI.CMF uFlags);
#pragma warning restore CS3001 // Argument type is not CLS-compliant
#pragma warning restore CS3001 // Argument type is not CLS-compliant
#pragma warning restore CS3001 // Argument type is not CLS-compliant

    	[PreserveSig]
    	int InvokeCommand(ref ShellAPI.CMINVOKECOMMANDINFOEX info);

    	[PreserveSig]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
#pragma warning disable CS3001 // Argument type is not CLS-compliant
    	int GetCommandString(uint idcmd, ShellAPI.GCS uflags, uint reserved, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder commandstring, int cch);
#pragma warning restore CS3001 // Argument type is not CLS-compliant
#pragma warning restore CS3001 // Argument type is not CLS-compliant

    	[PreserveSig]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
    	int HandleMenuMsg(uint uMsg, IntPtr wParam, IntPtr lParam);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

    	[PreserveSig]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
    	int HandleMenuMsg2(uint uMsg, IntPtr wParam, IntPtr lParam, IntPtr plResult);
#pragma warning restore CS3001 // Argument type is not CLS-compliant
    }
}
