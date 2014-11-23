using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n/2; i++)
        {
            for (int j = 0; j < n/2 -1 - i; j++)
            {
                Console.Write(".");
            }
            Console.Write("#");
            for (int j = 0; j <n - 2*(n/2 -1 -i) - 2; j++)
            {
                Console.Write(".");
            }
            Console.Write("#");
            for (int j = 0; j < n / 2 - 1 - i; j++)
            {
                Console.Write(".");
            }
            Console.WriteLine();
        }
        for (int i = 0; i < n/4; i++)
        {
            for (int j = 0; j < i; j++)
            {
                Console.Write(".");
            }
            Console.Write("#");
            for (int j = 0; j < n-2-2*i; j++)
            {
                Console.Write(".");
            }
            Console.Write("#");
            for (int j = 0; j < i; j++)
            {
                Console.Write(".");
            }
            Console.WriteLine();
        }
        for (int i = 0; i < n; i++)
        {
            Console.Write("-");
        }
        Console.WriteLine();
        for (int i = 0; i < n/2; i++)
        {
            for (int j = 0; j < i; j++)
            {
                Console.Write("."); 
            }
            for (int j = 0; j < n/2-i; j++)
            {
                Console.Write("\\");                 
            }
            for (int j = 0; j < n / 2 - i; j++)
            {
                Console.Write("/");
            }
            for (int j = 0; j < i; j++)
            {
                Console.Write(".");
            }
            Console.WriteLine();
        }
    }
}
