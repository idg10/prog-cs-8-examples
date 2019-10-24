namespace Deconstruction
{
    public readonly struct Size
    {
        public Size(double w, double h)
        {
            W = w;
            H = h;
        }

        public void Deconstruct(out double w, out double h)
        {
            w = W;
            h = H;
        }

        public double W { get; }
        public double H { get; }
    }
}
