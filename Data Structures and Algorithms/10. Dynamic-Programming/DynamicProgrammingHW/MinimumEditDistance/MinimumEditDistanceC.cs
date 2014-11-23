﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumEditDistance
{
    // I admit i copy-pasted this structured and well explained solution .... 

    public class MinimumEditDistanceC
    {
        private const decimal CostDelete = 0.9M;
        private const decimal CostInsert = 0.8M;
        private const decimal CostReplace = 1M;
        private static decimal[,] table;

        public static void Main()
        {
            var result1 = Compute("developer", "enveloped");
            Console.WriteLine("Words: developer -> enveloped");
            Console.WriteLine("Distance = {0}", result1);
            PrintCostsTable();
        }

        /// <summary>
        /// Compute the distance between two words.
        /// </summary>
        public static decimal Compute(string word1, string word2)
        {
            int n = word1.Length;
            int m = word2.Length;
            table = new decimal[n + 1, m + 1];

            // Step 1: Fill cost of deletions
            for (int row = 0; row <= n; row++)
            {
                table[row, 0] = row * CostDelete;
            }

            // Step 2: Fill cost of insertions
            for (int col = 0; col <= m; col++)
            {
                table[0, col] = col * CostInsert;
            }

            // Step 3: Calculate and choose min cost operation
            // -----------------------------------
            // |diag Cell  | above Cell           |
            // -----------------------------------
            // |           | min (above + delete, |
            // |left Cell  |      diag + replace, |
            // |           |      left + insert)  |
            // -----------------------------------
            for (int row = 1; row <= n; row++)
            {
                // Step 4
                for (int col = 1; col <= m; col++)
                {
                    // Step 5: Calculate the cost of replacing. If the letters are equal it is 0, otherwise its the replace operation cost
                    decimal cost = (word2[col - 1] == word1[row - 1]) ? 0 : CostReplace;

                    // Step 6: Find the minimal cost operation of the 3 possible
                    decimal delete = table[row - 1, col] + CostDelete;
                    decimal replace = table[row - 1, col - 1] + cost;
                    decimal insert = table[row, col - 1] + CostInsert;

                    table[row, col] = Math.Min(
                        Math.Min(delete, insert),
                        replace);
                }
            }

            // Step 7: Take and return the result (most down-right cell)
            return table[n, m];
        }

        public static void PrintCostsTable()
        {
            Console.WriteLine("Costs table");
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    Console.Write("{0, 4} ", table[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
