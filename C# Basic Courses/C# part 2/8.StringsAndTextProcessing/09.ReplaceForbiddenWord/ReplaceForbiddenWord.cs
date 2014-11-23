using System;
using System.Text;

// 9. We are given a string containing a list of forbidden words and a text containing some of these words. 
// Write a program that replaces the forbidden words with asterisks. Example:
//      Microsoft announced its next generation PHP compiler today. 
//      It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.
// Words: "PHP, CLR, Microsoft"
//	The expected result:
//      ********* announced its next generation *** compiler today. 
//      It is based on .NET Framework 4.0 and is implemented as a dynamic language in ***.

class ReplaceForbiddenWord
{
    static void Main()
    {
        string inputText = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
        string[] forbiddenWords = { "PHP", "CLR", "Microsoft" };

        Console.WriteLine(ReplaceForbidden(inputText, forbiddenWords));
    }

    static string ReplaceForbidden(string badText, string[] badWords)
    {
        StringBuilder goodText = new StringBuilder().Append(badText);

        foreach (var word in badWords)
        {
            goodText.Replace(word, new string('*', word.Length));
        }

        return goodText.ToString();
    }
}
