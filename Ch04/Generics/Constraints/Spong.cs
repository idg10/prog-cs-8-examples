using System;
using System.Collections.Generic;

namespace Constraints
{
    public class Spong<T>
        where T : IEnumerable<T>, IDisposable, new()
    {
    }
}