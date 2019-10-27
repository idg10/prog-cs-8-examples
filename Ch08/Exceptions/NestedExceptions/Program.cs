using System;
using System.IO;

namespace NestedExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ShowFirstLineLength(@"C:\Temp\File.txt");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("NullReferenceException");
            }
        }

        static void ShowFirstLineLength(string fileName)
        {
            try
            {
                using (var r = new StreamReader(fileName))
                {
                    try
                    {
                        Console.WriteLine(r.ReadLine().Length);
                    }
                    catch (IOException x)
                    {
                        Console.WriteLine("Error while reading file: {0}",
                            x.Message);
                    }
                }
            }
            catch (FileNotFoundException x)
            {
                Console.WriteLine("Couldn't find the file '{0}'", x.FileName);
            }
        }
    }
}
