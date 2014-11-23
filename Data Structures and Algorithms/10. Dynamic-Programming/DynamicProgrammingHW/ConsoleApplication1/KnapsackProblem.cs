using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnapsackProblem
{
    class KnapsackProblem
    {
        static void Main()
        {
            // http://en.wikipedia.org/wiki/Knapsack_problem
            int sackCapacity = 10;

            List<Item> items = new List<Item> 
             {
                 new Item { Name = "beer", Weight = 3, Cost = 2 },
                 new Item { Name = "vodka", Weight = 8, Cost = 12 },
                 new Item { Name = "cheese", Weight = 4, Cost = 5 },
                 new Item { Name = "nuts", Weight = 1, Cost = 4 },
                 new Item { Name = "ham", Weight = 2, Cost = 3 },
                 new Item { Name = "whiskey", Weight = 8, Cost = 13 }
             };

            int[,] table = new int[items.Count + 1, sackCapacity + 1];

            for (int itemIndex = 1; itemIndex < table.GetLength(0); itemIndex++)
            {
                for (int currentCapacity = 0; currentCapacity < table.GetLength(1); currentCapacity++)
                {
                    if (items[itemIndex - 1].Weight <= currentCapacity)
                    {
                        table[itemIndex, currentCapacity] = Math.Max(table[itemIndex - 1, currentCapacity],
                                                                     table[itemIndex - 1, currentCapacity - items[itemIndex - 1].Weight] + items[itemIndex - 1].Cost);
                    }
                    else
                    {
                        table[itemIndex, currentCapacity] = table[itemIndex - 1, currentCapacity];
                    }
                }
            }

            //PrintArray(table);
            //Get the biggest from the bottom row of the table
            var resultCandidates = new List<int>();

            for (int j = 0; j < table.GetLength(1); j++)
            {
                resultCandidates.Add(table[table.GetLength(0) - 1, j]);
            }

            Console.WriteLine("Maximal value in sack: {0}", resultCandidates.Max());
        }

        static void PrintArray(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + "  ");
                }

                Console.WriteLine();
            }
        }
    }
}
