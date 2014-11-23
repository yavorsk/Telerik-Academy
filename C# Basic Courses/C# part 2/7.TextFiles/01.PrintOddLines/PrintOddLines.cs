using System;
using System.IO;

// 1. Write a program that reads a text file and prints on the console its odd lines.

class PrintOddLines
{
    static void Main()
    {
        string fileName = @"..\..\txtFile.txt";
        using (StreamReader reader = new StreamReader(fileName))
        {
            int lineNumber = 0;
            string line = string.Empty;

            while (line != null)
            {
                line = reader.ReadLine();
                if (lineNumber % 2 !=0)
                {
                    Console.WriteLine(line);
                }
                lineNumber++;
            }
        }
    }
}
