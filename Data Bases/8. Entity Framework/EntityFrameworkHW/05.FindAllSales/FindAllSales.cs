using NorthWindDataa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.FindAllSales
{
    // 5.Write a method that finds all the sales by specified region and period (start / end dates). 

    class FindAllSales
    {
        static void Main()
        {
            NorthwindEntities context = new NorthwindEntities();

            DateTime startDate = new DateTime(1995, 5, 1);
            DateTime endDate = new DateTime(1998, 12, 1);
            string region = "SP";

            //ICollection<Customer> customers = FindCustomers(searchedYear, searchedShipmentDestination, context);

            //foreach (var customer in customers)
            //{
            //    Console.WriteLine(customer.CompanyName);
            //}
        }

        static void FindSales(string region, DateTime startDate, DateTime endDate, NorthwindEntities context)
        {
            var searchedSales = context.Orders.Where(o => o.ShipRegion == region &&
                                                                  o.OrderDate > startDate &&
                                                                  o.OrderDate < endDate)
                                      .Select(o => new { ShipName = o.ShipName, OrderDate = o.OrderDate});

            foreach (var sale in searchedSales)
            {
                Console.WriteLine("{0}: {1}", sale.ShipName, sale.OrderDate);
            }
        }
    }
}
