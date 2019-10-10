using System;

namespace BasicCoding
{
    internal static class Variables
    {
        internal static void DeclarationsAndAssignments()
        {
            string part1 = "the ultimate question";
            string part2 = "of something";
            int theAnswer = 42;
            int andAnotherThing;

            part2 = " of life, the universe, and everything";
            andAnotherThing = 123;

// To see the compiler error for Example 5, change this:
#if false
//  to:
// #if true
            theAnswer = "The compiler will reject this";
#endif

            double a = 1, b = 2.5, c = -3;

            // Use the variables to prevent unused variable warnings
            Console.WriteLine($"The answer to {part1}, {part2} is {theAnswer}, and not {andAnotherThing}, nor {a + b + c}");
        }

        internal static void ImplicitVariableTypes()
        {
            var part1 = "the ultimate question";
            var part2 = "of something";
            var theAnswer = 40 + 2;

            // Use the variable to prevent unused variable warnings
            Console.WriteLine($"The answer to {part1}, {part2} is {theAnswer}");
        }

        // To see the compiler errors for Examples 7, 10-15, change this:
#if false
//  to:
// #if true
        internal static void SomeBadCode()
        {
            var theAnswer = 42;
            theAnswer = "The compiler will reject this";

            int willNotWork;
            Console.WriteLine(willNotWork);
        }

        static void SomeMethod()
        {
            int thisWillNotWork = 42;
        }

        static void AnUncompilableMethod()
        {
            Console.WriteLine(thisWillNotWork);
        }

        internal static void NotInScope()
        {
            int someValue = GetValue();
            if (someValue > 100)
            {
                int willNotWork = someValue - 100;
            }
            Console.WriteLine(willNotWork);
        }

        public static void SurprisingNameCollision()
        {
            int someValue = GetValue();
            if (someValue > 100)
            {
                int anotherValue = someValue - 100;  // Compiler error
                Console.WriteLine(anotherValue);
            }

            int anotherValue = 123;
        }

        public static void HidingAVariable()
        {
            var r = new Random();
            bool problem1 = r.Next(0, 2) == 0;
            bool problem2 = r.Next(0, 2) == 0;
            bool problem3 = r.Next(0, 2) == 0;

            int errorCount = 0;
            if (problem1)
            {
                errorCount += 1;

                if (problem2)
                {
                    errorCount += 1;
                }

                // Imagine that in a real program there was a big
                // chunk of code here before the following lines.

                int errorCount = GetErrors();  // Compiler error
                if (problem3)
                {
                    errorCount += 1;
                }
            }

            Console.WriteLine(errorCount);
        }
#endif

        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Style",
            "IDE0059:Unnecessary assignment of a value",
            Justification = "Example shows two ways to assign a value to a variable, so this unnecessary assignment is inevitable")]
        internal static void UsingVariables()
        {
            string part1 = "the ultimate question";
            string part2 = "of something";
            int theAnswer = 42;

            part2 = "of life, the universe, and everything";

            string questionText = "What is the answer to " + part1 + ", " + part2 + "?";
            string answerText = "The answer to " + part1 + ", " +
                                   part2 + ", is: " + theAnswer;

            Console.WriteLine(questionText);
            Console.WriteLine(answerText);
        }

        internal static void UseVariableFromOuterScope()
        {
            int someValue = GetValue();
            if (someValue > 100)
            {
                Console.WriteLine(someValue);
            }
        }

        private static int GetValue() => 42;
    }
}
