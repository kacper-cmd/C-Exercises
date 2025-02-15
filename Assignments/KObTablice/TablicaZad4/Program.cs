namespace TablicaZad4;
class Program
{
    static void Main(string[] args)
    {

        int[] array1 = new int[2] { 1, 2 };
        int[] array2 = new int[2] { 3, 5 };
        int[] mergedArray = new int[4];

        for (int i = 0; i < array1.Length; i++)
        {
            mergedArray[i] = array1[i];
        }
        for (int i = 0; i < array2.Length; i++)
        {
            mergedArray[array1.Length + i] = array2[i];
        }
        Console.WriteLine("Trzecia tablica polaczona:");
        foreach (int item in mergedArray)
        {
            Console.Write(item + " ");
        }
    }
}
