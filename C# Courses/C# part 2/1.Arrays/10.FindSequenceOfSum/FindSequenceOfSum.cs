//Write a program that finds in given array of integers a sequence of given sum S (if present). 
//Example:	 {4, 3, 1, 4, 2, 5, 8}, S=11  {4, 2, 5}
using System;

class FindSequenceOfSum
{
    static void Main()
    {
        Console.Write("Enter sum to find: ");
        int s = int.Parse(Console.ReadLine());
        int[] arr = new int[13] { 20, 2, 10, 3, 17, 1, 13, 0, -1, 4, 1, 3, 3 };
        int sum = 0;
        int counter = 0;
        bool sequenceIspresent = false;

        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = i; j < arr.Length; j++)
            {
                sum += arr[j];
                counter++;
                if (s == sum)
                {
                    sequenceIspresent = true;
                    for (int k = i; k < i+counter; k++)
                    {
                        Console.Write(arr[k]+ " ");
                    }
                    Console.WriteLine();
                }
            }
            sum = 0;
            counter = 0;
        }
        if (!sequenceIspresent)
        {
            Console.WriteLine("Sequence of sum {0} is not present in the given array.", s);
        }
    }
}
