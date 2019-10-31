using System;
using System.IO;

namespace Streams
{
    class Program
    {
        static void Main()
        {
        }

        static int ReadAll(Stream s, byte[] buffer, int offset, int length)
        {
            if ((offset + length) > buffer.Length)
            {
                throw new ArgumentException("Buffer too small to hold requested data");
            }

            int bytesReadSoFar = 0;
            while (bytesReadSoFar < length)
            {
                int bytes = s.Read(
                    buffer, offset + bytesReadSoFar, length - bytesReadSoFar);
                if (bytes == 0)
                {
                    break;
                }
                bytesReadSoFar += bytes;
            }

            return bytesReadSoFar;
        }
    }

    // Members of Stream for illustration purposes only. These are defined by .NET so
    // we don't need to define them ourselves.
#if false
    public abstract int Read(byte[] buffer, int offset, int count);
    public abstract void Write(byte[] buffer, int offset, int count);
    public abstract long Position { get; set; }

    public abstract long Seek(long offset, SeekOrigin origin);
#endif
}