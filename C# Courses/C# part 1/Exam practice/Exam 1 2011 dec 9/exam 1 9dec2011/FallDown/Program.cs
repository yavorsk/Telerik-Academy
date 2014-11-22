using System;

class Program
{
    static void Main()
    {
        int[,] matr = new int[8, 8];

        for (int i = 0; i < 8; i++)
        {
            int n = int.Parse(Console.ReadLine());
            for (int j = 0; j < 8; j++)
            {
                matr[i, j] = (n >> j) & 1;
            }
        }

        for (int i = 7; i > -1; i--)
        {
            for (int j = 0; j < 8; j++)
            {
                if (matr[i,j]==0)
                {
                    for (int k = i-1; k > -1; k--)
                    {
                        if (matr[k,j] == 1)
                        {
                            matr[k, j] = 0;
                            matr[i, j] = 1;
                            break;
                        }
                    }
                }
            }
        }

        int[] nums = new int[8];

        for (int i = 0; i < 8; i++)
        {
            int numDeci = 0;
            for (int j = 0; j < 8; j++)
            {
                numDeci += matr[i, j] * (int)Math.Pow(2,j); 
            }
            nums[i] = numDeci;
        }

        for (int i = 0; i < 8; i++)
        {
            Console.WriteLine(nums[i]);
        }
    }
}
