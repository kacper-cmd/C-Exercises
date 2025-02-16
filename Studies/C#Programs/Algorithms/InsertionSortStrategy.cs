using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class InsertionSortStrategy : ISortStrategy
    {
        public void Sort(int[] data)
        {
            for (int i = 1; i < data.Length; i++)
            {
                int current = data[i];
                int j = i - 1;

                // Shift elements of the sorted portion to the right to make room.
                while (j >= 0 && data[j] > current)
                {
                    data[j + 1] = data[j];
                    j--;
                }
                data[j + 1] = current;
            }
        }
    }
}
