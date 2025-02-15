using System.Diagnostics;
int treeHeight, x, y, z;
bool resultOfParsing;
Stopwatch sw;
do
{
    do
    {
        Console.Write("Wprowadz liczbe wierszy - wysokosc choinki\n");
        resultOfParsing = int.TryParse(Console.ReadLine(), out treeHeight);
        string errorMessage = string.Empty;
        if (!resultOfParsing)
        {
            errorMessage = "!Dane niepoprawne wprowadź liczbę! ";
        }
        if (treeHeight <= 0)
        {
            errorMessage += "Wysokość musi byc wieksza od zera !";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorMessage);
            Console.ResetColor();
        }
    } while (!resultOfParsing || treeHeight <= 0);
    sw = Stopwatch.StartNew();
    for (x = 1; x <= treeHeight; x++)
    {
        for (y = x; y < treeHeight; y++)
        {
            Console.Write(" ");
        }
        for (z = 1; z < (x * 2); z++)
        {
            Console.Write("*");
        }
        Console.WriteLine();
    }
    sw.Stop();
    Console.WriteLine($"Wypisywanie na konsole trwalo {sw.ElapsedMilliseconds}");
    Console.WriteLine("Aby zakonczyc wcisnij n");
    var choice = Console.ReadLine();
    if (choice == "n")
    {
        break;
    }
} while (true);

Console.ReadLine();