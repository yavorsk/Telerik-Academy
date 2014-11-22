//* Write a program that reads a positive integer number N (N < 20) from console and outputs in the 
// console the numbers 1 ... N numbers arranged as a spiral.
using System;

class PrintSpiralMatrix
{
    static void Main()
    {
        Console.Write("Please enter positive integer which is less than 20: ");
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];
        int row = 0;
        int col = 0;
        int counter = 1;

        while (counter <= n*n)
        {
            for (int i = col; i < n - col; i++)  //assign matrix elements from left to right
            {
                matrix[row, i] = counter++;
            }
            for (int i = row + 1; i < n - row; i++)  //assign matrix elements downwards
            {
                matrix[i, n - 1 - col] = counter++;
            }
            for (int i = n - 2 - col; i >= col; i--)  //assign matrix elements from right to left
            {
                matrix[n - 1 - row, i] = counter++;
            }
            for (int i = n - 2 - row; i >= row + 1; i--)   //assign matrix elements upwards
            {
                matrix[i, col] = counter++;
            }
            row++;
            col++;            
        }

        for (int i = 0; i < n; i++)  //print the matrix
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("{0,3}",matrix[i,j]);
            }
            Console.WriteLine();
        }
    }
}

