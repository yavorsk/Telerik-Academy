using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.GenerateCombinations
{
    class GenerateCombinations
    {
        static void Main()
        {
            int n = 5;
            int k = 3;

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

                    GenerateCombos(arr, index + 1, i, endNum);
                }
            }
        }
    }
}
