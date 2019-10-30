using System;
using System.Collections.Generic;
using System.Linq;

namespace StandardOperators
{
    public static class Grouping
    {
        public static void GroupingQueryExpression()
        {
            var subjectGroups = from course in Course.Catalog
                                group course by course.Category;

            foreach (var group in subjectGroups)
            {
                Console.WriteLine("Category: " + group.Key);
                Console.WriteLine();

                foreach (var course in group)
                {
                    Console.WriteLine(course.Title);
                }
                Console.WriteLine();
            }
        }

        public static void ExpandingSimpleGroupingQuery()
        {
            var subjectGroups = Course.Catalog.GroupBy(course => course.Category);
        }

        public static void GroupingQueryItemProjection()
        {
            var subjectGroups = from course in Course.Catalog
                                group course.Title by course.Category;
        }

        public static void ExpandedGroupingQueryItemProjection()
        {
            var subjectGroups = Course.Catalog
                .GroupBy(course => course.Category, course => course.Title);
        }

        public static void GroupingQueryGroupProjection()
        {
            var subjectGroups =
               from course in Course.Catalog
               group course by course.Category into category
               select $"Category '{category.Key}' contains {category.Count()} courses";
        }

        public static void ExpandedGroupingQueryGroupProjection()
        {
            IEnumerable<string> subjectGroups = Course.Catalog
                .GroupBy(course => course.Category)
                .Select(category =>
                   $"Category '{category.Key}' contains {category.Count()} courses");
        }

        public static void GroupByWithKeyAndGroupProjection()
        {
            IEnumerable<string> subjectGroups = Course.Catalog.GroupBy(
                course => course.Category,
                (category, courses) =>
                   $"Category '{category}' contains {courses.Count()} courses");
        }

        public static void GroupByWithKeyItemAndGroupProjection()
        {
            IEnumerable<string> subjectGroups = Course.Catalog.GroupBy(
                course => course.Category,
                course => course.Title,
                (category, titles) =>
                     $"Category '{category}' contains {titles.Count()} courses: " +
                         string.Join(", ", titles));
        }

        public static void CompositeGroupKey()
        {
            var bySubjectAndYear =
                from course in Course.Catalog
                group course by new { course.Category, course.PublicationDate.Year };
            foreach (var group in bySubjectAndYear)
            {
                Console.WriteLine($"{group.Key.Category} ({group.Key.Year})");
                foreach (var course in group)
                {
                    Console.WriteLine(course.Title);
                }
            }
        }
    }
}