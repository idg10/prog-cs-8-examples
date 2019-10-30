using System;

namespace FundamentalInterfaces
{
    public class SimpleColdSource : IObservable<string>
    {
        public IDisposable Subscribe(IObserver<string> observer)
        {
            observer.OnNext("Hello,");
            observer.OnNext("world!");
            observer.OnCompleted();
            return NullDisposable.Instance;
        }

        private class NullDisposable : IDisposable
        {
            public readonly static NullDisposable Instance = new NullDisposable();
            public void Dispose() { }
        }
    }
}
