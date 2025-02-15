using Zad1._9._1.Visitor.Element;
using Zad1._9._1.Visitor.Visitor;

namespace Zad1._9._1.Abstract
{
    //skrzynia biegow
    public abstract class Gearbox : ICarPart
    {
        public abstract string Type { get; }
        public void Accept(ICarPartVisitor computerPartVisitor)
        {
            computerPartVisitor.Visit(this);
        }
    }

}
