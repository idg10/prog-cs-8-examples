using System;
using System.Runtime.CompilerServices;

namespace AwaitPattern
{
    public class MyAwaitableType
    {
        public MinimalAwaiter GetAwaiter()
        {
            return new MinimalAwaiter();
        }

        public class MinimalAwaiter : INotifyCompletion
        {
            public bool IsCompleted => true;

            public string GetResult() => "This is a result";

            public void OnCompleted(Action continuation)
            {
                throw new NotImplementedException();
            }
        }
    }
}
