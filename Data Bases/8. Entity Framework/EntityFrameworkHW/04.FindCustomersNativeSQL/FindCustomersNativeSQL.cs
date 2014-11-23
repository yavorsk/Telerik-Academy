using NorthWindDataa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.FindCustomersNativeSQL
{
    class FindCustomersNativeSQL
    {
        static void Main()
        {
            NorthwindEntities context = new NorthwindEntities();
            int searchedYear = 1997;
            string searchedShipmentDestination = "Canada";

            FindCustomers(searchedYear, searchedShipmentDestination, context);
        }

        static void FindCustomers(int year, string destinationCountry, NorthwindEntities context)
        {
            string nativeSqlString =
                "SELECT c.ContactName FROM Customers c" +
                "INNER JOIN Orders o " +
                "ON c.CustomerID = o.CustomerID " +
                "WHERE YEAR(o.OrderDate) = {0} AND o.ShipCountry = \'{1}\';";

            object[] parameters = { year, destinationCountry };

            var searchedCustomers = context.Database.SqlQuery<string>(nativeSqlString, parameters);

            foreach (var customer in searchedCustomers)
            {
                Console.WriteLine(customer);
            }
        }
    }
}
