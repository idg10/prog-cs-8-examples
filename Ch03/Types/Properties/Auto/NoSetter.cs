namespace Properties.Auto
{
    public class NoSetter
    {
        public NoSetter(int x)
        {
            this.X = x;
        }

        public int X { get; }
    }
}