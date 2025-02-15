using Zad1._9._1.Abstract;
using Zad1._9._1.Concrete;
using Zad1._9._1.Visitor.ConcreteVisitor;

public class Program
{
    public static void Main()
    {
        try
        {
            Engine racingEngine = new RacingEngine();
            Gearbox gearbox = new AutomaticGearbox();
            List<Tire> gravelTires = new List<Tire> { new GravelTire(12), new GravelTire(43), new GravelTire(24), new GravelTire(23) };

            Car car = new Car("Porshe", "911 Turbo S", racingEngine, gearbox, gravelTires);
            car.DisplayInfo();
            car.Drive();
            car.Turn("right");
            car.Brake();

            Console.WriteLine();
            Gearbox gearboxManual = new ManualGearbox();
            List<Tire> winterTires = new List<Tire> { new WinterTyres(42), new WinterTyres(91), new WinterTyres(64), new WinterTyres(43) };

            Amphibian amphibiousCar = new Amphibian("Amphibian Corpo", "DASP-23", racingEngine, gearboxManual, winterTires);
            amphibiousCar.DisplayInfo();
            amphibiousCar.Drive();
            amphibiousCar.Turn("right");
            amphibiousCar.Brake();
            amphibiousCar.Swim();


            #region Visitor
            Console.WriteLine();
            //https://medium.com/@lexitrainerph/visitor-pattern-in-c-from-basics-to-advanced-55c39534cd94
            CarPartDisplayVisitor lister = new CarPartDisplayVisitor();

            Console.WriteLine("Car Visitor:");
            car.Accept(lister);

            Console.WriteLine("\nAmphibious Car Visitor:");
            amphibiousCar.Accept(lister);
            #endregion



        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error -> {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error -> {ex.Message}");

        }
    }
}
