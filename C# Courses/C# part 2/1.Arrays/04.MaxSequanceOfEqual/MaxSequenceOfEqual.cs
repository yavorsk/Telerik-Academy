//Write a program that finds the maximal sequence of equal elements in an array.
//		Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1}  {2, 2, 2}.

using System;
using System.Collections.Generic;

class MaxSequenceOfEqual
{
    static void Main()
    {
        int[] arr = new int[13] { 2, 1, 1, 1, 2, 3, 3, 3, 1, 2, 2, 2, 2 };
        int len = 1;
        int bestStart = 0;
        int bestLen = 1;

        for (int i = 0; i < arr.Length-1; i++)
        {
            if (arr[i] == arr[i+1])
            {
                len++;
                if (len > bestLen)
                {
                    bestLen = len;
                    bestStart = i + 2 - len;
                }
            }
            else if (arr[i] != arr[i + 1])
            {
                len = 1;
            }
        }
        Console.Write("Longest sequence: ");
        for (int i = bestStart; i < bestStart+bestLen; i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();
    }
}
