using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.GenCombsWoDuplication
{
    class GenCombsWoDuplication
    {
        static void Main()
        {
            int n = 3;
            int k = 2;

            int[] arr = new int[k];

            GenerateCombos(arr, 0, 1, n);
        }

        private static void GenerateCombos(int[] arr, int index, int startNum, int endNum)
        {
            if (index >= arr.Length)
            {
                Console.WriteLine("(" + String.Join(" ", arr) + ")");
            }
            else
            {
                for (int i = startNum; i <= endNum; i++)
                {
                    arr[index] = i;

                    GenerateCombos(arr, index + 1, i + 1, endNum);
                }
            }
        }
    }
}
