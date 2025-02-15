Console.Write("Podaj wysokość choinki: ");
var height = int.Parse(Console.ReadLine());

for (int i = 0; i < height; i++)
{
    for (int j = 0; j < height-i; j++)
        Console.Write(" ");
    for (int j = 0; j < i*2+1; j++)
        Console.Write("*");
    Console.WriteLine();
}
