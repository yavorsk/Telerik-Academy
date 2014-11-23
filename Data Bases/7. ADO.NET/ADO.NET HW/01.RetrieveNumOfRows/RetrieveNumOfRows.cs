using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.RetrieveNumOfRows
{
    // 1.Write a program that retrieves from the Northwind sample database in MS SQL Server 
    // the number of  rows in the Categories table.

    class RetrieveNumOfRows
    {
        static void Main()
        {
            string connectionString = "Server=.; Database=Northwind; Integrated Security=true";

            SqlConnection dbCon = new SqlConnection(connectionString);

            dbCon.Open();

            using (dbCon)
            {
                SqlCommand cmdRowCount = new SqlCommand("SELECT COUNT(*) FROM Categories", dbCon);

                int categoriesCount = (int)cmdRowCount.ExecuteScalar();

                Console.WriteLine("Number of categories: {0}", categoriesCount);
            }
        }
    }
}
