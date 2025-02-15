int sum = 0;

int numberFromUser = 0;
bool isValidNumber;

Console.WriteLine("Wprowadź liczby całkowite, gdy wcisniesz 0 skonczy sie wprowadzanie:");

do
{
    Console.Write("Podaj liczbę: ");
    string userInput = Console.ReadLine();
    isValidNumber = int.TryParse(userInput, out numberFromUser);
    if (isValidNumber)
    { 
        sum += numberFromUser;
    }
    else
    {
        Console.WriteLine("Wpisz prawidlowa liczbe !!.");
    }
} while (numberFromUser != 0 || !isValidNumber);
Console.WriteLine($"Suma wprowadzonych liczb wynosi: {sum}");