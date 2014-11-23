using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frames2
{
    class Frames2
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            
            //int[][] frames = new int[2][N];
            List<int[]> frames = new List<int[]>();

            for (int i = 0; i < N; i++)
            {
                string[] size = Console.ReadLine().Split(new char[] { ' ' });

                frames.Add(new int[] { int.Parse(size[0]), int.Parse(size[1]) });
            }

            //PrintArr(frames);

            GeneratePermutations(frames, 0);
        }

        static void GeneratePermutations(List<int[]> arr, int index)
        {
            if (index >= arr.Count)
            {
                //PrintArr(arr);
            }
            else
            {
                GeneratePermutations(arr, index + 1);
                for (int i = index + 1; i < arr.Count; i++)
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

        static void Swap(int[] first, int[] second)
        {
            int[] oldFirst = first;
            first = second;
            second = oldFirst;
        }

        static void PrintArr(List<int[]> arr)
        {
            for (int i = 0; i < arr.Count; i++)
            {
                Console.Write("({0}, {1})", arr[i][0], arr[i][1]);
                if (i < arr.Count - 1)
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
