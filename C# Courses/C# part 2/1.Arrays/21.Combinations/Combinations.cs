//21.Write a program that reads two numbers N and K and generates all the combinations of K distinct elements from the set [1..N].
//Example: N = 5, K = 2  {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}
using System;

class Combinations
{    
    static void GetComb(int index, int startNum, int endNum, int[] arr)
    {
        if (index == arr.Length)
        {
            Print(arr);
        }
        else
        {
            for (int i = startNum; i <= endNum; i++)
            {
                arr[index] = i;
                GetComb(index + 1, i+1, endNum, arr);
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
        GetComb(0, 1, n, subSet);
    }
}
