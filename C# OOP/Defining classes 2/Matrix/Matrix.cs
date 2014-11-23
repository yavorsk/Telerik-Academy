using System;
using System.Text;

//8. Define a class Matrix<T> to hold a matrix of numbers (e.g. integers, floats, decimals). 

class Matrix<T>
    where T: struct
{
    private const int defaultRows = 8;
    private const int defaultCols = 8;

    private T[,] elements;
    public int rows { get; private set; }
    public int cols { get; private set; }

    public Matrix(int rows, int cols)
    {
        if (rows<0 || cols < 0) 
        {
            throw new ArgumentOutOfRangeException();
        }
        else
        {
            this.rows = rows;
            this.cols = cols;
            this.elements = new T[this.rows, this.cols];
        }
    }

    public Matrix(): this(defaultRows,defaultCols)
    {
    }

    // 9. Implement an indexer this[row, col] to access the inner matrix cells.

    public T this[int row, int column]
    {
        get 
        {
            if (0<=row && row< elements.GetLength(0) && 0<=column && column<elements.GetLength(1))
            {
                return this.elements[row, column];    
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        set
        {
            if (0 <= row && row < elements.GetLength(0) && 0 <= column && column < elements.GetLength(1))
            {
                this.elements[row, column] = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }

    // 10. Implement the operators + and - (addition and subtraction of matrices of the same size) and * for matrix multiplication. 
    // Throw an exception when the operation cannot be performed. Implement the true operator (check for non-zero elements).

    public static Matrix<T> operator +(Matrix<T> matr1, Matrix<T> matr2)
    {
        if (matr1.rows != matr2.rows || matr1.cols != matr2.cols)
        {
            throw new ArgumentException("These matrices are not of the same size!");
        }
        else
        {
            Matrix<T> resultMatrix = new Matrix<T>(matr1.rows,matr1.cols);

            for (int row = 0; row < matr1.rows; row++)
            {
                for (int col = 0; col < matr1.cols; col++)
                {
                    resultMatrix[row, col] = (dynamic)matr1[row, col] + (dynamic)matr2[row, col];
                }
            }

            return resultMatrix;
        }
    }

    public static Matrix<T> operator -(Matrix<T> matr1, Matrix<T> matr2)
    {
        if (matr1.rows != matr2.rows || matr1.cols != matr2.cols)
        {
            throw new ArgumentException("These matrices are not of the same size!");
        }
        else
        {
            Matrix<T> resultMatrix = new Matrix<T>(matr1.rows, matr1.cols);

            for (int row = 0; row < matr1.rows; row++)
            {
                for (int col = 0; col < matr1.cols; col++)
                {
                    resultMatrix[row, col] = (dynamic)matr1[row, col] - (dynamic)matr2[row, col];
                }
            }

            return resultMatrix;
        }
    }

    public static Matrix<T> operator *(Matrix<T> matr1, Matrix<T> matr2)
    {
        if (matr1.cols != matr2.rows)
        {
            throw new ArgumentException();
        }
        else
        {
            Matrix<T> resultMatrix = new Matrix<T>(matr1.rows, matr2.cols);

            for (int row = 0; row < resultMatrix.rows; row++)
            {
                for (int col = 0; col < resultMatrix.cols; col++)
                {
                    resultMatrix[row, col] = (dynamic)0;
                    for (int i = 0; i < matr1.cols; i++)
                    {
                        resultMatrix[row, col] += (dynamic)matr1[row, i] * (dynamic)matr2[i, col];
                    }
                }
            }

            return resultMatrix;
        }
    }

    public static bool operator true(Matrix<T> matr)
    {
        for (int row = 0; row < matr.rows; row++)
        {
            for (int col = 0; col < matr.cols; col++)
            {
                if ((dynamic)matr[row,col] != 0)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public static bool operator false(Matrix<T> matr)
    {
        for (int row = 0; row < matr.rows; row++)
        {
            for (int col = 0; col < matr.cols; col++)
            {
                if ((dynamic)matr[row, col] != 0)
                {
                    return false;
                }
            }
        }

        return true;
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        for (int row = 0; row < this.rows; row++)
        {
            result.Append("[ ");
            for (int col = 0; col < this.cols; col++)
            {
                result.Append(elements[row, col] + " ");
            }
            result.Append("]");
            result.AppendLine();
        }
        return result.ToString();
    }
}
