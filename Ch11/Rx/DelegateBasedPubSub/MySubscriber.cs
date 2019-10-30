using System;

namespace DelegateBasedPubSub
{
    class MySubscriber<T> : IObserver<T>
    {
        public void OnNext(T value) => Console.WriteLine("Received: " + value);
        public void OnCompleted() => Console.WriteLine("Complete");
        public void OnError(Exception ex) => Console.WriteLine("Error: " + ex);
    }
}
