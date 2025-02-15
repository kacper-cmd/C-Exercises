Console.WriteLine("----Wybierz metodę konwersji----");
Console.WriteLine();
Console.WriteLine("1) Z informacją (bool) czy udało się  przekonwertować podany ciąg znaków i\n" +
    "  podaniem przekonwertowanej liczby w przypadku powodzenia, w innym przypadku false.");
Console.WriteLine();
Console.WriteLine("2) Z komunikatem „Podana wartość nie jest liczbą całkowitą” w przypadku\n" +
    "  nie powodzenia konwertowania. A w przypadku poprawnej konwersji wypisze liczbę całkowitą.");
Console.WriteLine();
Console.WriteLine("3) Po wyborze tej opcji, użytkownik będzie miał dwie opcję do wyboru: \n" +
    "  podanie wartości z konsoli, podanie null do konwertowania. W przypadku podania wartości,\n" +
    "  którą da się przekonwertować aplikacja wyświetli liczbę całkowitą, w przypadku podania \n" +
    "  null aplikacja wypisze zero. W przypadku podanie nieprawidłowej wartości wyrzuci wyjątek\n" +
    "  z informację że nie da się przekonwertować podanej wartości. ");

var optionNumber = int.Parse(Console.ReadLine());

Console.Clear();

switch (optionNumber)
{
    case 1:
        FirstOption();
        break;
    case 2:
        SecondOption();
        break;
    case 3:
        ThirdOption();
        break;
}

static void FirstOption()
{
    Console.Write("Podaj ciąg znaków do konwersji: ");
    int number;
    var success = int.TryParse(Console.ReadLine(), out number);
    if (success)
    {
        Console.WriteLine($"Udało się przekonwertować: {number}!");
    }
    else
    {
        Console.WriteLine(false);
    }
}

static void SecondOption()
{
    Console.Write("Podaj ciąg znaków do konwersji: ");
    try
    {
        var number = int.Parse(Console.ReadLine());
        Console.WriteLine($"Udało się przekonwertować: {number}!");
    }
    catch (Exception ex)
    {
        Console.WriteLine("Podana wartość nie jest liczbą całkowitą");
    }
}

static void ThirdOption()
{
    Console.Write("Podaj ciąg znaków do konwersji: ");
    var valueToConvert = Console.ReadLine();

    if (string.IsNullOrEmpty(valueToConvert))
    {
        Console.WriteLine(0);
    }
    else
    {
        int number;
        var success = int.TryParse(valueToConvert, out number);

        if (!success)
        {
            throw new Exception("Nie da się przekonwertować tej wartości!");
        }
        else
        {
            Console.Write("Wynik konwersji:");
            Console.WriteLine(number);
        }
    }
}