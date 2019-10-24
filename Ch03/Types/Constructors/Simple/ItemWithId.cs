namespace Constructors.Simple
{
    public class ItemWithId
    {
        private static int _lastId;
        private int _id;

        public ItemWithId()
        {
            _id = ++_lastId;
        }
    }
}
