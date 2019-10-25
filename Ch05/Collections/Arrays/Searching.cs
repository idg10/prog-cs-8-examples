using System;
using System.Diagnostics;

namespace Arrays
{
    public class Searching
    {
        public static void SearchWithIndexOf(string[] myRecentFiles, string openedFile)
        {
            int recentFileListIndex = Array.IndexOf(myRecentFiles, openedFile);
            if (recentFileListIndex < 0)
            {
                AddNewRecentEntry(openedFile);
            }
            else
            {
                MoveExistingRecentEntryToTop(recentFileListIndex);
            }
        }

        public static int GetIndexOfFirstNonEmptyBin(int[] bins)
            => Array.FindIndex(bins, IsNonZero);

        private static bool IsNonZero(int value) => value != 0;

        public class WithLambda
        {
            public static int GetIndexOfFirstNonEmptyBin(int[] bins)
                => Array.FindIndex(bins, value => value != 0);
        }

        public T[] GetNonNullItems<T>(T[] items) where T : class
            => Array.FindAll(items, value => value != null);

        public static void SearchPerf()
        {
            var sw = new Stopwatch();

            int[] big = new int[100_000_000];
            Console.WriteLine("Initializing");
            sw.Start();
            var r = new Random(0);
            for (int i = 0; i < big.Length; ++i)
            {
                big[i] = r.Next(big.Length);
            }
            sw.Stop();
            Console.WriteLine(sw.Elapsed.ToString("s\\.f"));
            Console.WriteLine();

            Console.WriteLine("Searching");
            for (int i = 0; i < 6; ++i)
            {
                int searchFor = r.Next(big.Length);
                sw.Reset();
                sw.Start();
                int index = Array.IndexOf(big, searchFor);
                sw.Stop();
                Console.WriteLine($"Index: {index}");
                Console.WriteLine($"Time:  {sw.Elapsed:s\\.ffff}");
            }
            Console.WriteLine();

            Console.WriteLine("Sorting");
            sw.Reset();
            sw.Start();
            Array.Sort(big);
            sw.Stop();
            Console.WriteLine(sw.Elapsed.ToString("s\\.ff"));
            Console.WriteLine();

            Console.WriteLine("Searching (binary)");
            for (int i = 0; i < 6; ++i)
            {
                int searchFor = r.Next() % big.Length;
                sw.Reset();
                sw.Start();
                int index = Array.BinarySearch(big, searchFor);
                sw.Stop();
                Console.WriteLine($"Index: {index}");
                Console.WriteLine($"Time:  {sw.Elapsed:s\\.fffffff}");
            }
        }

        private static void MoveExistingRecentEntryToTop(int recentFileListIndex)
        {
        }

        private static void AddNewRecentEntry(string openedFile)
        {
        }
    }
}