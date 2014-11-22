//18* Write a program that reads an array of integers and removes from it a minimal number of elements in such way 
// that the remaining array is sorted in increasing order. Print the remaining sorted array. Example:
//	{6, 1, 4, 3, 0, 3, 6, 4, 5}  {1, 3, 3, 4, 5}

using System;
using System.Collections.Generic;

class LongestSortedSubset
{
    static bool IsSorted(List<int> arr)
    {
        bool result = false;
        for (int i = 0; i < arr.Count-1; i++)
        {
            if (arr[i] <= arr[i+1])
            {
                result = true;
            }
            else
            {
                result = false;
                break;
            }
        }
        return result;
    }
    static void Main()
    {
        int[] inputArr = new int[] { 6, 1, 4, 3, 0, 3, 6, 4, 5 };
        List<int> storrage = new List<int> ();
        List<int> longestSorted = new List<int>();
        int maxLength = 1;
        int combinator = (1 << inputArr.Length) - 1;

        for (int i = 0; i < combinator; i++)
        {
            storrage.Clear();
            for (int j = 0; j < inputArr.Length; j++)
            {
                if ((i>>j & 1) == 1)
                {
                    storrage.Add(inputArr[j]);
                }
            }
            if (IsSorted(storrage) && maxLength<storrage.Count)
            {
                maxLength = storrage.Count;
                longestSorted.Clear();
                for (int k = 0; k < storrage.Count; k++)
                {
                    longestSorted.Add(storrage[k]);
                }
            }
        }

        for (int i = 0; i < longestSorted.Count; i++)
        {
            Console.Write(longestSorted[i] + " ");
        }
        Console.WriteLine();
    }
}
