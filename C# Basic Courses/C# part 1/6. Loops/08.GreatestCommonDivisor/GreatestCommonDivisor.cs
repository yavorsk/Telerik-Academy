//Write a program that calculates the greatest common divisor (GCD) of given two numbers. Use the Euclidean algorithm.

using System;

class GreatestCommonDivisor
{
    static void Main()
    {
        Console.Write("Please enter random positive integer: ");
        int num1 = int.Parse(Console.ReadLine());
        Console.Write("Please enter random positive integer: ");
        int num2 = int.Parse(Console.ReadLine());

        while (num1 != num2)
        {
            if (num1 > num2)
            {
                num1 = num1 - num2;
            }
            else
            {
                num2 = num2 - num1;
            }            
        }
        Console.WriteLine("The greatest common divisor of the two numbers is {0}", num1);
    }
}