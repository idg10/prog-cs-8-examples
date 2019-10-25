using System;
using System.Collections.Generic;

namespace GenericTypes
{
    class Program
    {
        static void Main()
        {
            var a = new NamedContainer<int>(42, "The answer");
            var b = new NamedContainer<int>(99, "Number of red balloons");
            var c = new NamedContainer<string>("Programming C#", "Book title");

            // ...where a, and b come from #using_a_generic_class.
            var namedInts = new List<NamedContainer<int>>() { a, b };
            var namedNamedItem = new NamedContainer<NamedContainer<int>>(a, "Wrapped");

            Show(a);
            Show(b);
            Show(c);

            Show(namedInts);
            Show(namedNamedItem);
        }

        public static void Show<T>(NamedContainer<T> c)
        {
            Console.WriteLine($"{c.Name}: {c.Item}");
        }

        public static void Show<T>(IEnumerable<NamedContainer<T>> cs)
        {
            foreach (NamedContainer<T> c in cs)
            {
                Show(c);
            }
        }
    }
}
