using System;

namespace RxSubjects
{
    class Program
    {
        static void Main()
        {
            var kw = new KeyWatcher();
            kw.Subscribe(Console.WriteLine);
            kw.Run();
        }
    }
}
