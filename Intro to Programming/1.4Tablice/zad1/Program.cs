Console.Write("Podaj wielkość tablicy: ");
var size = int.Parse(Console.ReadLine());

var array = new int[size];
for (var i = 0; i < size; i++)
{
    array[i] = int.Parse(Console.ReadLine());
}

Console.WriteLine("Uporządkowanie elementów w tablicy od najmniejszego do największego i wypisanie ich - 1");
Console.WriteLine("Uporządkowanie elementów tablicy od największego do najmniejszego i wypisanie ich - 2");
Console.WriteLine("Wypisanie największego i najmniejszego elementu - 3");
Console.WriteLine("Wypisanie elementu o podanym nr indexu (po wybraniu tej opcji aplikacja wypiszę dostępne indexy elementów) - 4");
Console.WriteLine("Zastąpienie elementu o podanym indexie, nowym elementem - 5");
var taskNumber = int.Parse(Console.ReadLine());

switch (taskNumber)
{
    case 1:
        Console.WriteLine(string.Join(" ", array.OrderBy(x => x)));
        break;
    case 2:
        Console.WriteLine(string.Join(" ", array.OrderByDescending(x => x)));
        break;
    case 3:
        var greatestElement = array.Max();
        var smallestElement = array.Min();
        Console.WriteLine($"Największy: {greatestElement}");
        Console.WriteLine($"Najmniejszy: {smallestElement}");
        break;
    case 4:
    case 5:
        Console.Write("Wyierz numer indeksu: ");
        var choosenIndex = int.Parse(Console.ReadLine());
        if (choosenIndex < 0 || choosenIndex >= size)
        {
            Console.WriteLine("Index poza zakresem!");
        }
        else
        {
            switch (taskNumber)
            {
                case 4:
                    Console.WriteLine($"Element o podanym indeksie {array[choosenIndex]}");
                    Console.Write($"Dostępne indexy: ");
                    var indexList = Enumerable.Range(0, choosenIndex).Select(x => x);
                    Console.WriteLine(string.Join(" ", indexList.Where(i => i != choosenIndex)));
                    break;
                case 5:
                    Console.Write("Wpisz nową wartość dla indeksu: ");
                    array[choosenIndex] = int.Parse(Console.ReadLine());
                    Console.Write("Zaktualizowana Tablica: ");
                    Console.WriteLine(string.Join(" ", array));
                    break;
            }
        }

        break;
    default:
        Console.WriteLine("Wrong number");
        break;
}

