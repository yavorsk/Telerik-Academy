//17* Write a program that reads three integer numbers N, K and S and an array of N elements from the console. 
// Find in the array a subset of K elements that have sum S or indicate about its absence.

using System;

class KElemetsSSum
{
    static void Main()
    {
        Console.Write("Please enter the number of elements in the array: ");
        int n = int.Parse(Console.ReadLine());
        long[] arr = new long[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("Please enter element number {0}: ", i+1);
            arr[i] = long.Parse(Console.ReadLine());
        }
        Console.Write("Please enter the amount of elements in the subset: ");
        int k = int.Parse(Console.ReadLine());
        Console.Write("Please enter the target sum: ");
        long s = long.Parse(Console.ReadLine());

        bool subSetExist = false;
        long sum = 0;
        int counter = 0;
        long combinator = (1 << n) - 1;
        string suma = "";

        for (int i = 0; i < combinator; i++)
        {
            sum = 0;
            counter = 0;
            suma = "";
            for (int j = 0; j < n; j++)
            {
                if (((i>>j) & 1) == 1)
                {
                    sum += arr[j];
                    counter++;
                    suma = suma + " " + arr[j];
                }
            }
            if ((sum == s) && (counter == k))
            {
                subSetExist = true;
                Console.WriteLine(suma + "= " + s);
            }
        }
        if (!subSetExist)
        {
            Console.WriteLine("no");
        }
    }
}
