using System;
using System.Runtime.CompilerServices;

namespace Attributes
{
    public static class CallerInfo
    {
        public static void Log(
            string message,
            [CallerMemberName] string callingMethod = "",
            [CallerFilePath] string callingFile = "",
            [CallerLineNumber] int callingLineNumber = 0)
        {
            Console.WriteLine("Message {0}, called from {1} in file '{2}', line {3}",
                message, callingMethod, callingFile, callingLineNumber);
        }
    }
}