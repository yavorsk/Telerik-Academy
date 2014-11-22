using System;
using System.IO;

// 10. Write a program that extracts from given XML file all the text without the tags. Example:
// <?xml version="1.0"><student><name>Pesho</name><age>21</age><interests count="3"><interest> Games</instrest><interest>C#</instrest><interest> Java</instrest></interests></student>



class ExtractTextwoTags
{
    static void Main(string[] args)
    {
        string inputFile = @"..\..\inputFile.txt";
        string outputFile = @"..\..\outputFile.txt";

        using (StreamReader readInput = new StreamReader(inputFile))
        {
            using (StreamWriter writeOutput = new StreamWriter(outputFile))
            {
                string line = readInput.ReadLine();
                while (line != null)
                {
                    for (int i = 0; i < line.Length; i++)
                    {
                        i = line.IndexOf('>', i);
                        if (i == line.Length-1)
                        {
                            break;
                        }
                        int startTagInd = line.IndexOf('<', i);
                        int length = startTagInd - i-1;
                        string word = line.Substring(i+1, length).Trim();
                        
                        if (word != string.Empty)
                        {
                            writeOutput.WriteLine(word);
                        }
                    }
                    line = readInput.ReadLine();
                }
            }
        }
    }
}
