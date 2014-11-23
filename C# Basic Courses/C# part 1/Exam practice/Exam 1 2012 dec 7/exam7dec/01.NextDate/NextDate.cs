using System;
using System.Globalization;
using System.Threading;

class NextDate
{
    static void Main()
    {
        int day = int.Parse(Console.ReadLine());
        int month = int.Parse(Console.ReadLine());
        int year = int.Parse(Console.ReadLine());
        DateTime inputDate = new DateTime();
        string data = day.ToString("00") + "." + month.ToString("00") + "." + year.ToString("0000");
        inputDate = DateTime.ParseExact(data, "dd.MM.yyyy", null);
        DateTime outputDate = inputDate.AddDays(1);
        Console.WriteLine(outputDate.Day + "." + outputDate.Month + "." + outputDate.Year);
        //Console.WriteLine(outputDate.ToString("dd.MM.yyyy"));

        //int day = int.Parse(Console.ReadLine());
        //int month = int.Parse(Console.ReadLine());
        //int year = int.Parse(Console.ReadLine());
        //DateTime inputDate = new DateTime();
        //string data = day + "." + month + "." + year;
        //inputDate = DateTime.Parse(data);
        //DateTime outputDate = inputDate.AddDays(1);
        //Console.WriteLine(outputDate.Day + "." + outputDate.Month + "." + outputDate.Year);
    }
}
