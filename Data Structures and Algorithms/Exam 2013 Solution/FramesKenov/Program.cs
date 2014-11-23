using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FramesKenov
{
    class Program
    {
        static SortedSet<string> result = new SortedSet<string>();
 
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var frames = new Frame[n];

            for (int i = 0; i < n; i++)
            {
                int[] sizes = Console.ReadLine().Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                frames[i] = new Frame(sizes[0], sizes[1]);
            }

            GeneratePermutations(frames, 0);

            var output = new StringBuilder();
            foreach (var frame in result)
            {
                output.AppendLine(frame);
            }

            Console.WriteLine(result.Count);
            Console.WriteLine(output.ToString().Trim());
        }

        static void GeneratePermutations(Frame[] arr, int index)
        {
            if (index >= arr.Length)
            {
                result.Add(string.Join(" | ", arr));
            }
            else
            {
                GeneratePermutations(arr, index + 1);
                SwapFrame(ref arr[index]);
                GeneratePermutations(arr, index + 1);
                SwapFrame(ref arr[index]);

                for (int i = index + 1; i < arr.Length; i++)
                {
                    Swap(ref arr[index], ref arr[i]);

                    GeneratePermutations(arr, index + 1);
                    SwapFrame(ref arr[index]);
                    GeneratePermutations(arr, index + 1);
                    SwapFrame(ref arr[index]);

                    Swap(ref arr[index], ref arr[i]);
                }
            }
        }

        static void SwapFrame(ref Frame frame)
        {
            var temp = frame.Height;
            frame.Height = frame.Width;
            frame.Width = temp;
        }

        static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }

        public struct Frame
        {
            public Frame(int width, int height)
                : this()
            {
                this.Height = height;
                this.Width = width;
            }

            public int Width { get; set; }

            public int Height { get; set; }

            public override string ToString()
            {
                string res = string.Format("({0}, {1})", this.Width, this.Height);
                return res;
            }
        }
    }
}
