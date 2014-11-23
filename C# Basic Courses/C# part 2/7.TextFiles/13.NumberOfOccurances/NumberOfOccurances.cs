using System;
using System.IO;
using System.Collections.Generic;

// 13. Write a program that reads a list of words from a file words.txt and finds how many times 
// each of the words is contained in another file test.txt. 
// The result should be written in the file result.txt and the words should be sorted by the number of their occurrences in descending order.
// Handle all possible exceptions in your methods.

class NumberOfOccurances
{
    static void Main()
    {
        string words = @"..\..\words.txt";
        string test = @"..\..\test.txt";
        string result = @"..\..\result.txt";

        List<string> wordsToCount = new List<string>();

        try
        {
            using (StreamReader wordsFile = new StreamReader(words))
            {
                string line = wordsFile.ReadLine();
                while (line != null)
                {
                    wordsToCount.Add(line.Trim());
                    line = wordsFile.ReadLine();
                }
            }

            int[] wordsCount = new int[wordsToCount.Count];

            for (int i = 0; i < wordsToCount.Count; i++)
            {
                wordsCount[i] = NumOfOccuranceOfWord(wordsToCount[i], test);
            }

            string[] wordsArray = (wordsToCount.ToArray());

            Array.Sort(wordsCount, wordsArray);
            Array.Reverse(wordsArray);
            Array.Sort(wordsCount);
            Array.Reverse(wordsCount);

            using (StreamWriter resultFile = new StreamWriter(result))
            {
                for (int i = 0; i < wordsArray.Length; i++)
                {
                    resultFile.WriteLine(wordsArray[i] + " - " + wordsCount[i]);
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

    static int NumOfOccuranceOfWord(string word, string inputFile)
    {
        int count = 0;

        using (StreamReader testFile = new StreamReader(inputFile))
        {
            string line = testFile.ReadLine();
            while (line != null)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    i = line.IndexOf(word, i);
                    if (i==-1)
                    {
                        break;
                    }
                    i = i + word.Length;
                    count++;
                }
                line = testFile.ReadLine();
            }
        }

        return count;
    }
}
