Console.Write("Wprowadz temperature w stopniach Celcjusza: ");
double celsius = Convert.ToDouble(Console.ReadLine());
double fahrenheit = ((celsius * 9) / 5) + 32;
double kelvin = celsius + 273;
Console.WriteLine($"Podana temp wynosi : {fahrenheit} F");
Console.WriteLine($"Podana temp wynosi : {kelvin} K");
Console.ReadLine();

