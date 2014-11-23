//7.Sorting an array means to arrange its elements in increasing order. 
//Write a program to sort an array. Use the "selection sort" algorithm: 
//Find the smallest element, move it at the first position, find the smallest from the rest, move it at the second position, etc.
using System;

class SortingAlgorithm
{
    static void Main()
    {
        int[] arr = new int[13] { 20, 1, 10, 5, 17, 3, 13, 0, -1, 4, 6, 3, 9 };
        int smallest = 0;
        int smallestIndex = 0;
        int temp = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            smallest = arr[i];
            for (int j = 1+i; j < arr.Length; j++)
            {
                if (smallest>arr[j])
                {
                    smallest=arr[j];
                    smallestIndex = j;
                }
            }
            temp = smallest;
            arr[smallestIndex] = arr[i];
            arr[i] = smallest;
        }

        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();
    }
}
