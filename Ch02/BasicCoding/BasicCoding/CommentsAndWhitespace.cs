using System;

namespace BasicCoding
{
    internal static class CommentsAndWhitespace
    {
        internal static void SingleLineComments()
        {
            Console.WriteLine("Say");        // This text will be ignored but the code on
            Console.WriteLine("Anything");   // the left is still compiled as usual.
        }

        internal static void DelimitedComments()
        {
            Console.WriteLine(/* Has side effects */ GetLog());

            /* Some developers like to use delimited comments for big blocks of text,
             * where they need to explain something particularly complex or odd in the
             * code. The column of asterisks on the left is for decoration - asterisks
             * are necessary only at the start and end of the comment.
             */

            Console.WriteLine("This will run");   /* This comment includes not just the
            Console.WriteLine("This won't");       * text on the right, but also the text
            Console.WriteLine("Nor will this");   /* on the left except the first and last
            Console.WriteLine("Nor this");         * lines. */
            Console.WriteLine("This will also run");
        }

        internal static void InsignificantWhitespace()
        {
            Console.WriteLine("Testing");
            Console . WriteLine(   "Testing");
            Console.
                WriteLine ("Testing" )
              ;
        }

        private static string GetLog() => "Timber";
    }
}
