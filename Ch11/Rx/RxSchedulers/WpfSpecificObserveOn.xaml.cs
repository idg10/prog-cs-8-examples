using System;
using System.Reactive.Linq;
using System.Windows;

namespace RxSchedulers
{
    /// <summary>
    /// Interaction logic for WpfSpecificObserveOn.xaml
    /// </summary>
    public partial class WpfSpecificObserveOn : Window
    {
        public WpfSpecificObserveOn()
        {
            InitializeComponent();

            IObservable<Trade> trades = GetTradeStream();
            IObservable<Trade> tradesInUiContext = trades.ObserveOn(this.Dispatcher);
            tradesInUiContext.Subscribe(t =>
            {
                tradeInfoTextBox.AppendText(
                    $"{t.StockName}: {t.Number} at {t.UnitPrice}\r\n");
            });
        }

        private IObservable<Trade> GetTradeStream()
        {
            return Trade.TestStreamSlow();
        }
    }
}