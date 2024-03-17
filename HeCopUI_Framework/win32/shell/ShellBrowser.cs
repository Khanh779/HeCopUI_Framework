using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;

namespace HeCopUI_Framework.Win32
{
    public class ShellBrowser : Component
    {
    	private ShellItem desktopItem;

    	private ShellItem myComputerItem;

    	private string mydocsName;

    	private string mycompName;

    	private string sysfolderName;

    	private string mydocsPath;

    	private string recycleBinName;

    	private ArrayList browsers;

    	private ShellItemUpdateCondition updateCondition;

    	internal ShellItem DesktopItem => desktopItem;

    	internal ShellItem MyComputerItem => myComputerItem;

    	internal string MyDocumentsName => mydocsName;

    	internal string MyComputerName => mycompName;

    	internal string SystemFolderName => sysfolderName;

    	internal string RecycleBinName => recycleBinName;

    	internal ShellItemUpdateCondition UpdateCondition => updateCondition;

    	internal ArrayList Browsers => browsers;

    	internal event ShellItemUpdateEventHandler ShellItemUpdate;

    	public ShellBrowser()
    	{
    		InitVars();
    		browsers = new ArrayList();
    		updateCondition = new ShellItemUpdateCondition();
    	}

    	private void InitVars()
    	{
    		ShellAPI.SHFILEINFO sfi = default(ShellAPI.SHFILEINFO);
    		IntPtr ppidl = IntPtr.Zero;
    		ShellAPI.SHGetSpecialFolderLocation(IntPtr.Zero, ShellAPI.CSIDL.DRIVES, out ppidl);
    		ShellAPI.SHGetFileInfo(ppidl, (ShellAPI.FILE_ATTRIBUTE)0, ref sfi, ShellAPI.cbFileInfo, ShellAPI.SHGFI.DISPLAYNAME | ShellAPI.SHGFI.PIDL | ShellAPI.SHGFI.TYPENAME);
    		sysfolderName = sfi.szTypeName;
    		mycompName = sfi.szDisplayName;
    		Marshal.FreeCoTaskMem(ppidl);
    		ppidl = IntPtr.Zero;
    		desktopItem = new ShellItem(this, ShellAPI.CSIDL.DESKTOP);
    		desktopItem.Expand(expandFiles: true, expandFolders: true, IntPtr.Zero);
    		myComputerItem = desktopItem.SubFolders[MyComputerName];
    		uint pchEaten = 0u;
    		ShellAPI.SFGAO pdwAttributes = (ShellAPI.SFGAO)0u;
    		desktopItem.ShellFolder.ParseDisplayName(IntPtr.Zero, IntPtr.Zero, "::{450d8fba-ad25-11d0-98a8-0800361b1103}", ref pchEaten, out ppidl, ref pdwAttributes);
    		sfi = default(ShellAPI.SHFILEINFO);
    		ShellAPI.SHGetFileInfo(ppidl, (ShellAPI.FILE_ATTRIBUTE)0, ref sfi, ShellAPI.cbFileInfo, ShellAPI.SHGFI.DISPLAYNAME | ShellAPI.SHGFI.PIDL);
    		mydocsName = sfi.szDisplayName;
    		Marshal.FreeCoTaskMem(ppidl);
    		StringBuilder stringBuilder = new StringBuilder(260);
    		ShellAPI.SHGetFolderPath(IntPtr.Zero, ShellAPI.CSIDL.PERSONAL, IntPtr.Zero, ShellAPI.SHGFP.TYPE_CURRENT, stringBuilder);
    		mydocsPath = stringBuilder.ToString();
    		pchEaten = 0u;
    		pdwAttributes = (ShellAPI.SFGAO)0u;
    		desktopItem.ShellFolder.ParseDisplayName(IntPtr.Zero, IntPtr.Zero, "::{645FF040-5081-101B-9F08-00AA002F954E}", ref pchEaten, out ppidl, ref pdwAttributes);
    		sfi = default(ShellAPI.SHFILEINFO);
    		ShellAPI.SHGetFileInfo(ppidl, (ShellAPI.FILE_ATTRIBUTE)0, ref sfi, ShellAPI.cbFileInfo, ShellAPI.SHGFI.DISPLAYNAME | ShellAPI.SHGFI.PIDL);
    		recycleBinName = sfi.szDisplayName;
    		Marshal.FreeCoTaskMem(ppidl);
    	}

    	internal void OnShellItemUpdate(object sender, ShellItemUpdateEventArgs e)
    	{
    		if (this.ShellItemUpdate != null)
    		{
    			this.ShellItemUpdate(sender, e);
    		}
    	}

    	internal ShellItem GetShellItem(PIDL pidlFull)
    	{
    		ShellItem shellItem = DesktopItem;
    		if (pidlFull.Ptr == IntPtr.Zero)
    		{
    			return shellItem;
    		}
    		foreach (IntPtr item in pidlFull)
    		{
    			int index;
    			if ((index = shellItem.IndexOf(item)) > -1)
    			{
    				shellItem = shellItem[index];
    				continue;
    			}
    			shellItem = null;
    			break;
    		}
    		return shellItem;
    	}

    	internal ShellItem[] GetPath(ShellItem item)
    	{
    		ArrayList arrayList = new ArrayList();
    		ShellItem shellItem = item;
    		while (shellItem.ParentItem != null)
    		{
    			arrayList.Add(shellItem);
    			shellItem = shellItem.ParentItem;
    		}
    		arrayList.Add(shellItem);
    		arrayList.Reverse();
    		return (ShellItem[])arrayList.ToArray(typeof(ShellItem));
    	}

    	internal ShellItem GetSpecialFolderShellItem(ShellAPI.CSIDL rootFolder)
    	{
    		return new ShellItem(this, rootFolder);
    	}
    }
}
