using Zad1._9._1.Abstract;
using Zad1._9._1.Concrete;
namespace Zad1._9._1.Visitor.Visitor
{
    // Visitor - Defines a visit operation for each type of ConcreteElement
    public interface ICarPartVisitor
    {
        void Visit(Tire tire);
        void Visit(Engine engine);
        void Visit(Gearbox gearbox);
        void Visit(Car car);
    }
}