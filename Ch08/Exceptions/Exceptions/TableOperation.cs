using System;

namespace Exceptions
{
    // Dummy type to enable Example 6 to compile
    class TableOperation
    {
        internal static TableOperation Insert(MyEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
