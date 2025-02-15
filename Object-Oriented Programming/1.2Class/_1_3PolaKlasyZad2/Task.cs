using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_3PolaKlasyZad2Zad3
{
    internal class Task
    {
        private int TaskId { get; set; }
        private string TaskName { get; set; }
        public int StatusNumber { get; set; }
        public IEnumerable<Worker> Workers { get; set; }
    }
}
