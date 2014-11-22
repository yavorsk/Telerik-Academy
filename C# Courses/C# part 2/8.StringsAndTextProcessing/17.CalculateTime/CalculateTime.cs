using System;
using System.Globalization;

// 17. Write a program that reads a date and time given in the format: 
// day.month.year hour:minute:second and prints the date and time after 6 hours and 30 minutes (in the same format) 
// along with the day of week in Bulgarian.


class CalculateTime
{
    static void Main()
    {
        string inputDate = "15.08.2013 21:30:20";
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        DateTime time = DateTime.ParseExact(inputDate, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);
        time = time.AddHours(6.5);
        Console.WriteLine("{0} {1}", time.ToString("dd.MM.yyyy HH:mm:ss"), time.ToString("dddd", new CultureInfo("bg-BG")));
    }
}
