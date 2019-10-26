using System;

namespace Virtuals
{
    public abstract class MustBeComparable : IComparable<string>
    {
        public abstract int CompareTo(string other);
    }
}
