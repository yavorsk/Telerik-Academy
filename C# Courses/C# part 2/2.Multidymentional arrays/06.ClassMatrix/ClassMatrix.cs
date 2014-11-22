//6.* Write a class Matrix, to holds a matrix of integers. Overload the operators for adding, 
// subtracting and multiplying of matrices, indexer for accessing the matrix content and ToString().

using System;

class Matrix
{
    private int[,] matrix;
    private int rows;
    private int cols;

    //Constructor
    public Matrix(int rowCount, int colCount)
    {
        rows = rowCount;
        cols = colCount;
        matrix = new int[rows, cols];
    }

    //Getter / setter
    public int this[int row, int col]
    {
        get
        {
            return matrix[row, col];
        }
        set
        {
            matrix[row, col] = value;
        }
    }

    //property rowCount
    public int RowCount
    {
        get 
        {
            return rows;
        }
    }

    //property colCount
    public int ColCount
    {
        get
        {
            return cols;
        }
    }

    //Overload + operator
    public static Matrix operator +(Matrix matr1, Matrix matr2)
    {
        Matrix resultMatr = new Matrix(matr1.rows, matr1.cols);

        for (int i = 0; i < resultMatr.rows; i++)
        {
            for (int j = 0; j < resultMatr.cols; j++)
            {
                resultMatr[i,j] = matr1[i,j] + matr2[i,j];
            }
        }

        return resultMatr;
    }

    //Overload - operator
    public static Matrix operator -(Matrix matr1, Matrix matr2)
    {
        Matrix resultMatr = new Matrix(matr1.rows, matr1.cols);

        for (int i = 0; i < resultMatr.rows; i++)
        {
            for (int j = 0; j < resultMatr.cols; j++)
            {
                resultMatr[i, j] = matr1[i, j] - matr2[i, j];
            }
        }

        return resultMatr;
    }

    //Overload * operator
    public static Matrix operator *(Matrix matr1, Matrix matr2)
    {
        Matrix resultMatr = new Matrix(matr1.rows, matr2.cols);

        for (int i = 0; i < resultMatr.rows; i++)
        {
            for (int j = 0; j < resultMatr.cols; j++)
            {
                for (int k = 0; k < matr1.cols; k++)
                {
                    resultMatr[i, j] += matr1[i, k] * matr2[k, j];
                }
            }
        }
        return resultMatr;
    }

    //override ToString()
    public override string ToString()
    {
        int longest = matrix[0,0];
        foreach (int num in matrix)
        {
            longest = Math.Max(longest, num);
        }
        int size = longest.ToString().Length;

        string s = "";
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                s += (Convert.ToString(matrix[i, j]).PadRight(size+2, ' ') + (j != cols - 1 ? " " : "\n"));
            }
        }
        return s;
    }
}

class Program
{
    static void Main()
    {
        //test of multiplication of matrices 
        Matrix matr1 = new Matrix(3, 2);
        Matrix matr2 = new Matrix(2, 2);
        Matrix result = new Matrix(3, 2);

        int[,] arr1 = { { 1, 3 }, { 0, -2 }, { 4, -1 } };
        int[,] arr2 = { { 7, 9 }, { 5, 2 } };

        for (int i = 0; i < arr1.GetLength(0); i++)
        {
            for (int j = 0; j < arr1.GetLength(1); j++)
            {
                matr1[i, j] = arr1[i, j];
            }
        }

        for (int i = 0; i < arr2.GetLength(0); i++)
        {
            for (int j = 0; j < arr2.GetLength(1); j++)
            {
                matr2[i, j] = arr2[i, j];
            }
        }

        result = matr1 * matr2;

        Console.WriteLine(result.ToString());
    }
}
