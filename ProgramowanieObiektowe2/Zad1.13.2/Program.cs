using System.Collections.Immutable;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        try
        {
            const int rowSize = 10;
            const int colSize = 10;
            Matrix matrix1 = new Matrix(rowSize, colSize);
            Matrix matrix2 = new Matrix(rowSize, colSize);
            Random rand = new Random();

            for (int i = 0; i < rowSize; i++)
            {
                for (int j = 0; j < colSize; j++)
                {
                    matrix1[i, j] = rand.Next(1,100);
                }
            }
            for (int i = 0; i < rowSize; i++)
            {
                for (int j = 0; j < colSize; j++)
                {
                    matrix2[i, j] = rand.Next(1, 100);
                }
            }
            Matrix sum = matrix1 + matrix2;
            Console.WriteLine("\t\t Operator +");
            Console.WriteLine(sum.ToString());
            
            Matrix difference = matrix1 - matrix2;
            Console.WriteLine("\t\t Operator -");
            Console.WriteLine(difference.ToString());

            Matrix product = matrix1 * 3;
            Console.WriteLine("\t\t Operator * 3");
            Console.WriteLine( product.ToString());
            Matrix product1 = 8 * matrix1;
            Console.WriteLine("\t\t Operator 8 * ");
            Console.WriteLine( product1.ToString());
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine("Error " + e.Message);
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine("Error " +e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error " + e.Message);
        }
        
    }
}