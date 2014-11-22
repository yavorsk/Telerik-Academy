using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Grisko
{
    class Program
    {
        static int count = 0;
        static List<char> inputChars = new List<char>();

        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                inputChars.Add(input[i]);
            }

            int[] arrayOfNumbers = new int[inputChars.Count];

            for (int i = 0; i < inputChars.Count; i++)
            {
                arrayOfNumbers[i] = i;
            }

            Permute(arrayOfNumbers, 0, arrayOfNumbers.Length - 1);

            Console.WriteLine(count);
        }

        static void Swap(ref int first, ref int second)
        {
            int temp = first;
            first = second;
            second = temp;
        }

        static void Permute(int[] array, int current, int length)
        {
            if (current == length)
            {
                StringBuilder word = new StringBuilder();

                for (int i = 0; i <= length; i++)
                {
                    word.Append(inputChars[array[i]]);
                }

                CheckWord(word.ToString());
            }
            else
            {
                for (int i = current; i <= length; i++)
                {
                    Swap(ref array[i], ref array[current]);
                    Permute(array, current + 1, length);
                    Swap(ref array[i], ref array[current]);
                }
            }
        }

        private static void CheckWord(string word)
        {
            bool ok = true;

            for (int i = 0; i < word.Length - 1; i++)
            {
                if (word[i] == word[i+1])
                {
                    ok = false;
                    break;
                }
            }

            if (ok)
            {
                count++;
            }
        }
    }
}
