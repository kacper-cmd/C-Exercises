namespace TabliceZad3;
class Program
{
    /// <summary>
    /// SOURCE https://www.blackwasp.co.uk/EuclidsAlgorithm.aspx
    /// </summary>
    /// <param name="value1"></param>
    /// <param name="value2"></param>
    /// <returns></returns>
    public static int GreatestCommonDivisor(int value1, int value2)
    {
        while (value1 != 0 && value2 != 0)
        {
            if (value1 > value2)
                value1 -= value2;
            else
                value2 -= value1;
        }
        var result = Math.Max(value1, value2);
        return result;
    }
    static void Main()
    {
        int arraySize;
        Console.Write("Podaj liczbę (> 0): ");
        if (int.TryParse(Console.ReadLine(), out arraySize) && arraySize > 0)
        {
            bool[,] array = new bool[arraySize, arraySize];

            for (int i = 0; i < arraySize; i++)
            {
                for (int j = 0; j < arraySize; j++)
                {
                    bool isNumbersPrime = GreatestCommonDivisor(i + 1, j + 1) == 1;
                    array[i, j] = isNumbersPrime;
                }
            }
            Console.Write("    ");
            for (int i = 1; i <= arraySize; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.Write((i + 1) + "   ");
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] ? "+" : ".");
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Nieprawidłowe dane!");
        }
    }
}