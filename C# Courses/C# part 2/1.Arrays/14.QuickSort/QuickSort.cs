//14. Write a program that sorts an array of strings using the quick sort algorithm (find it in Wikipedia).
using System;
using System.Collections.Generic;

class QuickSort
{
    private static List<string> QuickSortt(List<string> unsorterArray)
    {
        if (unsorterArray.Count <= 1)
        {
            return unsorterArray;
        }

        string pivot = unsorterArray[unsorterArray.Count / 2];
        List<string> smaller = new List<string>();
        List<string> greater = new List<string>();
        List<string> sortedArray = new List<string>();

        for (int i = 0; i < unsorterArray.Count; i++)
        {
            if (i != unsorterArray.Count / 2)
            {
                if (string.Compare(unsorterArray[i], pivot) >= 0)
                {
                    greater.Add(unsorterArray[i]);
                }
                else
                {
                    smaller.Add(unsorterArray[i]);
                }
            }
        }
        sortedArray.AddRange(QuickSortt(smaller));
        sortedArray.Add(pivot); 
        sortedArray.AddRange(QuickSortt(greater));
        return sortedArray;
    }

    static void Main()
    {
        List<string> inputStringArray = new List<string>() { "abc", "efgh", "ath", "zxy", "ht", "pqswr", "dsaf", "lkjg", "aaa", "htyre", "oi", "a" };
        List<string> sortedArray = QuickSortt(inputStringArray);
        for (int i = 0; i < sortedArray.Count; i++)
        {
            Console.WriteLine(sortedArray[i]);
        }
    }
}
