using System;
using System.Collections;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HeCopUI_Framework.Win32
{
    public static class ShellImageList
    {
    	private static IntPtr smallImageListHandle;

    	private static IntPtr largeImageListHandle;

    	private static Hashtable imageTable;

    	private const int TVSIL_NORMAL = 0;

    	private const int TVSIL_SMALL = 1;

    	internal static IntPtr SmallImageList => smallImageListHandle;

    	internal static IntPtr LargeImageList => largeImageListHandle;

    	static ShellImageList()
    	{
    		imageTable = new Hashtable();
    		ShellAPI.SHGFI uFlags = ShellAPI.SHGFI.SMALLICON | ShellAPI.SHGFI.SYSICONINDEX | ShellAPI.SHGFI.USEFILEATTRIBUTES;
    		ShellAPI.SHFILEINFO sfi = default(ShellAPI.SHFILEINFO);
    		smallImageListHandle = ShellAPI.SHGetFileInfo(".txt", ShellAPI.FILE_ATTRIBUTE.NORMAL, ref sfi, ShellAPI.cbFileInfo, uFlags);
    		uFlags = ShellAPI.SHGFI.SYSICONINDEX | ShellAPI.SHGFI.USEFILEATTRIBUTES;
    		ShellAPI.SHFILEINFO sfi2 = default(ShellAPI.SHFILEINFO);
    		largeImageListHandle = ShellAPI.SHGetFileInfo(".txt", ShellAPI.FILE_ATTRIBUTE.NORMAL, ref sfi2, ShellAPI.cbFileInfo, uFlags);
    	}

    	internal static void SetIconIndex(ShellItem item, int index, bool SelectedIcon)
    	{
    		bool flag = false;
    		int num = 0;
    		ShellAPI.SHGFI sHGFI = ShellAPI.SHGFI.ICON | ShellAPI.SHGFI.PIDL | ShellAPI.SHGFI.SYSICONINDEX;
    		ShellAPI.FILE_ATTRIBUTE fILE_ATTRIBUTE = (ShellAPI.FILE_ATTRIBUTE)0;
    		int num2 = index * 256;
    		if (item.IsLink)
    		{
    			num2 |= 1;
    			sHGFI |= ShellAPI.SHGFI.LINKOVERLAY;
    			flag = true;
    		}
    		if (item.IsShared)
    		{
    			num2 |= 2;
    			sHGFI |= ShellAPI.SHGFI.ADDOVERLAYS;
    			flag = true;
    		}
    		if (SelectedIcon)
    		{
    			num2 |= 4;
    			sHGFI |= ShellAPI.SHGFI.OPENICON;
    			flag = true;
    		}
    		if (imageTable.ContainsKey(num2))
    		{
    			num = (int)imageTable[num2];
    		}
    		else if (!flag && !item.IsHidden)
    		{
    			num = (int)Math.Floor((double)num2 / 256.0);
    			imageTable[num2] = num;
    		}
    		else
    		{
    			if (item.IsFileSystem & !item.IsDisk & !item.IsFolder)
    			{
    				sHGFI |= ShellAPI.SHGFI.USEFILEATTRIBUTES;
    				fILE_ATTRIBUTE |= ShellAPI.FILE_ATTRIBUTE.NORMAL;
    			}
    			PIDL pIDLFull = item.PIDLFull;
    			ShellAPI.SHFILEINFO sfi = default(ShellAPI.SHFILEINFO);
    			ShellAPI.SHGetFileInfo(pIDLFull.Ptr, fILE_ATTRIBUTE, ref sfi, ShellAPI.cbFileInfo, sHGFI | ShellAPI.SHGFI.SMALLICON);
    			ShellAPI.SHFILEINFO sfi2 = default(ShellAPI.SHFILEINFO);
    			ShellAPI.SHGetFileInfo(pIDLFull.Ptr, fILE_ATTRIBUTE, ref sfi2, ShellAPI.cbFileInfo, sHGFI | ShellAPI.SHGFI.LARGEICON);
    			Marshal.FreeCoTaskMem(pIDLFull.Ptr);
    			lock (imageTable)
    			{
    				num = ShellAPI.ImageList_ReplaceIcon(smallImageListHandle, -1, sfi.hIcon);
    				ShellAPI.ImageList_ReplaceIcon(largeImageListHandle, -1, sfi2.hIcon);
    			}
    			ShellAPI.DestroyIcon(sfi.hIcon);
    			ShellAPI.DestroyIcon(sfi2.hIcon);
    			imageTable[num2] = num;
    		}
    		if (SelectedIcon)
    		{
    			item.SelectedImageIndex = num;
    		}
    		else
    		{
    			item.ImageIndex = num;
    		}
    	}

    	public static Icon GetIcon(int index, bool small)
    	{
    		IntPtr intPtr = ((!small) ? ShellAPI.ImageList_GetIcon(largeImageListHandle, index, ShellAPI.ILD.NORMAL) : ShellAPI.ImageList_GetIcon(smallImageListHandle, index, ShellAPI.ILD.NORMAL));
    		if (intPtr != IntPtr.Zero)
    		{
    			Icon icon = Icon.FromHandle(intPtr);
    			Icon result = (Icon)icon.Clone();
    			ShellAPI.DestroyIcon(intPtr);
    			return result;
    		}
    		return null;
    	}

    	internal static void SetSmallImageList(TreeView treeView)
    	{
    		ShellAPI.SendMessage(treeView.Handle, ShellAPI.WM.TVM_SETIMAGELIST, 0, smallImageListHandle);
    	}

    	internal static void SetSmallImageList(ListView listView)
    	{
    		ShellAPI.SendMessage(listView.Handle, ShellAPI.WM.LVM_SETIMAGELIST, 1, smallImageListHandle);
    	}

    	internal static void SetLargeImageList(ListView listView)
    	{
    		ShellAPI.SendMessage(listView.Handle, ShellAPI.WM.LVM_SETIMAGELIST, 0, largeImageListHandle);
    	}
    }
}
