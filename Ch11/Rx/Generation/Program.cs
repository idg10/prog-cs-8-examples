using System;
using System.Reactive.Linq;

namespace Generation
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello World!");
        }

        public static void GenerateItems()
        {
            IObservable<int> src = Observable.Generate(
                (Current: 0, Total: 0, Random: new Random()),
                state => state.Total <= 10000,
                state =>
                {
                    int value = state.Random.Next(1000);
                    return (value, state.Total + value, state.Random);
                },
                state => state.Current);
        }
    
        public static void GenerateTimedItems()
        {
            IObservable<int> src = Observable.Generate(
                (Current: 0, Total: 0, Random: new Random()),
                state => state.Total < 10000,
                state =>
                {
                    int value = state.Random.Next(1000);
                    return (value, state.Total + value, state.Random);
                },
                state => state.Current,
                state => TimeSpan.FromMilliseconds(state.Random.Next(1000)));
        }
    }
}
