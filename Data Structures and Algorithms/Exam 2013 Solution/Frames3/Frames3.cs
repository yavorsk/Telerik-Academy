using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frames3
{
    class Frames3
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());

            //int[][] frames = new int[2][N];
            string[] frames = new string[N];

            for (int i = 0; i < N; i++)
            {
                frames[i] = Console.ReadLine();
            }

            //PrintArr(frames);

            GeneratePermutations(frames, 0);
        }

        static void GeneratePermutations(string[] arr, int index)
        {
            if (index >= arr.Length)
            {
                PrintArr(arr);
            }
            else
            {
                GeneratePermutations(arr, index + 1);
                for (int i = index + 1; i < arr.Length; i++)
                {
                    //Swap(arr[index], arr[i]);
                    var temp = arr[index];
                    arr[index] = arr[i];
                    arr[i] = temp;
                    GeneratePermutations(arr, index + 1);
                    //Swap(arr[index], arr[i]);
                    var temp2 = arr[index];
                    arr[index] = arr[i];
                    arr[i] = temp2;
                }
            }
        }

        static void Swap(string first, string second)
        {
            string oldFirst = first;
            first = second;
            second = oldFirst;
        }

        static void PrintArr(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("({0})", arr[i]);
                if (i < arr.Length - 1)
                {
                    Console.Write(" | ");
                }
                else
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
