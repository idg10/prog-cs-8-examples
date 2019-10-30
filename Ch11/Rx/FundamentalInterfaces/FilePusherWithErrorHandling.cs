using System;
using System.IO;

namespace FundamentalInterfaces
{
    public class FilePusherWithErrorHandling : IObservable<string>
    {
        private readonly string _path;
        public FilePusherWithErrorHandling(string path)
        {
            _path = path;
        }

        public IDisposable Subscribe(IObserver<string> observer)
        {
            StreamReader sr = null;
            string line = null;
            bool failed = false;

            try
            {
                while (true)
                {
                    try
                    {
                        if (sr == null)
                        {
                            sr = new StreamReader(_path);
                        }
                        if (sr.EndOfStream)
                        {
                            break;
                        }
                        line = sr.ReadLine();
                    }
                    catch (IOException x)
                    {
                        observer.OnError(x);
                        failed = true;
                        break;
                    }

                    observer.OnNext(line);
                }
            }
            finally
            {
                if (sr != null)
                {
                    sr.Dispose();
                }
            }
            if (!failed)
            {
                observer.OnCompleted();
            }
            return NullDisposable.Instance;
        }

        private class NullDisposable : IDisposable
        {
            public static NullDisposable Instance = new NullDisposable();
            public void Dispose() { }
        }
    }
}