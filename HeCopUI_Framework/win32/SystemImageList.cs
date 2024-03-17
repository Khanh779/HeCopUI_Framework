#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;

namespace HeCopUI_Framework.Win32
{

    public class SystemImageList : IDisposable
    {
        [Flags]
        public enum ImageListDrawItemConstants
        {
            ILD_NORMAL = 0, ILD_TRANSPARENT = 1, ILD_BLEND25 = 2, ILD_SELECTED = 4, ILD_MASK = 0x10, ILD_IMAGE = 0x20, ILD_ROP = 0x40, ILD_PRESERVEALPHA = 0x1000, ILD_SCALE = 0x2000, ILD_DPISCALE = 0x4000
        }

        [Flags]
        public enum ImageListDrawStateConstants
        {
            ILS_NORMAL = 0,
            ILS_GLOW = 1,
            ILS_SHADOW = 2,
            ILS_SATURATE = 4,
            ILS_ALPHA = 8
        }

        [Flags]
    	private enum SHGetFileInfoConstants
    	{
    		SHGFI_ICON = 0x100,
    		SHGFI_DISPLAYNAME = 0x200,
    		SHGFI_TYPENAME = 0x400,
    		SHGFI_ATTRIBUTES = 0x800,
    		SHGFI_ICONLOCATION = 0x1000,
    		SHGFI_EXETYPE = 0x2000,
    		SHGFI_SYSICONINDEX = 0x4000,
    		SHGFI_LINKOVERLAY = 0x8000,
    		SHGFI_SELECTED = 0x10000,
    		SHGFI_ATTR_SPECIFIED = 0x20000,
    		SHGFI_LARGEICON = 0,
    		SHGFI_SMALLICON = 1,
    		SHGFI_OPENICON = 2,
    		SHGFI_SHELLICONSIZE = 4,
    		SHGFI_USEFILEATTRIBUTES = 0x10,
    		SHGFI_ADDOVERLAYS = 0x20,
    		SHGFI_OVERLAYINDEX = 0x40
    	}


        private struct RECT
    	{
            #pragma warning disable
            private int left;

    		private int top;

    		private int right;

    		private int bottom;
    	}

    	private struct POINT
    	{
    		private int x;

    		private int y;
    	}

    	private struct IMAGELISTDRAWPARAMS
    	{
    		public int cbSize;

    		public IntPtr himl;

    		public int i;

    		public IntPtr hdcDst;

    		public int x;

    		public int y;

    		public int cx;

    		public int cy;

    		public int xBitmap;

    		public int yBitmap;

    		public int rgbBk;

    		public int rgbFg;

    		public int fStyle;

    		public int dwRop;

    		public int fState;

    		public int Frame;

    		public int crEffect;
    	}

    	private struct IMAGEINFO
    	{
    		public IntPtr hbmImage;

    		public IntPtr hbmMask;

    		public int Unused1;

    		public int Unused2;

    		public RECT rcImage;
    	}

    	private struct SHFILEINFO
    	{
    		public IntPtr hIcon;

    		public int iIcon;

    		public int dwAttributes;

    		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
    		public string szDisplayName;

    		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
    		public string szTypeName;
    	}

