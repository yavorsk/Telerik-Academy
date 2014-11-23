using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World.Data;

namespace DbTest
{
    class Program
    {
        static void Main(string[] args)
        {
            WorldContext db = new WorldContext();

            var cities = db.Cities.Select(c => c.Name).ToList();

            foreach (var cityName in cities)
            {
                Console.WriteLine(cityName);
            }
        }
    }
}
