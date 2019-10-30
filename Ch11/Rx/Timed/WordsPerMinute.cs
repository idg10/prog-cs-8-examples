using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;

namespace Timed
{
    public static class WordsPerMinute
    {
        private static readonly KeyWatcher keySource = new KeyWatcher();
        private static readonly IObservable<IList<char>> wordWindows = keySource.Buffer(
            () => keySource.FirstAsync(char.IsWhiteSpace));

        private static readonly IObservable<string> words = from wordWindow in wordWindows
                                                            select new string(wordWindow.ToArray()).Trim();


        public static void WithGroups()
        {
            IObservable<long> ticks = Observable.Interval(TimeSpan.FromSeconds(6));
            IObservable<int> wordGroupCounts = from tick in ticks
                                               join word in words
                                                 on ticks equals words into wordsInTick
                                               from count in wordsInTick.Count()
                                               select count * 10;

            wordGroupCounts.Subscribe(c => Console.WriteLine($"Words per minute: {c}"));

            keySource.Run();
        }

        public static void TimedWindowsWithBuffer()
        {
            IObservable<int> wordGroupCounts =
                from wordGroup in words.Buffer(TimeSpan.FromSeconds(6))
                select wordGroup.Count * 10;
            wordGroupCounts.Subscribe(c => Console.WriteLine("Words per minute: " + c));

            keySource.Run();
        }

        public static void OverlappingTimedWindows()
        {
            IObservable<int> wordGroupCounts =
                from wordGroup in words.Buffer(TimeSpan.FromSeconds(6),
                                               TimeSpan.FromSeconds(1))
                select wordGroup.Count * 10;
            wordGroupCounts.Subscribe(c => Console.WriteLine("Words per minute: " + c));

            keySource.Run();
        }
    }
}