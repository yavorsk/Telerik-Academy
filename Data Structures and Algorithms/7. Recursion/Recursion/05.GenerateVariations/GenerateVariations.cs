using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.GenerateVariations
{
    class GenerateVariations
    {
        static int n = 3;
        static bool[] used = new bool[n];
        // Variations without repetition
        static void Main()
        {
            int k = 2;

            string[] set = new string[] { "hi", "a", "b" };

            string[] result = new string[k];

            GenerateVariationsOf<string>(set, result, 0);
        }

        private static void GenerateVariationsOf<T>(T[] set, T[] resultSet, int index)
        {
            if (index >= resultSet.Length)
            {
                Console.WriteLine("(" + String.Join(" ", resultSet) + ")");
            }
            else
            {
                for (int i = 0; i < set.Length; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        resultSet[index] = set[i];
                        GenerateVariationsOf<T>(set, resultSet, index + 1);
                        used[i] = false;
                    }
                }
            }
        }
    }
}