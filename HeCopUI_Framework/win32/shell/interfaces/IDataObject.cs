using System.Runtime.InteropServices;

namespace HeCopUI_Framework.Win32
{
    [ComImport]
    [Guid("0000010e-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDataObject
    {
    	[PreserveSig]
    	int GetData(ref ShellAPI.FORMATETC pformatetcIn, ref ShellAPI.STGMEDIUM pmedium);

    	[PreserveSig]
    	int GetDataHere(ref ShellAPI.FORMATETC pformatetcIn, ref ShellAPI.STGMEDIUM pmedium);

    	[PreserveSig]
    	int QueryGetData(ref ShellAPI.FORMATETC pformatetc);

    	[PreserveSig]
    	int GetCanonicalFormatEtc(ref ShellAPI.FORMATETC pformatetc, ref ShellAPI.FORMATETC pformatetcout);

    	[PreserveSig]
    	int SetData(ref ShellAPI.FORMATETC pformatetcIn, ref ShellAPI.STGMEDIUM pmedium, bool frelease);

    	[PreserveSig]
    	int EnumFormatEtc(int dwDirection, ref IEnumFORMATETC ppenumFormatEtc);

    	[PreserveSig]
    	int DAdvise(ref ShellAPI.FORMATETC pformatetc, ref ShellAPI.ADVF advf, ref IAdviseSink pAdvSink, ref int pdwConnection);

    	[PreserveSig]
    	int DUnadvise(int dwConnection);

    	[PreserveSig]
    	int EnumDAdvise(ref object ppenumAdvise);
    }
}
