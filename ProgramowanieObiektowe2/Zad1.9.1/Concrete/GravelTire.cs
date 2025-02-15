//Opona szutrowa
public class GravelTire : Tire
{
    public override string Type => "Gravel Tire";
    public GravelTire(double percentageOfDamage)
    {
        PercentageOfDamage = percentageOfDamage;
    }
}
