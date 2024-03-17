using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text;

namespace HeCopUI_Framework.Win32
{
    public class ShellItem : IEnumerable, IDisposable, IComparable
    {
    	private ShellBrowser browser;

    	private ShellItem parentItem;

    	private IShellFolder shellFolder;

    	private IntPtr shellFolderPtr;

    	private ShellItemCollection subFiles;

    	private ShellItemCollection subFolders;

    	private PIDL pidlRel;

    	private short sortFlag;

    	private int imageIndex;

    	private int selectedImageIndex;

    	private bool isFolder;

    	private bool isLink;

    	private bool isShared;

    	private bool isFileSystem;

    	private bool isHidden;

    	private bool hasSubfolder;

    	private bool isBrowsable;

    	private bool isDisk;

    	private bool filesExpanded;

    	private bool foldersExpanded;

    	private bool canRename;

    	private bool updateShellFolder;

    	private bool canRead;

    	private string text;

    	private string path;

    	private string type;

    	private bool disposed = false;

    	public static Guid IID_IShellFolder = new Guid("{000214E6-0000-0000-C000-000000000046}");

    	internal ShellBrowser Browser => browser;

    	internal ShellItem ParentItem => parentItem;

    	internal ShellItemCollection SubFiles => subFiles;

    	internal ShellItemCollection SubFolders => subFolders;

    	internal IShellFolder ShellFolder
    	{
    		get
    		{
    			if (updateShellFolder)
    			{
    				Marshal.ReleaseComObject(shellFolder);
    				Marshal.Release(shellFolderPtr);
    				if (ParentItem.ShellFolder.BindToObject(pidlRel.Ptr, IntPtr.Zero, ref ShellAPI.IID_IShellFolder, out shellFolderPtr) == 0)
    				{
    					shellFolder = (IShellFolder)Marshal.GetTypedObjectForIUnknown(shellFolderPtr, typeof(IShellFolder));
    				}
    				updateShellFolder = false;
    			}
    			return shellFolder;
    		}
    	}

    	internal int ImageIndex
    	{
    		get
    		{
    			return imageIndex;
    		}
    		set
    		{
    			imageIndex = value;
    		}
    	}

    	internal int SelectedImageIndex
    	{
    		get
    		{
    			return selectedImageIndex;
    		}
    		set
    		{
    			selectedImageIndex = value;
    		}
    	}

    	internal PIDL PIDLRel => pidlRel;

    	internal PIDL PIDLFull
    	{
    		get
    		{
    			PIDL pIDL = new PIDL(pidlRel.Ptr, clone: true);
    			for (ShellItem shellItem = ParentItem; shellItem != null; shellItem = shellItem.ParentItem)
    			{
    				pIDL.Insert(shellItem.PIDLRel.Ptr);
    			}
    			return pIDL;
    		}
    	}

    	public string Text => text;

    	public string Path => path;

    	public string Type => type;

    	internal short SortFlag => sortFlag;

    	public bool FilesExpanded => filesExpanded;

    	public bool FoldersExpanded => foldersExpanded;

    	public bool IsSystemFolder => type == browser.SystemFolderName;

    	public bool IsHidden => isHidden;

    	public bool IsFolder => isFolder;

    	public bool IsLink => isLink;

    	public bool IsShared => isShared;

    	public bool IsFileSystem => isFileSystem;

    	public bool IsBrowsable => isBrowsable;

    	public bool HasSubfolder => hasSubfolder;

    	public bool IsDisk => isDisk;

    	public bool CanRename => canRename;

    	public bool CanRead => canRead;

    	internal bool UpdateShellFolder
    	{
    		get
    		{
    			return updateShellFolder;
    		}
    		set
    		{
    			updateShellFolder = value;
    		}
    	}

    	internal ShellItem this[int index]
    	{
    		get
    		{
    			if (index >= 0 && index < SubFolders.Count)
    			{
    				return SubFolders[index];
    			}
    			if (index >= 0 && index - SubFolders.Count < SubFiles.Count)
    			{
    				return SubFiles[index - SubFolders.Count];
    			}
    			throw new IndexOutOfRangeException();
    		}
    		set
    		{
    			if (index >= 0 && index < SubFolders.Count)
    			{
    				SubFolders[index] = value;
    				return;
    			}
    			if (index >= 0 && index - SubFolders.Count < SubFiles.Count)
    			{
    				SubFiles[index - SubFolders.Count] = value;
    				return;
    			}
    			throw new IndexOutOfRangeException();
    		}
    	}

    	internal ShellItem this[string name]
    	{
    		get
    		{
    			ShellItem shellItem = SubFolders[name];
    			if (shellItem != null)
    			{
    				return shellItem;
    			}
    			return SubFiles[name];
    		}
    		set
    		{
    			ShellItem shellItem = SubFolders[name];
    			if (shellItem != null)
    			{
    				SubFolders[name] = value;
    			}
    			else
    			{
    				SubFiles[name] = value;
    			}
    		}
    	}

