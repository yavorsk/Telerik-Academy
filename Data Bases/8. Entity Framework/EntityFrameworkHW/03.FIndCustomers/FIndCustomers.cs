using NorthWindDataa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.FIndCustomers
{
    // 3. Write a method that finds all customers who have orders made in 1997 and shipped to Canada.

    class FIndCustomers
    {
        static void Main()
        {
            NorthwindEntities context = new NorthwindEntities();
            int searchedYear = 1997;
            string searchedShipmentDestination = "Canada";
            
            ICollection<Customer> customers = FindCustomers(searchedYear, searchedShipmentDestination, context);
            
            foreach (var customer in customers)
            {
                Console.WriteLine(customer.CompanyName);
            }
        }

        static public ICollection<Customer> FindCustomers(int year, string destinationCountry, NorthwindEntities context)
        {
            var searchedOrders =
                  from o in context.Orders
                  where o.OrderDate.Value.Year == year && o.ShipCountry == destinationCountry
                  select o;

            List<Customer> result = new List<Customer>();

            foreach (var order in searchedOrders)
            {
                result.Add(order.Customer);
            }

            return result;
        }
    }
}
