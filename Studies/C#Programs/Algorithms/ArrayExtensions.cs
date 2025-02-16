using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class ArrayExtensions
    {
        public static void Swap<T>(this T[] array, int index1, int index2)
        {
            if (index1 != index2)
            {
                T temp = array[index1];
                array[index1] = array[index2];
                array[index2] = temp;
            }
        }
    }
}
