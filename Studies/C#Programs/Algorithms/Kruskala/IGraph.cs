using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Kruskala
{
    interface IGraph
    {
        int Vertices { get; set; }
        List<Edge> Edges { get; set; }
    }
}
