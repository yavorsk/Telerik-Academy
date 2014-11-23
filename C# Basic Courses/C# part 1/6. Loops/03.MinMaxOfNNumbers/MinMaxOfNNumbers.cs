//Write a program that reads from the console a sequence of N integer numbers and returns the minimal and maximal of them.

using System;

class MinMaxOfNNumbers
{
    static void Main()
    {
        Console.Write("Please enter number of integers to read froma the console: ");
        int n = int.Parse(Console.ReadLine());
        int max = int.MinValue;
        int min = int.MaxValue;
        for (int i = 0; i < n; i++)
        {
            Console.Write("Please enter random integer: ");
            int c = int.Parse(Console.ReadLine());
            if (max < c)
            {
                max = c;
            }
            if (min > c)
            {
                min = c;
            }
        }
        Console.WriteLine("The biggest number is {0}.", max);
        Console.WriteLine("The smallest number is {0}.", min);
    }
}
