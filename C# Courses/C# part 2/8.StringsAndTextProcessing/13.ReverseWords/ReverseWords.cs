using System;
using System.Text;

// 13. Write a program that reverses the words in given sentence.
//	Example: "C# is not C++, not PHP and not Delphi!"  "Delphi not and PHP, not C++ not is C#!".


class ReverseWords
{
    static void Main()
    {
        string sentance = "C# is not C++, not PHP and not Delphi!";
        string[] splitted = sentance.Split(' ');
        Array.Reverse(splitted);

        StringBuilder resultSentance = new StringBuilder();

        for (int i = 0; i < splitted.Length; i++)
        {
            resultSentance.Append(splitted[i]);
            if (i < splitted.Length - 1)
            {
                resultSentance.Append(" ");
            }
        }

        Console.WriteLine(resultSentance.ToString());
    }
}