    	internal ShellItem this[IntPtr pidl]
    	{
    		get
    		{
    			ShellItem shellItem = SubFolders[pidl];
    			if (shellItem != null)
    			{
    				return shellItem;
    			}
    			return SubFiles[pidl];
    		}
    		set
    		{
    			ShellItem shellItem = SubFolders[pidl];
    			if (shellItem != null)
    			{
    				SubFolders[pidl] = value;
    			}
    			else
    			{
    				SubFiles[pidl] = value;
    			}
    		}
    	}

    	internal int Count => SubFolders.Count + SubFiles.Count;

    	internal event EventHandler ShellItemUpdated;

    	public ShellItem(ShellBrowser browser, ShellAPI.CSIDL specialFolder)
    	{
    		IntPtr ppidl = IntPtr.Zero;
    		ShellAPI.SHGetSpecialFolderLocation(IntPtr.Zero, specialFolder, out ppidl);
    		this.browser = browser;
    		IntPtr ppshf;
    		if (specialFolder == ShellAPI.CSIDL.DESKTOP)
    		{
    			ShellAPI.SHGetDesktopFolder(out ppshf);
    			shellFolderPtr = ppshf;
    			shellFolder = (IShellFolder)Marshal.GetTypedObjectForIUnknown(ppshf, typeof(IShellFolder));
    		}
    		else
    		{
    			shellFolder = GetShellFolderFromPidl(ppidl, out ppshf);
    			parentItem = browser.DesktopItem;
    		}
    		subFiles = new ShellItemCollection(this);
    		subFolders = new ShellItemCollection(this);
    		pidlRel = new PIDL(ppidl, clone: false);
    		ShellAPI.SHFILEINFO sfi = default(ShellAPI.SHFILEINFO);
    		ShellAPI.SHGetFileInfo(pidlRel.Ptr, (ShellAPI.FILE_ATTRIBUTE)0, ref sfi, ShellAPI.cbFileInfo, ShellAPI.SHGFI.DISPLAYNAME | ShellAPI.SHGFI.PIDL | ShellAPI.SHGFI.SYSICONINDEX | ShellAPI.SHGFI.TYPENAME);
    		type = sfi.szTypeName;
    		text = sfi.szDisplayName;
    		StringBuilder stringBuilder = new StringBuilder(260);
    		ShellAPI.SHGetFolderPath(IntPtr.Zero, specialFolder, IntPtr.Zero, ShellAPI.SHGFP.TYPE_CURRENT, stringBuilder);
    		path = stringBuilder.ToString();
    		if (specialFolder == ShellAPI.CSIDL.DESKTOP)
    		{
    			ShellImageList.SetIconIndex(this, sfi.iIcon, SelectedIcon: false);
    			ShellImageList.SetIconIndex(this, sfi.iIcon, SelectedIcon: true);
    			SetAttributesDesktop(this);
    		}
    		else
    		{
    			SetAttributesFolder(this);
    			SetInfo(this);
    		}
    		sortFlag = 1;
    	}

    	internal ShellItem(ShellBrowser browser, ShellItem parentItem, IntPtr pidl, IntPtr shellFolderPtr)
    	{
    		this.browser = browser;
    		this.parentItem = parentItem;
    		this.shellFolderPtr = shellFolderPtr;
    		shellFolder = (IShellFolder)Marshal.GetTypedObjectForIUnknown(shellFolderPtr, typeof(IShellFolder));
    		subFiles = new ShellItemCollection(this);
    		subFolders = new ShellItemCollection(this);
    		pidlRel = new PIDL(pidl, clone: false);
    		SetText(this);
    		SetPath(this);
    		SetAttributesFolder(this);
    		SetInfo(this);
    		sortFlag = MakeSortFlag(this);
    	}

    	internal ShellItem(ShellBrowser browser, ShellItem parentItem, IntPtr pidl)
    	{
    		this.browser = browser;
    		this.parentItem = parentItem;
    		pidlRel = new PIDL(pidl, clone: false);
    		SetText(this);
    		SetPath(this);
    		SetAttributesFile(this);
    		SetInfo(this);
    		sortFlag = MakeSortFlag(this);
    	}

    	~ShellItem()
    	{
    		((IDisposable)this).Dispose();
    	}

    	private static void SetText(ShellItem item)
    	{
    		IntPtr intPtr = Marshal.AllocCoTaskMem(524);
    		Marshal.WriteInt32(intPtr, 0, 0);
    		StringBuilder stringBuilder = new StringBuilder(260);
    		if (item.ParentItem.ShellFolder.GetDisplayNameOf(item.PIDLRel.Ptr, ShellAPI.SHGNO.INFOLDER, intPtr) == 0)
    		{
    			ShellAPI.StrRetToBuf(intPtr, item.PIDLRel.Ptr, stringBuilder, 260);
    			item.text = stringBuilder.ToString();
    		}
    		Marshal.FreeCoTaskMem(intPtr);
    	}

