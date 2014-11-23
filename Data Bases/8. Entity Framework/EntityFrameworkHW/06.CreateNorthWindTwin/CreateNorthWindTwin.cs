using NorthWindDataa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.IO;

namespace _06.CreateNorthWindTwin
{
    class CreateNorthWindTwin
    {
        static void Main()
        {
            NorthwindEntities dbCon = new NorthwindEntities();

            string creationScript = (dbCon as IObjectContextAdapter).ObjectContext.CreateDatabaseScript();

            string finalScript = "CREATE DATABASE [NorthwindTwin] \n GO \nUSE [NorthwindTwin] \n" + creationScript;

            StreamWriter northwindTwinScript = new StreamWriter("NorthwindTwin.sql");

            using (northwindTwinScript)
            {
                northwindTwinScript.WriteLine(finalScript);
            }
        }
    }
}
