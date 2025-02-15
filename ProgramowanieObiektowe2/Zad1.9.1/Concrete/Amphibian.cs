using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zad1._9._1.Abstract;

namespace Zad1._9._1.Concrete
{
    public class Amphibian : Car, ISwim
    {
        public Amphibian(string brand, string model, Engine engine, Gearbox gearbox, List<Tire> tires) : base(brand, model, engine, gearbox, tires)
        {
        }
        public override void Drive()
        {
            int count = 0;
            foreach (Tire ti in Tires)
            {
                if (ti.PercentageOfDamage > 95)
                {
                    throw new ArgumentException($"Your {Brand} cannot drive your {count} tires is damage in {ti.PercentageOfDamage} %. You might be dead !!");
                }
                count++;
            }
            Console.WriteLine($"Car {Brand} model: {Model} is driving on land with {Engine.Description} and {Gearbox.Type}.");
        }
        public void Swim()
        {
            Console.WriteLine($"Car {Brand} model: {Model} is swimming.");
        }      
    }
}
