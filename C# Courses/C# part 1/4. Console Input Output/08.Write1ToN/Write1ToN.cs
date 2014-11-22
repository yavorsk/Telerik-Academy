using System;

class Write1ToN
{
    static void Main()
    {
        Console.Write("Please enter random positive integer: ");
        int n = int.Parse(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine(i);
        }
    }
}
