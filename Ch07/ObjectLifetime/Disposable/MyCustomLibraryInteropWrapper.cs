using System;

namespace Disposable
{
    // Exists only to enable Example 17 to compile
    internal static class MyCustomLibraryInteropWrapper
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "This is only a fake example")]
        internal static void Close(IntPtr myCustomLibraryHandle)
        {
            throw new NotImplementedException();
        }
    }
}
