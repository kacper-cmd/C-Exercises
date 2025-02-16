using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class QuickSortStrategy : ISortStrategy
    {
        public void Sort(int[] array)
        {
            QuickSortAlgorithm(array, 0, array.Length - 1);
        }

        private void QuickSortAlgorithm(int[] array, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(array, low, high);
                QuickSortAlgorithm(array, low, pivotIndex - 1);
                QuickSortAlgorithm(array, pivotIndex + 1, high);
            }
        }

        private int Partition(int[] array, int low, int high)
        {
            int pivotIndex = ChoosePivot(array, low, high);
            int pivotValue = array[pivotIndex];

            // Move pivot to the end using the generic Swap extension method.
            array.Swap(pivotIndex, high);

            int leftIndex = low;

            for (int i = low; i < high; i++)
            {
                if (array[i] < pivotValue)
                {
                    array.Swap(i, leftIndex);
                    leftIndex++;
                }
            }

            // Move pivot to its correct position.
            array.Swap(leftIndex, high);

            return leftIndex;
        }

        private int ChoosePivot(int[] array, int low, int high)
        {
            // Choose three random indices between low and high (inclusive).
            Random random = new Random();
            int indexA = random.Next(low, high + 1);
            int indexB = random.Next(low, high + 1);
            int indexC = random.Next(low, high + 1);

            // Get the values at the chosen indices.
            int a = array[indexA];
            int b = array[indexB];
            int c = array[indexC];

            // Return the index corresponding to the median value.
            if ((a <= b && b <= c) || (c <= b && b <= a))
                return indexB;
            else if ((b <= a && a <= c) || (c <= a && a <= b))
                return indexA;
            else
                return indexC;
        }
    }
}
