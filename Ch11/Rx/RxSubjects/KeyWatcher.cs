using System;
using System.Reactive.Subjects;

namespace RxSubjects
{
    public class KeyWatcher : IObservable<char>
    {
        private readonly Subject<char> _subject = new Subject<char>();

        public IDisposable Subscribe(IObserver<char> observer)
        {
            return _subject.Subscribe(observer);
        }

        public void Run()
        {
            while (true)
            {
                _subject.OnNext(Console.ReadKey(true).KeyChar);
            }
        }
    }
}