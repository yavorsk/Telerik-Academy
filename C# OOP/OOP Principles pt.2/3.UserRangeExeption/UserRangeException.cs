using System;
using System.Globalization;

// 3. Define a class InvalidRangeException<T> that holds information about an error condition related to invalid range. 
// It should hold error message and a range definition [start … end].
// Write a sample application that demonstrates the InvalidRangeException<int> and InvalidRangeException<DateTime> 
// by entering numbers in the range [1..100] and dates in the range [1.1.1980 … 31.12.2013].

class UserRangeException
{
    static void Main()
    {
        int start = 1;
        int end = 100;
        DateTime startDate = new DateTime(1980, 1, 1);
        DateTime endDate = new DateTime(2013, 12, 31);

        try
        {
            Console.WriteLine(ReadInt(start, end));
        }
        catch (InvalidRangeException<int> irex)
        {
            Console.WriteLine("{0}\nPermissible range: {1} - {2}", irex.Message, irex.Start, irex.End);
        }

        try
        {
            Console.WriteLine(ReadDate(startDate, endDate));
        }
        catch (InvalidRangeException<DateTime> idrex)
        {
            Console.WriteLine("{0}\nPermissible range: {1} - {2}", idrex.Message, idrex.Start, idrex.End);
        }
    }

    private static string ReadDate(DateTime startDate, DateTime endDate)
    {
        Console.WriteLine("Enter a date in the format yyyy.mm.dd: ");
        DateTime userDate = DateTime.ParseExact(Console.ReadLine(), "yyyy.mm.dd", CultureInfo.InvariantCulture);

        if (userDate < startDate || endDate < userDate)
        {
            throw new InvalidRangeException<DateTime>("The date was not in the specified range!", startDate, endDate);
        }

        return userDate.ToString();
    }

    private static int ReadInt(int lowerBound, int upperBound)
    {
        int userNumber = int.Parse(Console.ReadLine());

        if (userNumber < lowerBound || upperBound < userNumber)
        {
            throw new InvalidRangeException<int>("The number was not in the permissible range!", lowerBound, upperBound);
        }

        return userNumber;
    }
}
