//7.* Write a program that finds the largest area of equal neighbor elements in a rectangular matrix and prints its size.

using System;

class AreaOfEqualElements
{
    static int currentArea = 0;

    static void AreaOfEquals(int[,] matrix, int row, int col, int cellValue)
    {
        if (!InMatrix(matrix, row, col))
        {
            return;
        }
        if (matrix[row,col] == 0)
        {
            return;
        }
        if (matrix[row,col] != cellValue)
        {
            return;
        }
        if (matrix[row,col] == cellValue)
        {
            currentArea++;
            matrix[row, col] = 0;

            AreaOfEquals(matrix, row + 1, col, cellValue);
            AreaOfEquals(matrix, row, col +1, cellValue);
            AreaOfEquals(matrix, row - 1, col, cellValue);
            AreaOfEquals(matrix, row, col-1, cellValue);
        }
    }

    static bool InMatrix(int[,] matrix, int row, int col)
    {
        return (row>=0 && row<matrix.GetLength(0) && col>=0 && col<matrix.GetLength(1));
    }

    static void Main()
    {
        int[,] matrix = { { 1, 3, 2, 2, 2, 4 },
                          { 3, 3, 3, 2, 4, 4 },
                          { 4, 3, 1, 2, 3, 3 },
                          { 4, 3, 1, 3, 3, 1 },
                          { 4, 3, 3, 3, 1, 1 } };

        int largestArea = 0;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i,j] != 0)
                {
                    currentArea = 0;
                    AreaOfEquals(matrix, i, j, matrix[i, j]);

                    largestArea = Math.Max(largestArea,currentArea);
                }
            }
        }
        Console.WriteLine(largestArea);
    }
}
