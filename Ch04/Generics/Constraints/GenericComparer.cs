namespace Constraints
{
    using System;
    using System.Collections.Generic;

    public class GenericComparer<T> : IComparer<T>
        where T : IComparable<T>
    {
        public int Compare(T x, T y)
        {
            return x.CompareTo(y);
        }
    }

    // The next two examples are versions of the class that will not compile,
    // because the book gives them as examples of things that won't work.
    // That is why they are inside the #if false block.
#if false
    public class GenericComparer<T> : IComparer<T>
    {
        public int Compare(IComparable<T> x, T y)
        {
            return x.CompareTo(y);
        }
    }

    public class GenericComparer<T> : IComparer<T>
    {
        public int Compare(T x, T y)
        {
            return x.CompareTo(y);
        }
    }
#endif
}