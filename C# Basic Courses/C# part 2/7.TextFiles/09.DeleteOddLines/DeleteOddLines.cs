using System;
using System.Collections.Generic;
using System.IO;

// 9. Write a program that deletes from given text file all odd lines. The result should be in the same file.

class DeleteOddLines
{
    static void Main()
    {
        string inputFile = @"..\..\inputFile.txt";
        List<string> evenLines = new List<string>();

        using (StreamReader readFile = new StreamReader(inputFile))
        {
            string line = readFile.ReadLine();
            int rowCounter = 1;
            while (line != null)
            {
                if (rowCounter % 2 ==0)
                {
                    evenLines.Add(line);
                }
                line = readFile.ReadLine();
                rowCounter++;
            }
        }

        using (StreamWriter writeFile = new StreamWriter(inputFile))
        {
            foreach (var line in evenLines)
            {
                writeFile.WriteLine(line);
            }
        }
    }
}
