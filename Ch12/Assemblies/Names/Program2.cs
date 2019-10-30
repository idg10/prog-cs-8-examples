using System;
using System.Resources;
using System.Threading;

namespace ResourceExample
{
    public static class Program2
    {
        // Rename this to Main, and change Program.Main to Program.AltMain to run this entry point,
        // to see the output that you get with the en-GB locale
        public static void AltMain(string[] args)
        {
            Thread.CurrentThread.CurrentUICulture =
                new System.Globalization.CultureInfo("en-GB");

            var rm = new ResourceManager(
                "ResourceExample.MyResources", typeof(Program).Assembly);
            string colText = rm.GetString("ColString");
            Console.WriteLine("And now in " + colText);
        }
    }
}