namespace Properties.ByRef
{
    using System.Windows;

    public class Item
    {
        private Point _location;

        public ref Point Location => ref _location;
    }
}