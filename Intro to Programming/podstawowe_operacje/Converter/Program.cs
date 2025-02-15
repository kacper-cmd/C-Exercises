Console.WriteLine("Podaj temperaturę w Celsjuszach:");
var celcjusTemperature = double.Parse(Console.ReadLine());

var farenheitTemperature = (celcjusTemperature * 9 / 5) + 32;
Console.WriteLine($"Temperatura w Farneheitah: " +
    $"{farenheitTemperature}");

var kelvinTemperature = celcjusTemperature + 273.15;
Console.WriteLine($"Temperatura w Kelwinach: " +
    $"{kelvinTemperature}");