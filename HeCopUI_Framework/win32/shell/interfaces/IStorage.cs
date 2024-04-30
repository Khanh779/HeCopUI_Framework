using System;
using System.Runtime.InteropServices;

namespace HeCopUI_Framework.Win32
{
    [ComImport]
    [Guid("0000000b-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IStorage
    {
    	[PreserveSig]
    	int CreateStream([MarshalAs(UnmanagedType.LPWStr)] string pwcsName, ShellAPI.STGM grfMode, int reserved1, int reserved2, out IntPtr ppstm);

    	[PreserveSig]
    	int OpenStream([MarshalAs(UnmanagedType.LPWStr)] string pwcsName, IntPtr reserved1, ShellAPI.STGM grfMode, int reserved2, out IntPtr ppstm);

    	[PreserveSig]
    	int CreateStorage([MarshalAs(UnmanagedType.LPWStr)] string pwcsName, ShellAPI.STGM grfMode, int reserved1, int reserved2, out IntPtr ppstg);

    	[PreserveSig]
    	int OpenStorage([MarshalAs(UnmanagedType.LPWStr)] string pwcsName, IStorage pstgPriority, ShellAPI.STGM grfMode, IntPtr snbExclude, int reserved, out IntPtr ppstg);

    	[PreserveSig]
    	int CopyTo(int ciidExclude, ref Guid rgiidExclude, IntPtr snbExclude, IStorage pstgDest);

    	[PreserveSig]
    	int MoveElementTo([MarshalAs(UnmanagedType.LPWStr)] string pwcsName, IStorage pstgDest, [MarshalAs(UnmanagedType.LPWStr)] string pwcsNewName, ShellAPI.STGMOVE grfFlags);

    	[PreserveSig]
    	int Commit(ShellAPI.STGC grfCommitFlags);

    	[PreserveSig]
    	int Revert();

    	[PreserveSig]
    	int EnumElements(int reserved1, IntPtr reserved2, int reserved3, out IntPtr ppenum);

    	[PreserveSig]
    	int DestroyElement([MarshalAs(UnmanagedType.LPWStr)] string pwcsName);

    	[PreserveSig]
    	int RenameElement([MarshalAs(UnmanagedType.LPWStr)] string pwcsOldName, [MarshalAs(UnmanagedType.LPWStr)] string pwcsNewName);

    	[PreserveSig]
    	int SetElementTimes([MarshalAs(UnmanagedType.LPWStr)] string pwcsName, ShellAPI.FILETIME pctime, ShellAPI.FILETIME patime, ShellAPI.FILETIME pmtime);

    	[PreserveSig]
    	int SetClass(ref Guid clsid);

    	[PreserveSig]
    	int SetStateBits(int grfStateBits, int grfMask);

    	[PreserveSig]
    	int Stat(out ShellAPI.STATSTG pstatstg, ShellAPI.STATFLAG grfStatFlag);
    }
}
