using System;

class PrintMatrix
{
    static void Main()
    {
        Console.Write("Please enter positive integer which is less than 20: ");
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                matrix[row, col] = row + col + 1;
                Console.Write("{0,3}", matrix[row,col]);
            }
            Console.WriteLine();
        }
    }
}
