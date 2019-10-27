using System;
using System.IO;

namespace Disposable
{
    public static class UsingStatements
    {
        public static void UsingUsing()
        {
            using (StreamReader reader = File.OpenText(@"C:\temp\File.txt"))
            {
                Console.WriteLine(reader.ReadToEnd());
            }
        }

        public static void TheEffectOfUsing()
        {
            // The extra braces here are deliberate, and they illustrate how a using statement
            // introduces its own scope, and how the variable in the using statement declaration
            // is available only in that scope.
            {
                StreamReader reader = File.OpenText(@"C:\temp\File.txt");
                try
                {
                    Console.WriteLine(reader.ReadToEnd());
                }
                finally
                {
                    if (reader != null)
                    {
                        ((IDisposable)reader).Dispose();
                    }
                }
            }
        }

        public static void UsingDeclaration()
        {
            using StreamReader reader = File.OpenText(@"C:\temp\File.txt");
            Console.WriteLine(reader.ReadToEnd());
        }

        public static void StackedUsingStatements()
        {
            using (Stream source = File.OpenRead(@"C:\temp\File.txt"))
            using (Stream copy = File.Create(@"C:\temp\Copy.txt"))
            {
                source.CopyTo(copy);
            }
        }
    }
}
