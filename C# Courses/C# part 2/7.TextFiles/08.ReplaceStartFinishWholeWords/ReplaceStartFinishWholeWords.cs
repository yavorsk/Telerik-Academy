using System;
using System.IO;
using System.Text.RegularExpressions;

// 8. Modify the solution of the previous problem to replace only whole words (not substrings).

class ReplaceStartFinishWholeWords
{
    static void Main()
    {
        string inputFile = @"..\..\inputFile.txt";

        using (StreamReader readFile = new StreamReader(inputFile))
        {
            using (StreamWriter writeFile = new StreamWriter(outputFile))
            {
                string line = readFile.ReadLine();
                while (line != null)
                {
                    line = Regex.Replace(line, @"\bstart\b", "finish");
                    writeFile.WriteLine(line);
                    line = readFile.ReadLine();
                }
            }
        }
    }
}
