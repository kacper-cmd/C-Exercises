﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public interface IBucketSort
    {
        List<int> Sort(List<int> inputList, int bucketCount);
    }

}
