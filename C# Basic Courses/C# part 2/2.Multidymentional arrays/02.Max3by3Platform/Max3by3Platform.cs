//Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3 
// that has maximal sum of its elements.

using System;

class Max3by3Platform
{
    static void Main()
    {
        Console.Write("Enter number of columns: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter number of rows: ");
        int m = int.Parse(Console.ReadLine());

        int[,] inputArr = new int[n, m];
        int maxSum = int.MinValue;
        int platformFirstCol = 0;
        int platformFirstRow = 0;

        for (int i = 0; i < inputArr.GetLength(0); i++)
        {
            for (int j = 0; j < inputArr.GetLength(1); j++)
            {
                Console.Write("Element [{0},{1}]: ", i, j);
                inputArr[i, j] = int.Parse(Console.ReadLine());
            }
        }

        for (int i = 0; i < inputArr.GetLength(0)-2; i++)
        {
            for (int j = 0; j < inputArr.GetLength(1)-2; j++)
            {
                int currentSum = inputArr[i, j] + inputArr[i, j+1] + inputArr[i, j+2] + inputArr[i+1, j] + inputArr[i+1, j+1] +
                    inputArr[i+1, j+2] + inputArr[i+2, j] + inputArr[i+2, j+1] + inputArr[i+2, j+2];
                if (currentSum>maxSum)
                {
                    maxSum = currentSum;
                    platformFirstCol = j;
                    platformFirstRow = i;
                }
            }
        }

        Console.WriteLine(maxSum);
        for (int i = platformFirstRow; i < platformFirstRow+3; i++)
        {
            for (int j = platformFirstCol; j < platformFirstCol+3; j++)
            {
                Console.Write(inputArr[i,j] + " ");
            }
            Console.WriteLine();
        }
    }
}
