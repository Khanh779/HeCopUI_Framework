using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HeCopUI_Framework.Win32
{
    internal static class ShellHelper
    {
    	public static uint HiWord(IntPtr ptr)
    	{
    		if (((int)ptr & int.MinValue) == int.MinValue)
    		{
    			return (uint)(int)ptr >> 16;
    		}
    		return ((uint)(int)ptr >> 16) & 0xFFFFu;
    	}

    	public static uint LoWord(IntPtr ptr)
    	{
    		return (uint)(int)ptr & 0xFFFFu;
    	}

    	public static bool GetIStream(ShellItem item, out IntPtr streamPtr, out IStream stream)
    	{
    		if (item.ParentItem.ShellFolder.BindToStorage(item.PIDLRel.Ptr, IntPtr.Zero, ref ShellAPI.IID_IStream, out streamPtr) == 0)
    		{
    			stream = (IStream)Marshal.GetTypedObjectForIUnknown(streamPtr, typeof(IStream));
    			return true;
    		}
    		stream = null;
    		streamPtr = IntPtr.Zero;
    		return false;
    	}

    	public static bool GetIStorage(ShellItem item, out IntPtr storagePtr, out IStorage storage)
    	{
    		if (item.ParentItem.ShellFolder.BindToStorage(item.PIDLRel.Ptr, IntPtr.Zero, ref ShellAPI.IID_IStorage, out storagePtr) == 0)
    		{
    			storage = (IStorage)Marshal.GetTypedObjectForIUnknown(storagePtr, typeof(IStorage));
    			return true;
    		}
    		storage = null;
    		storagePtr = IntPtr.Zero;
    		return false;
    	}

    	public static IntPtr GetIDataObject(ShellItem[] items)
    	{
    		ShellItem shellItem = ((items[0].ParentItem != null) ? items[0].ParentItem : items[0]);
    		IntPtr[] array = new IntPtr[items.Length];
    		for (int i = 0; i < items.Length; i++)
    		{
    			array[i] = items[i].PIDLRel.Ptr;
    		}
    		if (shellItem.ShellFolder.GetUIObjectOf(IntPtr.Zero, (uint)array.Length, array, ref ShellAPI.IID_IDataObject, IntPtr.Zero, out var ppv) == 0)
    		{
    			return ppv;
    		}
    		return IntPtr.Zero;
    	}

    	public static bool GetIDropTarget(ShellItem item, out IntPtr dropTargetPtr, out IDropTarget dropTarget)
    	{
    		ShellItem shellItem = ((item.ParentItem != null) ? item.ParentItem : item);
    		if (shellItem.ShellFolder.GetUIObjectOf(IntPtr.Zero, 1u, new IntPtr[1] { item.PIDLRel.Ptr }, ref ShellAPI.IID_IDropTarget, IntPtr.Zero, out dropTargetPtr) == 0)
    		{
    			dropTarget = (IDropTarget)Marshal.GetTypedObjectForIUnknown(dropTargetPtr, typeof(IDropTarget));
    			return true;
    		}
    		dropTarget = null;
    		dropTargetPtr = IntPtr.Zero;
    		return false;
    	}

    	public static bool GetIDropTargetHelper(out IntPtr helperPtr, out IDropTargetHelper dropHelper)
    	{
    		if (ShellAPI.CoCreateInstance(ref ShellAPI.CLSID_DragDropHelper, IntPtr.Zero, ShellAPI.CLSCTX.INPROC_SERVER, ref ShellAPI.IID_IDropTargetHelper, out helperPtr) == 0)
    		{
    			dropHelper = (IDropTargetHelper)Marshal.GetTypedObjectForIUnknown(helperPtr, typeof(IDropTargetHelper));
    			return true;
    		}
    		dropHelper = null;
    		helperPtr = IntPtr.Zero;
    		return false;
    	}

    	public static DragDropEffects CanDropClipboard(ShellItem item)
    	{
    		ShellAPI.OleGetClipboard(out var ppDataObj);
    		DragDropEffects dragDropEffects = DragDropEffects.None;
    		if (GetIDropTarget(item, out var dropTargetPtr, out var dropTarget))
    		{
    			DragDropEffects pdwEffect = DragDropEffects.Copy;
    			if (dropTarget.DragEnter(ppDataObj, ShellAPI.MK.CONTROL, new ShellAPI.POINT(0, 0), ref pdwEffect) == 0)
    			{
    				if (pdwEffect == DragDropEffects.Copy)
    				{
    					dragDropEffects |= DragDropEffects.Copy;
    				}
    				dropTarget.DragLeave();
    			}
    			pdwEffect = DragDropEffects.Move;
    			if (dropTarget.DragEnter(ppDataObj, ShellAPI.MK.SHIFT, new ShellAPI.POINT(0, 0), ref pdwEffect) == 0)
    			{
    				if (pdwEffect == DragDropEffects.Move)
    				{
    					dragDropEffects |= DragDropEffects.Move;
    				}
    				dropTarget.DragLeave();
    			}
    			pdwEffect = DragDropEffects.Link;
    			if (dropTarget.DragEnter(ppDataObj, ShellAPI.MK.ALT, new ShellAPI.POINT(0, 0), ref pdwEffect) == 0)
    			{
    				if (pdwEffect == DragDropEffects.Link)
    				{
    					dragDropEffects |= DragDropEffects.Link;
    				}
    				dropTarget.DragLeave();
    			}
    			Marshal.ReleaseComObject(dropTarget);
    			Marshal.Release(dropTargetPtr);
    		}
    		return dragDropEffects;
    	}

    	public static bool GetIQueryInfo(ShellItem item, out IntPtr iQueryInfoPtr, out IQueryInfo iQueryInfo)
    	{
    		ShellItem shellItem = ((item.ParentItem != null) ? item.ParentItem : item);
    		if (shellItem.ShellFolder.GetUIObjectOf(IntPtr.Zero, 1u, new IntPtr[1] { item.PIDLRel.Ptr }, ref ShellAPI.IID_IQueryInfo, IntPtr.Zero, out iQueryInfoPtr) == 0)
    		{
    			iQueryInfo = (IQueryInfo)Marshal.GetTypedObjectForIUnknown(iQueryInfoPtr, typeof(IQueryInfo));
    			return true;
    		}
    		iQueryInfo = null;
    		iQueryInfoPtr = IntPtr.Zero;
    		return false;
    	}
    }
}
