using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string inputValley = "1, 3, -6, 7, 4 ,1, 12"; //Console.ReadLine();
        char[] cDividers = { ',', ' ' };
        string[] segments = inputValley.Split(cDividers, StringSplitOptions.RemoveEmptyEntries);
        int[] valley = new int[segments.Length];
        int m = 1; // int.Parse(Console.ReadLine());

        int maxGold = 0;

        for (int i = 0; i < segments.Length; i++)
        {
            if (segments[i].Length > 0)
            {
                valley[i] = int.Parse(segments[i]);
            }
        }
        int gold = valley[0];

        for (int i = 0; i < m; i++)
        {
            string inputPattern = Console.ReadLine();
            string[] segmentsForP = inputPattern.Split(cDividers, StringSplitOptions.RemoveEmptyEntries);
            int[] pattern = new int[segmentsForP.Length];
            for (int j = 0; j < segmentsForP.Length; j++)
            {
                if (segmentsForP[j].Length > 0)
                {
                    pattern[j] = int.Parse(segmentsForP[j]);
                }
            }

            int valleyPos = 0;
            List<int> usedValleyPos = new List<int>();
            usedValleyPos.Add(valleyPos);

            //int gold = valley[0];
        again:
            for (int j = 0; j < pattern.Length; j++)
            {
                for (int k = 0; k < usedValleyPos.Count; k++)
                {
                    if (valleyPos == usedValleyPos[k] && valleyPos != 0)
                    {
                        goto end;
                    }
                }
                if (valleyPos < 0 || valleyPos > valley.Length)
                {
                    goto end;
                }
                valleyPos = valleyPos + pattern[j];
                gold = gold + valley[valleyPos];
                usedValleyPos.Add(valleyPos);
                if (j == pattern.Length -1)
                {
                    goto again;
                }
            }
            if (gold > maxGold)
            {
                maxGold = gold;
            }
        }
        end:
        Console.WriteLine(gold);
    }
}
