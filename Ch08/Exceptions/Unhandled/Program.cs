using System;

namespace Unhandled
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;

            // Crash deliberately to illustrate the UnhandledException event
            throw new InvalidOperationException();
        }

        private static void OnUnhandledException(object sender,
            UnhandledExceptionEventArgs e)
        {
            Console.WriteLine($"An exception went unhandled: {e.ExceptionObject}");
        }
    }
}
