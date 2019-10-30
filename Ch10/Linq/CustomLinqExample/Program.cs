using System;
using System.Globalization;

namespace CustomLinqExample
{
    public static class CustomLinqProvider
    {
        public static CultureInfo[] Where(this CultureInfo[] cultures,
                                          Predicate<CultureInfo> filter)
        {
            return Array.FindAll(cultures, filter);
        }

        public static T[] Select<T>(this CultureInfo[] cultures,
                                    Func<CultureInfo, T> map)
        {
            var result = new T[cultures.Length];
            for (int i = 0; i < cultures.Length; ++i)
            {
                result[i] = map(cultures[i]);
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var commaCultures =
              from culture in CultureInfo.GetCultures(CultureTypes.AllCultures)
              where culture.NumberFormat.NumberDecimalSeparator == ","
              select culture.Name;

            foreach (string cultureName in commaCultures)
            {
                Console.WriteLine(cultureName);
            }
        }
    }
}