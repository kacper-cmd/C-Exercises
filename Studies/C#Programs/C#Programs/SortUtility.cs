using System;
using System.Linq;

namespace C_Programs
{
    public static class SortUtility
    {

        public static T[] SortAscending<T>(T[] array) where T : IComparable
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            return array.OrderBy(x => x).ToArray();
        }

        public static T[] SortDescending<T>(T[] array) where T : IComparable
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            return array.OrderByDescending(x => x).ToArray();
        }

        public static void DisplaySorted<T>(T[] array, Func<T[], T[]> sortFunction)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if (sortFunction == null)
                throw new ArgumentNullException(nameof(sortFunction));

            var sortedArray = sortFunction(array);
            Console.WriteLine("Sorted elements:");
            foreach (var element in sortedArray)
            {
                Console.WriteLine(element);
            }
        }
    }

}
