using System;

namespace Exceptions
{
    // Dummy type to enable Example 6 to compile
    class CloudTable
    {
        internal void Execute(TableOperation tableOperation)
        {
            throw new NotImplementedException();
        }
    }
}
