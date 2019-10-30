using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace DelegateBasedPubSub
{
    class Program
    {
        static void Main()
        {
            SubscribeWihoutImplementingIObserver();
        }

        public static void DelegateBasedHotSource()
        {
            IObservable<char> singularHotSource = Observable.Create(
                (Func<IObserver<char>, IDisposable>)(obs =>
                {
                    while (true)
                    {
                        obs.OnNext(Console.ReadKey(true).KeyChar);
                    }
                }));

            IConnectableObservable<char> keySource = singularHotSource.Publish();

            keySource.Subscribe(new MySubscriber<char>());
            keySource.Subscribe(new MySubscriber<char>());
        }

        public static void SubscribeWihoutImplementingIObserver()
        {
            var source = new KeyWatcher();
            source.Subscribe(value => Console.WriteLine("Received: " + value));
            source.Run();
        }
    }
}