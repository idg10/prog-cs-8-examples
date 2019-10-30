using System;
using System.Reactive.Linq;

namespace RxQueryOperators
{
    public static class Aggregation
    {
        public static void SumWithAggregate()
        {
            IObservable<Trade> trades = Trade.TestStream();

            IObservable<long> tradeVolume = trades.Aggregate(
                0L, (total, trade) => total + trade.Number);
            tradeVolume.Subscribe(Console.WriteLine);
        }

        public static void RunningTotalWithScan()
        {
            IObservable<Trade> trades = Trade.TestStream();

            IObservable<long> tradeVolume = trades.Scan(
                0L, (total, trade) => total + trade.Number);
            tradeVolume.Subscribe(Console.WriteLine);
        }
    }
}