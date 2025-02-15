Console.Write("Podaj dochód: ");
var income = double.Parse(Console.ReadLine());

var tax = (income <= 85528) ? income * 18 / 100 : income * 32 / 100;

Console.WriteLine($"Podatek do opłacenia wynosi {tax} zł");