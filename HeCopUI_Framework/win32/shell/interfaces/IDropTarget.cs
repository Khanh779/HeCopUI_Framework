using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HeCopUI_Framework.Win32
{
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("00000122-0000-0000-C000-000000000046")]
    public interface IDropTarget
    {
    	[PreserveSig]
    	int DragEnter(IntPtr pDataObj, ShellAPI.MK grfKeyState, ShellAPI.POINT pt, ref DragDropEffects pdwEffect);

    	[PreserveSig]
    	int DragOver(ShellAPI.MK grfKeyState, ShellAPI.POINT pt, ref DragDropEffects pdwEffect);

    	[PreserveSig]
    	int DragLeave();

    	[PreserveSig]
    	int DragDrop(IntPtr pDataObj, ShellAPI.MK grfKeyState, ShellAPI.POINT pt, ref DragDropEffects pdwEffect);
    }
}
