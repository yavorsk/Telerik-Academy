using Company.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDataGenerator.DataGenerators
{
    public class ProjectDataGenerator : IDataGenerator
    {
        private IRandomDataGenerator random;
        private CompanyEntities db;
        private int count;

        public ProjectDataGenerator(IRandomDataGenerator randomDataGenerator, CompanyEntities dbContext, int countToGenerate)
        {
            this.random = randomDataGenerator;
            this.db = dbContext;
            this.count = countToGenerate;
        }

        public void Generate()
        {
            var projectsToBeAdded = new List<string>();

            while (projectsToBeAdded.Count != this.count)
            {
                projectsToBeAdded.Add(this.random.GetRandomStringWithRandomLength(5, 50));
            }

            int index = 0;
            Console.WriteLine("Adding projects");
            foreach (var projectName in projectsToBeAdded)
            {
                var project = new Project
                {
                    Name = projectName
                };

                this.db.Projects.Add(project);
                index++;

                if (index % 100 == 0)
                {
                    Console.Write(".");
                    db.SaveChanges();
                }
            }

            Console.WriteLine();
            Console.WriteLine("Projects added");
        }
    }
}
