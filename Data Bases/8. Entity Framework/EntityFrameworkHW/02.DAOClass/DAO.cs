using NorthWindDataa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.DAOClass
{
    // 2. Create a DAO class with static methods which provide functionality for inserting, 
    // modifying and deleting customers. Write a testing class.

    public class DAO
    {
        public void InsertCustumer(string customerId, string companyName, string contactName, string contactTitle,
                                    string address, string city, string region, string postalCode, string country,
                                    string phone, string fax, NorthwindEntities context)
        {
            Customer newCustomer = new Customer
            {
                CustomerID = customerId,
                CompanyName = companyName,
                ContactName = contactName,
                ContactTitle = contactTitle,
                Address = address,
                City = city,
                Region = region,
                PostalCode = postalCode,
                Country = country,
                Phone = phone,
                Fax = fax,
            };

            using (context)
            {
                context.Customers.Add(newCustomer);
                context.SaveChanges();
            }
        }

        public void UpdateCustomer(string customerId, string newContactName, NorthwindEntities context)
        {
            using (context)
            {
                var customer = context.Customers.Where(i => i.CustomerID == customerId).FirstOrDefault();
                customer.ContactName = newContactName;
                context.SaveChanges();
            }
        }

        public void DeleteCustomer(string customerId, NorthwindEntities context)
        {
            using (context)
            {
                var customer = context.Customers.Where(i => i.CustomerID == customerId).FirstOrDefault();
                context.Customers.Remove(customer);
                context.SaveChanges();
            }
        }
    }
}
