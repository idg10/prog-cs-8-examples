using System;

namespace AnonymousTypes
{
    class Program
    {
        static void Main()
        {
            var x = new { Title = "Lord", Surname = "Voldemort" };

            Console.WriteLine($"Welcome, {x.Title} {x.Surname}");
        }
    }
}
