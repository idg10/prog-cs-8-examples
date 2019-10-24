namespace Properties.MethodsInstead
{
    using System.Windows;

    public class Item
    {
        private Point _location;
        public Point get_Location()
        {
            return _location;
        }
        public void set_Location(Point value)
        {
            _location = value;
        }
    }
}