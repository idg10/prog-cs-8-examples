using System;
using System.Diagnostics.CodeAnalysis;

namespace Generics
{
    class Program
    {
        static void Main()
        {
        }
    }

    public class GenericBase1<T>
    {
        public T Item { get; set; }
    }

    public class GenericBase2<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
    }

    public class NonGenericDerived : GenericBase1<string>
    {
    }

    public class GenericDerived<T> : GenericBase1<T>
    {
    }

    public class MixedDerived<T> : GenericBase2<string, T>
    {
    }

    public class SelfAsTypeArgument : IComparable<SelfAsTypeArgument>
    {
        public int CompareTo([AllowNull] SelfAsTypeArgument other) => throw new NotImplementedException();
    }

    public class Curious<T>
        where T : Curious<T>
    {
    }

    // This is for illustration - these types are defined by .NET so we don't need to provide
    // our own definition
#if false
    public interface IEnumerable<out T> : IEnumerable

    public interface IComparer<in T>
#endif
}
