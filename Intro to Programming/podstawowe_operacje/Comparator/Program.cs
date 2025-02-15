try
{
    Console.WriteLine("Podaj dwie liczby całkowite:");
    int a;
    var aSuccess = int.TryParse(Console.ReadLine(), out a);
    int b;
    var bSuccess = int.TryParse(Console.ReadLine(), out b);

    if (aSuccess == true && bSuccess == true)
    {
        ChooseOperation(a, b);
    }
    else
    {
        Console.WriteLine($"Zły format liczb");
        return;
    }

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

static void CheckGreater(int a, int b)
{
    var greaterNumber = b > a ? b : a;
    Console.WriteLine($"większa liczba to {greaterNumber}");
}

static void CeckEquality(int a, int b)
{
    var equality = a == b;
    var equalityText = (equality == true) ? "są" : "nie są";
    Console.WriteLine($"liczby {equalityText} równe");
}

static void CheckUnequality(int a, int b)
{
    var unequality = b != a;
    var equalityText = (unequality == true) ? "są" : "nie są";
    Console.WriteLine($"liczby {equalityText} różne");
}

static void ChooseOperation(int a, int b)
{
    Console.WriteLine("Wybierz operację: \n" +
        "Sprawdzenie czy liczby są równe - 1\n" +
        "Sprawdzenie czy podane liczby są różne - 2\n" +
        "Sprawdzenie która liczba jest większa - 3\n");

    var operationNumber = int.Parse(Console.ReadLine());

    switch (operationNumber)
    {
        case 1:
            CeckEquality(a, b);
            break;
        case 2:
            CheckUnequality(a, b);
            break;
        case 3:
            CheckGreater(a, b);
            break;
    }
}