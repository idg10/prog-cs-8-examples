namespace ReadOnlyStructs
{
    public class LocationRecord
    {
        public LocationRecord(string label, Point location)
        {
            Label = label;
            Location = location;
        }

        public string Label { get; }
        public Point Location { get; }
    }
}
