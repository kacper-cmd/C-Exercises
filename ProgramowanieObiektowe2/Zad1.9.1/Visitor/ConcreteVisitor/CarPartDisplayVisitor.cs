using Zad1._9._1.Abstract;
using Zad1._9._1.Concrete;
using Zad1._9._1.Visitor.Visitor;

namespace Zad1._9._1.Visitor.ConcreteVisitor
{
    //// ConcreteVisitor -Implements each operation declared by the Visitor.
    public class CarPartDisplayVisitor : ICarPartVisitor
    {
        public void Visit(Tire tire)
        {
            Console.WriteLine($"Tire: {tire.Type} -> damage: {tire.PercentageOfDamage} %");
        }

        public void Visit(Engine engine)
        {
            Console.WriteLine($"Engine: {engine.Description} Power: {engine.EnginePower}");
        }

        public void Visit(Gearbox gearbox)
        {
            Console.WriteLine($"Gearbox type: {gearbox.Type}");
        }

        public void Visit(Car car)
        {
            Console.WriteLine($"Car {car.Brand} model: {car.Model} is driving with {car.Engine.Description} and {car.Gearbox.Type}.");
        }
    }
}
