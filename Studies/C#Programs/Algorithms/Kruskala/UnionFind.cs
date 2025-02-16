using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Kruskala
{
    class UnionFind : IUnionFind
    {
        public int Find(int[] parent, int i)
        {
            if (parent[i] == -1)
                return i;
            return Find(parent, parent[i]);
        }

        public void Union(int[] parent, int x, int y)
        {
            int xSet = Find(parent, x);
            int ySet = Find(parent, y);
            parent[xSet] = ySet;
        }
    }
}
