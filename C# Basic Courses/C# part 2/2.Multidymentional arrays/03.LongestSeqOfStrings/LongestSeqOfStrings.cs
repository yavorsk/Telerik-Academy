//We are given a matrix of strings of size N x M. 
//Sequences in the matrix we define as sets of several neighbor elements located on the same line, column or diagonal. 
//Write a program that finds the longest sequence of equal strings in the matrix. 
using System;

class LongestSeqOfStrings
{
    static void Main()
    {
        Console.Write("Enter number of columns: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter number of rows: ");
        int m = int.Parse(Console.ReadLine());

        string[,] inputArr = new string[n, m];
        for (int i = 0; i < inputArr.GetLength(0); i++)
        {
            for (int j = 0; j < inputArr.GetLength(1); j++)
            {
                Console.Write("Element [{0},{1}]: ", i, j);
                inputArr[i, j] = Console.ReadLine();
            }
        }

        //string[,] inputArr = {{"ha", "fifi", "ho", "hi"},
        //                   {"fo", "ha", "hi", "xx"},
        //                   {"xxx", "ho", "ha", "xx"},};
        //string[,] inputArr = {{"s", "qq", "s"},
        //                   {"pp", "pp", "s"},
        //                   {"pp", "qq", "s"},};

        int maxSeqLength = 1;
        string maxSeqElement = "";

        for (int i = 0; i <inputArr.GetLength(0) ; i++)
        {
            for (int j = 0; j < inputArr.GetLength(1); j++)
            {
                int tempRow = i;
                int tempCol = j;
                int currentLength = 0;
                //check upward diagonal sequence:
                while (tempCol<inputArr.GetLength(1) && tempRow<inputArr.GetLength(0))
                {
                    if (inputArr[tempRow, tempCol] == inputArr[i,j])
                    {
                        currentLength++;
                        tempCol++;
                        tempRow++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (currentLength > maxSeqLength)
                {
                    maxSeqLength = currentLength;
                    maxSeqElement = inputArr[i,j];
                }
                currentLength = 0;
                tempRow = i;
                tempCol = j;
                //check downward diagonal sequence:
                while (tempCol < inputArr.GetLength(1) && tempRow > -1)
                {
                    if (inputArr[tempRow, tempCol] == inputArr[i, j])
                    {
                        currentLength++;
                        tempCol++;
                        tempRow--;
                    }
                    else
                    {
                        break;
                    }
                }
                if (currentLength > maxSeqLength)
                {
                    maxSeqLength = currentLength;
                    maxSeqElement = inputArr[i, j];
                }
                currentLength = 0;
                tempRow = i;
                tempCol = j;
                //check horizontal sequence:
                while (tempCol < inputArr.GetLength(1))
                {
                    if (inputArr[tempRow, tempCol] == inputArr[i, j])
                    {
                        currentLength++;
                        tempCol++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (currentLength > maxSeqLength)
                {
                    maxSeqLength = currentLength;
                    maxSeqElement = inputArr[i, j];
                }
                currentLength = 0;
                tempRow = i;
                tempCol = j;
                //check vertical sequence:
                while (tempRow < inputArr.GetLength(0))
                {
                    if (inputArr[tempRow, tempCol] == inputArr[i, j])
                    {
                        currentLength++;
                        tempRow++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (currentLength > maxSeqLength)
                {
                    maxSeqLength = currentLength;
                    maxSeqElement = inputArr[i, j];
                }
                currentLength = 0;
                tempRow = i;
                tempCol = j;
            }
        }

        Console.WriteLine("Longest sequence: {0}", maxSeqLength);
        for (int i = 0; i < maxSeqLength; i++)
        {
            Console.Write(maxSeqElement + " ");
        }
        Console.WriteLine();
    }
}
