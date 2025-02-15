namespace _1_9DziedziczenieHermetyzacjaPolimorfizm.Engines
{
    internal class ThreeCylinder : Engine
    {
        public ThreeCylinder()
        {
            EngineType = "silnik eko";
            Power = "130KM";
        }
        public override void Work()
        {
            Console.WriteLine("Wrum");
        }
    }
}
