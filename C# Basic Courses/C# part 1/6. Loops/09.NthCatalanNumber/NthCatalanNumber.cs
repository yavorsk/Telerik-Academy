//Write a program to calculate the Nth Catalan number by given N.

using System;

class NthCatalanNumber
{
    static void Main()
    {
        Console.Write("Please enter random positive integer: ");
        int n = int.Parse(Console.ReadLine());
        decimal product = 1;
        for (int i = 2; i <= n; i++)
        {
            product *= (decimal)(n + i) / i;
        }
        Console.WriteLine("{0:0.00}", product);
    }
}