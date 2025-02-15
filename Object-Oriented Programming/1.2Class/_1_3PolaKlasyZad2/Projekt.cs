using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_3PolaKlasyZad2Zad3
{
    internal class Project
    {
        public string ProjectName { get; set; }
        public IEnumerable<Worker> Workers { get; set; }
        private int ProjectId { get; set; }
    }
}