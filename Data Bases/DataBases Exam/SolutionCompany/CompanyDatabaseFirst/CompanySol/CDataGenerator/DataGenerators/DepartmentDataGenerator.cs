using Company.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDataGenerator.DataGenerators
{
    internal class DepartmentDataGenerator : IDataGenerator
    {
        private IRandomDataGenerator random;
        private CompanyEntities db;
        private int count;

        public DepartmentDataGenerator(IRandomDataGenerator randomDataGenerator, CompanyEntities dbContext, int countToGenerate)
        {
            this.random = randomDataGenerator;
            this.db = dbContext;
            this.count = countToGenerate;
        }

        public void Generate()
        {
            var departmentsToBeAdded = new HashSet<string>();

            while (departmentsToBeAdded.Count != this.count)
            {
                departmentsToBeAdded.Add(this.random.GetRandomStringWithRandomLength(10, 50));
            }

            int index = 0;
            Console.WriteLine("Adding departments");
            foreach (var departmentName in departmentsToBeAdded)
            {
                var department = new Department
                {
                    Name = departmentName
                };
                
                this.db.Departments.Add(department);
                index++;

                if (index % 100 == 0)
                {
                    Console.Write(".");
                    db.SaveChanges();
                }
            }

            Console.WriteLine();
            Console.WriteLine("Departments added");
        }
    }
}
