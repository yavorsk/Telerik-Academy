using System;
using System.Text.RegularExpressions;

// 25. Write a program that extracts from given HTML file its title (if available), and its body text without the HTML tags. Example:
// <html>
//  <head><title>News</title></head>
//  <body><p><a href="http://academy.telerik.com">Telerik
//    Academy</a>aims to provide free real-world practical
//    training for young people who want to turn into
//    skillful .NET software engineers.</p></body>
// </html>


class ExtractTextWoTags
{
    static void Main()
    {
        string inputText = "<html>\n<head><title>News</title></head>\n<body><p><a href=\"http://academy.telerik.com\">Telerik Academy</a>aims to provide free real-world practical\ntraining for young people who want to turn into\nskillful .NET software engineers.</p></body>\n</html>";

        string pattern = @"(?<=^|>)[^><]+?(?=<|$)"; 

        MatchCollection extracted = Regex.Matches(inputText, pattern, RegexOptions.IgnoreCase);

        string first = extracted[0].ToString();

        foreach (var text in extracted)
        {
            if (text.ToString() != "\n")
            {
                Console.WriteLine(text);
            }
        }
    }
}
