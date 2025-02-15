var rnd = new Random();

var rndNumber = rnd.Next(1,100);

Console.WriteLine("Podaj Liczbę z zakresu 1 - 100");

var guesedNumber = -1;

while (guesedNumber != rndNumber)
{
    guesedNumber = int.Parse(Console.ReadLine());
    if (guesedNumber > rndNumber)
    {
        Console.WriteLine("większa");
    }
    if (guesedNumber < rndNumber)
    {
        Console.WriteLine("mniejsza");
    }
}
Console.WriteLine("Gratulacje !!!");
