using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Programs
{
    public static class ArrayUtils
    {
        /// <summary>
        /// Finds the minimum and maximum values in the provided array.
        /// </summary>
        /// <typeparam name="T">Type of elements in the array. Must implement IComparable&lt;T&gt;.</typeparam>
        /// <param name="array">The array to search.</param>
        /// <returns>A tuple containing the minimum and maximum values.</returns>
        /// <exception cref="ArgumentException">Thrown when the array is null or empty.</exception>
        public static (T Min, T Max) FindMinMax<T>(T[] array) where T : IComparable<T>
        {
            if (array == null || array.Length == 0)
            {
                throw new ArgumentException("Array cannot be null or empty.", nameof(array));
            }

            T min = array[0];
            T max = array[0];

            foreach (T item in array)
            {
                if (item.CompareTo(min) < 0)
                {
                    min = item;
                }
                if (item.CompareTo(max) > 0)
                {
                    max = item;
                }
            }

            return (min, max);
        }
    }

}
