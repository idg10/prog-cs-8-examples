using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Input;

namespace LinqQueries
{
    /// <summary>
    /// Interaction logic for CodeJoin.xaml
    /// </summary>
    public partial class CodeJoin : Window
    {
        public CodeJoin()
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

            IObservable<Point> dragPositions = downs.Join(
                allMoves,
                down => ups,
                move => allMoves,
                (down, move) => move.EventArgs.GetPosition(background));

            dragPositions.Subscribe(point => { line.Points.Add(point); });
        }
    }
}
