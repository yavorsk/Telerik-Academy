using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.MagicWords
{
    class Program
    {
        static List<string> words = new List<string>();

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int line = 0; line < n; line++)
            {
                words.Add(Console.ReadLine());
            }

            for (int word = 0; word < words.Count; word++)
            {
                int newPos = words[word].Length % (n + 1);
                if (newPos > word + 1)
                {
                    if (newPos<n)
                    {
                        words.Insert(newPos, words[word]);
                    }
                    else
                    {
                        words.Add(words[word]);
                    }

                    words.RemoveAt(word);
                }

                else if (newPos < word)
                {
                    if (newPos < n)
                    {
                        words.Insert(newPos, words[word]);
                    }
                    else
                    {
                        words.Add(words[word]);
                    }

                    words.RemoveAt(word + 1);
                }
            }

            int maxWordLength = 0;

            for (int i = 0; i < words.Count; i++)
            {
                if (words[i].Length > maxWordLength)
                {
                    maxWordLength = words[i].Length;
                }
            }

            StringBuilder result = new StringBuilder();

            for (int letter = 0; letter < maxWordLength; letter++)
            {
                for (int j = 0; j < words.Count; j++)
                {
                    if (words[j].Length > letter)
                    {
                        result.Append(words[j][letter]);
                    }
                }
            }

            Console.WriteLine(result.ToString());
        }
    }
}
