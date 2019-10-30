using System;
using System.Reactive.Linq;
using System.Windows;

namespace RxSchedulers
{
    /// <summary>
    /// Interaction logic for UseCurrentDispatcher.xaml
    /// </summary>
    public partial class UseCurrentDispatcher : Window
    {
        public UseCurrentDispatcher()
        {
            InitializeComponent();

            IObservable<Trade> trades = GetTradeStream();
            IObservable<Trade> tradesInUiContext = trades.ObserveOnDispatcher();
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
