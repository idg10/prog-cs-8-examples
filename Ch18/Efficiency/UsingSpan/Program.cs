using System;

namespace UsingSpan
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(SumSpan(new int[] { 1, 2, 3 }));

            Span<int> numbers = stackalloc int[] { 1, 2, 3 };
            Console.WriteLine(SumSpan(numbers));

            string uriString = "http://example.com/books/1323?edition=6&format=pdf";
            int id = int.Parse(uriString.AsSpan(25, 4));
        }

        public static int SumSpan(ReadOnlySpan<int> span)
        {
            int sum = 0;
            for (int i = 0; i < span.Length; ++i)
            {
                sum += span[i];
            }
            return sum;
        }
    }
}