using System.IO;

namespace Exceptions
{
    class Rethrow
    {
        public static void BadRethrow()
        {
            try
            {
                DoSomething();
            }
            catch (IOException x)
            {
                LogIOError(x);
                // This next line is BAD!
                throw x;  // Do not do this
            }
        }

        public static void GoodRethrow()
        {
            try
            {
                DoSomething();
            }
            catch (IOException x)
            {
                LogIOError(x);
                throw;
            }
        }

        private static void DoSomething()
        {
        }

        private static void LogIOError(IOException x)
        {
        }
    }
}
