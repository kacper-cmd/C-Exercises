namespace Zad1._9._1.Concrete
{
    public class SummerTyres : Tire
    {
        public override string Type => "Summer Tire";
        public SummerTyres(double percentageOfDamage)
        {
            PercentageOfDamage = percentageOfDamage;
        }
    }
}