namespace Properties.Auto
{
    public class WithPrivateSetter
    {
        public WithPrivateSetter(int x)
        {
            this.X = x;
        }

        public int X { get; private set; }

        public void MoveLeft(int by)
        {
            this.X -= by;
        }
    }
}
