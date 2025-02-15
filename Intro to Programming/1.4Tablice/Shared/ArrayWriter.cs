using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ArrayWriter
    {
        public static void WriteArray(IEnumerable<int> items)
        {
            Console.WriteLine(string.Join(" ", items));
        }
    }
}
