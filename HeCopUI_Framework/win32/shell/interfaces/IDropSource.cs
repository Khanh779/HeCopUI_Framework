using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HeCopUI_Framework.Win32
{
    [ComImport]
    [Guid("00000121-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDropSource
    {
    	[PreserveSig]
    	int QueryContinueDrag(bool fEscapePressed, ShellAPI.MK grfKeyState);

    	[PreserveSig]
    	int GiveFeedback(DragDropEffects dwEffect);
    }
}
