using System;
using System.IO;
using System.Text.RegularExpressions;

// 11. Write a program that deletes from a text file all words that start with the prefix "test". 
// Words contain only the symbols 0...9, a...z, A…Z, _.

class DeleteTestWords
{
    static void Main()
    {
        string inputFile = @"..\..\inputFile.txt";
        string outputFile = @"..\..\outpFile.txt";

        using (StreamReader readFile = new StreamReader(inputFile))
        {
            using (StreamWriter writeFile = new StreamWriter(outputFile))
            {
                string line = readFile.ReadLine();
                int rowCounter = 1;
                while (line != null)
                {
                    line = Regex.Replace(line, @"(\b)test((\d|\w|_)*)(\b)", "");
                    writeFile.WriteLine(line);

                    line = readFile.ReadLine();
                    rowCounter++;
                }  
            }
        }
    }
}
