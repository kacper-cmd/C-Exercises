using _1_9DziedziczenieHermetyzacjaPolimorfizm.Bodies;
using _1_9DziedziczenieHermetyzacjaPolimorfizm.Engines;
using _1_9DziedziczenieHermetyzacjaPolimorfizm.Suspections;
using _1_9DziedziczenieHermetyzacjaPolimorfizm.Tires;

namespace _1_9DziedziczenieHermetyzacjaPolimorfizm
{
    internal class Amfibian : Car
    {
        public Amfibian(IEnumerable<Tire> tires,
            Engine engine,
            Suspension suspension,
            Body body,
            string carBrand
            ) :
            base(tires, engine, suspension, body, carBrand)
        {
        }
        public void Swim()
        {
            Console.WriteLine("Bul bul bul..");
        }
    }
}
