using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Input;

namespace LinqQueries
{
    /// <summary>
    /// Interaction logic for QueryExpressionJoin.xaml
    /// </summary>
    public partial class QueryExpressionJoin : Window
    {
        public QueryExpressionJoin()
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

            IObservable<Point> dragPositions =
                from down in downs
                join move in allMoves
                  on ups equals allMoves
                select move.EventArgs.GetPosition(background);

            dragPositions.Subscribe(point => { line.Points.Add(point); });
        }
    }
}