    	[ComImport]
    	[Guid("46EB5926-582E-4017-9FDF-E8998DAA0950")]
    	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    	private interface IImageList
    	{
    		[PreserveSig]
    		int Add(IntPtr hbmImage, IntPtr hbmMask, ref int pi);

    		[PreserveSig]
    		int ReplaceIcon(int i, IntPtr hicon, ref int pi);

    		[PreserveSig]
    		int SetOverlayImage(int iImage, int iOverlay);

    		[PreserveSig]
    		int Replace(int i, IntPtr hbmImage, IntPtr hbmMask);

    		[PreserveSig]
    		int AddMasked(IntPtr hbmImage, int crMask, ref int pi);

    		[PreserveSig]
    		int Draw(ref IMAGELISTDRAWPARAMS pimldp);

    		[PreserveSig]
    		int Remove(int i);

    		[PreserveSig]
    		int GetIcon(int i, int flags, ref IntPtr picon);

    		[PreserveSig]
    		int GetImageInfo(int i, ref IMAGEINFO pImageInfo);

    		[PreserveSig]
    		int Copy(int iDst, IImageList punkSrc, int iSrc, int uFlags);

    		[PreserveSig]
    		int Merge(int i1, IImageList punk2, int i2, int dx, int dy, ref Guid riid, ref IntPtr ppv);

    		[PreserveSig]
    		int Clone(ref Guid riid, ref IntPtr ppv);

    		[PreserveSig]
    		int GetImageRect(int i, ref RECT prc);

    		[PreserveSig]
    		int GetIconSize(ref int cx, ref int cy);

    		[PreserveSig]
    		int SetIconSize(int cx, int cy);

    		[PreserveSig]
    		int GetImageCount(ref int pi);

    		[PreserveSig]
    		int SetImageCount(int uNewCount);

    		[PreserveSig]
    		int SetBkColor(int clrBk, ref int pclr);

    		[PreserveSig]
    		int GetBkColor(ref int pclr);

    		[PreserveSig]
    		int BeginDrag(int iTrack, int dxHotspot, int dyHotspot);

    		[PreserveSig]
    		int EndDrag();

    		[PreserveSig]
    		int DragEnter(IntPtr hwndLock, int x, int y);

    		[PreserveSig]
    		int DragLeave(IntPtr hwndLock);

    		[PreserveSig]
    		int DragMove(int x, int y);

    		[PreserveSig]
    		int SetDragCursorImage(ref IImageList punk, int iDrag, int dxHotspot, int dyHotspot);

    		[PreserveSig]
    		int DragShowNolock(int fShow);

    		[PreserveSig]
    		int GetDragImage(ref POINT ppt, ref POINT pptHotspot, ref Guid riid, ref IntPtr ppv);

    		[PreserveSig]
    		int GetItemFlags(int i, ref int dwFlags);

    		[PreserveSig]
    		int GetOverlayImage(int iOverlay, ref int piIndex);
    	}

    	private const int MAX_PATH = 260;

    	private const int FILE_ATTRIBUTE_NORMAL = 128;

    	private const int FILE_ATTRIBUTE_DIRECTORY = 16;

    	private const int FORMAT_MESSAGE_ALLOCATE_BUFFER = 256;

    	private const int FORMAT_MESSAGE_ARGUMENT_ARRAY = 8192;

    	private const int FORMAT_MESSAGE_FROM_HMODULE = 2048;

    	private const int FORMAT_MESSAGE_FROM_STRING = 1024;

    	private const int FORMAT_MESSAGE_FROM_SYSTEM = 4096;

    	private const int FORMAT_MESSAGE_IGNORE_INSERTS = 512;

    	private const int FORMAT_MESSAGE_MAX_WIDTH_MASK = 255;

    	private IntPtr hIml = IntPtr.Zero;

    	private IImageList iImageList = null;

    	private SystemImageListSize size = SystemImageListSize.SmallIcons;

    	private bool disposed = false;

    	public IntPtr Handle => hIml;

    	public SystemImageListSize ImageListSize
    	{
    		get
    		{
    			return size;
    		}
    		set
    		{
    			size = value;
    			create();
    		}
    	}

    	public Size Size
    	{
    		get
    		{
    			int cx = 0;
    			int cy = 0;
    			if (iImageList == null)
    			{
    				ImageList_GetIconSize(hIml, ref cx, ref cy);
    			}
    			else
    			{
    				iImageList.GetIconSize(ref cx, ref cy);
    			}
    			return new Size(cx, cy);
    		}
    	}

    	public SystemImageList()
    	{
    		create();
    	}

    	public SystemImageList(SystemImageListSize size)
    	{
    		this.size = size;
    		create();
    	}

    	public void Dispose()
    	{
    		Dispose(disposing: true);
    		GC.SuppressFinalize(this);
    	}

    	public virtual void Dispose(bool disposing)
    	{
    		if (!disposed && disposing)
    		{
    			if (iImageList != null)
    			{
    				Marshal.ReleaseComObject(iImageList);
    			}
    			iImageList = null;
    		}
    		disposed = true;
    	}

    	~SystemImageList()
    	{
    		Dispose(disposing: false);
    	}

    	[DllImport("shell32")]
    	private static extern IntPtr SHGetFileInfo(string pszPath, int dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, uint uFlags);

    	[DllImport("shell32")]
    	private static extern IntPtr SHGetFileInfo(IntPtr pid, int dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, uint uFlags);

    	[DllImport("Msg.dll")]
    	private static extern int DestroyIcon(IntPtr hIcon);

