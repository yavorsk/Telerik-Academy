//20.Write a program that reads two numbers N and K and generates all the variations of K elements from the set [1..N]. Example:
//	N = 3, K = 2  {1, 1}, {1, 2}, {1, 3}, {2, 1}, {2, 2}, {2, 3}, {3, 1}, {3, 2}, {3, 3}

using System;

class Program
{
    static void GetComb(int index, int endNum, int[] arr)
    {
        if (index == arr.Length)
        {
            Print(arr);
        }
        else
        {
            for (int i = 1; i <= endNum; i++)
            {
                arr[index] = i;
                GetComb(index + 1, endNum, arr);
            }
        }
    }

    static void Print(int[] arr)
    {
        Console.Write("( ");
        foreach (int i in arr)
        {
            Console.Write("{0} ", i);
        }
        Console.Write(")");
        Console.WriteLine();
    }

    static void Main()
    {
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("k = ");
        int k = int.Parse(Console.ReadLine());

        int[] subSet = new int[k];
        GetComb(0, n, subSet);
    }
}