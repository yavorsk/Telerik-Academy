//Write a program that finds the greatest of given 5 variables.
using System;

class GreatestOfFiveVars
{
    static void Main()
    {
        Console.Write("Enter 1st integer number: ");
        double n1 = double.Parse(Console.ReadLine());
        Console.Write("Enter 2nd integer number: ");
        double n2 = double.Parse(Console.ReadLine());
        Console.Write("Enter 3rd integer number: ");
        double n3 = double.Parse(Console.ReadLine());
        Console.Write("Enter 4th integer number: ");
        double n4 = double.Parse(Console.ReadLine());
        Console.Write("Enter 5th integer number: ");
        double n5 = double.Parse(Console.ReadLine());
        double[] numbers = {n1, n2, n3, n4, n5};
        double greatestNum = double.MinValue;
        for (int i = 0; i < 5; i++)
        {
            if (greatestNum < numbers[i])
            {
                greatestNum = numbers[i];
            }
        }
        Console.WriteLine("The greatest number is {0}.", greatestNum);      
    }
}
