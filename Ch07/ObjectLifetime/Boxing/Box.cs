namespace Boxing
{
    // Not a real box, but similar in effect.
    public class Box<T>
        where T : struct
    {
        public readonly T Value;
        public Box(T v)
        {
            Value = v;
        }

        public override string ToString() => Value.ToString();
        public override bool Equals(object obj) => Value.Equals(obj);
        public override int GetHashCode() => Value.GetHashCode();
    }
}