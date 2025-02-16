using System;

namespace ex_IIA4
{
    class Program
    {
        public static void ex_IIA4a()
        {
            const byte N = 3;
            const byte M = 5;

            Random generator = new Random();

            int[,] tab1 = new int[N, M];
            for (int i = 0; i<tab1.GetLength(0); i++)
            {
                for (int j = 0; j<tab1.GetLength(1); j++)
                {
                    tab1[i, j] = generator.Next(101);
                    Console.Write($"{tab1[i,j],4}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            int[] tab2 = new int[N * M];
            for (int i = 0; i<tab1.GetLength(0); i++)
            {
                for (int j = 0; j<tab1.GetLength(1); j++)
                {
                    tab2[i * M + j] = tab1[i, j];
                }
            }

            foreach (int i in tab2) Console.Write($"{i,4}");
            Console.WriteLine();
        }

        public static void ex_IIA4b()
        {
            const byte N = 3;

            Random generator = new Random();

            int[][] tab1 = new int[N][];
            for (int i = 0; i < tab1.Length; i++)
            {
                tab1[i] = new int[1+generator.Next(2*N)];
                for (int j = 0; j < tab1[i].Length; j++)
                {
                    tab1[i][j] = generator.Next(101);
                    Console.Write($"{tab1[i][j],4}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            int size = 0;
            foreach (int[] row in tab1) size += row.Length;

            int[] tab2 = new int[size];
            int k = 0;
            for (int i = 0; i < tab1.Length; i++)
            {
                for (int j = 0; j < tab1[i].Length; j++, k++)
                {
                    tab2[k] = tab1[i][j];
                }
            }

            foreach (int i in tab2) Console.Write($"{i,4}");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            ex_IIA4a();
            Console.WriteLine();

            ex_IIA4b();
        }   
    }
}
