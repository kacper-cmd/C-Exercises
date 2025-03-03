using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy;

interface ISortingStrategy
{
    void Sort<T>(List<T> dataToSort);
}