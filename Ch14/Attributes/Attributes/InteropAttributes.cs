using System.Runtime.InteropServices;

namespace Attributes
{
    internal static class InteropAttributes
    {
        [DllImport("User32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsWindowVisible(HandleRef hWnd);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true,
                   EntryPoint = "LookupPrivilegeValueW")]
        internal static extern bool LookupPrivilegeValue(
            [MarshalAs(UnmanagedType.LPTStr)] string lpSystemName,
            [MarshalAs(UnmanagedType.LPTStr)] string lpName,
            out LUID lpLuid);

        [StructLayout(LayoutKind.Sequential)]
        public struct LUID
        {
            public uint LowPart;
            public int HighPart;
        }
    }
}