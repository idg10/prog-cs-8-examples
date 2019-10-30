using System;
using System.Reactive.Linq;

namespace Adaptation
{
    public static class IObservableToEnumerable
    {
        public static void ShowAll(IObservable<string> source)
        {
            foreach (string s in source.ToEnumerable())
            {
                Console.WriteLine(s);
            }
        }
    }
}