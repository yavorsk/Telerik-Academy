using Cars.Data;
using Cars.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleQueries
{
    class Program
    {
        static void Main()
        {
            var db = new CarsDbContext();

            var xmlQueries = XElement.Load(@"..\..\Queries.xml").Elements();
            //var result = new XElement(@"..\..\search-results.xml");

            foreach (var xmlQuery in xmlQueries)
            {
                var filename = xmlQuery.Attribute("OutputFileName").ToString();

                var queryInCars = db.Cars.AsQueryable();

                var orderBy = xmlQuery.Element("OrderBy");
                var orderByWhat = orderBy.Value;

                var whereClauses = xmlQuery.Element("WhereClauses").Elements("WhereClause");
                foreach (var whereClause in whereClauses)
                {
                    var properyName = whereClause.Attribute("PropertyName").Value;
                    var compararer = whereClause.Attribute("Type").Value;
                    var value = whereClause.Value;

                    switch (properyName)
                    {
                        case "Id":
                            {
                                switch (compararer)
                                {
                                    case "Equals":
                                        {
                                            queryInCars = queryInCars.Where(c => c.id == int.Parse(value));
                                        } break;
                                    case "GreaterThan":
                                        {
                                            queryInCars = queryInCars.Where(c => c.id > int.Parse(value));
                                        } break;
                                    case "LessThan":
                                        {
                                            queryInCars = queryInCars.Where(c => c.id < int.Parse(value));
                                        } break;
                                }
                            } break;
                        case "Year":
                            {
                                switch (compararer)
                                {
                                    case "Equals":
                                        {
                                            queryInCars = queryInCars.Where(c => c.Year == int.Parse(value));
                                        } break;
                                    case "GreaterThan":
                                        {
                                            queryInCars = queryInCars.Where(c => c.Year > int.Parse(value));
                                        } break;
                                    case "LessThan":
                                        {
                                            queryInCars = queryInCars.Where(c => c.Year < int.Parse(value));
                                        } break;
                                }
                            } break;
                        case "Price":
                            {
                                switch (compararer)
                                {
                                    case "Equals":
                                        {
                                            queryInCars = queryInCars.Where(c => c.Price == decimal.Parse(value));
                                        } break;
                                    case "GreaterThan":
                                        {
                                            queryInCars = queryInCars.Where(c => c.Price > decimal.Parse(value));
                                        } break;
                                    case "LessThan":
                                        {
                                            queryInCars = queryInCars.Where(c => c.Price < decimal.Parse(value));
                                        } break;
                                }
                            } break;
                        case "Model":
                            {
                                switch (compararer)
                                {
                                    case "Equals":
                                        {
                                            queryInCars = queryInCars.Where(c => c.Model == value);
                                        } break;
                                    case "Contains":
                                        {
                                            queryInCars = queryInCars.Where(c => c.Model.Contains(value));
                                        } break;
                                }
                            } break;
                        case "Manufacturer":
                            {
                                switch (compararer)
                                {
                                    case "Equals":
                                        {
                                            queryInCars = queryInCars.Where(c => c.Manufacturer.Equals(value));
                                        } break;
                                    case "Contains":
                                        {
                                            queryInCars = queryInCars.Where(c => c.Manufacturer.ToString().Contains(value));
                                        } break;
                                }
                            } break;
                        case "Dealer":
                            {
                                switch (compararer)
                                {
                                    case "Equals":
                                        {
                                            queryInCars = queryInCars.Where(c => c.Dealer.Name == value);
                                        } break;
                                    case "Contains":
                                        {
                                            queryInCars = queryInCars.Where(c => c.Dealer.Name.Contains(value));
                                        } break;
                                }
                            } break;
                        //case "City":
                        //    {
                        //        var cityQueries = db.Cities.AsQueryable().Where(c => c.Name == value);

                        //        c.Dealer.c
                        //    } break;
                    }


                }

                var resultSet = queryInCars.Where(c => true).ToList();

                var xmlResultSet = new XElement("cars");

                foreach (var car in resultSet)
                {

                    var carElem = new XElement("car");
                    carElem.SetAttributeValue("Manufacturer", car.Manufacturer);
                    carElem.SetAttributeValue("Model", car.Model);
                    carElem.SetAttributeValue("Year", car.Year);
                    carElem.SetAttributeValue("Price", car.Price);
                    carElem.Add(new XElement("TransmissionType", car.TransmissionType.ToString()));
                    var dealer = new XElement("Dealer");
                    dealer.SetAttributeValue("Name", car.Dealer.Name);

                    foreach (var city in car.Dealer.Cities.ToList())
                    {
                        var cityElem = new XElement("City", city);
                        dealer.Add(cityElem);
                    }

                    carElem.Add(dealer);

                    xmlResultSet.Add(carElem);
                }

                xmlResultSet.Save(@"..\..\" + filename);
            }
        }
    }
}
