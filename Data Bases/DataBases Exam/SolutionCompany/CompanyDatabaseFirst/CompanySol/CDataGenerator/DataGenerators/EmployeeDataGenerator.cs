using Company.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDataGenerator.DataGenerators
{
    public class EmployeeDataGenerator : IDataGenerator
    {
        private IRandomDataGenerator random;
        private CompanyEntities db;
        private int count;

        public EmployeeDataGenerator(IRandomDataGenerator randomDataGenerator, CompanyEntities dbContext, int countToGenerate)
        {
            this.random = randomDataGenerator;
            this.db = dbContext;
            this.count = countToGenerate;
        }

        public void Generate()
        {
            var departmentIds = this.db.Departments.Select(d => d.Id).ToList();

            Console.WriteLine("Adding employees");
            for (int i = 0; i < this.count; i++)
            {
                var newEmployee = new Employee
                {
                    FirstName = this.random.GetRandomStringWithRandomLength(5, 20),
                    LastName = this.random.GetRandomStringWithRandomLength(5, 20),
                    YearSalary = (decimal)this.random.GetRandomNumber(50000, 200000),
                    DepartmentId = departmentIds[this.random.GetRandomNumber(0, departmentIds.Count - 1)]
                };

                if (i > 10 && this.random.GetRandomNumber(1, 100) < 95)
                {
                    newEmployee.ManagerId = this.random.GetRandomNumber(1, i);
                }
                else
                {
                    newEmployee.ManagerId = null;
                }

                this.db.Employees.Add(newEmployee);

                if (i % 100 == 0)
                {
                    db.SaveChanges();
                    Console.Write(".");
                }
            }
            Console.WriteLine();
            Console.WriteLine("Employees added");
        }
    }
}
