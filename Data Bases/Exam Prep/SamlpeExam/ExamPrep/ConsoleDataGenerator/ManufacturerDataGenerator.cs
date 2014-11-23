using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyStore.Data;

namespace ConsoleDataGenerator
{
    internal class ManufacturerDataGenerator : IDataGenerator
    {
        private IRandomDataGenerator random;
        private ToyStoreEntities db;
        private int count;

        public ManufacturerDataGenerator(IRandomDataGenerator randomDataGenerator, ToyStoreEntities dbContext, int countToGenerate)
        {
            this.random = randomDataGenerator;
            this.db = dbContext;
            this.count = countToGenerate;
        }

        public void Generate()
        {
            var manufacturersToBeAdded = new HashSet<string>();

            while (manufacturersToBeAdded.Count != this.count)
            {
                manufacturersToBeAdded.Add(this.random.GetRandomStringWithRandomLength(5, 20));
            }

            int index = 0;
            Console.WriteLine("Adding manufacturers");
            foreach (var manufacturerName in manufacturersToBeAdded)
            {
                var manufacturer = new Manufacturer
                {
                    Name = manufacturerName,
                    Country = this.random.GetRandomStringWithRandomLength(4, 40)
                };
                
                this.db.Manufacturers.Add(manufacturer);
                index++;

                if (index % 100 == 0)
                {
                    Console.Write(".");
                    db.SaveChanges();
                }
            }

            Console.WriteLine();
            Console.WriteLine("Manufacturers added");
        }
    }
}
