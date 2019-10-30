using System;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Input;

namespace RxQueryOperators
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MergingObservables : Window
    {
        public MergingObservables()
        {
            InitializeComponent();

            IObservable<EventPattern<MouseEventArgs>> downs =
                Observable.FromEventPattern<MouseEventArgs>(
                    background, nameof(background.MouseDown));
            IObservable<EventPattern<MouseEventArgs>> ups =
                Observable.FromEventPattern<MouseEventArgs>(
                    background, nameof(background.MouseUp));
            IObservable<EventPattern<MouseEventArgs>> allMoves =
                Observable.FromEventPattern<MouseEventArgs>(
                    background, nameof(background.MouseMove));

            IObservable<EventPattern<MouseEventArgs>> dragMoves =
                from move in allMoves
                where Mouse.Captured == background
                select move;

            IObservable<EventPattern<MouseEventArgs>> allDragPositionEvents =
                Observable.Merge(downs, ups, dragMoves);

            IObservable<Point> dragPositions =
                from move in allDragPositionEvents
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