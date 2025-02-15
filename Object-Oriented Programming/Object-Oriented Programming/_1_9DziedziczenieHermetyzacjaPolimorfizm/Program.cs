using _1_9DziedziczenieHermetyzacjaPolimorfizm;
using _1_9DziedziczenieHermetyzacjaPolimorfizm.Bodies;
using _1_9DziedziczenieHermetyzacjaPolimorfizm.Engines;
using _1_9DziedziczenieHermetyzacjaPolimorfizm.Suspections;
using _1_9DziedziczenieHermetyzacjaPolimorfizm.Tires;

var tires = new GravelTire[]
{
    new GravelTire(),
    new GravelTire(),
    new GravelTire(),
    new GravelTire()
};
var engine = new EightCylinder();
var suspection = new HighSuspension();
var body = new Hatchback();

var car = new Car(tires, engine, suspection, body, "Porshe");
CarAnalyzer.ShowCarProperties(car);
Console.WriteLine();
car.Engine.Work();
Console.WriteLine();
var amfibian = new Amfibian(tires, engine, suspection, body, "Porshe");
amfibian.Swim();