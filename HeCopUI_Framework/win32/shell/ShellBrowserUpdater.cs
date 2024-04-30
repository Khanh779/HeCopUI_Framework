using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HeCopUI_Framework.Win32
{
    internal class ShellBrowserUpdater : NativeWindow
    {
    	private ShellBrowser br;

    	private uint notifyId = 0u;

    	public ShellBrowserUpdater(ShellBrowser br)
    	{
    		this.br = br;
    		CreateHandle(new CreateParams());
    		ShellAPI.SHChangeNotifyEntry sHChangeNotifyEntry = new ShellAPI.SHChangeNotifyEntry
    		{
    			pIdl = br.DesktopItem.PIDLRel.Ptr,
    			Recursively = true
    		};
    		notifyId = ShellAPI.SHChangeNotifyRegister(base.Handle, ShellAPI.SHCNRF.InterruptLevel | ShellAPI.SHCNRF.ShellLevel, ShellAPI.SHCNE.ALLEVENTS | ShellAPI.SHCNE.INTERRUPT, ShellAPI.WM.SH_NOTIFY, 1, new ShellAPI.SHChangeNotifyEntry[1] { sHChangeNotifyEntry });
    	}

    	~ShellBrowserUpdater()
    	{
    		if (notifyId != 0)
    		{
    			ShellAPI.SHChangeNotifyDeregister(notifyId);
    			GC.SuppressFinalize(this);
    		}
    	}

    	protected override void WndProc(ref Message m)
    	{
    		if (m.Msg == 1025)
    		{
    			ShellAPI.SHNOTIFYSTRUCT sHNOTIFYSTRUCT = (ShellAPI.SHNOTIFYSTRUCT)Marshal.PtrToStructure(m.WParam, typeof(ShellAPI.SHNOTIFYSTRUCT));
    			switch ((ShellAPI.SHCNE)(int)m.LParam)
    			{
    			case ShellAPI.SHCNE.MKDIR:
    			case ShellAPI.SHCNE.DRIVEADD:
    			case ShellAPI.SHCNE.DRIVEADDGUI:
    			{
    				if (PIDL.IsEmpty(sHNOTIFYSTRUCT.dwItem1))
    				{
    					break;
    				}
    				PIDL.SplitPidl(sHNOTIFYSTRUCT.dwItem1, out var parent, out var child);
    				PIDL pidlFull = new PIDL(parent, clone: false);
    				ShellItem shellItem2 = br.GetShellItem(pidlFull);
    				if (shellItem2 != null && shellItem2.FoldersExpanded && !shellItem2.SubFolders.Contains(child))
    				{
    					ShellAPI.SHGetRealIDL(shellItem2.ShellFolder, child, out var ppidlReal);
    					if (shellItem2.ShellFolder.BindToObject(ppidlReal, IntPtr.Zero, ref ShellAPI.IID_IShellFolder, out var ppv) == 0)
    					{
    						shellItem2.AddItem(new ShellItem(br, shellItem2, ppidlReal, ppv));
    					}
    					else
    					{
    						Marshal.FreeCoTaskMem(ppidlReal);
    					}
    				}
    				Marshal.FreeCoTaskMem(child);
    				break;
    			}
    			case ShellAPI.SHCNE.ATTRIBUTES:
    			case ShellAPI.SHCNE.UPDATEDIR:
    				if (!PIDL.IsEmpty(sHNOTIFYSTRUCT.dwItem1))
    				{
    					ShellItem shellItem = br.GetShellItem(new PIDL(sHNOTIFYSTRUCT.dwItem1, clone: true));
    					if (shellItem != null)
    					{
    						shellItem.Update(IntPtr.Zero, ShellItemUpdateType.Updated);
    						shellItem.Update(IntPtr.Zero, ShellItemUpdateType.IconChange);
    					}
    				}
    				break;
    			case ShellAPI.SHCNE.MEDIAINSERTED:
    			case ShellAPI.SHCNE.MEDIAREMOVED:
    				if (!PIDL.IsEmpty(sHNOTIFYSTRUCT.dwItem1))
    				{
    					br.GetShellItem(new PIDL(sHNOTIFYSTRUCT.dwItem1, clone: true))?.Update(IntPtr.Zero, ShellItemUpdateType.MediaChange);
    				}
    				break;
    			case ShellAPI.SHCNE.UPDATEIMAGE:
    				UpdateRecycleBin();
    				break;
    			}
    		}
    		base.WndProc(ref m);
    	}

    	private void UpdateRecycleBin()
    	{
    		br.DesktopItem[br.RecycleBinName]?.Update(IntPtr.Zero, ShellItemUpdateType.IconChange);
    	}
    }
}
