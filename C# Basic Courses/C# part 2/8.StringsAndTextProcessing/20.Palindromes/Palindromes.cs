using System;
using System.Text.RegularExpressions;

// 20.Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".

class Palindromes
{
    static void Main()
    {
        string inputText = "Albert Bridge is a Grade II abba listed road bridge over the River 1.9.2012 Thames  lamal in London, connecting Chelsea to Battersea. Designed exe and built by Rowland Mason Ordish in 1873 as a toll bridge, it was commercially unsuccessful; ";
        string patternWord = @"\w{3,}";

        MatchCollection words = Regex.Matches(inputText, patternWord, RegexOptions.IgnoreCase);

        foreach (var word in words)
        {
            if (IsPalindrome(word.ToString()))
            {
                Console.WriteLine(word);
            }
        }
    }

    private static bool IsPalindrome(string word)
    {
        bool result = true;

        for (int i = 0; i < word.Length / 2; i++)
        {
            if (word[i] != word[word.Length - 1 - i])
            {
                result = false;
            }
        }

        return result;
    }
}
