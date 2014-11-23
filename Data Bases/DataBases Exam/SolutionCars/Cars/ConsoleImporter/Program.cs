using Cars.Data;
using Cars.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleImporter
{
    class Program
    {
        static void Main()
        {
            var db = new CarsDbContext();
            db.Configuration.AutoDetectChangesEnabled = false;


            // please correct the paths of the files if needed...
            var listOfFiles = new List<string>
            {
                 @"..\..\Data.Json.Files\data.0.json",
                 @"..\..\Data.Json.Files\data.1.json",
                 @"..\..\Data.Json.Files\data.2.json",
                 @"..\..\Data.Json.Files\data.3.json",
                 @"..\..\Data.Json.Files\data.4.json"
            };

            int counter = 0;
            int fileCounter = 1;

            foreach (var fileName in listOfFiles)
            {
                Console.WriteLine("From File {0}", fileCounter);
                fileCounter++;

                StreamReader reader = new StreamReader(fileName);
                StringBuilder fileData = new StringBuilder();

                using (reader)
                {
                    var line = reader.ReadLine();

                    while (line != null)
                    {
                        fileData.AppendLine(line);

                        line = reader.ReadLine();
                    }
                }

                var stringToParse = fileData.ToString();

                JArray data = JArray.Parse(stringToParse);

                foreach (var jsonObj in data)
                {
                    var year = int.Parse(jsonObj["Year"].ToString());
                    var transmissionType = int.Parse(jsonObj["TransmissionType"].ToString()) == 0 ? TransmissionType.Manual : TransmissionType.Automatic;
                    var manufacturerName = jsonObj["ManufacturerName"].ToString();
                    var model = jsonObj["Model"].ToString();
                    var price = decimal.Parse(jsonObj["Price"].ToString());
                    var dealerName = jsonObj["Dealer"]["Name"].ToString();
                    var dealerCity = jsonObj["Dealer"]["City"].ToString();

                    City city;
                    if (db.Cities.Any(c => c.Name == dealerCity))
                    {
                        city = db.Cities.FirstOrDefault(c => c.Name == dealerCity);
                    }
                    else
                    {
                        city = new City
                        {
                            Name = dealerCity
                        };
                    };

                    Manufacturer manufacturer;
                    if (db.Manufacturers.Any(m => m.Name == manufacturerName))
                    {
                        manufacturer = db.Manufacturers.FirstOrDefault(m => m.Name == manufacturerName);
                    }
                    else
                    {
                        manufacturer = new Manufacturer
                        {
                            Name = manufacturerName
                        };
                    };

                    Dealer dealer;
                    if (db.Dealers.Any(d => d.Name == dealerName))
                    {
                        dealer = db.Dealers.FirstOrDefault(d => d.Name == dealerName);
                        dealer.Cities.Add(city);
                    }
                    else
                    {
                        dealer = new Dealer
                        {
                            Name = dealerName,
                        };
                        dealer.Cities.Add(city);
                    };

                    Car newCar = new Car
                    {
                        Year = year,
                        Dealer = dealer,
                        Manufacturer = manufacturer,
                        Model = model,
                        Price = price,
                        TransmissionType = transmissionType
                    };

                    db.Cars.Add(newCar);
                    counter++;

                    if (counter % 100 == 0)
                    {
                        db.SaveChanges();
                        Console.Write(".");
                    }
                }

                db.SaveChanges();
                Console.WriteLine();
            }
        }
    }
}
