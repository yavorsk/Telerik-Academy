using System;
using System.IO;

//4. Write a program that compares two text files line by line and prints the number of lines 
// that are the same and the number of lines that are different. Assume the files have equal number of lines.

class CompareFiles
{
    static void Main()
    {
        string file1 = @"..\..\File1.txt";
        string file2 = @"..\..\File2.txt";
        int sameLinesCount = 0;
        int differentLinesCount = 0;

        using (StreamReader file1reader = new StreamReader(file1))
        {
            using (StreamReader file2reader = new StreamReader(file2))
            {
                string line1 = file1reader.ReadLine();
                string line2 = file2reader.ReadLine();

                while (line1 != null)
                {
                    if (line1 == line2)
                    {
                        sameLinesCount++;
                    }
                    else
                    {
                        differentLinesCount++;
                    }
                    line1 = file1reader.ReadLine();
                    line2 = file2reader.ReadLine();
                }
            }
        }
        Console.WriteLine("Number of lines that are the same: {0}", sameLinesCount);
        Console.WriteLine("Number of lines that are the same: {0}", differentLinesCount);
    }
}
