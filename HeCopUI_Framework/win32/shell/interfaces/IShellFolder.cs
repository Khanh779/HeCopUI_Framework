using System;
using System.Runtime.InteropServices;

namespace HeCopUI_Framework.Win32
{
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("000214E6-0000-0000-C000-000000000046")]
    public interface IShellFolder
    {
    	[PreserveSig]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
    	int ParseDisplayName(IntPtr hwnd, IntPtr pbc, [MarshalAs(UnmanagedType.LPWStr)] string pszDisplayName, ref uint pchEaten, out IntPtr ppidl, ref ShellAPI.SFGAO pdwAttributes);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

    	[PreserveSig]
    	int EnumObjects(IntPtr hwnd, ShellAPI.SHCONTF grfFlags, out IntPtr enumIDList);

    	[PreserveSig]
    	int BindToObject(IntPtr pidl, IntPtr pbc, ref Guid riid, out IntPtr ppv);

    	[PreserveSig]
    	int BindToStorage(IntPtr pidl, IntPtr pbc, ref Guid riid, out IntPtr ppv);

    	[PreserveSig]
    	int CompareIDs(IntPtr lParam, IntPtr pidl1, IntPtr pidl2);

    	[PreserveSig]
    	int CreateViewObject(IntPtr hwndOwner, Guid riid, out IntPtr ppv);

    	[PreserveSig]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
    	int GetAttributesOf(uint cidl, [MarshalAs(UnmanagedType.LPArray)] IntPtr[] apidl, ref ShellAPI.SFGAO rgfInOut);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

    	[PreserveSig]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
    	int GetUIObjectOf(IntPtr hwndOwner, uint cidl, [MarshalAs(UnmanagedType.LPArray)] IntPtr[] apidl, ref Guid riid, IntPtr rgfReserved, out IntPtr ppv);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

    	[PreserveSig]
    	int GetDisplayNameOf(IntPtr pidl, ShellAPI.SHGNO uFlags, IntPtr lpName);

    	[PreserveSig]
    	int SetNameOf(IntPtr hwnd, IntPtr pidl, [MarshalAs(UnmanagedType.LPWStr)] string pszName, ShellAPI.SHGNO uFlags, out IntPtr ppidlOut);
    }
}
