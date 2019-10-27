using System;
using System.Collections.Generic;
using System.Net;

namespace GarbageCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<string>();
            long total = 0;
            for (int i = 1; i < 100_000; ++i)
            {
                numbers.Add(i.ToString());
                total += i;
            }
            Console.WriteLine("Total: {0}, average: {1}",
                total, total / numbers.Count);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Code Quality",
            "IDE0067:Dispose objects before losing scope",
            Justification = "This example comes from a point in the book before we've introduced IDisposable")]
        public static string WriteUrl(string relativeUri)
        {
            var baseUri = new Uri("https://endjin.com/");
            var fullUri = new Uri(baseUri, relativeUri);
            var w = new WebClient();
            return w.DownloadString(fullUri);
        }
    }
}