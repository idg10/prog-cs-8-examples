namespace Constructors.MoreChaining
{
    public class ItemWithId
    {
        private static int _lastId;
        private int _id;
        private string _name;

        public ItemWithId()
            : this(null)
        {
        }

        public ItemWithId(string name)
            : this(name, ++_lastId)
        {
        }

        private ItemWithId(string name, int id)
        {
            _name = name;
            _id = id;
        }
    }
}
