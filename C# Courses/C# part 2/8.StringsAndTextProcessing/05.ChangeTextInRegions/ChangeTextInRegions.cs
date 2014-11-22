using System;
using System.Text.RegularExpressions;

// 5. You are given a text. Write a program that changes the text in all regions surrounded by the tags <upcase> and </upcase> to uppercase. 
//     The tags cannot be nested. Example:
//  We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.
//  The expected result:
//  We are living in a YELLOW SUBMARINE. We don't have ANYTHING else.

class ChangeTextInRegions
{
    static void Main()
    {
        string inputText = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";

        string[] splitted = inputText.Split('<','>');

        string result = string.Empty;

        for (int i = 0; i < splitted.Length; i++)
        {
            if (splitted[i] != "upcase" && splitted[i] != "/upcase")
            {
                result += splitted[i];
            }
            if (splitted[i] == "upcase")
            {
                result += splitted[i + 1].ToUpper();
                splitted[i + 1] = string.Empty;
            }
        }

        Console.WriteLine(result);
    }
}