    	private static void SetPath(ShellItem item)
    	{
    		IntPtr intPtr = Marshal.AllocCoTaskMem(524);
    		Marshal.WriteInt32(intPtr, 0, 0);
    		StringBuilder stringBuilder = new StringBuilder(260);
    		if (item.ParentItem.ShellFolder.GetDisplayNameOf(item.PIDLRel.Ptr, ShellAPI.SHGNO.FORADDRESSBAR | ShellAPI.SHGNO.FORPARSING, intPtr) == 0)
    		{
    			ShellAPI.StrRetToBuf(intPtr, item.PIDLRel.Ptr, stringBuilder, 260);
    			item.path = stringBuilder.ToString();
    		}
    		Marshal.FreeCoTaskMem(intPtr);
    	}

    	private static void SetInfo(ShellItem item)
    	{
    		PIDL pIDLFull = item.PIDLFull;
    		ShellAPI.SHFILEINFO sfi = default(ShellAPI.SHFILEINFO);
    		ShellAPI.SHGetFileInfo(pIDLFull.Ptr, (ShellAPI.FILE_ATTRIBUTE)0, ref sfi, ShellAPI.cbFileInfo, ShellAPI.SHGFI.PIDL | ShellAPI.SHGFI.SYSICONINDEX | ShellAPI.SHGFI.TYPENAME);
    		pIDLFull.Free();
    		ShellImageList.SetIconIndex(item, sfi.iIcon, SelectedIcon: false);
    		ShellImageList.SetIconIndex(item, sfi.iIcon, SelectedIcon: true);
    		item.type = sfi.szTypeName;
    	}

    	private static void SetAttributesDesktop(ShellItem item)
    	{
    		item.isFolder = true;
    		item.isLink = false;
    		item.isShared = false;
    		item.isFileSystem = true;
    		item.isHidden = false;
    		item.hasSubfolder = true;
    		item.isBrowsable = true;
    		item.canRename = false;
    		item.canRead = true;
    	}

    	private static void SetAttributesFolder(ShellItem item)
    	{
    		ShellAPI.SFGAO rgfInOut = ShellAPI.SFGAO.BROWSABLE | ShellAPI.SFGAO.CANRENAME | ShellAPI.SFGAO.CONTENTSMASK | ShellAPI.SFGAO.FILESYSTEM | ShellAPI.SFGAO.HIDDEN | ShellAPI.SFGAO.SHARE | ShellAPI.SFGAO.STORAGE;
    		item.ParentItem.ShellFolder.GetAttributesOf(1u, new IntPtr[1] { item.PIDLRel.Ptr }, ref rgfInOut);
    		item.isFolder = true;
    		item.isLink = false;
    		item.isShared = (rgfInOut & ShellAPI.SFGAO.SHARE) != 0;
    		item.isFileSystem = (rgfInOut & ShellAPI.SFGAO.FILESYSTEM) != 0;
    		item.isHidden = (rgfInOut & ShellAPI.SFGAO.HIDDEN) != 0;
    		item.hasSubfolder = ((uint)rgfInOut & 0x80000000u) != 0;
    		item.isBrowsable = (rgfInOut & ShellAPI.SFGAO.BROWSABLE) != 0;
    		item.canRename = (rgfInOut & ShellAPI.SFGAO.CANRENAME) != 0;
    		item.canRead = (rgfInOut & ShellAPI.SFGAO.STORAGE) != 0;
    		item.isDisk = item.path.Length == 3 && item.path.EndsWith(":\\");
    	}

    	private static void SetAttributesFile(ShellItem item)
    	{
    		ShellAPI.SFGAO rgfInOut = ShellAPI.SFGAO.CANMONIKER | ShellAPI.SFGAO.CANRENAME | ShellAPI.SFGAO.FILESYSTEM | ShellAPI.SFGAO.HIDDEN | ShellAPI.SFGAO.LINK | ShellAPI.SFGAO.SHARE;
    		item.ParentItem.ShellFolder.GetAttributesOf(1u, new IntPtr[1] { item.PIDLRel.Ptr }, ref rgfInOut);
    		item.isFolder = false;
    		item.isLink = (rgfInOut & ShellAPI.SFGAO.LINK) != 0;
    		item.isShared = (rgfInOut & ShellAPI.SFGAO.SHARE) != 0;
    		item.isFileSystem = (rgfInOut & ShellAPI.SFGAO.FILESYSTEM) != 0;
    		item.isHidden = (rgfInOut & ShellAPI.SFGAO.HIDDEN) != 0;
    		item.hasSubfolder = false;
    		item.isBrowsable = false;
    		item.canRename = (rgfInOut & ShellAPI.SFGAO.CANRENAME) != 0;
    		item.canRead = (rgfInOut & ShellAPI.SFGAO.CANMONIKER) != 0;
    		item.isDisk = false;
    	}

