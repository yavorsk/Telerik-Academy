using System;
using System.IO;

/// <summary>
/// Write a program that reads a text file containing a square matrix of numbers and finds in the matrix 
/// an area of size 2 x 2 with a maximal sum of its elements. 
/// The first line in the input file contains the size of matrix N. 
/// Each of the next N lines contain N numbers separated by space. 
/// The output should be a single number in a separate text file. 
/// </summary>

class ReadMatrix
{
    static int[,] ReadMatrixFromFile(string inputFile)
    {
        using (StreamReader readInput = new StreamReader(inputFile))
        {
            int matrixSize = int.Parse(readInput.ReadLine());
            int[,] resultMatrix = new int[matrixSize, matrixSize];
            
            for (int i = 0; i < matrixSize; i++)
            {
                string[] matrixRow = readInput.ReadLine().Split(' ');

                for (int j = 0; j < matrixSize; j++)
                {
                    resultMatrix[i, j] = int.Parse(matrixRow[j]);
                }
            }
            return resultMatrix;
        }
    }

    static void Main()
    {
        string input = @"..\..\matrix.txt";
        string output = @"..\..\output.txt";

        int[,] matrix = ReadMatrixFromFile(input);
        int maxSum = int.MinValue;
        int currentSum = 0;

        for (int i = 0; i < matrix.GetLength(0) - 1; i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                currentSum = matrix[i, j] + matrix[i, j + 1] + matrix[i + 1, j] + matrix[i + 1, j + 1];
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                }
            }
        }

        using (StreamWriter outputFile = new StreamWriter(output, false))
        {
            outputFile.WriteLine(maxSum);
        }
    }
}
