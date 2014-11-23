using System;

class Program
{
    static void Main()
    {
        int x = int.Parse(Console.ReadLine());
        int y = x;
        int z = x / 2 + 1;

        for (int i = 0; i < z; i++)
        {
            for (int j = 0; j < z - i -1; j++)
            {
                Console.Write(".");
            }
            Console.Write("*");
            if (i==0)
            {
                for (int j = 0; j < 2*y - 3; j++)
                {
                    Console.Write(".");
                }
                Console.Write("*");
                for (int j = 0; j < z - i -1; j++)
                {
                    Console.Write(".");
                }
            }
            else
            {
                for (int j = 0; j < 2*i - 1; j++)
                {
                    Console.Write(".");
                }
                Console.Write("*");
                for (int j = 0; j < 2*y -3 - 2 * i; j++)
                {
                    Console.Write(".");
                }
                Console.Write("*");
                for (int j = 0; j < 2 * i - 1; j++)
                {
                    Console.Write(".");
                }
                Console.Write("*");
                for (int j = 0; j < z - i -1 ; j++)
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
        }

        for (int i = 0; i < y - z - 1 ; i++) 
        {
            for (int j = 0; j < z*2 -1 + i; j++)
            {
                Console.Write(".");                
            }
            Console.Write("*");
            for (int j = 0; j < 2*x - 2*z  -3 - 2* i; j++) //
            {
                Console.Write(".");
            }
            Console.Write("*");
            for (int j = 0; j < z*2 -1 + i; j++)
            {
                Console.Write(".");
            }
            Console.WriteLine();
        }

        for (int i = 0; i < x; i++)
        {
            if (i == 0)
            {
                for (int j = 0; j < x+z-2-i; j++)
                {
                    Console.Write(".");
                }
                Console.Write("*");
                for (int j = 0; j < x + z - 2 - i; j++)
                {
                    Console.Write(".");
                }
            }
            else
            {
                for (int j = 0; j < x + z - 2 - i; j++)
                {
                    Console.Write(".");
                }
                Console.Write("*");
                for (int j = 0; j < i*2-1; j++)
                {
                    Console.Write("."); 
                }
                Console.Write("*");
                for (int j = 0; j < x + z - 2 - i; j++)
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
        }

        for (int i = 0; i < x-1; i++)
        {
            if (i == x-2)
            {
                for (int j = 0; j < z+i; j++)
                {
                    Console.Write(".");
                }
                Console.Write("*");
                for (int j = 0; j < z + i; j++)
                {
                    Console.Write(".");
                }
            }
            else
            {
                for (int j = 0; j < z + i; j++)
                {
                    Console.Write(".");
                }
                Console.Write("*");
                for (int j = 0; j < 2*x - 5 - 2*i; j++)
                {
                    Console.Write(".");
                }
                Console.Write("*");
                for (int j = 0; j < z + i; j++)
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
        }
    }
}
