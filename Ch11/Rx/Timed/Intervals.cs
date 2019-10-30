using System;
using System.Reactive.Linq;
using System.Threading;

namespace Timed
{
    public static class Intervals
    {
        public static void RegularIntervals()
        {
            IObservable<long> src = Observable.Interval(TimeSpan.FromSeconds(1));
            src.Subscribe(i => Console.WriteLine($"Event {i} at {DateTime.Now:T}"));
        }

        public static void TwoSubscribers()
        {
            IObservable<long> src = Observable.Interval(TimeSpan.FromSeconds(1));
            src.Subscribe(i => Console.WriteLine($"Event {i} at {DateTime.Now:T}"));

            Thread.Sleep(2500);
            src.Subscribe(i => Console.WriteLine(
                $"Event {i} at {DateTime.Now:T} (2nd subscriber)"));
        }
    }
}
