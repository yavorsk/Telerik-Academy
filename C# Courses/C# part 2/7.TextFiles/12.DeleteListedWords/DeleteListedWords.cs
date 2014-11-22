using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

// 12.Write a program that removes from a text file all words listed in given another text file. 
// Handle all possible exceptions in your methods.

class DeleteListedWords
{
    static void Main()
    {
        string inputFile = @"..\..\inputFile.txt";
        string outputFile = @"..\..\outpFile.txt";
        string words = @"..\..\words.txt";

        List<string> wordsToDelete = new List<string>();
        
        using (StreamReader wordsFile = new StreamReader(words))
        {
            string line = wordsFile.ReadLine();
            while (line != null)
            {
                wordsToDelete.Add(line.Trim());
                line = wordsFile.ReadLine();
            }
        }

        StringBuilder wordCheck = new StringBuilder();

        try
        {
            using (StreamReader readInput = new StreamReader(inputFile))
            {
                using (StreamWriter writeOutput = new StreamWriter(outputFile))
                {
                    string line = readInput.ReadLine();
                    while (line != null)
                    {
                        for (int i = 0; i < line.Length; i++)
                        {
                            if (!char.IsLetter(line[i]))
                            {
                                if (wordsToDelete.Contains(wordCheck.ToString()))
                                {
                                    line = line.Replace(wordCheck.ToString(), "");
                                    i = i - wordCheck.Length;
                                }
                                wordCheck.Clear();
                            }
                            else
                            {
                                wordCheck.Append(line[i]);
                            }
                        }
                        writeOutput.WriteLine(line);
                        line = readInput.ReadLine();
                    }
                }
            }
        }
        catch (FileNotFoundException fnfe)
        {
            Console.WriteLine(fnfe.Message);
        }
        catch (DirectoryNotFoundException dnfe)
        {
            Console.WriteLine(dnfe.Message);
        }
        catch (ArgumentNullException ane)
        {
            Console.WriteLine(ane.Message);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
        catch (UnauthorizedAccessException uae)
        {
            Console.WriteLine(uae.Message);
        }
        catch (IOException ioe)
        {
            Console.WriteLine(ioe.Message);
        }
    }
}
