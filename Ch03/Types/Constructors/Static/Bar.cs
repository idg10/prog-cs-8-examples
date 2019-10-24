using System;

namespace Constructors.Static
{
    public class Bar
    {
        private static DateTime _firstUsed;
        static Bar()
        {
            Console.WriteLine("Bar's static constructor");
            _firstUsed = DateTime.Now;
        }
    }
}