namespace Constructors.Chaining
{
    public class ItemWithId
    {
        private static int _lastId;
        private int _id;
        private string _name;

        public ItemWithId()
        {
            _id = ++_lastId;
        }

        public ItemWithId(string name)
            : this()
        {
            _name = name;
        }
        public ItemWithId(string name, int id)
        {
            _name = name;
            _id = id;
        }
    }
}
