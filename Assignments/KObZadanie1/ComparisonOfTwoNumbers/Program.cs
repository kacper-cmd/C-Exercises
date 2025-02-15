namespace ComparisonOfTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj pierwszą liczbę całkowitą:");
            string firstNumberFromUser = Console.ReadLine();
            Console.WriteLine("Podaj drugą liczbę całkowitą:");
            string secondNumberFromUser = Console.ReadLine();

            if (int.TryParse(firstNumberFromUser, out int number1) && int.TryParse(secondNumberFromUser, out int number2))
            {
                Console.WriteLine("Wybierz jedna z ponizszych operacji (wprowadz numer):");
                Console.WriteLine("1 - Sprawdzenie czy liczby są równe");
                Console.WriteLine("2 - Sprawdzenie czy podane liczby są różne");
                Console.WriteLine("3 - Sprawdzenie która liczba jest większa");
                string userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        if (number1 == number2)
                        {
                            Console.WriteLine("Liczby są równe (=).");
                        }
                        else
                        {
                            Console.WriteLine("Liczby nie są równe.");
                        }
                        break;
                    case "2":
                        if (number1 != number2)
                        {
                            Console.WriteLine("Liczby są różne (!=).");
                        }
                        else
                        {
                            Console.WriteLine("Liczby nie są różne.");
                        }
                        break;
                    case "3":
                        if (number1 > number2)
                        {
                            Console.WriteLine($"Liczba {number1} jest większa od {number2}.");
                        }
                        else if (number1 < number2)
                        {
                            Console.WriteLine($"Liczba {number2} jest większa od {number1}.");
                        }
                        else
                        {
                            Console.WriteLine("Liczby są równe.");
                        }
                        break;
                    default:
                        Console.WriteLine("Dokonales nieprawidłowego wybóru :(.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Nieprawidłowy format ! Musisz wprowadzic liczbę z klawiatury");
            }
        }
    }
}


