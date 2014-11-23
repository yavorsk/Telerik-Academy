using NorthWindDataa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.CreateNewOreder
{
    // 2. Create a method that places a new order in the Northwind database. 
    // The order should contain several order items. 
    // Use transaction to ensure the data consistency.

    class CreateNewOreder
    {
        static void Main()
        {
            NorthwindEntities context = new NorthwindEntities();
        }

        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<System.DateTime> RequiredDate { get; set; }
        public Nullable<System.DateTime> ShippedDate { get; set; }
        public Nullable<int> ShipVia { get; set; }
        public Nullable<decimal> Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }

        public void AddNewOrder(string customerID, int? employeeID, DateTime? orderDate, DateTime? requiredDate,
                                DateTime shippedDate, int? shipVia, decimal? freight, string shipName, string shipAdress,
                                string shipCity, string shipRegion, string shipPostalCode, shipCountry, 
                                Order_Detail[] orderDetails, NorthwindEntities context)
        {

        }

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
    }
}
