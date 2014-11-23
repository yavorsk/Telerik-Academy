using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.SearchProduct
{
    class SearchProduct
    {
        static void Main()
        {
            string connectionString = "Server=.; Database=Northwind; Integrated Security=true";

            SqlConnection dbCon = new SqlConnection(connectionString);

            Console.WriteLine("Enter something to search in products:");

            string forSearch = Console.ReadLine();

            string[] harmlessStrings = forSearch.Split(new char[] { '\'', '%', '\"', '\\', '_' });

            if (harmlessStrings.Length > 1)
            {
                Console.WriteLine("You're hacker!");
            }
            else
            {
                SearchForProduct(forSearch, dbCon);
            }
        }

        static void SearchForProduct(string searched, SqlConnection con)
        {
            SqlCommand cmdSeacrh = new SqlCommand("SELECT ProductName FROM Products WHERE ProductName like @searched;", con);

            string searcedParam = "%" + searched + "%";
            cmdSeacrh.Parameters.AddWithValue("@searched", searcedParam);

            con.Open();

            using (con)
            {
                SqlDataReader reader = cmdSeacrh.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        string found = (string)reader["ProductName"];
                        Console.WriteLine(found);
                    }
                }
            }
        }
    }
}