    	[DllImport("kernel32")]
    	private static extern int FormatMessage(int dwFlags, IntPtr lpSource, int dwMessageId, int dwLanguageId, string lpBuffer, uint nSize, int argumentsLong);

    	[DllImport("kernel32")]
    	private static extern int GetLastError();

    	[DllImport("comctl32")]
    	private static extern int ImageList_Draw(IntPtr hIml, int i, IntPtr hdcDst, int x, int y, int fStyle);

    	[DllImport("comctl32")]
    	private static extern int ImageList_DrawIndirect(ref IMAGELISTDRAWPARAMS pimldp);

    	[DllImport("comctl32")]
    	private static extern int ImageList_GetIconSize(IntPtr himl, ref int cx, ref int cy);

    	[DllImport("comctl32")]
    	private static extern IntPtr ImageList_GetIcon(IntPtr himl, int i, int flags);

    	[DllImport("shell32.dll", EntryPoint = "#727")]
    	private static extern int SHGetImageList(int iImageList, ref Guid riid, ref IImageList ppv);

    	[DllImport("shell32.dll", EntryPoint = "#727")]
    	private static extern int SHGetImageListHandle(int iImageList, ref Guid riid, ref IntPtr handle);

    	private bool isXpOrAbove()
    	{
    		bool result = false;
    		if (Environment.OSVersion.Version.Major > 5)
    		{
    			result = true;
    		}
    		else if (Environment.OSVersion.Version.Major == 5 && Environment.OSVersion.Version.Minor >= 1)
    		{
    			result = true;
    		}
    		return result;
    	}

    	private void create()
    	{
    		hIml = IntPtr.Zero;
    		if (isXpOrAbove())
    		{
    			Guid riid = new Guid("46EB5926-582E-4017-9FDF-E8998DAA0950");
    			int num = SHGetImageList((int)size, ref riid, ref iImageList);
    			SHGetImageListHandle((int)size, ref riid, ref hIml);
    			return;
    		}
    		SHGetFileInfoConstants sHGetFileInfoConstants = SHGetFileInfoConstants.SHGFI_SYSICONINDEX | SHGetFileInfoConstants.SHGFI_USEFILEATTRIBUTES;
    		if (size == SystemImageListSize.SmallIcons)
    		{
    			sHGetFileInfoConstants |= SHGetFileInfoConstants.SHGFI_SMALLICON;
    		}
    		SHFILEINFO psfi = default(SHFILEINFO);
    		uint cbFileInfo = (uint)Marshal.SizeOf(psfi.GetType());
    		hIml = SHGetFileInfo(".txt", 128, ref psfi, cbFileInfo, (uint)sHGetFileInfoConstants);
    		Debug.Assert(hIml != IntPtr.Zero, "Failed to create Image List");
    	}

    	public Icon Icon(int index)
    	{
    		Icon result = null;
    		IntPtr picon = IntPtr.Zero;
    		if (iImageList == null)
    		{
    			picon = ImageList_GetIcon(hIml, index, 1);
    		}
    		else
    		{
    			iImageList.GetIcon(index, 1, ref picon);
    		}
    		if (picon != IntPtr.Zero)
    		{
    			result = System.Drawing.Icon.FromHandle(picon);
    		}
    		return result;
    	}

    	public int IconIndex(string fileName)
    	{
    		return IconIndex(fileName, forceLoadFromDisk: false);
    	}

    	public int IconIndex(string fileName, bool forceLoadFromDisk)
    	{
    		return IconIndex(fileName, forceLoadFromDisk, ShellIconStateConstants.ShellIconStateNormal);
    	}

    	public int IconIndex(string fileName, bool forceLoadFromDisk, ShellIconStateConstants iconState)
    	{
    		SHGetFileInfoConstants sHGetFileInfoConstants = SHGetFileInfoConstants.SHGFI_SYSICONINDEX;
    		int num = 0;
    		if (size == SystemImageListSize.SmallIcons)
    		{
    			sHGetFileInfoConstants |= SHGetFileInfoConstants.SHGFI_SMALLICON;
    		}
    		if (!forceLoadFromDisk)
    		{
    			sHGetFileInfoConstants |= SHGetFileInfoConstants.SHGFI_USEFILEATTRIBUTES;
    			num = 128;
    		}
    		else
    		{
    			num = 0;
    		}
    		SHFILEINFO psfi = default(SHFILEINFO);
    		uint cbFileInfo = (uint)Marshal.SizeOf(psfi.GetType());
    		if (SHGetFileInfo(fileName, num, ref psfi, cbFileInfo, (uint)sHGetFileInfoConstants | (uint)iconState).Equals(IntPtr.Zero))
    		{
    			return 0;
    		}
    		return psfi.iIcon;
    	}

