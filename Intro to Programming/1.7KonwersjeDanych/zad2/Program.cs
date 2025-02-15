using System.Globalization;

StartMenu();

static void StartMenu()
{
    Console.Write("Podaj dzień: ");
    var day = int.Parse(Console.ReadLine());
    Console.Write("Podaj miesiąc: ");
    var month = int.Parse(Console.ReadLine());
    Console.Write("Podaj rok: ");
    var year = int.Parse(Console.ReadLine());
    Console.Write("Podaj godzinę: ");
    var hour = int.Parse(Console.ReadLine());
    Console.Write("Podaj minutę: ");
    var minute = int.Parse(Console.ReadLine());

    try
    {
        var date = new DateTime(year, month, day, hour, minute, 0);
        Console.WriteLine();
        Console.WriteLine("1) Wyświetl datę i godzinę w formacie US");
        Console.WriteLine("2) Wyświetl datę i godzinę w formacie Francuskim");
        Console.WriteLine("3) Wyświetl datę i godzinę w formacie Niemieckim");

        var optionNumber = int.Parse(Console.ReadLine());

        switch (optionNumber)
        {
            case 1:
                Console.WriteLine(date.ToString("dd MMMM yyyy hh mm", CultureInfo.CreateSpecificCulture("en-US")));
                break;
            case 2:
                Console.WriteLine(date.ToString("dd MMMM yyyy hh mm", CultureInfo.CreateSpecificCulture("fr-FR")));
                break;
            case 3:
                Console.WriteLine(date.ToString("dd MMMM yyyy hh mm", CultureInfo.CreateSpecificCulture("de-DE")));
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(false);
        Thread.Sleep(2000);
        Console.Clear();
        Console.WriteLine("               PODAJ POPRAWNĄ DATĘ\n");
        StartMenu();
    }
}