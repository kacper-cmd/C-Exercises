using System;

namespace delegates_2a
{

    public delegate int NavigationMethod(int[,] dataTab, int index);

    class TableNavigable
    {
     // 2-dimensional table data
        int[,] data;

     // method of "walking" over the table
        NavigationMethod navMethod;

        public TableNavigable(int[,] d, NavigationMethod nav)
        {
            data = new int[d.GetLength(0), d.GetLength(1)];
            for (int i = 0; i < d.GetLength(0); i++) 
                for (int j = 0; j < d.GetLength(1); j++) data[i, j] = d[i, j];
            navMethod = nav;
        }

        public void PrintAsSequence()
        {            
            // below we invoke a delegate object of name 'navMethod', which delegates some function
            // to visit all elements of 2-dimensional array using only one index
            for (int i = 0; i < data.GetLength(0) * data.GetLength(1); i++)
                Console.Write("{0} ", navMethod(data, i));
        }

    }
    
    // below class defined various ways to return an element of 2-dimensional array
    // based on only one index
    static class NavigationMethods
    {
        public static int ByRowsFromLeft(int[,] tab2D, int idx)
        {
            return tab2D[idx / tab2D.GetLength(0), idx % tab2D.GetLength(0)];
        }
        public static int SpirallyFromLeft(int[,] tab2D, int idx)
        {
            int rowIdx = idx / tab2D.GetLength(0);
            int colIdx = rowIdx % 2 == 0 ? idx % tab2D.GetLength(1) : tab2D.GetLength(1)-1 - idx % tab2D.GetLength(1);
            return tab2D[rowIdx, colIdx];
        }
        public static int ByRowsFromRight(int[,] tab2D, int idx)
        {
            return tab2D[idx / tab2D.GetLength(0), tab2D.GetLength(1)-1-idx % tab2D.GetLength(1)];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[,] testArray = new int[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };

            TableNavigable test = new TableNavigable(testArray, NavigationMethods.ByRowsFromLeft);
            test.PrintAsSequence();
            Console.WriteLine();

            TableNavigable test2 = new TableNavigable(testArray, NavigationMethods.SpirallyFromLeft);
            test2.PrintAsSequence();
            Console.WriteLine();

            TableNavigable test3 = new TableNavigable(testArray, NavigationMethods.ByRowsFromRight);
            test3.PrintAsSequence();

            Console.ReadLine();
        }
    }
}
