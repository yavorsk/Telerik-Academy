using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        //int n = 0;
        List<uint> inputNums = new List<uint>();
        bool inside = false;
        //bool insideChek = false;
        //bool boundCheck = false;
        int bound = -1;

        while (true)
        {
            uint num = new uint();
            if (uint.TryParse(Console.ReadLine(), out num))
            {
                inputNums.Add(num);
            }
            else
            {
                break;
            }
        }
        //Console.WriteLine();
        //Console.WriteLine(inputNums.Count);
        //Console.WriteLine();
        //for (int i = 0; i < inputNums.Count; i++)
        //{
        //    Console.WriteLine(inputNums[i]);
        //}
        uint[,] matrix = new uint[inputNums.Count, 32];

        for (int i = 0; i < inputNums.Count; i++)
        {
            for (int j = 0; j < 32; j++)
            {
                matrix[i, j] = (inputNums[i] >> j) & 1;
            }
        }

        //for (int i = 0; i < inputNums.Count; i++) // print the matrix
        //{
        //    for (int j = 0; j < 32; j++)
        //    {
        //        Console.Write(matrix[i, j]);
        //    }
        //    Console.WriteLine();
        //}

        for (int i = 0; i < inputNums.Count; i++)
        {
            for (int j = 0; j < 32; j++)
            {
                if (matrix[i,j]==1 && bound == -1)
                {
                    int ones = 0;
                    int k = j;
                    while (matrix[i,k]==1)
                    {
                        ones++;
                        k++;
                        if (k>31)
                        {
                            break;
                        }
                    }
                    if (ones>2)
                    {
                        bound = 2;
                    }
                    else if (ones==2)
                    {
                        bound = 1;
                    }
                    else if (ones==1)
                    {
                        bound = 0;
                    }
                }
                if (matrix[i,j] == 1 && bound == 2)
                {
                    matrix[i, j] = 0; continue;
                }
                if (matrix[i,j] == 1 && bound == 1)
                {
                    matrix[i, j] = 0; 
                    bound = 0;
                    continue;
                }
                if (matrix[i, j] == 1 && bound == 0)
                {
                    matrix[i, j] = 0;
                    if (inside==true)
                    {
                        inside = false;
                    }
                    else
                    {
                        inside = true;
                    }
                    continue;
                }
                if (matrix[i, j] == 0 && inside == true)
                {
                    matrix[i, j] = 1;
                    bound = -1;
                    continue;
                }
                if (matrix[i, j] == 0 && inside == false)
                {
                    matrix[i, j] = 0;
                    bound = -1;
                    continue;
                }
            }
            inside = false;
            bound = -1;
        }

        //for (int i = 0; i < inputNums.Count; i++) // print the matrix
        //{
        //    for (int j = 0; j < 32; j++)
        //    {
        //        Console.Write(matrix[i, j]);
        //    }
        //    Console.WriteLine();
        //}

        for (int i = 0; i < inputNums.Count; i++)
        {
            uint output = 0;
            for (int j = 0; j < 32; j++)
            {
                output += matrix[i, j] * (uint)Math.Pow(2, j);
            }
            Console.WriteLine(output);
        }
    }
}
