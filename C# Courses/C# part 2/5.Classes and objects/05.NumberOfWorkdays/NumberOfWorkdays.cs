// 05.Write a method that calculates the number of workdays between today and given date, passed as parameter. 
// Consider that workdays are all days from Monday to Friday except a fixed list of public holidays 
// specified preliminary as array.

using System;

class NumberOfWorkdays
{
    public static DateTime[] hollidays = {new DateTime(2013, 01, 01), new DateTime( 2013, 03, 03), new DateTime( 2013, 05, 01),
                                  new DateTime( 2013, 05, 03), new DateTime( 2013, 05, 04), new DateTime( 2013, 05, 05),
                                  new DateTime( 2013, 05, 06), new DateTime( 2013, 05, 24), new DateTime( 2013, 09, 06),
                                  new DateTime( 2013, 09, 22), new DateTime( 2013, 12, 23), new DateTime( 2013, 12, 24),
                                  new DateTime( 2013, 12, 25)};

    public static bool CheckIfWorkday(DateTime currentDate) // returns True if currentDate day is workday
    {
        bool workday = true;

        foreach (var day in hollidays)
        {
            if (currentDate == day)
            {
                workday = false;
                break;
            }
        }

        return workday;
    }

    public static int CalculateNumberOfWorkDays(DateTime endDate)
    {
        int countOfWorkdays = 0;

        for (DateTime i = DateTime.Today; i <= endDate; i = i.AddDays(1))
        {
            if (i.DayOfWeek == DayOfWeek.Saturday || i.DayOfWeek == DayOfWeek.Sunday)
            {
                continue;
            }
            else if (CheckIfWorkday(i))
            {
                countOfWorkdays++;
            }
        }

        return countOfWorkdays;
    }

    static void Main()
    {
        DateTime endDate = new DateTime(2013, 8, 14);

        Console.WriteLine(CalculateNumberOfWorkDays(endDate));
    }
}
