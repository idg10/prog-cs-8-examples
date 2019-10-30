using System;
using System.Collections.Generic;

namespace ListsAndSequences
{
    public class Program
    {
        static void Main()
        {
            var numbers = new List<int>();
            numbers.Add(123);
            numbers.Add(99);
            numbers.Add(42);
            Console.WriteLine(numbers.Count);
            Console.WriteLine($"{numbers[0]}, {numbers[1]}, {numbers[2]}");

            numbers[1] += 1;
            Console.WriteLine(numbers[1]);

            numbers.RemoveAt(1);
            Console.WriteLine(numbers.Count);
            Console.WriteLine($"{numbers[0]}, { numbers[1]}");

            IList<int> array = new[] { 1, 2, 3 };
            array.Add(4);  // Will throw an exception
        }

        public static void ListInitializer()
        {
            var numbers = new List<int> { 123, 99, 42 };
        }
    }

    // The book shows these interfaces for illustration purposes. They are defined
    // by the .NET Framework Class Library, so we do not need to write our own
    // definitions in practice.
#if false
    public interface IEnumerable<out T> : IEnumerable
    {
        IEnumerator<T> GetEnumerator();
    }

    public interface IEnumerable
    {
        IEnumerator GetEnumerator();
    }

    public interface IEnumerator<out T> : IDisposable, IEnumerator
    {
        T Current { get; }
    }

    public interface IEnumerator
    {
        bool MoveNext();
        object Current { get; }
        void Reset();
    }

    public interface IAsyncEnumerable<out T>
    {
        IAsyncEnumerator<T> GetAsyncEnumerator(
            CancellationToken cancellationToken = default);
    }

    public interface IAsyncEnumerator<out T> : IAsyncDisposable
    {
        T Current { get; }

        ValueTask<bool> MoveNextAsync();
    }

    public interface ICollection<T> : IEnumerable<T>, IEnumerable
    {
        void Add(T item);
        void Clear();
        bool Contains(T item);
        void CopyTo(T[] array, int arrayIndex);
        bool Remove(T item);

        int Count { get; }
        bool IsReadOnly { get; }
    }

    public interface IList<T> : ICollection<T>, IEnumerable<T>, IEnumerable
    {
        int IndexOf(T item);
        void Insert(int index, T item);
        void RemoveAt(int index);

        T this[int index] { get; set; }
    }
#endif
}