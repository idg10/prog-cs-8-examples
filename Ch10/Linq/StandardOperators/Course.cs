using System;

namespace StandardOperators
{
    public class Course
    {
        public string Title { get; set; }

        public string Category { get; set; }

        public int Number { get; set; }

        public DateTime PublicationDate { get; set; }

        public TimeSpan Duration { get; set; }

        public static readonly Course[] Catalog =
        {
            new Course
            {
                Title = "Elements of Geometry",
                Category = "MAT", Number = 101, Duration = TimeSpan.FromHours(3),
                PublicationDate = new DateTime(2009, 5, 20)
            },
            new Course
            {
                Title = "Squaring the Circle",
                Category = "MAT", Number = 102, Duration = TimeSpan.FromHours(7),
                PublicationDate = new DateTime(2009, 4, 1)
            },
            new Course
            {
                Title = "Recreational Organ Transplantation",
                Category = "BIO", Number = 305, Duration = TimeSpan.FromHours(4),
                PublicationDate = new DateTime(2002, 7, 19)
            },
            new Course
            {
                Title = "Hyperbolic Geometry",
                Category = "MAT", Number = 207, Duration = TimeSpan.FromHours(5),
                PublicationDate = new DateTime(2007, 10, 5)
            },
            new Course
            {
                Title = "Oversimplified Data Structures for Demos",
                Category = "CSE", Number = 104, Duration = TimeSpan.FromHours(2),
                PublicationDate = new DateTime(2019, 9, 21)
            },
            new Course
            {
                Title = "Introduction to Human Anatomy and Physiology",
                Category = "BIO", Number = 201, Duration = TimeSpan.FromHours(12),
                PublicationDate = new DateTime(2001, 4, 11)
            },
        };
    }
}