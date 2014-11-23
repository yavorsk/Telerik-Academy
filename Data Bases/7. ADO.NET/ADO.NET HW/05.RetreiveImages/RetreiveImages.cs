using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace _05.RetreiveImages
{
    // 5. Write a program that retrieves the images for all categories in the Northwind database 
    // and stores them as JPG files in the file system.

    class RetreiveImages
    {
        static void Main()
        {
            int fileOffset = 78;

            string connectionString = "Server=.; Database=Northwind; Integrated Security=true";

            SqlConnection dbCon = new SqlConnection(connectionString);

            dbCon.Open();

            using (dbCon)
            {
                SqlCommand command = new SqlCommand(
                  "SELECT CategoryName, Picture " +
                  "FROM Categories", dbCon);

                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        string categoryName = ((string)reader["CategoryName"]);
                        if (categoryName.Contains('/') == true)
                        {
                            categoryName = categoryName.Replace('/', ' ');
                        }
                        byte[] pictureBytes = reader["Picture"] as byte[];

                        MemoryStream stream = new MemoryStream(
                            pictureBytes, fileOffset,
                            pictureBytes.Length - fileOffset);

                        Image image = Image.FromStream(stream);
                        using (image)
                        {
                            image.Save("..\\..\\" + categoryName + ".jpg", ImageFormat.Jpeg);
                        }
                    }

                    Console.WriteLine("Retrieved images are in the project folder...");
                }
            }
        }
    }
}
