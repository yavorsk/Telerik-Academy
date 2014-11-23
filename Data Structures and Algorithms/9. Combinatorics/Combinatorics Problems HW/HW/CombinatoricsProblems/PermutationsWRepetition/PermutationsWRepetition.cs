using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColouredBallsSequence
{
    class PermutationsWRepetition
    {
        static int countOfPermutations = 0;

        static void Main()
        {
            int[] array = new int[] { 3, 5, 1, 5, 5 };
            Array.Sort(array);
            PrintArr(array);
            Console.WriteLine(new string('-', 20));

            GeneratePermutations(array, 0, array.Length);
            Console.WriteLine(countOfPermutations);
        }

        static void GeneratePermutations(int[] arr, int start, int n)
        {
            countOfPermutations++;
            PrintArr(arr);

            for (int left = n - 2; left >= start; left--)
            {
                for (int right = left + 1; right < n; right++)
                {
                    if (arr[left] != arr[right])
                    {
                        Swap(ref arr[left], ref arr[right]);
                        GeneratePermutations(arr, left + 1, n);
                    }
                }

                var firstElement = arr[left];
                for (int i = left; i < n - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }

                arr[n - 1] = firstElement;
            }
        }

        static void Swap(ref int first, ref int second)
        {
            int oldFirst = first;
            first = second;
            second = oldFirst;
        }

        static void PrintArr(int[] arr)
        {
            Console.WriteLine(string.Join(", ", arr));
        }
    }
}
