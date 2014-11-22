using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._4.CSharpBrackets2
{
    class CSharpBrackets2
    {
        static StringBuilder formattedCode = new StringBuilder();
        static string indent = string.Empty;

        static void Main()
        {
            int linesOfCode = int.Parse(Console.ReadLine());
            indent = Console.ReadLine();
            int indCount = 0;

            for (int i = 0; i < linesOfCode; i++)
            {
                StringBuilder inputLine = new StringBuilder(Console.ReadLine().Trim()); // imame line bez leading ili trailing whitespaces

                if (string.IsNullOrWhiteSpace(inputLine.ToString()))
                {
                    continue;
                }

                for (int j = 1; j < inputLine.Length - 1; j++) // imame line bez posledovatelni whitespaces
                {
                    if (inputLine[j] == ' ' && inputLine[j + 1] == ' ')
                    {
                        inputLine.Remove(j + 1, 1);
                        j--;
                    }
                }

                for (int j = 0; j < inputLine.Length; j++)
                {
                    if (inputLine[j] == '{')
                    {
                        MakeLine(indCount++, "{");
                        formattedCode.Append("\n");
                    }
                    else if (inputLine[j] == '}')
                    {
                         MakeLine(--indCount, "}");
                         formattedCode.Append("\n");
                    }
                    else if (inputLine[j] != '{' && inputLine[j] != '}')
                    {
                        StringBuilder inLine = new StringBuilder();

                        while (j < inputLine.Length && (inputLine[j] != '{' && inputLine[j] != '}'))
                        {
                            inLine.Append(inputLine[j]);
                            j++;
                        }

                        MakeLine(indCount, inLine.ToString().Trim());
                        formattedCode.Append("\n");
                        j--;                         

                    }
                }
            }

            Console.WriteLine(formattedCode.ToString());
        }

        static void MakeLine(int indCount, string text)
        {
            for (int j = 0; j < indCount; j++) // dobaviame indentaciite v nachaloto na vseki red
            {
                formattedCode.Append(indent);
            }
            formattedCode.Append(text);
        }
    }
}
