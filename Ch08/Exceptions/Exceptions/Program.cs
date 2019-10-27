using System;
using System.IO;
using System.Linq;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var r = new StreamReader(@"C:\Temp\File.txt"))
            {
                while (!r.EndOfStream)
                {
                    Console.WriteLine(r.ReadLine());
                }
            }
        }

        static int Divide(int x, int y)
        {
            return x / y;
        }

        static void HandlingExceptions()
        {
            try
            {
                using (StreamReader r = new StreamReader(@"C:\Temp\File.txt"))
                {
                    while (!r.EndOfStream)
                    {
                        Console.WriteLine(r.ReadLine());
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Couldn't find the file");
            }
        }

        static void ExceptionObjects()
        {
            try
            {
                // ... same code as Example 8-3 ...
                using (StreamReader r = new StreamReader(@"C:\Temp\File.txt"))
                {
                    while (!r.EndOfStream)
                    {
                        Console.WriteLine(r.ReadLine());
                    }
                }
            }
            catch (FileNotFoundException x)
            {
                Console.WriteLine($"File '{x.FileName}' is missing");
            }
        }

        static void MultipleCatchBlocks()
        {
            try
            {
                using (StreamReader r = new StreamReader(@"C:\Temp\File.txt"))
                {
                    while (!r.EndOfStream)
                    {
                        Console.WriteLine(r.ReadLine());
                    }
                }
            }
            catch (FileNotFoundException x)
            {
                Console.WriteLine($"File '{x.FileName}' is missing");
            }
            catch (IOException x)
            {
                Console.WriteLine($"IO error: '{x.Message}'");
            }
        }

        public static bool InsertIfDoesNotExist(MyEntity item, CloudTable table)
        {
            try
            {
                table.Execute(TableOperation.Insert(item));
                return true;
            }
            catch (StorageException x)
            when (x.RequestInformation.HttpStatusCode == 409)
            {
                return false;
            }
        }

        public static int CountCommas(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }
            return text.Count(ch => ch == ',');
        }
    }
}
