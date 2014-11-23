//Write a program that calculates N!*K! / (K-N)! for given N and K (1<N<K).

using System;

class FactorielExpression2
{
    static void Main()
    {
        Console.Write("Please enter random positive integer, bigger than 1: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Please enter random positive integer, bigger than the previous: ");
        int k = int.Parse(Console.ReadLine());
        decimal result = 1;
        for (int i = k - n + 1; i <= n; i++)
        {
            result *= i;
        }
        for (int i = 1; i <= k; i++)
        {
            result *= i;
        }
        Console.WriteLine(result);
    }
}
