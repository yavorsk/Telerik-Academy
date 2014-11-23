using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyStore.Data;

namespace ConsoleDataGenerator
{
    internal class AgeRangeDataGenerator : IDataGenerator
    {
        private IRandomDataGenerator random;
        private ToyStoreEntities db;
        private int count;

        public AgeRangeDataGenerator(IRandomDataGenerator randomDataGenerator, ToyStoreEntities dbContext, int countToGenerate)
        {
            this.random = randomDataGenerator;
            this.db = dbContext;
            this.count = countToGenerate;
        }

        public void Generate()
        {
            var counter = 0;

            Console.WriteLine("Adding age ranges");
            for (int i = 0; i < this.count / 5; i++)
            {
                for (int j = i+1; j < i+5; j++)
                {
                    var ageRange = new AgeRange()
                    {
                        MinAge = i,
                        MaxAge = j
                    };

                    this.db.AgeRanges.Add(ageRange);
                    counter++;

                    if (counter % 100 == 0)
                    {
                        this.db.SaveChanges();
                        Console.Write(".");
                    }

                    if (counter == this.count)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Age ranges added");
                        return;
                    }
                }
            }
        }
    }
}
