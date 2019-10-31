using System;
using System.Threading.Tasks;

namespace AwaitPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static async Task UseCustomAsync()
        {
            string result = await CustomAsync();
            Console.WriteLine(result);
        }

        public static MyAwaitableType CustomAsync()
        {
            return new MyAwaitableType();
        }

        class Approximate
        {

            static void ManualUseCustomAsync()
            {
                var awaiter = CustomAsync().GetAwaiter();
                if (awaiter.IsCompleted)
                {
                    TheRest(awaiter);
                }
                else
                {
                    awaiter.OnCompleted(() => TheRest(awaiter));
                }
            }

            private static void TheRest(MyAwaitableType.MinimalAwaiter awaiter)
            {
                string result = awaiter.GetResult();
                Console.WriteLine(result);
            }
        }

        private class ManualUseCustomAsyncState
        {
            private int state;
            private MyAwaitableType.MinimalAwaiter awaiter;

            public void MoveNext()
            {
                if (state == 0)
                {
                    awaiter = CustomAsync().GetAwaiter();
                    if (!awaiter.IsCompleted)
                    {
                        state = 1;
                        awaiter.OnCompleted(MoveNext);
                        return;
                    }
                }
                string result = awaiter.GetResult();
                Console.WriteLine(result);
            }
        }

        static void ManualUseCustomAsync()
        {
            var s = new ManualUseCustomAsyncState();
            s.MoveNext();
        }
    }
}
