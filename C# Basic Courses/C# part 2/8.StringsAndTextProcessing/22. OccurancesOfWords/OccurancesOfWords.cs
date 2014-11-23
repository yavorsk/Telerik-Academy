using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

// 22. Write a program that reads a string from the console and lists all different words in the string 
// along with information how many times each word is found.

class OccurancesOfWords
{
    static void Main()
    {
        string inputString = Console.ReadLine();

        string patternWord = @"\w+";

        MatchCollection words = Regex.Matches(inputString, patternWord, RegexOptions.IgnoreCase);

        List<string> usedWords = new List<string>();

        foreach (var word in words)
        {
            MatchCollection certainWord = Regex.Matches(inputString, word.ToString(), RegexOptions.IgnoreCase);

            int matchCount = certainWord.Count;

            if (!usedWords.Contains(word.ToString()))
            {
                Console.WriteLine(word.ToString() + " - " + matchCount);                
            }

            if (matchCount > 1)
            {
                usedWords.Add(word.ToString());
            }
        }
    }
}
