//Write a program that reads a number N and calculates the sum of the first N members of the sequence of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …

using System;

class SumOfNFibonacci
{
    static void Main()
    {
        Console.Write("Please enter random positive integer: ");
        int n = int.Parse(Console.ReadLine());
        int counter = 2;
        int sum = 1;
        int prevMember = 0;
        int member = 1;

        if (n == 1)
        {
            sum = 0;
        }
        else if (n == 2)
        {
            sum = 1;
        }
        else if (n > 2)
        {
            while (counter < n)
            {
                member = prevMember + member;
                prevMember = member - prevMember;
                sum += member;
                counter++;
            }
        }
        Console.WriteLine(sum);
    }
}
