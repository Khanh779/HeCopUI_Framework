using System;
using System.Runtime.InteropServices;
using System.Text;

namespace HeCopUI_Framework.Win32
{

	[ComImport]
	[Guid("000214f4-0000-0000-c000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IContextMenu2
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
	}
}