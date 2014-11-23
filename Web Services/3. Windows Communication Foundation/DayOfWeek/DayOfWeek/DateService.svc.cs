using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DayOfWeek
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IDateService
    {
        public string GetDayOfWeek(DateTime date)
        {
            var dayOfWeek = date.DayOfWeek;

            var dayOfWeekInBulgaran = "";

            switch (dayOfWeek)
            {
                case System.DayOfWeek.Friday: dayOfWeekInBulgaran = "Petak";
                    break;
                case System.DayOfWeek.Monday: dayOfWeekInBulgaran = "Понеделник";
                    break;
                case System.DayOfWeek.Saturday: dayOfWeekInBulgaran = "Събота";
                    break;
                case System.DayOfWeek.Sunday: dayOfWeekInBulgaran = "Неделя";
                    break;
                case System.DayOfWeek.Thursday: dayOfWeekInBulgaran = "Четвъртък";
                    break;
                case System.DayOfWeek.Tuesday: dayOfWeekInBulgaran = "Вторник";
                    break;
                case System.DayOfWeek.Wednesday: dayOfWeekInBulgaran = "Сряда";
                    break;
                default:
                    break;
            }

            return dayOfWeekInBulgaran;
        }
    }
}
