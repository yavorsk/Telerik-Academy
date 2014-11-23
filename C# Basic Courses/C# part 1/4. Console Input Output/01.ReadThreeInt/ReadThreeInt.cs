using System;

class ReadThreeInt
{
    static void Main()
    {
        Console.WriteLine("Enter first integer number: ");
        int num1 = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter second integer number: ");
        int num2 = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter third integer number: ");
        int num3 = int.Parse(Console.ReadLine());
        int sum = num1 + num2 + num3;
        Console.WriteLine("The sum of the three numbers is {0}.", sum);
    }
}

