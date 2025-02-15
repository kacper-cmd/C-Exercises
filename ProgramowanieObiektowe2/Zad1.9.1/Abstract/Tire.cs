using Zad1._9._1.Visitor.Element;
using Zad1._9._1.Visitor.Visitor;
public abstract class Tire : ICarPart
{
    public abstract string Type { get; }
    public double PercentageOfDamage { get; set; }
    //czy tutaj:  public abstract void Accept(ICarPartVisitor visitor); i zaimplementowac ja  w np GravelTire  !!!!
    public void Accept(ICarPartVisitor computerPartVisitor)
    {
        computerPartVisitor.Visit(this);
    }
}
