using System;
using System.Collections.Generic;
using System.IO;

namespace NestedTypes
{
    class Program
    {
        private static void Main(string[] args)
        {
            // Ask the class library where the user's My Documents folder lives
            string path =
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string[] files = Directory.GetFiles(path);
            var comparer = new LengthComparer();
            Array.Sort(files, comparer);
            foreach (string file in files)
            {
                Console.WriteLine(file);
            }
        }

        private class LengthComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                int diff = x.Length - y.Length;
                return diff == 0 ? x.CompareTo(y) : diff;
            }
        }
    }
}