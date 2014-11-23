using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyStore.Data;

namespace ConsoleDataGenerator
{
    internal class CategoryDataGenerator : IDataGenerator
    {
        private IRandomDataGenerator random;
        private ToyStoreEntities db;
        private int count;

        public CategoryDataGenerator(IRandomDataGenerator randomDataGenerator, ToyStoreEntities dbContext, int countToGenerate)
        {
            this.random = randomDataGenerator;
            this.db = dbContext;
            this.count = countToGenerate;
        }

        public void Generate()
        {
            Console.WriteLine("Adding categories");

            for (int i = 0; i < this.count; i++)
            {
                var category = new Category
                {
                    CategoryName = this.random.GetRandomStringWithRandomLength(5, 20)
                };

                this.db.Categories.Add(category);

                if (i % 100 == 0)
                {
                    Console.Write(".");
                    db.SaveChanges();
                }
            }

            Console.WriteLine();
            Console.WriteLine("Categories added");
        }
    }
}
