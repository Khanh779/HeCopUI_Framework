using System;
using System.Runtime.InteropServices;

namespace HeCopUI_Framework.Win32
{
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("000214F2-0000-0000-C000-000000000046")]
    public interface IEnumIDList
    {
    	[PreserveSig]
    	int Next(int celt, out IntPtr rgelt, out int pceltFetched);

    	[PreserveSig]
    	int Skip(int celt);

    	[PreserveSig]
    	int Reset();

    	[PreserveSig]
    	int Clone(out IEnumIDList ppenum);
    }
}
