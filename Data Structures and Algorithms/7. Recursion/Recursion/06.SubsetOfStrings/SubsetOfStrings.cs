using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.SubsetOfStrings
{
    class SubsetOfStrings
    {
        static int n = 4;
        static bool[] used = new bool[n];
        // Variations without repetition
        static void Main()
        {
            //int n = 3;
            int k = 2;

            string[] set = new string[] { "test", "rock", "fun", "scissors" };

            string[] result = new string[k];

            GenerateVariationsOf<string>(set, result, 0, 0);
        }

        private static void GenerateVariationsOf<T>(T[] set, T[] resultSet, int index, int startIndex)
        {
            if (index >= resultSet.Length)
            {
                Console.WriteLine("(" + String.Join(" ", resultSet) + ")");
            }
            else
            {
                for (int i = startIndex; i < set.Length; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        resultSet[index] = set[i];
                        GenerateVariationsOf<T>(set, resultSet, index + 1, i + 1);
                        used[i] = false;
                    }
                }
            }
        }
    }
}
