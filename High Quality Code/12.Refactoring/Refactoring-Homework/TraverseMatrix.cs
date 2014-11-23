using System;

public class TraverseMatrix
{
    private static readonly int[] DirectionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
    private static readonly int[] DirectionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };

    public static int[,] GenerateMatrix(int n)
    {
        int[,] matrix = new int[n, n];
        int cellValue = 1;
        int col = 0;
        int row = 0;

        FillTriangleOfMatrix(n, matrix, ref cellValue, ref col, ref row);

        GetFirstEmptyCell(matrix, out col, out row);
        cellValue++;

        if (col != 0 && row != 0)
        {
            FillTriangleOfMatrix(n, matrix, ref cellValue, ref col, ref row);
        }

        return matrix;
    }

    public static void Main()
    {
        Console.WriteLine("Enter a positive number ");
        string input = Console.ReadLine();
        int n = 0;

        while (!int.TryParse(input, out n) || n < 0 || n > 100)
        {
            Console.WriteLine("You haven't entered a correct positive number");
            input = Console.ReadLine();
        }

        int[,] matrix = GenerateMatrix(n);
        PrintMatrix(matrix);
    }

    private static void FillTriangleOfMatrix(int n, int[,] matrix, ref int cellValue, ref int col, ref int row)
    {
        int currentDirX = 1;
        int currentDirY = 1;
        while (true)
        {
            matrix[col, row] = cellValue;

            if (IsCollisionDetected(matrix, col, row))
            {
                break;
            }

            if (col + currentDirX >= matrix.GetLength(1) || col + currentDirX < 0 ||
                row + currentDirY >= matrix.GetLength(0) || row + currentDirY < 0 ||
                matrix[col + currentDirX, row + currentDirY] != 0)
            {
                while (col + currentDirX >= n || col + currentDirX < 0 || row + currentDirY >= n || row + currentDirY < 0 || matrix[col + currentDirX, row + currentDirY] != 0)
                {
                    ChangeDirections(ref currentDirX, ref currentDirY);
                }
            }

            col += currentDirX;
            row += currentDirY;
            cellValue++;
        }
    }

    private static void ChangeDirections(ref int dirX, ref int dirY)
    {
        int currentDirectionIndex = 0;

        for (int i = 0; i < 8; i++)
        {
            if (DirectionsX[i] == dirX && DirectionsY[i] == dirY)
            {
                currentDirectionIndex = i;
                break;
            }
        }

        if (currentDirectionIndex == 7)
        {
            dirX = DirectionsX[0];
            dirY = DirectionsY[0];
            return;
        }

        dirX = DirectionsX[currentDirectionIndex + 1];
        dirY = DirectionsY[currentDirectionIndex + 1];
    }

    private static bool IsCollisionDetected(int[,] matrix, int x, int y)
    {
        int[] collisionDirectionX = (int[])DirectionsX.Clone();
        int[] collisionDirectionY = (int[])DirectionsY.Clone();

        for (int i = 0; i < collisionDirectionX.Length; i++)
        {
            if (x + collisionDirectionX[i] >= matrix.GetLength(0) || x + collisionDirectionX[i] < 0)
            {
                collisionDirectionX[i] = 0;
            }

            if (y + collisionDirectionY[i] >= matrix.GetLength(0) || y + collisionDirectionY[i] < 0)
            {
                collisionDirectionY[i] = 0;
            }
        }

        for (int i = 0; i < collisionDirectionX.Length; i++)
        {
            if (matrix[x + collisionDirectionX[i], y + collisionDirectionY[i]] == 0)
            {
                return false;
            }
        }

        return true;
    }

    private static void GetFirstEmptyCell(int[,] matrix, out int row, out int col)
    {
        row = 0;
        col = 0;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                if (matrix[i, j] == 0)
                {
                    row = i;
                    col = j;
                    return;
                }
            }
        }
    }

    private static void PrintMatrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("{0,3}", matrix[row, col]);
            }

            Console.WriteLine();
        }
    }
}