using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Kruskala
{
    class Graph : IGraph
    {
        public int Vertices { get; set; }
        public List<Edge> Edges { get; set; }

        public Graph(int vertices, List<Edge> edges)
        {
            Vertices = vertices;
            Edges = edges;
        }
    }
}
