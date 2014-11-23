using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyStore.Data;

namespace ConsoleDataGenerator
{
    internal class ToyDataGenerator : IDataGenerator
    {
        private IRandomDataGenerator random;
        private ToyStoreEntities db;
        private int count;

        public ToyDataGenerator(IRandomDataGenerator randomDataGenerator, ToyStoreEntities dbContext, int countToGenerate)
        {
            this.random = randomDataGenerator;
            this.db = dbContext;
            this.count = countToGenerate;
        }

        public void Generate()
        {
            var ageRangeIds = this.db.AgeRanges.Select(a => a.id).ToList();
            var manufacturerIds = this.db.Manufacturers.Select(m => m.id).ToList();
            var categoryIds = this.db.Categories.Select(c => c.id).ToList();

            Console.WriteLine("Adding toys");
            for (int i = 0; i < this.count; i++)
            {
                var toy = new Toy
                {
                    ToyName = this.random.GetRandomStringWithRandomLength(5, 20),
                    Type = this.random.GetRandomStringWithRandomLength(5, 20),
                    Price = this.random.GetRandomNumber(10, 500),
                    Color = this.random.GetRandomNumber(1, 5) == 5 ? null : this.random.GetRandomStringWithRandomLength(5, 20),
                    ManufacturerId = manufacturerIds[this.random.GetRandomNumber(0, manufacturerIds.Count - 1)],
                    AgeRangeId = ageRangeIds[this.random.GetRandomNumber(0, ageRangeIds.Count - 1)],

                };

                if (categoryIds.Count > 0)
                {
                    var uniqueCategoryIds = new HashSet<int>();

                    var categoriesInToy = this.random.GetRandomNumber(1, Math.Min(10, categoryIds.Count));

                    while (uniqueCategoryIds.Count != categoriesInToy)
                    {
                        uniqueCategoryIds.Add(categoryIds[this.random.GetRandomNumber(0, categoryIds.Count - 1)]);
                    }

                    foreach (var id in uniqueCategoryIds)
                    {
                        toy.Categories.Add(this.db.Categories.Find(id));
                    }
                }

                this.db.Toys.Add(toy);

                if (i % 100 == 0)
                {
                    db.SaveChanges();
                    Console.Write(".");
                }
            }

            Console.WriteLine("");
            Console.WriteLine("Toys added");
        }
    }
}
