using System;

class Program
{
    static void Main()
    {
        long q1 = long.Parse(Console.ReadLine());
        long q2 = long.Parse(Console.ReadLine());
        long q3 = long.Parse(Console.ReadLine());
        long q4 = long.Parse(Console.ReadLine());
        int r = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());

        long q5 = 0;

        Console.Write("{0} {1} {2}", q1, q2, q3);
        if (c==4)
        {
             Console.Write(" {0}", q4);
             Console.WriteLine();
        }
        else
        {
            Console.Write(" {0} ", q4);
        }

        if (c != 4)
        {
            for (int i = 4; i < c; i++)
            {
                if (i == c-1)
                {
                    q5 = q1 + q2 + q3 + q4;
                    q1 = q2;
                    q2 = q3;
                    q3 = q4;
                    q4 = q5;
                    Console.Write("{0}", q5);                    
                }
                else
                {
                    q5 = q1 + q2 + q3 + q4;
                    q1 = q2;
                    q2 = q3;
                    q3 = q4;
                    q4 = q5;
                    Console.Write("{0} ", q5);
                }
            }
            Console.WriteLine();

            for (int i = 1; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if (j == c - 1)
                    {
                        q5 = q1 + q2 + q3 + q4;
                        q1 = q2;
                        q2 = q3;
                        q3 = q4;
                        q4 = q5;
                        Console.Write("{0}", q5);
                    }
                    else
                    {
                        q5 = q1 + q2 + q3 + q4;
                        q1 = q2;
                        q2 = q3;
                        q3 = q4;
                        q4 = q5;
                        Console.Write("{0} ", q5);
                    }
                }
                Console.WriteLine();
            }
        }
        else
        {
            for (int i = 1; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if (j == c - 1)
                    {
                        q5 = q1 + q2 + q3 + q4;
                        q1 = q2;
                        q2 = q3;
                        q3 = q4;
                        q4 = q5;
                        Console.Write("{0}", q5);
                    }
                    else
                    {
                        q5 = q1 + q2 + q3 + q4;
                        q1 = q2;
                        q2 = q3;
                        q3 = q4;
                        q4 = q5;
                        Console.Write("{0} ", q5);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
