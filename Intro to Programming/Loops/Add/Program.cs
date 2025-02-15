var sum = 0;

var number = -1;

while (number != 0)
{
    Console.Write("podaj liczbę całkowitą: ");
    number = int.Parse(Console.ReadLine());
    sum += number;
}

Console.WriteLine($"Suma podanych liczb to: {sum}");
