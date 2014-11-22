// 1. Write a program that reads a year from the console and checks whether it is a leap. Use DateTime.
// http://en.wikipedia.org/wiki/Leap_year

using System;

class LeapYear
{
    static void Main()
    {
        Console.Write("Enter day: ");
        int day = int.Parse(Console.ReadLine());
        Console.Write("Enter month: ");
        int month = int.Parse(Console.ReadLine());
        Console.Write("Enter year: ");
        int year = int.Parse(Console.ReadLine());

        DateTime date = new DateTime(year, month, day);

        bool isleap = false;

        if (date.Year % 400 == 0)
        {
            isleap = true;
        }
        else if (date.Year % 100 == 0)
        {
            isleap = false;
        }
        else if (date.Year % 4 == 0)
        {
            isleap = true;
        }
        else
        {
            isleap = false;
        }

        if (isleap)
        {
            Console.WriteLine("{0} is leap year.", date.Year);
        }
        else
        {
            Console.WriteLine("{0} is not leap year.", date.Year);
        }
    }
}
