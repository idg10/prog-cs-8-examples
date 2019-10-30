using System;
using System.IO;
using System.Reactive.Linq;

namespace DelegateBasedPubSub
{
    public static class DelegateBasedSource
    {
        public static IObservable<string> GetFilePusher(string path)
        {
            return Observable.Create<string>(observer =>
            {
                using (var sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        observer.OnNext(sr.ReadLine());
                    }
                }
                observer.OnCompleted();
                return () => { };
            });
        }
    }
}