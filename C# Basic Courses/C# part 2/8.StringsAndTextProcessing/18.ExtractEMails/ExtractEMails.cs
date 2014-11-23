using System;
using System.Text.RegularExpressions;

// 17.Write a program for extracting all email addresses from given text. 
// All substrings that match the format <identifier>@<host>…<domain> should be recognized as emails.


namespace _18.ExtractEMails
{
    class ExtractEMails
    {
        static void Main()
        {
            string inputText = "Albert Bridge is a Grade II* alabala@gmail.com listed road bridge over the River boiko.boikov@abv.bg Thames in London, connecting Chelsea to Battersea. Designed and built by Rowland Mason Ordish in 1873 as a toll bridge, it was commercially unsuccessful; ";
            string pattern = @"\s+\w+\.*\w+@\w+\.\w{2,4}\s+";

            foreach (var match in Regex.Matches(inputText, pattern))
            {
                Console.WriteLine(match.ToString().Trim());
            }
        }
    }
}
