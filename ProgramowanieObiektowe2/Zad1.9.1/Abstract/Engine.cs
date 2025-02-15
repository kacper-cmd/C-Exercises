using Zad1._9._1.Visitor.Element;
using Zad1._9._1.Visitor.Visitor;

public abstract class Engine : ICarPart //ConcreteElement: Implements the Accept operation.
{
    public abstract string EnginePower {  get; }
    public abstract string Description { get; }
    public void Accept(ICarPartVisitor computerPartVisitor)
    {
        computerPartVisitor.Visit(this);
    }
}
