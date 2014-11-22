using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4.ConsoleJustification
{
    class ConsoleJustification
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int w = int.Parse(Console.ReadLine());

            StringBuilder inputText = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                inputText.Append(Console.ReadLine());
                if (i != n-1)
                {
                    inputText.Append(" ");
                }
            }

            string[] words = inputText.ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            StringBuilder outputLine = new StringBuilder();
            int index = 0;
            int outputLineLength = outputLine.Length;

            while (index <= words.Length - 1)
            {
                while (true)
                {
                    if (index < words.Length && outputLine.Length + words[index].Length <= w)
                    {
                        outputLine.Append(words[index]);
                        index++;
                    }
                    else
                    {
                        break;
                    }
                    if (1 + outputLine.Length <= w)
                    {
                        outputLine.Append(" ");
                    }
                    else
                    {
                        break;
                    }
                }

                if (outputLine[outputLine.Length - 1] == ' ')
                {
                    outputLine.Remove(outputLine.Length - 1, 1);
                }
                index--;
                if (outputLine.ToString().IndexOf(' ', 0) != -1)// && index < words.Length - 1)
                {
                    int missingSpaces = w - outputLine.Length;
                    int ind = 0;
                    int gap = 2;

                    for (int j = 0; j < missingSpaces; j++)
                    {
                        ind = outputLine.ToString().IndexOf(' ', ind);
                        
                        if (ind == -1)
                        {
                            ind = 0;
                            j--;
                            gap++;
                            continue;
                        }
                        outputLine.Insert(ind, ' ');
                        ind += gap;
                    }
                }
                index++;
                Console.WriteLine(outputLine.ToString());
                outputLine.Clear();
            }
        }
    }
}
