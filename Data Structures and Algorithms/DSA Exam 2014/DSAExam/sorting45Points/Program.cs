using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Program
    {
        static int minMoves;
        static HashSet<int[]> used = new HashSet<int[]>();
        static Queue<Sequence> queue = new Queue<Sequence>();

        static void Main()
        {
            //int N = int.Parse(Console.ReadLine());
            //Console.WriteLine(N);

            int N = int.Parse(Console.ReadLine());

            int[] array = new int[N];

            string[] strNumbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = int.Parse(strNumbers[i]);
            }

            int K = int.Parse(Console.ReadLine());


            var newSeq = new Sequence(array);
            queue.Enqueue(newSeq);
            used.Add(array);

            //Solve(newSeq, 0);

            while (queue.Count > 0)
            {
                var currentSeq = queue.Dequeue();

                if (IsSorted(currentSeq.Arr))
                {
                    Console.WriteLine(currentSeq.QueueLevel);
                    break;
                }

                for (int i = 0; i <= N - K; i++)
                {
                    int[] arr = HandleArr(currentSeq.Arr, i, K);
                    if (!used.Contains(arr))
                    {
                        var nextSeq = new Sequence(arr);
                        nextSeq.QueueLevel = currentSeq.QueueLevel + 1;
                        queue.Enqueue(nextSeq);
                        used.Add(arr);
                    }
                }
            }
        }

        private static int[] HandleArr(int[] currentArray, int index, int K)
        {
            List<int> newArray = new List<int>();

            for (int i = 0; i <= index - 1; i++)
            {
                newArray.Add(currentArray[i]);
            }

            for (int i = index + K - 1; i >= index; i--)
            {
                newArray.Add(currentArray[i]);
            }

            for (int i = K + index; i < currentArray.Length; i++)
            {
                newArray.Add(currentArray[i]);
            }

            return newArray.ToArray();
        }

        private static void HandleArr2(int[] currentArray, int index, int K)
        {
            for (int i = 0; i < K - 1; i++)
            {
                Swap<int>(ref currentArray[index + i], ref currentArray[index + K - 1 - i]);
            }
        }

        //BFS(node)
        //{
        //  queue  node
        //  visited[node] = true
        //  while queue not empty
        //    v  queue
        //    print v
        //    for each child c of v
        //      if not visited[c]
        //        queue  c
        //        visited[c] = true
        //}

        private static bool IsSorted(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    return false;
                }
            };

            return true;
        }

        static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }

        public class Sequence
        {
            public Sequence(int[] arr)
            {
                this.Arr = arr;
            }

            public int[] Arr { get; set; }

            public int QueueLevel { get; set; }
        }
    }
}
