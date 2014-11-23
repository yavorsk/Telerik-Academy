using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Towns
{
    class Program
    {
        static List<Town> towns = new List<Town>();

        static void Main()
        {
            int numberOfTowns = int.Parse(Console.ReadLine());

            //for (int i = 0; i < numberOfTowns; i++)
            //{
            //    string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            //    towns.Add(new Town(long.Parse(input[0]), input[1]));
            //}

            Console.WriteLine(numberOfTowns);
        }
    }

    class Town
    {
        public Town(long population, string name)
        {
            this.Population = population;
            this.Name = name;
        }
        public long Population { get; set; }
        public string Name { get; set; }
    }
}
