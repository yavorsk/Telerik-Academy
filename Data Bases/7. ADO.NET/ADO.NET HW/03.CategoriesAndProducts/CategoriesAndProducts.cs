using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CategoriesAndProducts
{
    // 3. Write a program that retrieves from the Northwind database all product categories 
    // and the names of the products in each category. Can you do this with a single SQL query (with table join)?

    class CategoriesAndProducts
    {
        static void Main()
        {
            string connectionString = "Server=.; Database=Northwind; Integrated Security=true";

            SqlConnection dbCon = new SqlConnection(connectionString);

            dbCon.Open();

            using (dbCon)
            {
                SqlCommand cmdRetrieveCategoriesAndProducts = new SqlCommand(
                "SELECT c.CategoryName, p.ProductName " +
                "FROM Categories c " +
                "JOIN Products p " +
                "ON c.CategoryID = p.CategoryID " +
                "GROUP BY c.CategoryName, p.ProductName", dbCon);

                SqlDataReader reader = cmdRetrieveCategoriesAndProducts.ExecuteReader();

                Console.WriteLine("Name and description of all categories:");

                using (reader)
                {
                    while (reader.Read())
                    {
                        string categoryName = (string)reader["CategoryName"];
                        string productName = (string)reader["ProductName"];

                        Console.WriteLine("{0}: {1}", categoryName, productName);
                    }
                }
            }
        }
    }
}
