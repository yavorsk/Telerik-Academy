using System;

class Program
{
    static void Main()
    {
        int k = int.Parse(Console.ReadLine());
        int kDecimal = 7 * 7 * (k / 100) + 7 * ((k % 100) / 10) + (k % 10);
        kDecimal++;
        Console.WriteLine(kDecimal % 7 + (10 * ((kDecimal / 7) % 7)) + (100 * (((kDecimal / 7) / 7) % 7)));
    }
}
