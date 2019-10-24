namespace Classes
{
    public class Counter
    {
        private int _count;

        public int GetNextValue()
        {
            _count += 1;
            return _count;
        }
    }
}