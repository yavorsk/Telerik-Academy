using System;

class SumOfN
{
    static void Main()
    {
        Console.Write("Please enter the number of numbers to sum: ");
        int n = int.Parse(Console.ReadLine());
        double sum = 0;
        for (int i = 0; i < n; i++)
        {
            Console.Write("Please enter a number: ");
            sum = sum + double.Parse(Console.ReadLine());
        }
        Console.WriteLine("The sum of the entered numbers is {0}.",sum);
    }
}
