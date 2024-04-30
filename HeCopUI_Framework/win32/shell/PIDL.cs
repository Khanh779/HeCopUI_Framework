using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text;

namespace HeCopUI_Framework.Win32
{
    internal class PIDL : IEnumerable
    {
    	public class PIDLEnumerator : IEnumerator
    	{
    		private IntPtr pidl;

    		private IntPtr currentPidl;

    		private IntPtr clonePidl;

    		private bool start;

    		public object Current
    		{
    			get
    			{
    				if (clonePidl != IntPtr.Zero)
    				{
    					Marshal.FreeCoTaskMem(clonePidl);
    					clonePidl = IntPtr.Zero;
    				}
    				clonePidl = ILCloneFirst(currentPidl);
    				return clonePidl;
    			}
    		}

    		public PIDLEnumerator(IntPtr pidl)
    		{
    			start = true;
    			this.pidl = pidl;
    			currentPidl = pidl;
    			clonePidl = IntPtr.Zero;
    		}

    		public bool MoveNext()
    		{
    			if (clonePidl != IntPtr.Zero)
    			{
    				Marshal.FreeCoTaskMem(clonePidl);
    				clonePidl = IntPtr.Zero;
    			}
    			if (start)
    			{
    				start = false;
    				return true;
    			}
    			IntPtr intPtr = ILGetNext(currentPidl);
    			if (!IsEmpty(intPtr))
    			{
    				currentPidl = intPtr;
    				return true;
    			}
    			return false;
    		}

    		public void Reset()
    		{
    			start = true;
    			currentPidl = pidl;
    			if (clonePidl != IntPtr.Zero)
    			{
    				Marshal.FreeCoTaskMem(clonePidl);
    				clonePidl = IntPtr.Zero;
    			}
    		}
    	}

    	private IntPtr pidl = IntPtr.Zero;

    	public IntPtr Ptr => pidl;

    	public PIDL(IntPtr pidl, bool clone)
    	{
    		if (clone)
    		{
    			this.pidl = ILClone(pidl);
    		}
    		else
    		{
    			this.pidl = pidl;
    		}
    	}

    	public PIDL(PIDL pidl, bool clone)
    	{
    		if (clone)
    		{
    			this.pidl = ILClone(pidl.Ptr);
    		}
    		else
    		{
    			this.pidl = pidl.Ptr;
    		}
    	}

    	public void Append(IntPtr appendPidl)
    	{
    		IntPtr intPtr = ILCombine(pidl, appendPidl);
    		Marshal.FreeCoTaskMem(pidl);
    		pidl = intPtr;
    	}

    	public void Insert(IntPtr insertPidl)
    	{
    		IntPtr intPtr = ILCombine(insertPidl, pidl);
    		Marshal.FreeCoTaskMem(pidl);
    		pidl = intPtr;
    	}

    	public static bool IsEmpty(IntPtr pidl)
    	{
    		if (pidl == IntPtr.Zero)
    		{
    			return true;
    		}
    		byte[] array = new byte[2];
    		Marshal.Copy(pidl, array, 0, 2);
    		int num = array[0] + array[1] * 256;
    		return num <= 2;
    	}

    	public static bool SplitPidl(IntPtr pidl, out IntPtr parent, out IntPtr child)
    	{
    		parent = ILClone(pidl);
    		child = ILClone(ILFindLastID(pidl));
    		if (!ILRemoveLastID(parent))
    		{
    			Marshal.FreeCoTaskMem(parent);
    			Marshal.FreeCoTaskMem(child);
    			return false;
    		}
    		return true;
    	}

    	public static void Write(IntPtr pidl)
    	{
    		StringBuilder stringBuilder = new StringBuilder(256);
    		ShellAPI.SHGetPathFromIDList(pidl, stringBuilder);
    		Console.Out.WriteLine("Pidl: {0}", stringBuilder);
    	}

    	public static void WriteBytes(IntPtr pidl)
    	{
    		int num = Marshal.ReadByte(pidl, 0) + Marshal.ReadByte(pidl, 1) * 256 - 2;
    		for (int i = 0; i < num; i++)
    		{
    			Console.Out.WriteLine(Marshal.ReadByte(pidl, i + 2));
    		}
    		Console.Out.WriteLine(Marshal.ReadByte(pidl, num + 2));
    		Console.Out.WriteLine(Marshal.ReadByte(pidl, num + 3));
    	}

