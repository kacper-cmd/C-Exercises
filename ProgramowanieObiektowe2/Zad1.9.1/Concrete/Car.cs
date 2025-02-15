using Zad1._9._1.Abstract;
using Zad1._9._1.Visitor.Visitor;

namespace Zad1._9._1.Concrete
{
    public class Car : IDrive
    {
        #region Fields&Properties
        public string Brand { get; set; }
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Gearbox Gearbox { get; set; }

        private List<Tire> tires = new List<Tire>();
        public List<Tire> Tires
        {
            get => tires;
            set
            {
                if (value.Count == 4)
                {
                    tires = value;
                }
                else
                {
                    throw new ArgumentException("Car must have 4 tires!!");
                }
            }
        }

        #endregion

        #region Constructors
        public Car(string brand,string model, Engine engine, Gearbox gearbox, List<Tire> tires)
        {
            Brand = brand;
            Model = model;
            Engine = engine;
            Gearbox = gearbox;
            Tires = tires;
        }

        #endregion

        #region Methods
        public virtual void Drive()
        {
            int count = 0;
            foreach (Tire ti in Tires)
            {
                if(ti.PercentageOfDamage > 95)
                {
                    throw new ArgumentException($"Your {Brand} cannot drive your {count} tires is damage in {ti.PercentageOfDamage} %. You might be dead !!");
                }
                count++;
            }
            Console.WriteLine($"Car {Brand} model: {Model} is driving with {Engine.Description} and {Gearbox.Type}.");
        }

        public void Brake()
        {
            Console.WriteLine($"Car {Brand} model: {Model}  is braking.");
        }

        public void Turn(string direction)
        {
            Console.WriteLine($"Car {Brand} model: {Model}  is turning {direction}.");
        }

        public void DisplayInfo()
        {
            string tiresType = string.Empty;
            int tiresCounter = 1;
            foreach (Tire ti in Tires)
            {
                tiresType +=  "\n"+ tiresCounter + " type: " + ti.Type + " -> damage " + ti.PercentageOfDamage + " %";
                tiresCounter++;
            }

            Console.WriteLine($"The car model {Model} and brand {Brand}, has a {Engine.Description}, {Gearbox.Type}, and i have {Tires.Count} tires : {tiresType}.");
        }
        #endregion

        #region Visitor
        public void Accept(ICarPartVisitor visitor)
        {
            visitor.Visit(this);
            Engine.Accept(visitor);
            Gearbox.Accept(visitor);
            foreach (var tire in Tires)
            {
                tire.Accept(visitor);
            }
        }
        #endregion

    }


}
