using System;

class CompareFPNumbers
{
    static void Main()
    {
        Console.Write("Please enter number 1: ");
        decimal num1 = decimal.Parse(Console.ReadLine());
        Console.Write("Please enter number 2: ");
        decimal num2 = decimal.Parse(Console.ReadLine());
        bool comparison = (Math.Abs(num1 - num2) < 0.000001m);
        Console.Write("The two numbers are equal? ");
        Console.WriteLine(comparison);
    }
}
