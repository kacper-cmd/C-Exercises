Console.WriteLine("Podaj liczbę całkowitą dodatnią");
var number = int.Parse(Console.ReadLine());
for (int i = 0; i <= number; i++)
{
    if (i % 2 == 0)
    {
        Console.WriteLine(i);
    };
}