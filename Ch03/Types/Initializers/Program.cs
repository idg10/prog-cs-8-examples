using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Initializers
{
    class Program
    {
        static void Main()
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "cmd.exe",
                UseShellExecute = true,
                WindowStyle = ProcessWindowStyle.Maximized,
            });

            Process.Start(new ProcessStartInfo("cmd.exe")
            {
                UseShellExecute = true,
                WindowStyle = ProcessWindowStyle.Maximized,
            });

            var d = new Dictionary<string, int>
            {
                ["One"] = 1,
                ["Two"] = 2,
                ["Three"] = 3
            };

            Console.WriteLine(d["One"]);
        }
    }
}