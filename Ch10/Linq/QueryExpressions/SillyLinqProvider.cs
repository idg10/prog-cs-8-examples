using System;

namespace QueryExpressions
{
    public class SillyLinqProvider
    {
        public SillyLinqProvider Where(Func<string, int> pred)
        {
            Console.WriteLine("Where invoked");
            return this;
        }

        public string Select<T>(Func<DateTime, T> map)
        {
            Console.WriteLine($"Select invoked, with type argument {typeof(T)}");
            return "This operator makes no sense";
        }
    }
}