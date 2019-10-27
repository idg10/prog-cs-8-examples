using System;
using System.IO;

namespace Disposable
{
    public class MyFunkyStream : Stream
    {
        // For illustration purposes only. Usually better to avoid this whole
        // pattern and to use some type derived from SafeHandle instead.
        private IntPtr _myCustomLibraryHandle;
        private Logger _log;

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (_myCustomLibraryHandle != IntPtr.Zero)
            {
                MyCustomLibraryInteropWrapper.Close(_myCustomLibraryHandle);
                _myCustomLibraryHandle = IntPtr.Zero;
            }
            if (disposing)
            {
                if (_log != null)
                {
                    _log.Dispose();
                    _log = null;
                }
            }
        }

        // ... overloads of Stream's abstract methods would go here

        public override bool CanRead => throw new NotImplementedException();
        public override bool CanSeek => throw new NotImplementedException();
        public override bool CanWrite => throw new NotImplementedException();
        public override long Length => throw new NotImplementedException();
        public override long Position
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
        public override void Flush() => throw new NotImplementedException();
        public override int Read(byte[] buffer, int offset, int count) => throw new NotImplementedException();
        public override long Seek(long offset, SeekOrigin origin) => throw new NotImplementedException();
        public override void SetLength(long value) => throw new NotImplementedException();
        public override void Write(byte[] buffer, int offset, int count) => throw new NotImplementedException();
    }
}
