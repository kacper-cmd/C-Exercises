namespace _1_9DziedziczenieHermetyzacjaPolimorfizm.Engines
{
    internal class FiveCylinder : Engine
    {
        public FiveCylinder()
        {
            EngineType = "silnik nromalny";
            Power = "500KM";
        }
        public override void Work()
        {
            Console.WriteLine("Wrrrum");
        }
    }
}
