using System;
using System.IO;

namespace FundamentalInterfaces
{
    public class FilePusher : IObservable<string>
    {
        private readonly string _path;
        public FilePusher(string path)
        {
            _path = path;
        }

        public IDisposable Subscribe(IObserver<string> observer)
        {
            using (var sr = new StreamReader(_path))
            {
                while (!sr.EndOfStream)
                {
                    observer.OnNext(sr.ReadLine());
                }
            }
            observer.OnCompleted();
            return NullDisposable.Instance;
        }

        private class NullDisposable : IDisposable
        {
            public static NullDisposable Instance = new NullDisposable();
            public void Dispose() { }
        }
    }
}