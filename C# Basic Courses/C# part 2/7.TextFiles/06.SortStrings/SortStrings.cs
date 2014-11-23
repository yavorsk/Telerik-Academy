using System;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file. 
/// Example:
///	Ivan			George
///	Peter			Ivan
///	Maria			Maria
///	George			Peter
/// </summary>

class SortStrings
{
    static List<string> ReadAndSort(string inputFile)
    {
        List<string> resultList = new List<string>();

        using (StreamReader input = new StreamReader(inputFile))
        {
            string line = input.ReadLine();
            while (line != null)
            {
                resultList.Add(line);
                line = input.ReadLine();
            }
        }

        resultList.Sort();
        return resultList;
    }

    static void WriteListTooFile(List<string> sortedStringList, string outputFile)
    {
        using (StreamWriter writeOutputFile = new StreamWriter(outputFile))
        {
            for (int i = 0; i < sortedStringList.Count; i++)
            {
                writeOutputFile.WriteLine(sortedStringList[i]);
            }
        }
    }

    static void Main()
    {
        string input = @"..\..\input.txt";
        string output = @"..\..\output.txt";

        List<string> sortedStringList = ReadAndSort(input);
        WriteListTooFile(sortedStringList, output);
    }
}
