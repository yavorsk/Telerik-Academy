using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        decimal deci = 0;

        for (int i = 1; i <= n; i++)
        {
            char c = Convert.ToChar(Console.ReadLine());
            int charIndex = (int)c - 64;
            deci += (decimal)Math.Pow(26, n - i) * charIndex;
        }
        Console.WriteLine(deci);
    }
}
