using System;
using System.Collections.Generic;

namespace Timed
{
    public class KeyWatcher : IObservable<char>
    {
        private readonly List<Subscription> _subscriptions = new List<Subscription>();

        public IDisposable Subscribe(IObserver<char> observer)
        {
            var sub = new Subscription(this, observer);
            _subscriptions.Add(sub);
            return sub;
        }

        public void Run()
        {
            while (true)
            {
                // Passing true here stops the console from showing the character
                char c = Console.ReadKey(true).KeyChar;
                // Iterate over snapshot to handle the case where the observer
                // unsubscribes from inside its OnNext method.
                foreach (Subscription sub in _subscriptions.ToArray())
                {
                    sub.Observer.OnNext(c);
                }
            }
        }

        private void RemoveSubscription(Subscription sub)
        {
            _subscriptions.Remove(sub);
        }

        private class Subscription : IDisposable
        {
            private KeyWatcher _parent;
            public Subscription(KeyWatcher parent, IObserver<char> observer)
            {
                _parent = parent;
                Observer = observer;
            }

            public IObserver<char> Observer { get; }

            public void Dispose()
            {
                if (_parent != null)
                {
                    _parent.RemoveSubscription(this);
                    _parent = null;
                }
            }
        }
    }
}