using System;
using System.Runtime.InteropServices;

namespace HeCopUI_Framework.Win32
{
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("000214e8-0000-0000-c000-000000000046")]
    public interface IShellExtInit
    {
    	[PreserveSig]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
    	int Initialize(IntPtr pidlFolder, IntPtr lpdobj, uint hKeyProgID);
#pragma warning restore CS3001 // Argument type is not CLS-compliant
    }
}
