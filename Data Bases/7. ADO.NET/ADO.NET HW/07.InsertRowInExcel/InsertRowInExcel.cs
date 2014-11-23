using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.InsertRowInExcel
{
    // 7. Implement appending new rows to the Excel file.

    class InsertRowInExcel
    {
        static void Main()
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\..\\ScoreBoard.xlsx;Extended Properties=Excel 12.0 Xml;";

            OleDbConnection dbCon = new OleDbConnection(connectionString);

            InsertRowIntoExcel("Yashkata", 54, dbCon);
        }

        static void InsertRowIntoExcel(string name, int score, OleDbConnection con)
        {
            OleDbCommand cmdInsertRow = new OleDbCommand("INSERT INTO [Sheet1$] (Name, Score) VALUES (@name, @score)", con);

            con.Open();

            using (con)
            {
                cmdInsertRow.Parameters.AddWithValue("@name", name);
                cmdInsertRow.Parameters.AddWithValue("@score", score);
                cmdInsertRow.ExecuteNonQuery();
            }
        }
    }
}
