using System;
using System.Runtime.InteropServices;

namespace HeCopUI_Framework.Win32
{
    [ComImport]
    [Guid("0000010f-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAdviseSink
    {
    	[PreserveSig]
    	void OnDataChange(ref ShellAPI.FORMATETC pformatetcIn, ref ShellAPI.STGMEDIUM pmedium);

    	[PreserveSig]
    	void OnViewChange(int dwAspect, int lindex);

    	[PreserveSig]
    	void OnRename(IntPtr pmk);

    	[PreserveSig]
    	void OnSave();

    	[PreserveSig]
    	void OnClose();
    }
}
