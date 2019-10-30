using System;
using System.IO;
using System.Reactive.Linq;

namespace DelegateBasedPubSub
{
    public static class AsyncSource
    {
        public static IObservable<string> GetFilePusher(string path)
        {
            return Observable.Create<string>(async (observer, cancel) =>
            {
                using (var sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream && !cancel.IsCancellationRequested)
                    {
                        observer.OnNext(await sr.ReadLineAsync());
                    }
                }
                observer.OnCompleted();
                return () => { };
            });
        }
    }
}