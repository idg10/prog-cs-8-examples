namespace Constructors.Simple
{
    public class Item
    {
        public Item(decimal price, string name)
        {
            _price = price;
            _name = name;
        }
        private readonly decimal _price;
        private readonly string _name;
    }
}
