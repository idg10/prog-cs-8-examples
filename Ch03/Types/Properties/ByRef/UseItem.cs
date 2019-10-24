namespace Properties.ByRef
{
    using System.Windows;

    class UseItem
    {
        public static void CompilesButProbablyNotAGoodIdea()
        {
            var item = new Item();
            Point location = item.Location;
            location.X = 123;
        }
    }
}