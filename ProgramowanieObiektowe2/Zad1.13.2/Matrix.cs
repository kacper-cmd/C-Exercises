using System.Text;
public class Matrix
{
    #region Fields
    private const int MaxSize = 10;
    private int rows;
    private int columns;
    private int[,] matrix;
    #endregion

    #region Constructors
    public Matrix(int rows, int columns)
    {
        if (rows <= 0 || columns <= 0 || rows > MaxSize || columns > MaxSize)
        {
            throw new ArgumentOutOfRangeException("Matrix must be max 10 * 10 and positive number");
        }
        
        this.rows = rows;
        this.columns = columns;
        matrix = new int[rows, columns];
    }
    #endregion
    
    #region Indexer
    public int this[int row, int column]
    {
        get
        {
            return matrix[row, column];
        }
        set
        {
            matrix[row, column] = value;
        }
    }
    #endregion

    #region OperatorsOverloading
    public static Matrix operator +(Matrix a, Matrix b)
    {
        if (a.rows != b.rows || a.columns != b.columns)
        {
            throw new InvalidOperationException("Only allow if matrices have the same dimensions!");
        }

        Matrix resultMatrix = new Matrix(a.rows, a.columns);

        for (int i = 0; i < a.rows; i++)
        {
            for (int j = 0; j < a.columns; j++)
            {
                resultMatrix[i, j] = a[i, j] + b[i, j];
            }
        }
        return resultMatrix;
    }

    public static Matrix operator -(Matrix a, Matrix b)
    {
        if (a.rows != b.rows || a.columns != b.columns)
        {
            throw new InvalidOperationException("Only allow if matrices have the same dimensions!");
        }

        Matrix resultMatrix = new Matrix(a.rows, a.columns);

        for (int i = 0; i < a.rows; i++)
        {
            for (int j = 0; j < a.columns; j++)
            {
                resultMatrix[i, j] = a[i, j] - b[i, j];
            }
        }
        return resultMatrix;
    }

    public static Matrix operator *(Matrix a, int scalar)
    {
        Matrix resultMatrix = new Matrix(a.rows, a.columns);

        for (int i = 0; i < a.rows; i++)
        {
            for (int j = 0; j < a.columns; j++)
            {
                resultMatrix[i, j] = a[i, j] * scalar;
            }
        }

        return resultMatrix;
    }
    public static Matrix operator *(int scalar, Matrix a)
    {
        return a * scalar;
    }
    #endregion

    #region ToStringMethod
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
               sb.Append(matrix[i, j] + "\t");
            }
            sb.AppendLine();
        }
        
        return sb.ToString();
    }
    #endregion
}