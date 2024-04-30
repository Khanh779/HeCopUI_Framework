using System.Runtime.InteropServices;

namespace HeCopUI_Framework.Win32
{
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("00000103-0000-0000-C000-000000000046")]
    public interface IEnumFORMATETC
    {
    	[PreserveSig]
    	int GetNext(int celt, ref ShellAPI.FORMATETC rgelt, ref int pceltFetched);

    	[PreserveSig]
    	int Skip(int celt);

    	[PreserveSig]
    	int Reset();

    	[PreserveSig]
    	int Clone(ref IEnumFORMATETC ppenum);
    }
}
