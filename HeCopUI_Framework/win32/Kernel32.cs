using System;
using System.Runtime.InteropServices;
using System.Text;

namespace HeCopUI_Framework.Win32
{
    public class Kernel32
    {
        [DllImport("KERNEL32.DLL", EntryPoint = "RtlZeroMemory")]
        public static extern bool ZeroMemory(IntPtr Destination, int Length);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool FindClose(SafeHandle hFindFile);

        [DllImport("kernel32.dll")]
        public static extern void RtlMoveMemory(int des, int src, int count);

        [DllImport("kernel32.dll")]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
#pragma warning disable CS3001 // Argument type is not CLS-compliant
        public static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, uint dwProcessId);
#pragma warning restore CS3001 // Argument type is not CLS-compliant
#pragma warning restore CS3001 // Argument type is not CLS-compliant

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        public static extern int GetProcAddress(int hwnd, string procedureName);

        [DllImport("kernel32.dll")]
        public static extern int GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll")]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
#pragma warning disable CS3001 // Argument type is not CLS-compliant
#pragma warning disable CS3001 // Argument type is not CLS-compliant
        public static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);
#pragma warning restore CS3001 // Argument type is not CLS-compliant
#pragma warning restore CS3001 // Argument type is not CLS-compliant
#pragma warning restore CS3001 // Argument type is not CLS-compliant

        [DllImport("kernel32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll")]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
        public static extern void Sleep(uint dwMilliseconds);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

        [DllImport("kernel32")]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
#pragma warning disable CS3001 // Argument type is not CLS-compliant
#pragma warning disable CS3001 // Argument type is not CLS-compliant
        public static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, uint lpThreadId);
#pragma warning restore CS3001 // Argument type is not CLS-compliant
#pragma warning restore CS3001 // Argument type is not CLS-compliant
#pragma warning restore CS3001 // Argument type is not CLS-compliant

        [DllImport("kernel32.dll")]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
        public static extern IntPtr WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] buffer, uint size, IntPtr lpNumberOfBytesWritten);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
        public static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        public static extern long WritePrivateProfileString(string section, string key, string val, string filepath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        public static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filepath);

     

    }
}
