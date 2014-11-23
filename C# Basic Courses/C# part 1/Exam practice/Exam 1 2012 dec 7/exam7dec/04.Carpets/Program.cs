using System;


class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());


        for (int row = 1; row <= n/2; row++)
        {
            int elPos = 1;
            while (elPos <= n)
            {
                if (elPos <= n / 2 - row || elPos > n / 2 + row)
                {
                    Console.Write(".");
                    elPos++;
                }
                else
                {
                    for (int col = 0; col < row; col++)
                    {
                        if (col% 2 ==0)
                        {
                            Console.Write("/");
                            elPos++;
                        }
                        else
                        {
                            Console.Write(" ");
                            elPos++;
                        }
                    }
                    for (int i = row; i > 0; i--)
                    {
                        if (i% 2 !=0)
                        {
                            Console.Write("\\");
                            elPos++;
                        }
                        else
                        {
                            Console.Write(" ");
                            elPos++;
                        }
                    }
                }
            }
            Console.WriteLine();
        }

        for (int row = n/2; row > 0; row--)
        {
            int elPos = 1;
            while (elPos <= n)
            {
                if (elPos <= n / 2 - row || elPos > n / 2 + row)
                {
                    Console.Write(".");
                    elPos++;
                }
                else
                {
                    for (int col = 0; col < row; col++)
                    {
                        if (col % 2 == 0)
                        {
                            Console.Write("\\");
                            elPos++;
                        }
                        else
                        {
                            Console.Write(" ");
                            elPos++;
                        }
                    }
                    for (int i = row; i > 0; i--)
                    {
                        if (i % 2 != 0)
                        {
                            Console.Write("/");
                            elPos++;
                        }
                        else
                        {
                            Console.Write(" ");
                            elPos++;
                        }
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
