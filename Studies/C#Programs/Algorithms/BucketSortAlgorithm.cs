using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class BucketSortAlgorithm : IBucketSort
    {
        public List<int> Sort(List<int> inputList, int bucketCount)
        {
            if (inputList.Count <= 1)
                return inputList;

            int minValue = inputList[0];
            int maxValue = inputList[0];

            for (int i = 1; i < inputList.Count; i++)
            {
                if (inputList[i] < minValue)
                    minValue = inputList[i];
                else if (inputList[i] > maxValue)
                    maxValue = inputList[i];
            }

            double range = (double)(maxValue - minValue + 1) / bucketCount;
            List<List<int>> buckets = new List<List<int>>(bucketCount);

            for (int i = 0; i < bucketCount; i++)
                buckets.Add(new List<int>());

            foreach (int num in inputList)
            {
                int bucketIndex = (int)((num - minValue) / range);
                buckets[bucketIndex].Add(num);
            }

            foreach (List<int> bucket in buckets)
            {
                if (bucket.Count > 1)
                    InsertionSort(bucket);
            }

            List<int> sortedList = new List<int>(inputList.Count);
            foreach (List<int> bucket in buckets)
            {
                sortedList.AddRange(bucket);
            }

            return sortedList;
        }

        private void InsertionSort(List<int> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                int currentValue = list[i];
                int j = i - 1;

                while (j >= 0 && list[j] > currentValue)
                {
                    list[j + 1] = list[j];
                    j--;
                }

                list[j + 1] = currentValue;
            }
        }
    }
}
