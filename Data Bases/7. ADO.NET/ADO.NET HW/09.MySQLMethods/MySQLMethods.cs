using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace _09.MySQLMethods
{
    // 9. Download and install MySQL database, MySQL Connector/Net (.NET Data Provider for MySQL) + 
    // MySQL Workbench GUI administration tool . 
    // Create a MySQL database to store Books (title, author, publish date and ISBN). 
    // Write methods for listing all books, finding a book by name and adding a book.


    class MySQLMethods
    {
        static void Main()
        {
            Console.Write("Enter password for MySQL server: ");
            string password = Console.ReadLine();

            string connectionString = "Server=localhost;Database=BooksDB;Uid=root;Pwd=" + password + ";";

            MySqlConnection connection = new MySqlConnection(connectionString);

            //AddBook("Hyperion", "Dan Simmons", new DateTime(1997, 12, 12), "12315468762", connection);
            FindBookByName("Hyperion", connection);
            ListAllBooks(connection);
        }

        private static void ListAllBooks(MySqlConnection connection)
        {
            connection.Open();

            using (connection)
            {
                MySqlCommand cmdFind = new MySqlCommand("SELECT Title, Author, PublishDate FROM Books", connection);
                var reader = cmdFind.ExecuteReader();

                while (reader.Read())
                {
                    string title = (string)reader["Title"];
                    string author = (string)reader["Author"];
                    string publishDate = ((DateTime)reader["PublishDate"]).ToString();

                    Console.WriteLine("Book title: {0}, Author: {1}, published on {2}", title, author, publishDate);
                }

            }
        }

        static void AddBook(string title, string author, DateTime publishDate, string ISBN, MySqlConnection connection)
        {
            connection.Open();

            using (connection)
            {
                MySqlCommand addBookCommand = new MySqlCommand("INSERT INTO Books (Title, Author, PublishDate, ISBN) " +
                                                "VALUES (@title, @author, @publishDate, @ISBN)", connection);

                addBookCommand.Parameters.AddWithValue("@title", title);
                addBookCommand.Parameters.AddWithValue("@author", author);
                addBookCommand.Parameters.AddWithValue("@publishDate", publishDate);
                addBookCommand.Parameters.AddWithValue("@ISBN", ISBN);

                addBookCommand.ExecuteNonQuery(); 
            }
        }

        static void FindBookByName(string title, MySqlConnection connection)
        {
            connection.Open();

            using (connection)
            {
                MySqlCommand cmdFind = new MySqlCommand("SELECT Title, Author, PublishDate FROM Books " +
                                                            "WHERE Title=\'" + title + "\';", connection);
                var reader = cmdFind.ExecuteReader();

                while (reader.Read())
                {
                    string foundTitle = (string)reader["Title"];
                    string author = (string)reader["Author"];
                    string publishDate = ((DateTime)reader["PublishDate"]).ToString();

                    Console.WriteLine("Book title: {0}, Author: {1}, published on {2}", foundTitle, author, publishDate);
                }
            }
        }
    }
}
