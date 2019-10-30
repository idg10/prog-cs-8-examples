namespace RangeAndIndex
{
    public class Rangeable
    {
        public int Length => 10;

        public Rangeable Slice(int offset, int length) => this;
    }
}