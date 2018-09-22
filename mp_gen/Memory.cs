using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace MemoryEdit
{
    class Memory
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle,
        uint dwProcessId);
        [DllImport("kernel32.dll")]
        static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress,
        byte[] lpBuffer, UIntPtr nSize, uint lpNumberOfBytesWritten);
        [DllImport("kernel32.dll")]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress,
        byte[] lpBuffer, UIntPtr nSize, uint lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        static extern bool VirtualProtectEx(IntPtr hProcess, IntPtr lpAddress,
        uint dwSize, uint flNewProtect, out uint lpflOldProtect);

        public enum Protection : uint
        {
            PAGE_NOACCESS = 0x01,
            PAGE_READONLY = 0x02,
            PAGE_READWRITE = 0x04,
            PAGE_WRITECOPY = 0x08,
            PAGE_EXECUTE = 0x10,
            PAGE_EXECUTE_READ = 0x20,
            PAGE_EXECUTE_READWRITE = 0x40,
            PAGE_EXECUTE_WRITECOPY = 0x80,
            PAGE_GUARD = 0x100,
            PAGE_NOCACHE = 0x200,
            PAGE_WRITECOMBINE = 0x400
        }

        [DllImport("kernel32.dll")]
        static extern IntPtr CreateRemoteThread(IntPtr hProcess,
           IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress,
           IntPtr lpParameter, uint dwCreationFlags, out uint lpThreadId);
        [DllImport("kernel32.dll")]
        static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress,
           uint dwSize, uint flAllocationType, uint flProtect);

        /*public enum AllocationType : uint
        {
            Commit = 0x1000,
            Reserve = 0x2000,
            Decommit = 0x4000,
            Release = 0x8000,
            Reset = 0x80000,
            Physical = 0x400000,
            TopDown = 0x100000,
            WriteWatch = 0x200000,
            LargePages = 0x20000000
        }*/

        [DllImport("kernel32.dll")]
        static extern bool CloseHandle(IntPtr hObject);

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        //Create handle
        IntPtr Handle;
        uint Pid;

        public bool IsFocused()
        {
            uint id;
            GetWindowThreadProcessId(GetForegroundWindow(), out id);
            return Pid == id;
        }

        public bool Attach(Process sprocess, uint access)
        {
            //access to the process
            //0x10 - read
            //0x20 - write
            //0x001F0FFF - all
            Pid = (uint)sprocess.Id;
            Handle = OpenProcess(access, false, Pid);
            return true;
        }

        public void Detach()
        {
            if (Handle != IntPtr.Zero)
                CloseHandle(Handle);
        }

        //Memory reading

        //Byte array
        public byte[] ReadBytes(uint pointer, int blen)
        {
            byte[] bytes = new byte[blen];

            //Reading the specific address within the process
            ReadProcessMemory(Handle, (IntPtr)pointer, bytes, (UIntPtr)blen, 0);
            return bytes;
        }

        //Int32
        public uint Read(uint pointer)
        {
            byte[] bytes = new byte[4];

            //Reading the specific address within the process
            ReadProcessMemory(Handle, (IntPtr)pointer, bytes, (UIntPtr)4, 0);
            //Return the result as 4 byte int
            return BitConverter.ToUInt32(bytes, 0);
        }

        //Memory writing

        public void WriteByte(uint pointer, byte[] Buffer, int blen)
        {
            WriteProcessMemory(Handle, (IntPtr)pointer, Buffer, (UIntPtr)blen, 0);
        }
    }
}