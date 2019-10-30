using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;

namespace RxQueryOperators
{
    public static class WordBreaking
    {
        public static void BreakTextWithWindows()
        {
            var keySource = new KeyWatcher();

            IObservable<IObservable<char>> wordWindows = keySource.Window(
                () => keySource.FirstAsync(char.IsWhiteSpace));

            IObservable<string> words = from wordWindow in wordWindows
                                        from chars in wordWindow.ToArray()
                                        select new string(chars).Trim();

            words.Subscribe(word => Console.WriteLine("Word: " + word));
        }

        public static void BreakTextWithBuffers()
        {
            var keySource = new KeyWatcher();

            IObservable<IList<char>> wordWindows = keySource.Buffer(
                () => keySource.FirstAsync(char.IsWhiteSpace));

            IObservable<string> words = from wordWindow in wordWindows
                                        select new string(wordWindow.ToArray()).Trim();
        }
    }
}