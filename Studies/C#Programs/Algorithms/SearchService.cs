using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class SearchService
    {
        private readonly ISearchAlgorithm _searchAlgorithm;

        public SearchService(ISearchAlgorithm searchAlgorithm)
        {
            _searchAlgorithm = searchAlgorithm;
        }

        public int Search(int[] array, int target)
        {
            return _searchAlgorithm.Search(array, target);
        }
    }
}