    	internal bool Expand(bool expandFiles, bool expandFolders, IntPtr winHandle)
    	{
    		if (((expandFiles && !filesExpanded) || !expandFiles) && ((expandFolders && !foldersExpanded) || !expandFolders) && (expandFiles || expandFolders) && ShellFolder != null && !disposed)
    		{
    			IntPtr enumIDList = IntPtr.Zero;
    			IntPtr enumIDList2 = IntPtr.Zero;
    			IEnumIDList enumIDList3 = null;
    			IEnumIDList enumIDList4 = null;
    			ShellAPI.SHCONTF grfFlags = ShellAPI.SHCONTF.NONFOLDERS | ShellAPI.SHCONTF.INCLUDEHIDDEN;
    			ShellAPI.SHCONTF grfFlags2 = ShellAPI.SHCONTF.FOLDERS | ShellAPI.SHCONTF.INCLUDEHIDDEN;
    			try
    			{
    				IntPtr rgelt;
    				int pceltFetched;
    				if (expandFiles)
    				{
    					if (Equals(browser.DesktopItem) || (parentItem != null && parentItem.Equals(browser.DesktopItem)))
    					{
    						if (ShellFolder.EnumObjects(winHandle, grfFlags, out enumIDList) == 0)
    						{
    							enumIDList3 = (IEnumIDList)Marshal.GetTypedObjectForIUnknown(enumIDList, typeof(IEnumIDList));
    							ShellAPI.SFGAO rgfInOut = ShellAPI.SFGAO.FOLDER;
    							while (enumIDList3.Next(1, out rgelt, out pceltFetched) == 0 && pceltFetched == 1)
    							{
    								ShellFolder.GetAttributesOf(1u, new IntPtr[1] { rgelt }, ref rgfInOut);
    								if ((rgfInOut & ShellAPI.SFGAO.FOLDER) == 0)
    								{
    									ShellItem shellItem = new ShellItem(browser, this, rgelt);
    									if (!subFolders.Contains(shellItem.Text))
    									{
    										subFiles.Add(shellItem);
    									}
    								}
    								else
    								{
    									Marshal.FreeCoTaskMem(rgelt);
    								}
    							}
    							subFiles.Sort();
    							filesExpanded = true;
    						}
    					}
    					else if (ShellFolder.EnumObjects(winHandle, grfFlags, out enumIDList) == 0)
    					{
    						enumIDList3 = (IEnumIDList)Marshal.GetTypedObjectForIUnknown(enumIDList, typeof(IEnumIDList));
    						while (enumIDList3.Next(1, out rgelt, out pceltFetched) == 0 && pceltFetched == 1)
    						{
    							ShellItem value = new ShellItem(browser, this, rgelt);
    							subFiles.Add(value);
    						}
    						subFiles.Sort();
    						filesExpanded = true;
    					}
    				}
    				if (expandFolders && ShellFolder.EnumObjects(winHandle, grfFlags2, out enumIDList2) == 0)
    				{
    					enumIDList4 = (IEnumIDList)Marshal.GetTypedObjectForIUnknown(enumIDList2, typeof(IEnumIDList));
    					while (enumIDList4.Next(1, out rgelt, out pceltFetched) == 0 && pceltFetched == 1)
    					{
    						if (ShellFolder.BindToObject(rgelt, IntPtr.Zero, ref ShellAPI.IID_IShellFolder, out var ppv) == 0)
    						{
    							ShellItem value2 = new ShellItem(browser, this, rgelt, ppv);
    							subFolders.Add(value2);
    						}
    					}
    					subFolders.Sort();
    					foldersExpanded = true;
    				}
    			}
    			catch (Exception)
    			{
    			}
    			finally
    			{
    				if (enumIDList4 != null)
    				{
    					Marshal.ReleaseComObject(enumIDList4);
    					Marshal.Release(enumIDList2);
    				}
    				if (enumIDList3 != null)
    				{
    					Marshal.ReleaseComObject(enumIDList3);
    					Marshal.Release(enumIDList);
    				}
    			}
    		}
    		return (expandFiles == filesExpanded || !expandFiles) && (expandFolders == foldersExpanded || !expandFolders);
    	}

