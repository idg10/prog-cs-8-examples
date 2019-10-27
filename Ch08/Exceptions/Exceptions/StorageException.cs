using System;

namespace Exceptions
{
    // Dummy type to enable Example 6 to compile
    class StorageException : Exception
    {
        public Info RequestInformation { get; set; }

        public class Info
        {
            public int HttpStatusCode { get; set; }
        }
    }
}
