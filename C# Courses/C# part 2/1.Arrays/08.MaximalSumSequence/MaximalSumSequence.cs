//Write a program that finds the sequence of maximal sum in given array. Example:
//	{2, 3, -6, -1, 2, -1, 6, 4, -8, 8}  {2, -1, 6, 4}
using System;

class MaximalSumSequence
{
    static void Main()
    {
        int[] arr = new int[10] { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };
        //int[] arr = new int[13] { 2, 3, -6, -1, 2, 3, -1, 6, 4, -8, 8, -1, -3 };
        int biggestSum = 0;
        int sum = 0;
        int bestStart = 0;
        int counter = 0;
        int bestSeqLength = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            sum = 0;
            counter = 0;
            for (int j = i; j < arr.Length; j++)
            {
                sum += arr[j];
                counter++;
                if (biggestSum < sum)
                {
                    biggestSum = sum;
                    bestStart = i;
                    bestSeqLength = counter;
                }
            }
        }
        for (int i = bestStart; i < bestStart + bestSeqLength; i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();
        Console.WriteLine(biggestSum);
    }
}