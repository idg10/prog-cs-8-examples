using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Input;

namespace RxQueryOperators
{
    /// <summary>
    /// Interaction logic for SmoothingWithWindow.xaml
    /// </summary>
    public partial class SmoothingWithWindow : Window
    {
        public SmoothingWithWindow()
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
                from down in downs
                join move in allMoves
                  on ups equals allMoves
                select move;

            IObservable<EventPattern<MouseEventArgs>> allDragPositionEvents =
                Observable.Merge(downs, ups, dragMoves);

            IObservable<Point> dragPositions =
                from move in allDragPositionEvents
                select move.EventArgs.GetPosition(background);

            IObservable<Point> smoothed =
                from points in dragPositions.Window(5, 2)
                from totals in points.Aggregate(
                  new { X = 0.0, Y = 0.0, Count = 0 },
                  (acc, point) => new
                  { X = acc.X + point.X, Y = acc.Y + point.Y, Count = acc.Count + 1 })
                where totals.Count > 0
                select new Point(totals.X / totals.Count, totals.Y / totals.Count);

            smoothed.Subscribe(point => { line.Points.Add(point); });
        }
    }
}