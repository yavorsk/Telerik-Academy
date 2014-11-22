//Write a program that calculates N!/K! for given N and K (1<K<N).

using System;

class NDivKFactoriel
{
    static void Main()
    {
        Console.Write("Please enter random positive integer, bigger than 1: ");
        int k = int.Parse(Console.ReadLine());
        Console.Write("Please enter random positive integer, bigger than the previous: ");
        int n = int.Parse(Console.ReadLine());
        decimal result = 1;
        for (int i = k+1; i <= n; i++)
        {
            result *= i;
        }
        Console.WriteLine(result);
    }
}
