using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.GenerateVariations
{
    class VariationsWithRepetition
    {
        // Variations with repetition
        static void Main()
        {
            //int n = 3;
            int k = 3;

            string[] set = new string[] { "hi", "a", "b", "cc" };

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
                    resultSet[index] = set[i];
                    GenerateVariationsOf<T>(set, resultSet, index + 1);
                }
            }
        }
    }
}
