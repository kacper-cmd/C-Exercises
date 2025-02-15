namespace _1_9DziedziczenieHermetyzacjaPolimorfizm
{
    internal static class CarAnalyzer
    {
        public static void ShowCarProperties(Car car)
        {
            Console.WriteLine($"Marka Samochodu: {car.CarBrand}");
            ShowBodyProperties(car);
            ShowTiresProperties(car);
            ShowEngineProperties(car);
            ShowSuspensionProperties(car);
        }
        public static void ShowBodyProperties(Car car)
        {
            Console.WriteLine($"Typ Karoserii: {car.Body.BodyType}");
        }
        public static void ShowTiresProperties(Car car)
        {
            Console.WriteLine($"Typ Opony: {car.Tires.FirstOrDefault().TireType}");
        }
        public static void ShowEngineProperties(Car car)
        {
            Console.WriteLine($"Typ Silnika: {car.Engine.EngineType}");
            Console.WriteLine($"Moc Silnika: {car.Engine.Power}");

        }
        public static void ShowSuspensionProperties(Car car)
        {
            Console.WriteLine($"Typ Zawieszenia: {car.Suspension.SuspensionType}");
        }
    }
}
