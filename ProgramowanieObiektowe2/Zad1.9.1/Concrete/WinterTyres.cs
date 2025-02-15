using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1._9._1.Concrete
{
    public class WinterTyres : Tire
    {
        public override string Type => "Winter Tire";
        public WinterTyres(double percentageOfDamage)
        {
            PercentageOfDamage = percentageOfDamage;
        }
    }
}
