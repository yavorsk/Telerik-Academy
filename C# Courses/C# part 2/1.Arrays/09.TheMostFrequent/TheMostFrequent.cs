//Write a program that finds the most frequent number in an array. Example:
//	{4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3}  4 (5 times)
using System;

class TheMostFrequent
{
    static void Main()
    {
        int[] arr = new int[13] { 20, 2, 10, 3, 17, 1, 13, 0, -1, 4, 1, 3, 3 };
        int maxIndex = 0;
        int maxCounter = 0;
        int counter = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            counter = 0;
            for (int j = i; j < arr.Length; j++)
            {
                if (arr[i] == arr[j])
                {
                    counter++;
                }                
            }
            if (maxCounter<counter)
            {
                maxCounter = counter;
                maxIndex = i;
            }
        }
        Console.WriteLine("{0} - {1} times.", arr[maxIndex], maxCounter);
    }
}
