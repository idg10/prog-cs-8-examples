using System;

namespace ZeroLike
{
    class Program
    {
        static void Main()
        {
            ShowDefault<bool>();
            Console.WriteLine(GetDefault<bool>());
        }

        static void ShowDefault<T>()
        {
            Console.WriteLine(default(T));
        }

        static T GetDefault<T>() => default;
    }
}
