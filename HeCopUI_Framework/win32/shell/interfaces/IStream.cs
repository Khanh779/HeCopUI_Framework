using System;
using System.IO;
using System.Runtime.InteropServices;

namespace HeCopUI_Framework.Win32
{
    [ComImport]
    [Guid("0000000c-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IStream
    {
    	[PreserveSig]
    	int Read([MarshalAs(UnmanagedType.LPArray)] byte[] pv, int cb, IntPtr pcbRead);

    	[PreserveSig]
    	int Write([MarshalAs(UnmanagedType.LPArray)] byte[] pv, int cb, IntPtr pcbWritten);

    	[PreserveSig]
    	int Seek(long dlibMove, SeekOrigin dwOrigin, IntPtr plibNewPosition);

    	[PreserveSig]
    	int SetSize(long libNewSize);

    	[PreserveSig]
    	int CopyTo(IStream pstm, long cb, IntPtr pcbRead, IntPtr pcbWritten);

    	[PreserveSig]
    	int Commit(ShellAPI.STGC grfCommitFlags);

    	[PreserveSig]
    	int Revert();

    	[PreserveSig]
    	int LockRegion(long libOffset, long cb, ShellAPI.LOCKTYPE dwLockType);

    	[PreserveSig]
    	int UnlockRegion(long libOffset, long cb, ShellAPI.LOCKTYPE dwLockType);

    	[PreserveSig]
    	int Stat(out ShellAPI.STATSTG pstatstg, ShellAPI.STATFLAG grfStatFlag);

    	[PreserveSig]
    	int Clone(out IntPtr ppstm);
    }
}
