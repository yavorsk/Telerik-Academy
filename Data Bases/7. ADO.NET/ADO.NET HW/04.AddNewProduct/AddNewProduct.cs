using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.AddNewProduct
{
    // 4. Write a method that adds a new product in the products table in the Northwind database.
    // Use a parameterized SQL command.

    class AddNewProduct
    {
        static void Main()
        {
            string connectionString = "Server=.; Database=Northwind; Integrated Security=true";

            SqlConnection dbCon = new SqlConnection(connectionString);

            dbCon.Open();

            using (dbCon)
            {
                string productName = "Whiskey";
                int supplierID = 2;
                int categoryID = 3;
                decimal unitPrice = 60.50m;

                SqlCommand cmdAddNewProduct = new SqlCommand(
                    "INSERT INTO Products(ProductName, SupplierID, CategoryID, UnitPrice) " +
                    "VALUES (@productName, @supplierID, @categoryID, @unitPrice)", dbCon);

                cmdAddNewProduct.Parameters.AddWithValue("@productName", productName);
                cmdAddNewProduct.Parameters.AddWithValue("@supplierID", supplierID);
                cmdAddNewProduct.Parameters.AddWithValue("@categoryID", categoryID);
                cmdAddNewProduct.Parameters.AddWithValue("@unitPrice", unitPrice);

                cmdAddNewProduct.ExecuteNonQuery();
            }
        }
    }
}