    	public void DrawImage(IntPtr hdc, int index, int x, int y)
    	{
    		DrawImage(hdc, index, x, y, ImageListDrawItemConstants.ILD_TRANSPARENT);
    	}

    	public void DrawImage(IntPtr hdc, int index, int x, int y, ImageListDrawItemConstants flags)
    	{
    		if (iImageList == null)
    		{
    			int num = ImageList_Draw(hIml, index, hdc, x, y, (int)flags);
    			return;
    		}
    		IMAGELISTDRAWPARAMS pimldp = default(IMAGELISTDRAWPARAMS);
    		pimldp.hdcDst = hdc;
    		pimldp.cbSize = Marshal.SizeOf(pimldp.GetType());
    		pimldp.i = index;
    		pimldp.x = x;
    		pimldp.y = y;
    		pimldp.rgbFg = -1;
    		pimldp.fStyle = (int)flags;
    		iImageList.Draw(ref pimldp);
    	}

    	public void DrawImage(IntPtr hdc, int index, int x, int y, ImageListDrawItemConstants flags, int cx, int cy)
    	{
    		IMAGELISTDRAWPARAMS pimldp = default(IMAGELISTDRAWPARAMS);
    		pimldp.hdcDst = hdc;
    		pimldp.cbSize = Marshal.SizeOf(pimldp.GetType());
    		pimldp.i = index;
    		pimldp.x = x;
    		pimldp.y = y;
    		pimldp.cx = cx;
    		pimldp.cy = cy;
    		pimldp.fStyle = (int)flags;
    		if (iImageList == null)
    		{
    			pimldp.himl = hIml;
    			int num = ImageList_DrawIndirect(ref pimldp);
    		}
    		else
    		{
    			iImageList.Draw(ref pimldp);
    		}
    	}

       

        public void DrawImage(IntPtr hdc, int index, int x, int y, ImageListDrawItemConstants flags, int cx, int cy, Color foreColor, ImageListDrawStateConstants stateFlags, Color saturateColorOrAlpha, Color glowOrShadowColor)
    	{
    		IMAGELISTDRAWPARAMS pimldp = default(IMAGELISTDRAWPARAMS);
    		pimldp.hdcDst = hdc;
    		pimldp.cbSize = Marshal.SizeOf(pimldp.GetType());
    		pimldp.i = index;
    		pimldp.x = x;
    		pimldp.y = y;
    		pimldp.cx = cx;
    		pimldp.cy = cy;
    		pimldp.rgbFg = Color.FromArgb(0, foreColor.R, foreColor.G, foreColor.B).ToArgb();
    		Console.WriteLine("{0}", pimldp.rgbFg);
    		pimldp.fStyle = (int)flags;
    		pimldp.fState = (int)stateFlags;
    		if ((stateFlags & ImageListDrawStateConstants.ILS_ALPHA) == ImageListDrawStateConstants.ILS_ALPHA)
    		{
    			pimldp.Frame = saturateColorOrAlpha.A;
    		}
    		else if ((stateFlags & ImageListDrawStateConstants.ILS_SATURATE) == ImageListDrawStateConstants.ILS_SATURATE)
    		{
    			saturateColorOrAlpha = Color.FromArgb(0, saturateColorOrAlpha.R, saturateColorOrAlpha.G, saturateColorOrAlpha.B);
    			pimldp.Frame = saturateColorOrAlpha.ToArgb();
    		}
    		glowOrShadowColor = Color.FromArgb(0, glowOrShadowColor.R, glowOrShadowColor.G, glowOrShadowColor.B);
    		pimldp.crEffect = glowOrShadowColor.ToArgb();
    		if (iImageList == null)
    		{
    			pimldp.himl = hIml;
    			int num = ImageList_DrawIndirect(ref pimldp);
    		}
    		else
    		{
    			iImageList.Draw(ref pimldp);
    		}
    	}
    }
}
