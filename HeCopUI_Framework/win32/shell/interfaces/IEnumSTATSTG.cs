using System.Runtime.InteropServices;

namespace HeCopUI_Framework.Win32
{
    [ComImport]
    [Guid("0000000d-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IEnumSTATSTG
    {
    	[PreserveSig]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
#pragma warning disable CS3002 // Return type is not CLS-compliant
#pragma warning disable CS3001 // Argument type is not CLS-compliant
    	uint Next(uint celt, [MarshalAs(UnmanagedType.LPArray)] out ShellAPI.STATSTG[] rgelt, out uint pceltFetched);
#pragma warning restore CS3001 // Argument type is not CLS-compliant
#pragma warning restore CS3002 // Return type is not CLS-compliant
#pragma warning restore CS3001 // Argument type is not CLS-compliant

    	[PreserveSig]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
    	void Skip(uint celt);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

    	[PreserveSig]
    	void Reset();

    	[PreserveSig]
    	IEnumSTATSTG Clone();
    }
}
