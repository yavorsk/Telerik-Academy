using System;
using System.Globalization;

// 16. Write a program that reads two dates in the format: day.month.year and calculates the number of days between them. Example:
//  Enter the first date: 27.02.2006
//  Enter the second date: 3.03.2004
//  Distance: 4 days


class DaysBetweenDates
{
    static void Main()
    {
        DateTime firstDate = DateTime.ParseExact(Console.ReadLine(), "d.M.yyyy", CultureInfo.InvariantCulture);
        DateTime secondDate = DateTime.ParseExact(Console.ReadLine(), "d.M.yyyy", CultureInfo.InvariantCulture);

        Console.WriteLine((firstDate - secondDate).TotalDays);
    }
}
