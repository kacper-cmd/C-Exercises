using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Sorter
    {
        private ISortStrategy _sortStrategy;

        public Sorter(ISortStrategy sortStrategy)
        {
            _sortStrategy = sortStrategy;
        }

        public void SetStrategy(ISortStrategy sortStrategy)
        {
            _sortStrategy = sortStrategy;
        }

        public void Sort(int[] arr)
        {
            _sortStrategy.Sort(arr);
        }
    }
}
