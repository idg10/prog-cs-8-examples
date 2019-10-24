using System;

namespace ReferenceTypes
{
    class Program
    {
        static void Main()
        {
            CopyingReferences();

            Console.WriteLine();
            Console.WriteLine();

            ComparingReferences();

            Console.WriteLine();
            Console.WriteLine();

            ComparingValues();
        }

        internal static void CopyingReferences()
        {
            var c1 = new Counter();
            Counter c2 = c1;
            Console.WriteLine("c1: " + c1.GetNextValue());
            Console.WriteLine("c1: " + c1.GetNextValue());
            Console.WriteLine("c1: " + c1.GetNextValue());

            Console.WriteLine("c2: " + c2.GetNextValue());

            Console.WriteLine("c1: " + c1.GetNextValue());
        }

        internal static void ComparingReferences()
        {
            var c1 = new Counter();
            c1.GetNextValue();
            Counter c2 = c1;
            var c3 = new Counter();
            c3.GetNextValue();

            Console.WriteLine(c1.Count);
            Console.WriteLine(c2.Count);
            Console.WriteLine(c3.Count);
            Console.WriteLine(c1 == c2);
            Console.WriteLine(c1 == c3);
            Console.WriteLine(c2 == c3);
            Console.WriteLine(object.ReferenceEquals(c1, c2));
            Console.WriteLine(object.ReferenceEquals(c1, c3));
            Console.WriteLine(object.ReferenceEquals(c2, c3));
        }

        internal static void ComparingValues()
        {
            int c1 = new int();
            c1++;
            int c2 = c1;
            int c3 = new int();
            c3++;

            Console.WriteLine(c1);
            Console.WriteLine(c2);
            Console.WriteLine(c3);
            Console.WriteLine(c1 == c2);
            Console.WriteLine(c1 == c3);
            Console.WriteLine(c2 == c3);
            Console.WriteLine(object.ReferenceEquals(c1, c2));
            Console.WriteLine(object.ReferenceEquals(c1, c3));
            Console.WriteLine(object.ReferenceEquals(c2, c3));
            Console.WriteLine(object.ReferenceEquals(c1, c1));
        }
    }
}