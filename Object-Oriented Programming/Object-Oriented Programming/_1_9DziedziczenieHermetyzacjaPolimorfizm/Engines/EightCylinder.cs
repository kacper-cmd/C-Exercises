namespace _1_9DziedziczenieHermetyzacjaPolimorfizm.Engines
{
    internal class EightCylinder : Engine
    {
        public EightCylinder()
        {
            EngineType = "silnik wyścigowy";
            Power = "1000KM";
        }
        public override void Work()
        {
            Console.WriteLine("Wrrrrrrrrrum");
        }
    }
}