    	public void Free()
    	{
    		if (pidl != IntPtr.Zero)
    		{
    			Marshal.FreeCoTaskMem(pidl);
    			pidl = IntPtr.Zero;
    		}
    	}

    	private static int ItemIDSize(IntPtr pidl)
    	{
    		if (!pidl.Equals(IntPtr.Zero))
    		{
    			byte[] array = new byte[2];
    			Marshal.Copy(pidl, array, 0, 2);
    			return array[1] * 256 + array[0];
    		}
    		return 0;
    	}

    	private static int ItemIDListSize(IntPtr pidl)
    	{
    		if (pidl.Equals(IntPtr.Zero))
    		{
    			return 0;
    		}
    		int num = ItemIDSize(pidl);
    		for (int num2 = Marshal.ReadByte(pidl, num) + Marshal.ReadByte(pidl, num + 1) * 256; num2 > 0; num2 = Marshal.ReadByte(pidl, num) + Marshal.ReadByte(pidl, num + 1) * 256)
    		{
    			num += num2;
    		}
    		return num;
    	}

    	public static IntPtr ILClone(IntPtr pidl)
    	{
    		int num = ItemIDListSize(pidl);
    		byte[] array = new byte[num + 2];
    		Marshal.Copy(pidl, array, 0, num);
    		IntPtr intPtr = Marshal.AllocCoTaskMem(num + 2);
    		Marshal.Copy(array, 0, intPtr, num + 2);
    		return intPtr;
    	}

    	public static IntPtr ILCloneFirst(IntPtr pidl)
    	{
    		int num = ItemIDSize(pidl);
    		byte[] array = new byte[num + 2];
    		Marshal.Copy(pidl, array, 0, num);
    		IntPtr intPtr = Marshal.AllocCoTaskMem(num + 2);
    		Marshal.Copy(array, 0, intPtr, num + 2);
    		return intPtr;
    	}

    	public static IntPtr ILGetNext(IntPtr pidl)
    	{
    		int num = ItemIDSize(pidl);
    		return new IntPtr((int)pidl + num);
    	}

    	public static IntPtr ILFindLastID(IntPtr pidl)
    	{
    		IntPtr result = pidl;
    		IntPtr intPtr = ILGetNext(result);
    		while (ItemIDSize(intPtr) > 0)
    		{
    			result = intPtr;
    			intPtr = ILGetNext(result);
    		}
    		return result;
    	}

    	public static bool ILRemoveLastID(IntPtr pidl)
    	{
    		IntPtr intPtr = ILFindLastID(pidl);
    		if (intPtr != pidl)
    		{
    			int num = (int)intPtr - (int)pidl + 2;
    			Marshal.ReAllocCoTaskMem(pidl, num);
    			Marshal.Copy(new byte[2], 0, new IntPtr((int)pidl + num - 2), 2);
    			return true;
    		}
    		return false;
    	}

    	public static IntPtr ILCombine(IntPtr pidl1, IntPtr pidl2)
    	{
    		int num = ItemIDListSize(pidl1);
    		int num2 = ItemIDListSize(pidl2);
    		IntPtr intPtr = Marshal.AllocCoTaskMem(num + num2 + 2);
    		byte[] array = new byte[num + num2 + 2];
    		Marshal.Copy(pidl1, array, 0, num);
    		Marshal.Copy(pidl2, array, num, num2);
    		Marshal.Copy(array, 0, intPtr, array.Length);
    		return intPtr;
    	}

    	public IEnumerator GetEnumerator()
    	{
    		return new PIDLEnumerator(pidl);
    	}

    	public override bool Equals(object obj)
    	{
    		try
    		{
    			if (obj is IntPtr)
    			{
    				return ShellAPI.ILIsEqual(Ptr, (IntPtr)obj);
    			}
    			if (obj is PIDL)
    			{
    				return ShellAPI.ILIsEqual(Ptr, ((PIDL)obj).Ptr);
    			}
    			return false;
    		}
    		catch (Exception)
    		{
    			return false;
    		}
    	}

    	public override int GetHashCode()
    	{
    		return pidl.GetHashCode();
    	}
    }
}
