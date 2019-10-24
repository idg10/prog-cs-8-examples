namespace ClassWithStaticMembers
{
    public class CounterUsingThis
    {
        private int _count;
        private static int _totalCount;

        public int GetNextValue()
        {
            this._count += 1;
            _totalCount += 1;
            return this._count;
        }

        public static int TotalCount => _totalCount;
    }
}