    	internal void Clear(bool clearFiles, bool clearFolders)
    	{
    		if (((!clearFiles || !filesExpanded) && clearFiles) || ((!clearFolders || !foldersExpanded) && clearFolders) || !(clearFiles || clearFolders) || ShellFolder == null || disposed)
    		{
    			return;
    		}
    		lock (browser)
    		{
    			try
    			{
    				if (clearFiles)
    				{
    					foreach (IDisposable subFile in subFiles)
    					{
    						subFile.Dispose();
    					}
    					subFiles.Clear();
    					filesExpanded = false;
    				}
    				if (!clearFolders)
    				{
    					return;
    				}
    				foreach (IDisposable subFolder in subFolders)
    				{
    					subFolder.Dispose();
    				}
    				subFolders.Clear();
    				foldersExpanded = false;
    			}
    			catch (Exception)
    			{
    			}
    		}
    	}

    	internal void Update(bool updateFiles, bool updateFolders)
    	{
    		if (!browser.UpdateCondition.ContinueUpdate || !(updateFiles || updateFolders) || ShellFolder == null || disposed)
    		{
    			return;
    		}
    		lock (browser)
    		{
    			IntPtr enumIDList = IntPtr.Zero;
    			IntPtr enumIDList2 = IntPtr.Zero;
    			IEnumIDList enumIDList3 = null;
    			IEnumIDList enumIDList4 = null;
    			ShellAPI.SHCONTF grfFlags = ShellAPI.SHCONTF.NONFOLDERS | ShellAPI.SHCONTF.INCLUDEHIDDEN;
    			ShellAPI.SHCONTF grfFlags2 = ShellAPI.SHCONTF.FOLDERS | ShellAPI.SHCONTF.INCLUDEHIDDEN;
    			bool[] array = new bool[subFiles.Count];
    			bool[] array2 = new bool[subFolders.Count];
    			try
    			{
    				IntPtr rgelt;
    				int pceltFetched;
    				if (browser.UpdateCondition.ContinueUpdate && updateFiles)
    				{
    					ShellItemCollection shellItemCollection = new ShellItemCollection(this);
    					ShellItemCollection shellItemCollection2 = new ShellItemCollection(this);
    					bool flag = false;
    					if (Equals(browser.DesktopItem) || parentItem.Equals(browser.DesktopItem))
    					{
    						if (ShellFolder.EnumObjects(IntPtr.Zero, grfFlags, out enumIDList) == 0)
    						{
    							enumIDList3 = (IEnumIDList)Marshal.GetTypedObjectForIUnknown(enumIDList, typeof(IEnumIDList));
    							ShellAPI.SFGAO rgfInOut = ShellAPI.SFGAO.FOLDER;
    							while (browser.UpdateCondition.ContinueUpdate && enumIDList3.Next(1, out rgelt, out pceltFetched) == 0 && pceltFetched == 1)
    							{
    								ShellFolder.GetAttributesOf(1u, new IntPtr[1] { rgelt }, ref rgfInOut);
    								if ((rgfInOut & ShellAPI.SFGAO.FOLDER) == 0)
    								{
    									int num;
    									if ((num = subFiles.IndexOf(rgelt)) == -1)
    									{
    										ShellItem shellItem = new ShellItem(browser, this, rgelt);
    										if (!subFolders.Contains(shellItem.Text))
    										{
    											shellItemCollection.Add(shellItem);
    										}
    									}
    									else if (num < array.Length)
    									{
    										array[num] = true;
    										Marshal.FreeCoTaskMem(rgelt);
    									}
    								}
    								else
    								{
    									Marshal.FreeCoTaskMem(rgelt);
    								}
    							}
    							flag = true;
    						}
    					}
    					else if (ShellFolder.EnumObjects(IntPtr.Zero, grfFlags, out enumIDList) == 0)
    					{
    						enumIDList3 = (IEnumIDList)Marshal.GetTypedObjectForIUnknown(enumIDList, typeof(IEnumIDList));
    						while (browser.UpdateCondition.ContinueUpdate && enumIDList3.Next(1, out rgelt, out pceltFetched) == 0 && pceltFetched == 1)
    						{
    							int num;
    							if ((num = subFiles.IndexOf(rgelt)) == -1)
    							{
    								shellItemCollection.Add(new ShellItem(browser, this, rgelt));
    							}
    							else if (num < array.Length)
    							{
    								array[num] = true;
    								Marshal.FreeCoTaskMem(rgelt);
    							}
    						}
    						flag = true;
    					}
    					int num2 = 0;
    					while (flag && browser.UpdateCondition.ContinueUpdate && num2 < array.Length)
    					{
    						if (!array[num2] && subFiles[num2] != null)
    						{
    							shellItemCollection2.Add(subFiles[num2]);
    						}
    						num2++;
    					}
    					if (flag && browser.UpdateCondition.ContinueUpdate)
    					{
    						foreach (ShellItem item in shellItemCollection2)
    						{
    							int index;
    							if ((index = shellItemCollection.IndexOf(item.Text)) > -1)
    							{
    								ShellItem shellItem3 = shellItemCollection[index];
    								shellItemCollection.Remove(shellItem3);
    								item.pidlRel.Free();
    								item.pidlRel = new PIDL(shellItem3.pidlRel.Ptr, clone: true);
    								item.shellFolder = shellItem3.shellFolder;
    								item.shellFolderPtr = shellItem3.shellFolderPtr;
    								((IDisposable)shellItem3).Dispose();
    								browser.OnShellItemUpdate(this, new ShellItemUpdateEventArgs(item, item, ShellItemUpdateType.Updated));
    							}
    							else
    							{
    								subFiles.Remove(item);
    								browser.OnShellItemUpdate(this, new ShellItemUpdateEventArgs(item, null, ShellItemUpdateType.Deleted));
    								((IDisposable)item).Dispose();
    							}
    						}
    						foreach (ShellItem item2 in shellItemCollection)
    						{
    							subFiles.Add(item2);
    							browser.OnShellItemUpdate(this, new ShellItemUpdateEventArgs(null, item2, ShellItemUpdateType.Created));
    						}
    						subFiles.Capacity = subFiles.Count;
    						subFiles.Sort();
    						filesExpanded = true;
    					}
    				}
    				if (!(browser.UpdateCondition.ContinueUpdate && updateFolders))
    				{
    					return;
    				}
    				ShellItemCollection shellItemCollection3 = new ShellItemCollection(this);
    				ShellItemCollection shellItemCollection4 = new ShellItemCollection(this);
    				bool flag2 = false;
    				if (ShellFolder.EnumObjects(IntPtr.Zero, grfFlags2, out enumIDList2) == 0)
    				{
    					enumIDList4 = (IEnumIDList)Marshal.GetTypedObjectForIUnknown(enumIDList2, typeof(IEnumIDList));
    					while (browser.UpdateCondition.ContinueUpdate && enumIDList4.Next(1, out rgelt, out pceltFetched) == 0 && pceltFetched == 1)
    					{
    						int num;
    						if ((num = subFolders.IndexOf(rgelt)) == -1)
    						{
    							if (ShellFolder.BindToObject(rgelt, IntPtr.Zero, ref ShellAPI.IID_IShellFolder, out var ppv) == 0)
    							{
    								shellItemCollection3.Add(new ShellItem(browser, this, rgelt, ppv));
    							}
    						}
    						else if (num < array2.Length)
    						{
    							array2[num] = true;
    							Marshal.FreeCoTaskMem(rgelt);
    						}
    					}
    					flag2 = true;
    				}
    				int num3 = 0;
    				while (flag2 && browser.UpdateCondition.ContinueUpdate && num3 < array2.Length)
    				{
    					if (!array2[num3] && subFolders[num3] != null)
    					{
    						shellItemCollection4.Add(subFolders[num3]);
    					}
    					num3++;
    				}
    				if (!flag2 || !browser.UpdateCondition.ContinueUpdate)
    				{
    					return;
    				}
    				foreach (ShellItem item3 in shellItemCollection4)
    				{
    					int index2;
    					if ((index2 = shellItemCollection3.IndexOf(item3.Text)) > -1)
    					{
    						ShellItem shellItem6 = shellItemCollection3[index2];
    						shellItemCollection3.Remove(shellItem6);
    						item3.pidlRel.Free();
    						item3.pidlRel = new PIDL(shellItem6.pidlRel, clone: true);
    						Marshal.ReleaseComObject(item3.shellFolder);
    						Marshal.Release(item3.shellFolderPtr);
    						item3.shellFolder = shellItem6.shellFolder;
    						item3.shellFolderPtr = shellItem6.shellFolderPtr;
    						shellItem6.shellFolder = null;
    						shellItem6.shellFolderPtr = IntPtr.Zero;
    						((IDisposable)shellItem6).Dispose();
    						browser.OnShellItemUpdate(this, new ShellItemUpdateEventArgs(item3, item3, ShellItemUpdateType.Updated));
    					}
    					else
    					{
    						subFolders.Remove(item3);
    						browser.OnShellItemUpdate(this, new ShellItemUpdateEventArgs(item3, null, ShellItemUpdateType.Deleted));
    						((IDisposable)item3).Dispose();
    					}
    				}
    				foreach (ShellItem item4 in shellItemCollection3)
    				{
    					subFolders.Add(item4);
    					browser.OnShellItemUpdate(this, new ShellItemUpdateEventArgs(null, item4, ShellItemUpdateType.Created));
    				}
    				subFolders.Capacity = subFolders.Count;
    				subFolders.Sort();
    				foldersExpanded = true;
    			}
    			catch (Exception)
    			{
    			}
    			finally
    			{
    				if (enumIDList4 != null)
    				{
    					Marshal.ReleaseComObject(enumIDList4);
    					Marshal.Release(enumIDList2);
    				}
    				if (enumIDList3 != null)
    				{
    					Marshal.ReleaseComObject(enumIDList3);
    					if (!(type == browser.SystemFolderName) || string.Compare(text, "Control Panel", ignoreCase: true) != 0)
    					{
    						Marshal.Release(enumIDList);
    					}
    				}
    			}
    		}
    	}

