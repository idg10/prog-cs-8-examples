using System;
using System.Collections.Generic;
using System.IO;

namespace Disposable
{
    public static class ForeachDisposal
    {
        public static void SimpleForeach()
        {
            foreach (string file in Directory.EnumerateFiles(@"C:\temp"))
            {
                Console.WriteLine(file);
            }
        }

        public static void HowForeachExpands()
        {
            IEnumerator<string> e =
                Directory.EnumerateFiles(@"C:\temp").GetEnumerator();
            try
            {
                while (e.MoveNext())
                {
                    string file = e.Current;
                    Console.WriteLine(file);
                }
            }
            finally
            {
                if (e != null)
                {
                    ((IDisposable)e).Dispose();
                }
            }
        }
    }
}
