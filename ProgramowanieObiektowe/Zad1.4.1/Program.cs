public class Program
{
    public static void Main()
    {
        Methods methods = new Methods();

        Console.WriteLine(methods.Scream("Czesc ", "!")); 
        Console.WriteLine(methods.Scream("Czesc "));
        
        int[] numbers = { 1, 2, 3, 4, 5 };
        Array array = new Array();

        Console.WriteLine("Array before:");
        
        foreach (var number in numbers)
        {
            Console.Write(number + " ");
        }

        Console.WriteLine();
        array.MultiplyByTwo(numbers);

        Console.WriteLine("Array after:");
        foreach (var number in numbers)
        {
            Console.Write(number + " ");
        }
    }
}

