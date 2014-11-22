using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n/2; i++)
        {
                for (int k = 0; k < i; k++)
                {
                    Console.Write(".");
                }
                Console.Write("\\");
                for (int k = 0; k < n/2 -i -1; k++)
                {
                    Console.Write(".");                    
                }
                Console.Write("|");
                for (int k = 0; k < n / 2 - i - 1; k++)
                {
                    Console.Write(".");
                }
                Console.Write("/");
                for (int k = 0; k < i; k++)
                {
                    Console.Write(".");
                }
            Console.WriteLine();
        }

        for (int j = 0; j < n / 2; j++)
        {
            Console.Write("-");
        }
        Console.Write("*");
        for (int j = 0; j < n / 2; j++)
        {
            Console.Write("-");
        }
        Console.WriteLine();

        for (int i = n/2 - 1; i >= 0; i--)
        {
            for (int k = 0; k < i; k++)
            {
                Console.Write(".");
            }
            Console.Write("/");
            for (int k = 0; k < n / 2 - i - 1; k++)
            {
                Console.Write(".");
            }
            Console.Write("|");
            for (int k = 0; k < n / 2 - i - 1; k++)
            {
                Console.Write(".");
            }
            Console.Write("\\");
            for (int k = 0; k < i; k++)
            {
                Console.Write(".");
            }
            Console.WriteLine();
        }
    }
}