    	internal void AddItem(ShellItem item)
    	{
    		browser.UpdateCondition.ContinueUpdate = false;
    		lock (browser)
    		{
    			try
    			{
    				if (item.IsFolder)
    				{
    					SubFolders.Add(item);
    				}
    				else
    				{
    					SubFiles.Add(item);
    				}
    				Browser.OnShellItemUpdate(this, new ShellItemUpdateEventArgs(null, item, ShellItemUpdateType.Created));
    			}
    			catch (Exception)
    			{
    			}
    		}
    	}

    	internal void Update(IntPtr newPidlFull, ShellItemUpdateType changeType)
    	{
    		browser.UpdateCondition.ContinueUpdate = false;
    		lock (browser)
    		{
    			if (newPidlFull != IntPtr.Zero)
    			{
    				IntPtr intPtr = PIDL.ILClone(PIDL.ILFindLastID(newPidlFull));
    				ShellAPI.SHGetRealIDL(ParentItem.ShellFolder, intPtr, out var ppidlReal);
    				if (IsFolder && ParentItem.ShellFolder.BindToObject(ppidlReal, IntPtr.Zero, ref ShellAPI.IID_IShellFolder, out var ppv) == 0)
    				{
    					Marshal.ReleaseComObject(shellFolder);
    					Marshal.Release(shellFolderPtr);
    					pidlRel.Free();
    					shellFolderPtr = ppv;
    					shellFolder = (IShellFolder)Marshal.GetTypedObjectForIUnknown(shellFolderPtr, typeof(IShellFolder));
    					pidlRel = new PIDL(ppidlReal, clone: false);
    					foreach (ShellItem subFolder in SubFolders)
    					{
    						UpdateShellFolders(subFolder);
    					}
    				}
    				else
    				{
    					pidlRel.Free();
    					pidlRel = new PIDL(ppidlReal, clone: false);
    				}
    				Marshal.FreeCoTaskMem(intPtr);
    				Marshal.FreeCoTaskMem(newPidlFull);
    			}
    			switch (changeType)
    			{
    			case ShellItemUpdateType.Renamed:
    				SetText(this);
    				SetPath(this);
    				break;
    			case ShellItemUpdateType.Updated:
    				if (IsFolder)
    				{
    					SetAttributesFolder(this);
    				}
    				else
    				{
    					SetAttributesFile(this);
    				}
    				break;
    			case ShellItemUpdateType.MediaChange:
    				SetInfo(this);
    				SetText(this);
    				Clear(clearFiles: true, clearFolders: true);
    				break;
    			case ShellItemUpdateType.IconChange:
    				SetInfo(this);
    				break;
    			case ShellItemUpdateType.Deleted:
    				break;
    			}
    		}
    		if (this.ShellItemUpdated != null)
    		{
    			this.ShellItemUpdated(this, EventArgs.Empty);
    		}
    		Browser.OnShellItemUpdate(ParentItem, new ShellItemUpdateEventArgs(this, this, changeType));
    	}

