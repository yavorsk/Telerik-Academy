//6.Write a program that reads two integer numbers N and K and an array of N elements from the console. 
//Find in the array those K elements that have maximal sum.
using System;

class MaximalSumOfK
{
    static void Main()
    {
        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter K: ");
        int k = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        int maxSum = 0;

        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter arr[{0}]: ",i);
            arr[i] = int.Parse(Console.ReadLine());
        }

        Array.Sort(arr);

        for (int i = n-k; i < n; i++)
        {
            maxSum += arr[i];
        }

        Console.WriteLine(maxSum);
    }
}
