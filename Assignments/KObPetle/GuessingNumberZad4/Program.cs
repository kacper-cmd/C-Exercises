Random random = new Random();

int numberToGuess = random.Next(1, 101);

int userGuess = 0;
Console.WriteLine("Zadanie 4 -  Petle");
Console.WriteLine("Losuje liczbę z zakresu od 1 do 100.");
Console.WriteLine("Zgadnij jaka to liczba!");
while (userGuess != numberToGuess)
{
    Console.Write("Wpisz liczbę: ");

    if (int.TryParse(Console.ReadLine(), out userGuess))
    {
        if (userGuess > numberToGuess)
        {
            Console.WriteLine("Większa");
        }
        else if (userGuess < numberToGuess)
        {
            Console.WriteLine("Mniejsza");
        }
        else
        {
          
            Console.WriteLine("Gratulacje !!!");
        }
    }
    else
    {
        Console.WriteLine("Powinienieś wpisac liczbę !! - Spróbuj ponownie");
    }
}