    	internal void RemoveItem(ShellItem item)
    	{
    		browser.UpdateCondition.ContinueUpdate = false;
    		lock (browser)
    		{
    			try
    			{
    				if (item.IsFolder)
    				{
    					SubFolders.Remove(item);
    				}
    				else
    				{
    					SubFiles.Remove(item);
    				}
    				Browser.OnShellItemUpdate(this, new ShellItemUpdateEventArgs(item, null, ShellItemUpdateType.Deleted));
    				((IDisposable)item).Dispose();
    			}
    			catch (Exception)
    			{
    			}
    		}
    	}

    	public static IShellFolder GetShellFolderFromPidl(IntPtr pidl, out IntPtr pidlRelative)
    	{
    		ShellAPI.SHBindToParent(pidl, ref IID_IShellFolder, out var ppv, out pidlRelative);
    		Type typeFromHandle = typeof(IShellFolder);
    		object typedObjectForIUnknown = Marshal.GetTypedObjectForIUnknown(ppv, typeFromHandle);
    		IShellFolder shellFolder = (IShellFolder)typedObjectForIUnknown;
    		if (ppv != IntPtr.Zero)
    		{
    			try
    			{
    				Marshal.Release(ppv);
    			}
    			catch (Exception)
    			{
    			}
    			finally
    			{
    				ppv = IntPtr.Zero;
    			}
    		}
    		shellFolder.BindToObject(pidlRelative, IntPtr.Zero, ref ShellAPI.IID_IShellFolder, out var ppv2);
    		typedObjectForIUnknown = Marshal.GetTypedObjectForIUnknown(ppv2, typeFromHandle);
    		return (IShellFolder)typedObjectForIUnknown;
    	}

