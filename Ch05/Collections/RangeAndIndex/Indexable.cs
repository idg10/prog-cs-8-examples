namespace RangeAndIndex
{
    public class Indexable
    {
        public char this[int index] => (char)('0' + index);

        public int Length => 10;
    }
}