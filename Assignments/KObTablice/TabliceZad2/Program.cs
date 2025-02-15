namespace TabliceZad2;
class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();

        int[] array = new int[20];

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(1, 11);//od 1 do 10
        }
        
        Console.WriteLine("Utworzona tablica:");
        Console.WriteLine(string.Join(", ", array));

        int[] arrayForCountingOccurrencesOfNumbers = new int[10];
        //for (int i = 0; i < array.Length; i++)
        //{
        //    arrayForCountingOccurrencesOfNumbers[array[i] - 1]++;
        //}

        foreach (int number in array)
        {
            arrayForCountingOccurrencesOfNumbers[number - 1]++;//0 do 9
        }

        Console.WriteLine("\nLiczba wystąpień każdej liczby z przedziału od 1 do 10:");
        for (int i = 0; i < arrayForCountingOccurrencesOfNumbers.Length; i++)
        {
            Console.WriteLine($"Liczba: ( {i + 1} ) wystapila: {arrayForCountingOccurrencesOfNumbers[i]}" +
                (arrayForCountingOccurrencesOfNumbers[i] == 1 ?" raz": " razy") );
        }
    }
}