using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Kruskala
{
    class KruskalMST
    {
        private readonly IUnionFind _unionFind;

        public KruskalMST(IUnionFind unionFind)
        {
            _unionFind = unionFind;
        }

        public void FindMST(IGraph graph)
        {
            List<Edge> result = new List<Edge>();
            int[] parent = Enumerable.Repeat(-1, graph.Vertices).ToArray();

            graph.Edges = graph.Edges.OrderBy(edge => edge.Weight).ToList();

            foreach (Edge edge in graph.Edges)
            {
                int x = _unionFind.Find(parent, edge.Source);
                int y = _unionFind.Find(parent, edge.Destination);

                if (x != y)
                {
                    result.Add(edge);
                    _unionFind.Union(parent, x, y);
                }
            }

            Console.WriteLine("Minimalne drzewo rozpinające:");

            foreach (Edge edge in result)
            {
                Console.WriteLine($"{edge.Source} -- {edge.Destination}   Waga: {edge.Weight}");
            }
        }
    }
}
