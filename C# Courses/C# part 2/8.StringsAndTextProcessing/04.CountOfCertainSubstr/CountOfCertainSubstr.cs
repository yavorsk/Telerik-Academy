using System;
using System.Text.RegularExpressions;

// 4.Write a program that finds how many times a substring is contained in a given text (perform case insensitive search).
//		Example: The target substring is "in". The text is as follows:
// We are living in an yellow submarine. We don't have anything else. 
// Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.


class CountOfCertainSubstr
{
    static void Main()
    {
        string text = @"We are living in an yellow submarine. We don't have anything else. 
                        Inside the submarine is very tight. So we are drinking all the day. 
                        We will move out of it in 5 days.";
        string strToSearch = "in";

        int i = 0;
        int count = 0;

        while (i < text.Length)
        {
            i = text.ToLower().IndexOf(strToSearch.ToLower(), i);
            if (i==-1)
            {
                break;
            }
            count++;
            i += strToSearch.Length;
        }

        Console.WriteLine(count);

        // with regex:

        string pattern = "in";
        Console.WriteLine(Regex.Matches(text, pattern, RegexOptions.IgnoreCase).Count);
    }
}
