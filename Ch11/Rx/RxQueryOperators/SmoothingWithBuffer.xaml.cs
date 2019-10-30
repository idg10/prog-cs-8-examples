using System;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Input;

namespace RxQueryOperators
{
    /// <summary>
    /// Interaction logic for SmoothingWithBuffer.xaml
    /// </summary>
    public partial class SmoothingWithBuffer : Window
    {
        public SmoothingWithBuffer()
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

            IObservable<Point> smoothed = from points in dragPositions.Buffer(5, 2)
                                          let x = points.Average(p => p.X)
                                          let y = points.Average(p => p.Y)
                                          select new Point(x, y);

            smoothed.Subscribe(point => { line.Points.Add(point); });
        }
    }
}