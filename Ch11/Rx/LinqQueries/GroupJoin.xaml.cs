using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LinqQueries
{
    /// <summary>
    /// Interaction logic for GroupJoin.xaml
    /// </summary>
    public partial class GroupJoin : Window
    {
        public GroupJoin()
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

            var dragPointSets = from mouseDown in downs
                                join move in allMoves
                                  on ups equals allMoves into m
                                select m.Select(e => e.EventArgs.GetPosition(background));

            dragPointSets.Subscribe(dragPoints =>
            {
                var currentLine = new Polyline { Stroke = Brushes.Black, StrokeThickness = 2 };
                background.Children.Add(currentLine);

                dragPoints.Subscribe(point =>
                {
                    currentLine.Points.Add(point);
                });
            });
        }
    }
}