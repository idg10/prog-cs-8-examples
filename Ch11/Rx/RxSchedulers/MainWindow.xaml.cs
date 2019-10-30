using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Windows;

namespace RxSchedulers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            IObservable<Trade> trades = GetTradeStream();
            IObservable<Trade> tradesInUiContext =
                trades.ObserveOn(DispatcherScheduler.Current);
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
