using Zad1._9._1.Visitor.Visitor;

namespace Zad1._9._1.Visitor.Element
{
    // Element - Defines an Accept operation that takes a visitor as an argument.
    public interface ICarPart
    {
        void Accept(ICarPartVisitor computerPartVisitor);
    }
}
