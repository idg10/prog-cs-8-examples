using System;
using System.Collections.Generic;
using System.Reactive.Linq;

namespace Adaptation
{
    public static class IEnumerableToObservable
    {
        public static void ShowAll(IEnumerable<string> source)
        {
            IObservable<string> observableSource = source.ToObservable();
            observableSource.Subscribe(Console.WriteLine);
        }

        public static IObservable<T> MyToObservable<T>(this IEnumerable<T> input)
        {
            return Observable.Create((IObserver<T> observer) =>
            {
                bool inObserver = false;
                try
                {
                    foreach (T item in input)
                    {
                        inObserver = true;
                        observer.OnNext(item);
                        inObserver = false;
                    }
                    inObserver = true;
                    observer.OnCompleted();
                }
                catch (Exception x)
                {
                    if (inObserver)
                    {
                        throw;
                    }
                    observer.OnError(x);
                }
                return () => { };
            });
        }
    }
}
