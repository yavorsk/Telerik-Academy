using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.ReadFromExcel
{
    // 7. Create an Excel file with 2 columns: name and score:
    // Write a program that reads your MS Excel file through the OLE DB data provider and 
    // displays the name and score row by row.

    class ReadFromExcel
    {
        static void Main()
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\..\\ScoreBoard.xlsx;Extended Properties=Excel 12.0 Xml;";

            OleDbConnection dbCon = new OleDbConnection(connectionString);

            dbCon.Open();

            //// Don't know why this didn't work:
            //using (dbCon)
            //{
            //    OleDbCommand cmdGetScores = new OleDbCommand("SELECT * FROM [Sheet1$]", dbCon);

            //    OleDbDataReader reader = cmdGetScores.ExecuteReader();

            //    using (reader)
            //    {
            //        string name = (string)reader["Name"];
            //        int score = (int)reader["Score"];

            //        Console.WriteLine("{0}: {1}", name, score);
            //    }
            //}

            using (dbCon)
            {
                DataTable dataSet = new DataTable();

                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", dbCon);

                adapter.Fill(dataSet);

                foreach (DataRow item in dataSet.Rows)
                {
                    Console.WriteLine("{0}'s score: {1}", item.ItemArray[0], item.ItemArray[1]);
                }
            }
        }
    }
}
