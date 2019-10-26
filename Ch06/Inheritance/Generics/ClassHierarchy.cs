using System;
using System.Collections.Generic;

namespace Generics
{
    public class Shape
    {
        public Rect BoundingBox { get; set; }
    }

    public class RoundedRectangle : Shape
    {
        public double CornerRadius { get; set; }
    }

    public class BoxAreaComparer : IComparer<Shape>
    {
        public int Compare(Shape x, Shape y)
        {
            double xArea = x.BoundingBox.Width * x.BoundingBox.Height;
            double yArea = y.BoundingBox.Width * y.BoundingBox.Height;

            return Math.Sign(xArea - yArea);
        }
    }

    public class CornerSharpnessComparer : IComparer<RoundedRectangle>
    {
        public int Compare(RoundedRectangle x, RoundedRectangle y)
        {
            // Smaller corners are sharper, so smaller radius is "greater" for
            // the purpose of this comparison, hence the backward subtraction.
            return Math.Sign(y.CornerRadius - x.CornerRadius);
        }
    }
}
