// Write a method that return the maximal element in a portion of array of integers starting at given index. 
// Using it write another method that sorts an array in ascending / descending order.

using System;

class SortAnArray
{
    static int BiggestInPortionOfArr(int[] arr, int startInd, int endInd)
    {
        int biggestNum = int.MinValue;
        int biggestNumIndex = 0;

        for (int i = startInd; i <= endInd; i++)
        {
            if (arr[i]>biggestNum)
            {
                biggestNum = arr[i];
                biggestNumIndex = i;
            }
        }

        return biggestNumIndex;
    }

    static void SwapValues(int[] arr, int ind1, int ind2)
    {
        int temp = arr[ind1];
        arr[ind1] = arr[ind2];
        arr[ind2] = temp;
    }

    static void SortAscending(int[] arr)
    {
        for (int i = arr.Length-1; i >= 0; i--)
        {
            SwapValues(arr, BiggestInPortionOfArr(arr, 0, i), i);
        }
    }

    static void SortDescending(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            SwapValues(arr, i, BiggestInPortionOfArr(arr, i, arr.Length-1));
        }
    }

    static void PrintArray(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write((i == arr.Length - 1) ? arr[i] + "" : (arr[i] + " "));
        }
        Console.WriteLine();
    }

    static void Main()
    {
        int[] inputArr = { 8, 2, -11, 7, 1, 0, 7, 4, 5, 6, 15, 4, -5, 5, 4, 3, 2, 6, 13, 1, 2, 22 };
        PrintArray(inputArr);
        Console.WriteLine();
        SortDescending(inputArr);
        PrintArray(inputArr);
        Console.WriteLine();
        SortAscending(inputArr);
        PrintArray(inputArr);
        Console.WriteLine();
    }
}
