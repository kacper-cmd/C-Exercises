using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class MergeSortStrategy : ISortStrategy
    {
        public void Sort(int[] array)
        {
            MergeSortAlgorithm(array, 0, array.Length - 1);
        }

        private void MergeSortAlgorithm(int[] array, int left, int right)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;
                MergeSortAlgorithm(array, left, mid);
                MergeSortAlgorithm(array, mid + 1, right);
                Merge(array, left, mid, right);
            }
        }

        private void Merge(int[] array, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];

            // Copy data to temporary arrays.
            for (int i = 0; i < n1; i++)
                leftArray[i] = array[left + i];
            for (int j = 0; j < n2; j++)
                rightArray[j] = array[mid + 1 + j];

            int p = 0, q = 0, k = left;

            // Merge the temporary arrays back into the original array.
            while (p < n1 && q < n2)
            {
                if (leftArray[p] <= rightArray[q])
                {
                    array[k] = leftArray[p];
                    p++;
                }
                else
                {
                    array[k] = rightArray[q];
                    q++;
                }
                k++;
            }

            // Copy any remaining elements of leftArray.
            while (p < n1)
            {
                array[k] = leftArray[p];
                p++;
                k++;
            }

            // Copy any remaining elements of rightArray.
            while (q < n2)
            {
                array[k] = rightArray[q];
                q++;
                k++;
            }
        }
    }
}
