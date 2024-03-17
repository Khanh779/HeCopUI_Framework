using System;
using System.Runtime.InteropServices;

namespace HeCopUI_Framework.Win32
{
    [ComImport]
    [Guid("DE5BF786-477A-11d2-839D-00C04FD918D0")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDragSourceHelper
    {
    	[PreserveSig]
    	int InitializeFromBitmap(ref ShellAPI.SHDRAGIMAGE pshdi, IntPtr pDataObject);

    	[PreserveSig]
    	int InitializeFromWindow(IntPtr hwnd, ref ShellAPI.POINT ppt, IntPtr pDataObject);
    }
}
