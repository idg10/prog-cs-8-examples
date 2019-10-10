using System;
using System.Collections.Generic;
using System.IO;

namespace BasicCoding
{
    internal static class FlowControl
    {
        internal static void SimpleIf(int age)
        {
            if (age < 18)
            {
                Console.WriteLine("You are too young to buy alcohol in a bar in the UK.");
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Style",
            "IDE0011:Add braces",
            Justification = "This example deliberately shows the wrong way to do it")]
        internal static void BadIf(bool launchCodesCorrect)
        {
            if (launchCodesCorrect)
                TurnOnMissileLaunchedIndicator();
                LaunchMissiles();
        }

        internal static void IfAndElse(bool optimistic)
        {
            if (optimistic)
            {
                Console.WriteLine("Glass half full");
            }
            else
            {
                Console.WriteLine("Glass half empty");
            }
        }

        internal static void MultipleElses(double temperatureInCelsius)
        {
            if (temperatureInCelsius < 52)
            {
                Console.WriteLine("Too cold");
            }
            else if (temperatureInCelsius > 58)
            {
                Console.WriteLine("Too hot");
            }
            else
            {
                Console.WriteLine("Just right");
            }
        }

        internal static void MultipleElsesLotsOfBlocks(double temperatureInCelsius)
        {
            if (temperatureInCelsius < 52)
            {
                Console.WriteLine("Too cold");
            }
            else
            {
                if (temperatureInCelsius > 58)
                {
                    Console.WriteLine("Too hot");
                }
                else
                {
                    Console.WriteLine("Just right");
                }
            }
        }

        internal static void SwitchWithStrings(string workStatus)
        {
            switch (workStatus)
            {
                case "ManagerInRoom":
                    WorkDiligently();
                    break;

                case "HaveNonUrgentDeadline":
                case "HaveImminentDeadline":
                    CheckTwitter();
                    CheckEmail();
                    CheckTwitter();
                    ContemplateGettingOnWithSomeWork();
                    CheckTwitter();
                    CheckTwitter();
                    break;

                case "DeadlineOvershot":
                    WorkFuriously();
                    break;

                default:
                    CheckTwitter();
                    CheckEmail();
                    break;
            }
        }

        // To see the compiler error for Example 67, change this:
#if false
//  to:
// #if true
        internal static void IllegalSwitchFallThrough(string x)
        {
            switch (x)
            {
                case "One":
                    Console.WriteLine("One");
                case "Two":  // This line will not compile
                    Console.WriteLine("One or two");
                    break;
            }
        }
#endif

        internal static void SwitchFallThrough(string x)
        {
            switch (x)
            {
                case "One":
                    Console.WriteLine("One");
                    goto case "Two";
                case "Two":
                    Console.WriteLine("One or two");
                    break;
            }
        }

        internal static void WhileLoop(StreamReader reader)
        {
            while (!reader.EndOfStream)
            {
                Console.WriteLine(reader.ReadLine());
            }
        }

        internal static void DoLoop()
        {
            char k;
            do
            {
                Console.WriteLine("Press x to exit");
                k = Console.ReadKey().KeyChar;
            }
            while (k != 'x');
        }

        internal static void ForLoops(int[] myArray)
        {
            for (int i = 0; i < myArray.Length; i++)
            {
                myArray[i] *= 2;
            }

            for (int i = 0, j = 0; i < myArray.Length; i++, j++)
            {
                myArray[i] = myArray[j] / 2;
            }
        }

        internal static void NestedLoop(int[,] myArray)
        {
            int height = myArray.GetLength(0);
            int width = myArray.GetLength(1);

            for (int j = 0; j < height; ++j)
            {
                for (int i = 0; i < width; ++i)
                {
                    Console.WriteLine($"{i},{j}: {myArray[i, j]}");
                }
            }
        }

        internal static void ForeachLoops()
        {
            string[] messages = GetMessagesFromSomewhere();
            foreach (string message in messages)
            {
                Console.WriteLine(message);
            }

            static string[] GetMessagesFromSomewhere() => new[] { "Hello", "world" };
        }

        public static void ShowMessages(IEnumerable<string> messages)
        {
            foreach (string message in messages)
            {
                Console.WriteLine(message);
            }
        }

        private static void TurnOnMissileLaunchedIndicator() => Console.WriteLine("Awhoogha!");

        private static void LaunchMissiles() => Console.WriteLine("Fwoom!");

        private static void WorkDiligently() => Console.WriteLine("Makes Jack a dull boy");

        private static void CheckTwitter() => Console.WriteLine("Refresh");

        private static void CheckEmail() => Console.WriteLine("Scroll");

        private static void ContemplateGettingOnWithSomeWork() => Console.WriteLine("Sigh");

        private static void WorkFuriously() => Console.WriteLine("Here's Johnny!");
    }
}
