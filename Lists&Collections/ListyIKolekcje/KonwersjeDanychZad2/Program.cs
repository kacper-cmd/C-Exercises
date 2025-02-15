using KonwersjeDanychZad2.Helpers;
using System.Globalization;
class Program
{
    /// <summary>
    /// https://www.meziantou.net/difference-between-cultureinfo-get-and-new-cultureinfo.htm
    /// </summary>
    static void Main()
    {
        while (true)
        {
            try
            {
                Console.WriteLine("Podaj dzień:");
                int day = int.Parse(Console.ReadLine());

                Console.WriteLine("Podaj miesiąc:");
                var monthInput = Console.ReadLine();
                if (!DateValidator.isValidMonth(monthInput, out int month))
                {
                    throw new FormatException($"Nieprawidlowy miesiac {monthInput}");
                }

                Console.WriteLine("Podaj rok:");
                int year = int.Parse(Console.ReadLine());

                Console.WriteLine("Podaj godzinę:");
                var hourInput = Console.ReadLine();
                if (!DateValidator.isValidHour(hourInput, out int hour))
                {
                    throw new FormatException($"Nieprawidlowa godzina {hourInput}");
                }


                Console.WriteLine("Podaj minuty:");
                var minuteInput = Console.ReadLine();
                if (!DateValidator.isValidMinute(minuteInput, out int minute))
                {
                    throw new FormatException($"Nieprawidlowe minuty {minuteInput}");
                }

                DateTime date = new DateTime(year, month, day, hour, minute, 0);

                Console.WriteLine("Wybierz opcję formatu daty:");
                Console.WriteLine("a) US format");
                Console.WriteLine("b) Francuski format");
                Console.WriteLine("c) Niemiecki format");

                string userChoice = Console.ReadLine();

                switch (userChoice?.ToLower())
                {
                    case "a":
                        Console.WriteLine("Format US: " + date.ToString("MM/dd/yyyy hh:mm tt", new CultureInfo("en-US")));//CultureInfo.InvariantCulture
                        break;
                    case "b":
                        Console.WriteLine("Format Francuski: " + date.ToString("dd/MM/yyyy HH:mm", new CultureInfo("fr-FR")));
                        //  Console.WriteLine("Format Francuski: " + date.ToString("dd/MM/yyyy HH:mm", CultureInfo.GetCultureInfo("fr-FR")));
                        break;
                    case "c":
                        Console.WriteLine("Format Niemiecki: " + date.ToString("dd.MM.yyyy HH:mm", new CultureInfo("de-DE")));
                        break;
                    default:
                        Console.WriteLine("Niepoprawna wybór. Popraw się !");
                        break;
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"FALSE-> {ex.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine("FALSE");
            }
        }
    }
}