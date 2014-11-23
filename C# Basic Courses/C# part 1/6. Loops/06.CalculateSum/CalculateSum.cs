//Write a program that, for a given two integer numbers N and X, calculates the sumS = 1 + 1!/X + 2!/X2 + … + N!/XN

using System;

class CalculateSum
{
    static void Main()
    {
        Console.Write("Please enter random integer: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Please enter random integer: ");
        int x = int.Parse(Console.ReadLine());
        decimal sum = 1;
        decimal factoriel = 1;
        decimal power = 1;
        for (int i = 1; i <= n; i++)
        {
            factoriel *= i;
            power = (decimal) (Math.Pow(x,i));
            sum += factoriel / power;
        }
        Console.WriteLine(sum);
    }
}
