using System.Text;

namespace _1_13PrzeladowanieOperatorow
{
    internal class Matrix
    {
        public int[,] Numbers { get; set; }
        public override string? ToString()
        {
            var sb = new StringBuilder();
            var xDimension = Numbers.GetLength(0);
            var yDimension = Numbers.GetLength(1);
            for (var i = 0; i < xDimension; i++)
            {
                for (var j = 0; j < yDimension; j++)
                {
                    var number = Numbers[i, j];
                    sb.Append($"{(number > 9 ? $" {number} " : $" 0{number} ")}");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
        public static Matrix operator +(Matrix matrixA, Matrix matrixB)
        {
            var xDimension = matrixA.Numbers.GetLength(0);
            var yDimension = matrixA.Numbers.GetLength(1);
            if (xDimension == matrixB.Numbers.GetLength(0) &&
                yDimension == matrixB.Numbers.GetLength(1))
            {
                var newMatrix = new Matrix() { Numbers = new int[xDimension, yDimension] };
                for (int i = 0; i < xDimension; i++)
                {
                    for (int j = 0; j < yDimension; j++)
                    {
                        newMatrix.Numbers[i, j] = matrixA.Numbers[i, j] + matrixB.Numbers[i, j];
                    }
                }
                return newMatrix;
            }
            throw new ArgumentException("Difrent sizes of matrix");
        }
        public static Matrix operator -(Matrix matrixA, Matrix matrixB)
        {
            var xDimension = matrixA.Numbers.GetLength(0);
            var yDimension = matrixA.Numbers.GetLength(1);
            if (xDimension == matrixB.Numbers.GetLength(0)
                && yDimension == matrixB.Numbers.GetLength(1))
            {
                var newMatrix = new Matrix() { Numbers = new int[xDimension, yDimension] };
                for (int i = 0; i < xDimension; i++)
                {
                    for (int j = 0; j < yDimension; j++)
                    {
                        newMatrix.Numbers[i, j] = matrixA.Numbers[i, j] - matrixB.Numbers[i, j];
                    }
                }
                return newMatrix;
            }
            throw new ArgumentException("Difrent sizes of matrix");
        }
        public static Matrix operator *(Matrix matrix, int number)
        {
            var xDimension = matrix.Numbers.GetLength(0);
            var yDimension = matrix.Numbers.GetLength(1);
            for (int i = 0; i < xDimension; i++)
            {
                for (int j = 0; j < yDimension; j++)
                {
                    matrix.Numbers[i, j] *= number;
                }
            }
            return matrix;
        }
    }
}
