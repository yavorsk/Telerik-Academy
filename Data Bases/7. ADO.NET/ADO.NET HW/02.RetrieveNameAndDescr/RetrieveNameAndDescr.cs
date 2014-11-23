using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.RetrieveNameAndDescr
{
    // 2. Write a program that retrieves the name and description of all categories in the Northwind DB.

    class RetrieveNameAndDescr
    {
        static void Main()
        {
            string connectionString = "Server=.; Database=Northwind; Integrated Security=true";

            SqlConnection dbCon = new SqlConnection(connectionString);

            dbCon.Open();

            using (dbCon)
            {
                SqlCommand cmdRetrieveCategories = new SqlCommand("SELECT * FROM Categories", dbCon);

                SqlDataReader reader = cmdRetrieveCategories.ExecuteReader();

                Console.WriteLine("Name and description of all categories:");

                using (reader)
                {
                    while (reader.Read())
                    {
                        string name = (string)reader["CategoryName"];
                        string description = (string)reader["Description"];

                        Console.WriteLine("{0}: {1}", name, description);
                    }
                }
            }
        }
    }
}
