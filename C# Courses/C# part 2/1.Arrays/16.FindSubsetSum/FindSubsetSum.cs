//16* We are given an array of integers and a number S. 
// Write a program to find if there exists a subset of the elements of the array that has a sum S. Example:
//	arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14  yes (1+2+5+6)

using System;

class FindSubsetSum
{
    static void Main()
    {
        int S = 14;
        int[] arr = new int[8] {2, 1, 2, 4, 3, 5, 2, 6 };
        bool subSetExist = false;
        int sum = 0;
        int combinator = (1 << arr.Length) - 1;

        for (int i = 0; i < combinator; i++)
        {
            sum = 0;
            for (int j = 0; j < arr.Length; j++)
            {
                sum += ((i >> j) & 1) * arr[j];
            }
            if (sum == S)
            {
                subSetExist = true;
                for (int j = 0; j < arr.Length; j++)
                {
                    if ((((i >> j) & 1) * arr[j]) != 0)
                    {
                    Console.Write(((i >> j) & 1) * arr[j] + " ");                        
                    }
                }
                Console.Write("=" + S);
                Console.WriteLine();
            }
        }
        if (!subSetExist)
        {
            Console.WriteLine("no");
        }
    }
}
