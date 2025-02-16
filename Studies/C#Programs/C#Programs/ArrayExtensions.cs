using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Programs
{
    public static class ArrayExtensions
    {
        public static T[][] Transpose<T>(this T[][] source)
        {
            if (source.Length == 0 || source[0].Length == 0)
            {
                return Array.Empty<T[]>();
            }

            int rows = source.Length;
            int cols = source[0].Length;

            T[][] result = new T[cols][];

            for (int i = 0; i < cols; i++)
            {
                result[i] = new T[rows];

                for (int j = 0; j < rows; j++)
                {
                    result[i][j] = source[j][i];
                }
            }
            return result;
        }


        public static T[][] ToJaggedArray<T>(this T[,] source)
        {
            int rows = source.GetLength(0);
            int cols = source.GetLength(1);
            T[][] result = new T[rows][];

            for (int i = 0; i < rows; i++)
            {
                result[i] = new T[cols];
                for (int j = 0; j < cols; j++)
                {
                    result[i][j] = source[i, j];
                }
            }
            return result;
        }
    }


    public class ArrayExtensions<T>
    {
        public static T[,] Transpose(T[,] matrix)
        {

            var rows = matrix.GetLength(0);
            var columns = matrix.GetLength(1);

            var result = new T[columns, rows];

            for (var c = 0; c < columns; c++)
            {
                for (var r = 0; r < rows; r++)
                {
                    result[c, r] = matrix[r, c];
                }
            }
            return result;
        }
      
    }


}
