public class Program
{
    public static List<int> GenerateListFrom0To9(int size)
    {
        List<int> numberList = new List<int>();
        for (int i = 0; i < size; i++)
        {
            numberList.Add(i % 10);
        }
        return numberList;
    }
    public static void Main()
    {
        Console.WriteLine("Podaj wielkość listy (n):");
        int size = Convert.ToInt32(Console.ReadLine());
        List<int> result = GenerateListFrom0To9(size);
        Console.WriteLine("Wynik:");
        foreach (int number in result)
        {
            Console.Write(number + " ");
        }
    }
}
