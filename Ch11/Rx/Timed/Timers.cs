using System;
using System.Reactive;
using System.Reactive.Linq;

namespace Timed
{
    public static class Timers
    {
        public static void SingleItem()
        {
            IObservable<long> src = Observable.Timer(TimeSpan.FromSeconds(1));
            src.Subscribe(i => Console.WriteLine($"Event {i} at {DateTime.Now:T}"));
        }
    
        public static void Timestamped()
        {
            IObservable<Timestamped<long>> src =
                Observable.Interval(TimeSpan.FromSeconds(1)).Timestamp();
            src.Subscribe(i => Console.WriteLine(
                $"Event {i.Value} at {i.Timestamp.ToLocalTime():T}"));
        }

        public static void Interval()
        {
            IObservable<long> ticks = Observable.Interval(TimeSpan.FromSeconds(0.75));
            IObservable<TimeInterval<long>> timed = ticks.TimeInterval();
            timed.Subscribe(x => Console.WriteLine(
                $"Event {x.Value} took {x.Interval.TotalSeconds:F3}"));
        }
    }
}