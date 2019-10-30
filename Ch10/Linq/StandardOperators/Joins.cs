using System;
using System.Linq;

namespace StandardOperators
{
    public static class Joins
    {
        private static readonly CourseChoice[] choices =
            {
                new CourseChoice { StudentId = 1, Category = "MAT", Number = 101 },
                new CourseChoice { StudentId = 1, Category = "MAT", Number = 102 },
                new CourseChoice { StudentId = 1, Category = "MAT", Number = 207 },
                new CourseChoice { StudentId = 2, Category = "MAT", Number = 101 },
                new CourseChoice { StudentId = 2, Category = "BIO", Number = 201 },
            };

        public static void QueryWithJoin()
        {
            CourseChoice[] choices =
            {
                new CourseChoice { StudentId = 1, Category = "MAT", Number = 101 },
                new CourseChoice { StudentId = 1, Category = "MAT", Number = 102 },
                new CourseChoice { StudentId = 1, Category = "MAT", Number = 207 },
                new CourseChoice { StudentId = 2, Category = "MAT", Number = 101 },
                new CourseChoice { StudentId = 2, Category = "BIO", Number = 201 },
            };

            var studentsAndCourses = from choice in choices
                                     join course in Course.Catalog
                                       on new { choice.Category, choice.Number }
                                       equals new { course.Category, course.Number }
                                     select new { choice.StudentId, Course = course };

            foreach (var item in studentsAndCourses)
            {
                Console.WriteLine(
                    $"Student {item.StudentId} will attend {item.Course.Title}");
            }
        }

        public static void JoinOperator()
        {
            var studentsAndCourses = choices.Join(
                Course.Catalog,
                choice => new { choice.Category, choice.Number },
                course => new { course.Category, course.Number },
                (choice, course) => new { choice.StudentId, Course = course });
        }

        public static void GroupedJoin()
        {
            var studentsAndCourses =
                from choice in choices
                join course in Course.Catalog
                  on new { choice.Category, choice.Number }
                  equals new { course.Category, course.Number }
                  into courses
                select new { choice.StudentId, Courses = courses };

            foreach (var item in studentsAndCourses)
            {
                Console.WriteLine($"Student {item.StudentId} will attend " +
                    string.Join(",", item.Courses.Select(course => course.Title)));
            }
        }

        public static void GroupedJoinOperator()
        {
            var studentsAndCourses = choices.GroupJoin(
                Course.Catalog,
                choice => new { choice.Category, choice.Number },
                course => new { course.Category, course.Number },
                (choice, courses) => new { choice.StudentId, Courses = courses });
        }
    }
}