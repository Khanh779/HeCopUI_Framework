using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HeCopUI_Framework.Win32
{
    [ComImport]
    [Guid("4657278B-411B-11d2-839A-00C04FD918D0")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDropTargetHelper
    {
    	[PreserveSig]
    	int DragEnter(IntPtr hwndTarget, IntPtr pDataObject, ref ShellAPI.POINT ppt, DragDropEffects dwEffect);

    	[PreserveSig]
    	int DragLeave();

    	[PreserveSig]
    	int DragOver(ref ShellAPI.POINT ppt, DragDropEffects dwEffect);

    	[PreserveSig]
    	int Drop(IntPtr pDataObject, ref ShellAPI.POINT ppt, DragDropEffects dwEffect);

    	[PreserveSig]
    	int Show(bool fShow);
    }
}
