using System;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Input;

namespace LinqQueries
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            IObservable<EventPattern<MouseEventArgs>> mouseMoves =
                Observable.FromEventPattern<MouseEventArgs>(
                    background, nameof(background.MouseMove));

            IObservable<Point> dragPositions =
                from move in mouseMoves
                where Mouse.Captured == background
                select move.EventArgs.GetPosition(background);

            dragPositions.Subscribe(point => { line.Points.Add(point); });
        }

        private void OnBackgroundMouseDown(object sender, MouseButtonEventArgs e)
        {
            background.CaptureMouse();
        }

        private void OnBackgroundMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.Captured == background)
            {
                background.ReleaseMouseCapture();
            }
        }
    }
}
