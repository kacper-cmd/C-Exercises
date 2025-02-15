using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1._9._1.Concrete
{
    public class AllSeasonTyres : Tire
    {
        public override string Type => "All-season Tire";

        public AllSeasonTyres(double percentageOfDamage)
        {
            PercentageOfDamage = percentageOfDamage;
        }
    }
}