    	public static string GetRealPath(ShellItem item)
    	{
    		if (item.Equals(item.browser.DesktopItem))
    		{
    			return "::{450d8fba-ad25-11d0-98a8-0800361b1103}";
    		}
    		if (item.Type == item.Browser.SystemFolderName)
    		{
    			IntPtr intPtr = Marshal.AllocCoTaskMem(524);
    			Marshal.WriteInt32(intPtr, 0, 0);
    			StringBuilder stringBuilder = new StringBuilder(260);
    			if (item.ParentItem.ShellFolder.GetDisplayNameOf(item.PIDLRel.Ptr, ShellAPI.SHGNO.FORPARSING, intPtr) == 0)
    			{
    				ShellAPI.StrRetToBuf(intPtr, item.PIDLRel.Ptr, stringBuilder, 260);
    			}
    			Marshal.FreeCoTaskMem(intPtr);
    			return stringBuilder.ToString();
    		}
    		return item.Path;
    	}

    	public static void UpdateShellFolders(ShellItem item)
    	{
    		item.UpdateShellFolder = true;
    		foreach (ShellItem subFolder in item.SubFolders)
    		{
    			UpdateShellFolders(subFolder);
    		}
    	}

    	public IEnumerator GetEnumerator()
    	{
    		return new ShellItemEnumerator(this);
    	}

    	void IDisposable.Dispose()
    	{
    		if (!disposed)
    		{
    			DisposeShellItem();
    			GC.SuppressFinalize(this);
    		}
    	}

    	private void DisposeShellItem()
    	{
    		disposed = true;
    		if (ShellFolder != null)
    		{
    			Marshal.ReleaseComObject(ShellFolder);
    			shellFolder = null;
    		}
    		if (shellFolderPtr != IntPtr.Zero)
    		{
    			try
    			{
    				Marshal.Release(shellFolderPtr);
    			}
    			catch (Exception)
    			{
    			}
    			finally
    			{
    				shellFolderPtr = IntPtr.Zero;
    			}
    		}
    		PIDLRel.Free();
    	}

    	private static short MakeSortFlag(ShellItem item)
    	{
    		if (item.IsFolder)
    		{
    			if (item.IsDisk)
    			{
    				return 1;
    			}
    			if (item.Text == item.browser.MyDocumentsName && item.Type == item.Browser.SystemFolderName)
    			{
    				return 2;
    			}
    			if (item.Text == item.browser.MyComputerName)
    			{
    				return 3;
    			}
    			if (item.Type == item.Browser.SystemFolderName)
    			{
    				if (!item.IsBrowsable)
    				{
    					return 4;
    				}
    				return 5;
    			}
    			if (item.IsFolder && !item.IsBrowsable)
    			{
    				return 6;
    			}
    			return 7;
    		}
    		return 8;
    	}

    	public int CompareTo(object obj)
    	{
    		ShellItem shellItem = (ShellItem)obj;
    		if (SortFlag != shellItem.SortFlag)
    		{
    			return (SortFlag > shellItem.SortFlag) ? 1 : (-1);
    		}
    		if (IsDisk)
    		{
    			return string.Compare(Path, shellItem.Path);
    		}
    		return string.Compare(Text, shellItem.Text);
    	}

    	internal bool Contains(ShellItem value)
    	{
    		return SubFolders.Contains(value) || SubFiles.Contains(value);
    	}

    	internal bool Contains(string name)
    	{
    		return SubFolders.Contains(name) || SubFiles.Contains(name);
    	}

    	internal bool Contains(IntPtr pidl)
    	{
    		return SubFolders.Contains(pidl) || SubFiles.Contains(pidl);
    	}

    	internal int IndexOf(ShellItem value)
    	{
    		int num = SubFolders.IndexOf(value);
    		if (num > -1)
    		{
    			return num;
    		}
    		num = SubFiles.IndexOf(value);
    		if (num > -1)
    		{
    			return SubFolders.Count + num;
    		}
    		return -1;
    	}

    	internal int IndexOf(string name)
    	{
    		int num = SubFolders.IndexOf(name);
    		if (num > -1)
    		{
    			return num;
    		}
    		num = SubFiles.IndexOf(name);
    		if (num > -1)
    		{
    			return SubFolders.Count + num;
    		}
    		return -1;
    	}

    	internal int IndexOf(IntPtr pidl)
    	{
    		int num = SubFolders.IndexOf(pidl);
    		if (num > -1)
    		{
    			return num;
    		}
    		num = SubFiles.IndexOf(pidl);
    		if (num > -1)
    		{
    			return SubFolders.Count + num;
    		}
    		return -1;
    	}

    	public override string ToString()
    	{
    		return text;
    	}
    }
}
