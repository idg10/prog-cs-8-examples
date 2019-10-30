using System;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace RxSchedulers
{
    public class Trade
    {
        public string StockName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Number { get; set; }

        public static IObservable<Trade> TestStreamSlow()
        {
            return Observable.Create<Trade>(async obs =>
            {
                string[] names = { "MSFT", "GOOGL", "AAPL" };
                var r = new Random(0);
                for (int i = 0; i < 100; ++i)
                {
                    var t = new Trade
                    {
                        StockName = names[r.Next(names.Length)],
                        UnitPrice = r.Next(1, 100),
                        Number = r.Next(10, 1000)
                    };
                    await Task.Delay(TimeSpan.FromSeconds(r.Next(1, 5))).ConfigureAwait(false);
                    obs.OnNext(t);
                }
                obs.OnCompleted();
                return default(IDisposable);
            });
        }
    }
}