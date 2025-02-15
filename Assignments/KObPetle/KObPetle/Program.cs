Console.Write("Wprowadz liczbę całkowitą dodatnią: ");
string userInput = Console.ReadLine();
if (int.TryParse(userInput, out int number) && number > 0)
{
    Console.WriteLine($"Poniżej liczby parzyste nie większe od podanej liczby: {userInput}");
    for (int i = 2; i <= number; i += 2)
    {
        Console.Write(i + "\t");
    }
}
else
{
    Console.WriteLine("Wprowadziłeś nieprawidłową liczbę niespelniającą założeń");
}