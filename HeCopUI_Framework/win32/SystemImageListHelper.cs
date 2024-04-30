using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HeCopUI_Framework.Win32
{
    public class SystemImageListHelper
    {
    	private const int LVM_FIRST = 4096;

    	private const int LVM_SETIMAGELIST = 4099;

    	private const int LVSIL_NORMAL = 0;

    	private const int LVSIL_SMALL = 1;

    	private const int LVSIL_STATE = 2;

    	private const int TV_FIRST = 4352;

    	private const int TVM_SETIMAGELIST = 4361;

    	private const int TVSIL_NORMAL = 0;

    	private const int TVSIL_STATE = 2;

    	[DllImport("Msg", CharSet = CharSet.Auto)]
    	private static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

    	public static void SetListViewImageList(ListView listView, SystemImageList sysImageList, bool forStateImages)
    	{
    		IntPtr wParam = (IntPtr)0;
    		if (sysImageList.ImageListSize == SystemImageListSize.SmallIcons)
    		{
    			wParam = (IntPtr)1;
    		}
    		if (forStateImages)
    		{
    			wParam = (IntPtr)2;
    		}
    		SendMessage(listView.Handle, 4099, wParam, sysImageList.Handle);
    	}

    	public static void SetTreeViewImageList(TreeView treeView, SystemImageList sysImageList, bool forStateImages)
    	{
    		IntPtr wParam = (IntPtr)0;
    		if (forStateImages)
    		{
    			wParam = (IntPtr)2;
    		}
    		SendMessage(treeView.Handle, 4361, wParam, sysImageList.Handle);
    	}
    }
}
