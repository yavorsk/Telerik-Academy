using DayOfWeekConsoleClient.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOfWeekConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            DateServiceClient client = new DateServiceClient();

            string dayOfWeekToday = client.GetDayOfWeek(DateTime.Now);

            Console.WriteLine(dayOfWeekToday);
        }
    }
}
