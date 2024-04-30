using System;
using System.Runtime.InteropServices;

namespace HeCopUI_Framework.Win32
{
    [ComImport]
    [Guid("00021500-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IQueryInfo
    {
    	[PreserveSig]
    	int GetInfoTip(ShellAPI.QITIPF dwFlags, [MarshalAs(UnmanagedType.LPWStr)] out string ppwszTip);

    	[PreserveSig]
    	int GetInfoFlags(out IntPtr pdwFlags);
    }
}
