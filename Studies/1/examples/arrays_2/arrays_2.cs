using System;
using System.Text;

namespace arrays_2
{
    class Test
    {
        static void Main(string[] args)
        {
          
          // 2-dimensional, regular arrays
          // =================================
            Console.WriteLine("\nTwo-dimensional array\n");
            int[,] tab1;
            //int[,] tab1 = { {11, 111}, {12, 222}, {13, 333}, {14, 444} };
                        
            // initialization
            tab1 = new int[,] { { 11, 111 }, { 12, 222 }, { 13, 333 }, { 14, 444 } };
            /*
            tab1 = new int[4, 2];
            Random generator = new Random();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 2; j++) tab1[i,j] = generator.Next(1000);
            */

            // printing            
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 2; j++) Console.Write("{0,5}", tab1[i,j]);
                Console.WriteLine();
            }


            // jagged arrays (arrays of arrays)
            // =================================
            Console.WriteLine("\nJagged array\n");
            int[][] tab2;
            //int[][] tab2 = { new int[] { 11 }, new int[] { 12, 22 }, 
            //                     new int[] { 13, 23, 33 }, new int[] { 14, 24, 34, 44 } };
            
            // initialization
            tab2 = new int[][] { new int[] { 11 }, new int[] { 12, 22 }, 
                                 new int[] { 13, 23, 33 }, new int[] { 14, 24, 34, 44 } 
                               };
            /*
            tab2 = new int[4][];
            Random generator = new Random();
            for (int i = 0; i < 4; i++)
            {
                tab2[i] = new int[i+1];
                for (int j = 0; j < i+1; j++) tab2[i][j] = generator.Next(1000);
            }
            */

            // printing
            foreach (int[] row in tab2)
            {
                foreach (int element in row) Console.Write("{0,5}", element);
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
