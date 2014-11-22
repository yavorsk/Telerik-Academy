using System;
using System.IO;

//3. Write a program that reads a text file and inserts line numbers in front of each of its lines. 
// The result should be written to another text file.

class InsertLineNumbers
{
    static void Main()
    {
        string sourceFile = @"..\..\source.txt";
        string outputFile = @"..\..\out.txt";

        using (StreamReader reader = new StreamReader(sourceFile))
        {
            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                string line = reader.ReadLine();
                int lineNumber = 0;

                while (line != null)
                {
                    writer.WriteLine(line.Insert(0, lineNumber++ + ". "));
                    line = reader.ReadLine();
                }
            }
        }
    }
}
