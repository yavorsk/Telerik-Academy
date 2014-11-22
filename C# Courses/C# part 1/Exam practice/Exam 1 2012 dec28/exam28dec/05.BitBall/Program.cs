using System;

class Program
{
    static void Main()
    {
        int[,] field = new int[8, 8];
        int n = 0;
        int scoreTop = 0;
        int scoreBottom = 0;

        for (int i = 0; i < 8; i++)
        {
            n = int.Parse(Console.ReadLine());
            for (int j = 0; j < 8; j++)
            {
                if (((n>>j) & 1) == 1)
                {
                    field[i, j] = 1;
                }
                else
                {
                    field[i, j] = 0;
                }
            }
        }

        for (int i = 0; i < 8; i++)
        {
            n = int.Parse(Console.ReadLine());
            for (int j = 0; j < 8; j++)
            {
                if (((n>>j) & 1) == 1)
                {
                    if (field[i, j] == 1)
                    {
                        field[i, j] = 0;
                    }
                    else
                    {
                        field[i, j] = 2;
                    }
                }                
            }
        }

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (field[i, j] == 1)
                {
                    int sum = 0;
                    for (int k = i + 1; k <= 7; k++)
                    {
                        sum += field[k, j];
                    }
                    if (sum == 0)
                    {
                        scoreTop++;
                    }
                }
                else if (field[i, j] == 2)
                {
                    int sum = 0;
                    for (int k = i - 1; k >= 0; k--)
                    {
                        sum += field[k, j];
                    }
                    if (sum == 0)
                    {
                        scoreBottom++;
                    }
                }
            }
        }
        Console.WriteLine("{0}:{1}", scoreTop, scoreBottom);
    }
}
