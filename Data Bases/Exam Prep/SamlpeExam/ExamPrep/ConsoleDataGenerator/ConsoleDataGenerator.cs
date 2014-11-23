using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyStore.Data;

namespace ConsoleDataGenerator
{
    class ConsoleDataGenerator
    {
        static void Main()
        {
            var random = RandomDataGenerator.Instance;
            var dbContext = new ToyStoreEntities();
            dbContext.Configuration.AutoDetectChangesEnabled = false;

            var countCategoriesToGenerate = 100;
            var countManufacturersToGenerate = 50;
            var countAgeRangesToGenerate = 100;
            var countToysToGenerate = 20000;
            
            var listOfGenerators = new List<IDataGenerator>
            {
                new CategoryDataGenerator(random, dbContext, countCategoriesToGenerate),
                new ManufacturerDataGenerator(random, dbContext, countManufacturersToGenerate),
                new AgeRangeDataGenerator(random, dbContext, countAgeRangesToGenerate),
                new ToyDataGenerator(random, dbContext, countToysToGenerate)
            };

            foreach (var generator in listOfGenerators)
            {
                generator.Generate();
                dbContext.SaveChanges();
            }
        }
    }
}
