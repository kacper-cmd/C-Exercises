using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Kruskala
{
    interface IUnionFind
    {
        int Find(int[] parent, int i);
        void Union(int[] parent, int x, int y);
    }
}
