using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

// 19. Write a program that extracts from a given text all dates that match the format DD.MM.YYYY. 
// Display them in the standard date format for Canada.

class ExtractDates
{
    static void Main()
    {
        string inputText = "Albert Bridge is a Grade II* 23.08.2013 listed road bridge over the River 1.9.2012 Thames in London, connecting Chelsea to Battersea. Designed and built by Rowland Mason Ordish in 1873 as a toll bridge, it was commercially unsuccessful; ";
        string pattern = @"\d{1,2}\.\d{1,2}\.\d{4}";

        List<DateTime> dates = new List<DateTime>();

        foreach (var match in Regex.Matches(inputText, pattern))
        {
            dates.Add(DateTime.Parse(match.ToString()));
        }

        System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");

        foreach (var date in dates)
        {
            Console.WriteLine(date);
        }
    }
}
