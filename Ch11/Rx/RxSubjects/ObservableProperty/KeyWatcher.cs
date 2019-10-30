using System;
using System.Reactive.Subjects;

namespace RxSubjects.ObservableProperty
{
    public class KeyWatcher
    {
        private readonly Subject<char> _subject = new Subject<char>();

        public IObservable<char> Keys => _subject;

        public void Run()
        {
            while (true)
            {
                _subject.OnNext(Console.ReadKey(true).KeyChar);
            }
        }
    }
}
