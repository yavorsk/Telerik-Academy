using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SimulateNestedLoops
{
    class SimulateNestedLoops
    {
        static void Main()
        {
            int n = 3;

            int[] arr = new int[n];

            GenerateLoop(arr, 0);
        }

        private static void GenerateLoop(int[] arr, int index)
        {
            if (index >= arr.Length)
            {
                Console.WriteLine(String.Join(" ", arr));
            }
            else
            {
                for (int i = 1; i <= arr.Length; i++)
                {
                    arr[index] = i;

                    GenerateLoop(arr, index + 1);
                }
            }
        }
    }
}
