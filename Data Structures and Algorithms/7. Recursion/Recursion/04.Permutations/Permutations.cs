using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Permutations
{
    class Permutations
    {
        static void Main()
        {
            int n = 3;

            int[] arr = new int[3];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i + 1;
            }

            GeneratePermutations(arr, 0);
        }

        static void GeneratePermutations(int[] arr, int index)
        {
            if (index >= arr.Length)
            {
                Console.WriteLine("{" + String.Join(" ", arr) + "}");
            }
            else
            {
                GeneratePermutations(arr, index + 1);
                for (int i = index + 1; i < arr.Length; i++)
                {
                    Swap(ref arr[index], ref arr[i]);
                    GeneratePermutations(arr, index + 1);
                    Swap(ref arr[index], ref arr[i]);
                }
            }
        }

        static void Swap(ref int first, ref int second)
        {
            int oldFirst = first;
            first = second;
            second = oldFirst;
        }
    }
}
