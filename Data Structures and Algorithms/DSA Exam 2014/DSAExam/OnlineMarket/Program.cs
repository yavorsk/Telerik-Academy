using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace OnlineMarket
{
    class Program
    {
        //static SortedDictionary<double, Product> priceDict = new SortedDictionary<double, Product>();
        static OrderedMultiDictionary<string, Product> typeDict = new OrderedMultiDictionary<string, Product>(true);
        static HashSet<string> nameSet = new HashSet<string>();
        static OrderedMultiDictionary<double, Product> priceDict2 = new OrderedMultiDictionary<double, Product>(true);


        static OrderedSet<Product> productSet = new OrderedSet<Product>();

        static StringBuilder result = new StringBuilder();

        static void Main()
        {
            string currentCommand = Console.ReadLine();
            bool firstPass = true;

            while (currentCommand != "end")
            {
                if (!firstPass)
                {
                    result.AppendLine();
                }
                firstPass = false;

                string[] splittedCommand = currentCommand.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (splittedCommand[0] == "add")
                {
                    AddProduct(splittedCommand[1], splittedCommand[2], splittedCommand[3]);
                }
                else
                {
                    if (splittedCommand[2] == "type")
                    {
                        FilterByType(splittedCommand[3]);
                    }
                    else
                    {
                        if (splittedCommand.Length == 7)
                        {
                            FilterByPriceFromTo(splittedCommand[4], splittedCommand[6]);
                        }
                        else
                        {
                            if (splittedCommand[3] == "from")
                            {
                                FilterByPriceFrom(splittedCommand[4]);
                            }
                            else if (splittedCommand[3] == "to")
                            {
                                FilterByPriceTo(splittedCommand[4]);
                            }
                        }
                    }
                }

                currentCommand = Console.ReadLine();
            }


            //using (StreamWriter writer = new StreamWriter("..\\..\\output.txt"))
            //{
            //    writer.WriteLine(result.ToString());
            //}
            Console.WriteLine(result);
        }

        private static void FilterByPriceTo(string toPrice)
        {
            var resultSet = productSet.Where(p => p.Price <= double.Parse(toPrice)).OrderBy(p => p.Price).OrderBy(p => p.Price).ThenBy(p => p.Name).ThenBy(p => p.Type).Take(10);
            //var resultSet2 = resultSet.Skip(Math.Max(0, resultSet.Count() - 10))

            result.Append("Ok: " + string.Join(", ", resultSet));
        }

        private static void FilterByPriceFrom(string fromPrice)
        {
            var resultSet = productSet.Where(p => p.Price >= double.Parse(fromPrice)).OrderBy(p => p.Price).ThenBy(p => p.Name).Take(10);

            result.Append("Ok: " + string.Join(", ", resultSet));
        }

        private static void FilterByPriceFromTo(string fromPrice, string toPrice)
        {
            var resultSet = productSet.Where(p => p.Price <= double.Parse(toPrice) && p.Price >= double.Parse(fromPrice)).OrderBy(p => p.Price).ThenBy(p => p.Name).Take(10);

            result.Append("Ok: " + string.Join(", ", resultSet));
        }

        private static void FilterByType(string type)
        {
            var resultSet = typeDict[type].OrderBy(p => p.Price).ThenBy(p => p.Name).Take(10).ToList();

            if (resultSet.Count != 0)
            {
                result.Append("Ok: " + string.Join(", ", resultSet));
            }
            else
            {
                result.Append(string.Format("Error: Type {0} does not exists", type));
            }
        }

        private static void AddProduct(string name, string price, string type)
        {
            if (nameSet.Contains(name))
            {
                result.Append(string.Format("Error: Product {0} already exists", name));
            }
            else
            {
                nameSet.Add(name);
                Product newProduct = new Product(name, double.Parse(price), type);

                priceDict2.Add(newProduct.Price, newProduct);

                typeDict.Add(newProduct.Type, newProduct);

                productSet.Add(newProduct);
                //if (typeDict.ContainsKey(newProduct.Type))
                //{
                //    typeDict[newProduct.Type].Add(newProduct.Price, newProduct);
                //}
                //else
                //{
                //    typeDict[newProduct.Type] = new OrderedMultiDictionary<double, Product>(true);
                //    typeDict[newProduct.Type].Add(newProduct.Price, newProduct);
                //}

                result.Append(string.Format("Ok: Product {0} added successfully", newProduct.Name));
            }

        }
    }

    class Product : IComparable
    {
        public Product(string name, double price, string type)
        {
            this.Name = name;
            this.Price = price;
            this.Type = type;
        }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Type { get; set; }

        public int CompareTo(object obj)
        {
            var other = obj as Product;
            return this.Name.CompareTo(other.Name);
        }

        public override string ToString()
        {
            return string.Format("{0}({1})", this.Name, this.Price);
        }
    }
}
