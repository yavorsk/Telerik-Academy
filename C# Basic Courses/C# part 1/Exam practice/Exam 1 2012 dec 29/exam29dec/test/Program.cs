﻿using System;

class Program
{
    static void Main()
    {
        int[,] field = new int[8, 16];
        int n = new int();
        int lof = 0;
        int pigsDown = 0;
        int score = 0;
        bool hit = false;
        bool win = true;

        for (int i = 0; i < 8; i++)
        {
            n = int.Parse(Console.ReadLine());
            for (int j = 0; j < 16; j++)
            {
                field[i, j] = (n >> j) & 1;
            }
        }

        for (int j = 8; j < 16; j++)
        {
            for (int i = 0; i < 8; i++)
            {
                if (field[i, j] == 1)
                {
                    field[i, j] = 0;
                    int r = i;
                    int c = j;
                    while (r > 0)
                    {
                        r--;
                        c--;
                        lof++;
                        if (field[r, c] == 1)
                        {
                            hit = true;
                            if (r > 0)
                            {
                                for (int k = c - 1; k <= c + 1; k++)
                                {
                                    for (int l = r - 1; l <= r + 1; l++)
                                    {
                                        if (field[l, k] == 1)
                                        {
                                            pigsDown++;
                                            field[l, k] = 0;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                for (int k = c - 1; k <= c + 1; k++)
                                {
                                    for (int l = r; l <= r + 1; l++)
                                    {
                                        if (field[l, k] == 1)
                                        {
                                            pigsDown++;
                                            field[l, k] = 0;
                                        }
                                    }
                                }
                            }
                        }
                        if (hit)
                        {
                            score += lof * pigsDown;
                            lof = 0;
                            pigsDown = 0;
                            break;
                        }
                    }
                    if (hit)
                    {
                        break;
                    }
                    else
                    {
                        hit = false;
                        while (c > 0)
                        {
                            r++;
                            c--;
                            lof++;
                            if (field[r, c] == 1)
                            {
                                hit = true;
                                if (c == 0 && r == 7)
                                {
                                    for (int k = c - 1; k <= c; k++)
                                    {
                                        for (int l = r - 1; l <= r; l++)
                                        {
                                            if (field[l, k] == 1)
                                            {
                                                pigsDown++;
                                                field[l, k] = 0;
                                            }
                                        }
                                    }
                                }
                                else if (c == 0 && r < 7)
                                {
                                    for (int k = c - 1; k <= c; k++)
                                    {
                                        for (int l = r - 1; l <= r + 1; l++)
                                        {
                                            if (field[l, k] == 1)
                                            {
                                                pigsDown++;
                                                field[l, k] = 0;
                                            }
                                        }
                                    }
                                }
                                else if (c > 0 && r < 7)
                                {
                                    for (int k = c - 1; k <= c + 1; k++)
                                    {
                                        for (int l = r - 1; l <= r + 1; l++)
                                        {
                                            if (field[l, k] == 1) //problrm tuk
                                            {
                                                pigsDown++;
                                                field[l, k] = 0;
                                            }
                                        }
                                    }
                                }
                                else if (c > 0 && r == 7)
                                {
                                    for (int k = c - 1; k <= c + 1; k++)
                                    {
                                        for (int l = r - 1; l <= r; l++)
                                        {
                                            if (field[l, k] == 1)
                                            {
                                                pigsDown++;
                                                field[l, k] = 0;
                                            }
                                        }
                                    }
                                }
                            }
                            if (hit)
                            {
                                score += lof * pigsDown;
                                lof = 0;
                                pigsDown = 0;
                                hit = false;
                                break;
                            }
                        }
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
                    win = false;
                }
            }
        }

        if (win)
        {
            Console.WriteLine(score + " Yes");
        }
        else
        {
            Console.WriteLine(score + " No");
        }
    }
}