using System.Diagnostics;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayChooseOption();
            Console.WriteLine("a) Z informacją (bool) czy udało się przekonwertować.");
            Console.WriteLine("b) Z komunikatem w przypadku niepowodzenia konwertowania.");
            Console.WriteLine("c) Dwie opcje: podanie wartości lub null.");
            string userChoice = Console.ReadLine();
            
            switch (userChoice.ToLower())
            {
                case "a":
                    ConvertWithBool();
                    break;
                case "b":
                    ConvertWithException();
                    break;
                case "c":
                    ConvertWithNull();
                    break;
                default:
                    Console.WriteLine("Nieprawidłowy wybór.");
                    break;
            }
        }
        static void DisplayChooseOption()
        {
            Console.WriteLine("Wybierz opcje:");
        }
        static void DisplayEnterValue()
        {
            Console.Write("Wprowadz wartość do konwersji: ");
        }
        static void ConvertWithBool()
        {
            DisplayEnterValue();
            string userInput = Console.ReadLine();
            if (int.TryParse(userInput, out int result))
            {
                Console.WriteLine($"Konwersja  {result}");
            }
            else
            {
                Console.WriteLine("Konwersja nieudana: false");
            }
        }
        static void ConvertWithException()
        {
            DisplayEnterValue();
            string userInput = Console.ReadLine();
            try
            {
                int result = int.Parse(userInput);
                var resultSecOption = Convert.ToInt32(userInput);
                Console.WriteLine($"Konwersja  {result}");
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Nie wprowadziles liczby calkowitej {e.Message}");
            }
        }

        static void ConvertWithNull()
        {
            DisplayChooseOption();
            Console.WriteLine("1) Podaj wartość");
            Console.WriteLine("2) Podaj null");
            string userChoice = Console.ReadLine();
            switch (userChoice?.ToLower())
            {
                case "1":
                    DisplayEnterValue();
                    string input = Console.ReadLine();
                    try
                    {
                        int result = Convert.ToInt32(input);
                        Console.WriteLine($"Konwersja {result}");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Blad konwersji.{e.Message}");
                    }
                    break;
                case "2":
                    int? nullValue = null;
                    int resultValue = nullValue ?? 0;
                    Console.WriteLine($"Konwersja ok: {resultValue}");
                    break;
                default:
                    Console.WriteLine("Nieprawidłowy wybór.");
                    break;
            }
        }
    }
}

