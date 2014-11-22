using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._4.CsharpBrackets
{
    class CsharpBrackets
    {
        static StringBuilder formattedCode = new StringBuilder();

        static void Main()
        {
            int linesOfCode = int.Parse(Console.ReadLine());
            string indent = Console.ReadLine();

            int indCount = 0;

            for (int i = 0; i < linesOfCode; i++)
            {
                StringBuilder line = new StringBuilder(Console.ReadLine().Trim()); // imame line bez leading ili trailing whitespaces

                if (line.ToString() == string.Empty) // preskachame ako imame prazen red
                {
                    continue;
                }

                if (string.IsNullOrWhiteSpace(line.ToString()))
                {
                    continue;
                }

                if (line.ToString() == " ")
                {
                    continue;
                }

                for (int j = 1; j < line.Length - 1; j++) // imame line bez posledovatelni whitespaces
                {
                    if (line[j] == ' ' && line[j + 1] == ' ')
                    {
                        line.Remove(j + 1, 1);
                        j--;
                    }
                }

                for (int j = 0; j < indCount; j++) // dobaviame indentaciite v nachaloto na vseki red
                {
                    formattedCode.Append(indent);
                }

                for (int j = 0; j < line.Length; j++) // obhojdame simvolite na line
                {
                    if (j == 0 && j== line.Length - 1 && line[j] == '{')
                    {
                        formattedCode.Append(line[j]);
                        indCount++;
                        formattedCode.Append("\n");
                        break;
                    }

                    if (j == 0 && line[j] == '{')
                    {
                        formattedCode.Append(line[j]);
                        formattedCode.Append("\n");
                        indCount++;
                        for (int k = 0; k < indCount; k++)
                        {
                            formattedCode.Append(indent);
                        }
                        continue;
                    }

                    if (j == line.Length - 1 && line[j] == '{')
                    {
                        formattedCode.Append("\n");
                        for (int k = 0; k < indCount; k++)
                        {
                            formattedCode.Append(indent);
                        }
                        formattedCode.Append(line[j]);
                        indCount++;
                        formattedCode.Append("\n");
                        break;
                    }

                    if (j != 0 && j!= line.Length - 1 && line[j] == '{')
                    {
                        formattedCode.Append("\n");
                        for (int k = 0; k < indCount; k++)
                        {
                            formattedCode.Append(indent);
                        }
                        formattedCode.Append(line[j]);
                        indCount++;
                        formattedCode.Append("\n");
                        for (int k = 0; k < indCount; k++)
                        {
                            formattedCode.Append(indent);
                        }
                        continue;
                    }

                    if (j == 0 && j == line.Length - 1 && line[j] == '}')
                    {
                        formattedCode.Remove(formattedCode.Length - indent.Length, indent.Length);
                        formattedCode.Append(line[j]);
                        indCount--;
                        formattedCode.Append("\n");
                        break;
                    }

                    if (j == 0 && line[j] == '}')
                    {
                        formattedCode.Remove(formattedCode.Length - indent.Length, indent.Length);
                        formattedCode.Append(line[j]);
                        indCount--;
                        formattedCode.Append("\n");
                        continue;
                    }

                    if (j == line.Length - 1 && line[j] == '}')
                    {
                        formattedCode.Append("\n");
                        indCount--;
                        for (int k = 0; k < indCount; k++)
                        {
                            formattedCode.Append(indent);
                        }
                        formattedCode.Append(line[j]);
                        formattedCode.Append("\n");
                        break;
                    }

                    if (j != line.Length - 1 && j != 0 && line[j] == '}')
                    {
                        formattedCode.Append("\n");
                        indCount--;
                        for (int k = 0; k < indCount; k++)
                        {
                            formattedCode.Append(indent);
                        }
                        formattedCode.Append(line[j]);
                        formattedCode.Append("\n");
                        for (int k = 0; k < indCount; k++)
                        {
                            formattedCode.Append(indent);
                        }
                        continue;
                    }

                    else
                    {
                        if (line[j] == ' ' && ( line[j - 1] == '{' || line[j+1] == '{' || line[j - 1] == '}' || line[j+1] == '}'))
                        {
                            continue;
                        }

                        if (j == line.Length - 1)
                        {
                            formattedCode.Append(line[j]);
                            formattedCode.Append("\n");
                            break;
                        }
                        else
                        {
                            formattedCode.Append(line[j]);
                            continue;
                        }
                    }
                }
            }
            formattedCode.Remove(formattedCode.Length - 1, 1);
            Console.WriteLine(formattedCode.ToString());
        }
    }
}
