using System;
using System.IO;

//2. Write a program that concatenates two text files into another text file.

class ConcatenateTextFiles
{
    static void Main()
    {
        string sourceFile1 = @"..\..\source1.txt";
        string sourceFile2 = @"..\..\source2.txt";
        string outputFile = @"..\..\out.txt";

        using (StreamReader file1 = new StreamReader(sourceFile1))
        {
            using (StreamReader file2 = new StreamReader(sourceFile2))
            {
                using (StreamWriter writer = new StreamWriter(outputFile, true))
                {
                    string line = string.Empty;
                    while (line!= null)
                    {
                        line = file1.ReadLine();
                        writer.WriteLine(line);
                    }
                    line = string.Empty;
                    while (line != null)
                    {
                        line = file2.ReadLine();
                        writer.WriteLine(line);
                    }
                }
            }
        }
    }
}
