using System;
using System.IO;

// 7. Write a program that replaces all occurrences of the substring "start" with the substring "finish" in a text file. 
// Ensure it will work with large files (e.g. 100 MB).

class ReplaseStartFinish
{
    static void Main()
    {
        string inputFile = @"..\..\inputFile.txt";
        string outputFile = @"..\..\outputFile.txt";

        using (StreamReader readFile = new StreamReader(inputFile))
        {
            using (StreamWriter writeFile = new StreamWriter(outputFile))
            {
                string line = readFile.ReadLine();
                while (line != null)
                {
                    line = line.Replace("start".ToLower(), "finish");
                    writeFile.WriteLine(line);
                    line = readFile.ReadLine();
                }
            }
        }
    }
}
