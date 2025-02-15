try
{
    Console.WriteLine("Podaj masę ciała (w kilogramach)");
    var weight = float.Parse(Console.ReadLine());
    Console.WriteLine("Podaj wzrost (w metrach)");
    var height = float.Parse(Console.ReadLine());
    var bmi = weight / Math.Pow(height, 2);
    Console.WriteLine($"Bmi wynosi {bmi}");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

