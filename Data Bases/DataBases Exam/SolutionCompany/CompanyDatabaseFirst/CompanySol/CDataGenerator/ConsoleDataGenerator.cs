using Company.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDataGenerator.DataGenerators;

namespace CDataGenerator
{
    public class ConsoleDataGenerator
    {
        static void Main()
        {
            var random = RandomDataGenerator.Instance;
            var dbContext = new CompanyEntities();
            dbContext.Configuration.AutoDetectChangesEnabled = false;

            var countOfDepartments = 100;
            var countOfEmployees = 5000;
            var countOfProjects = 10000;
            var countOfEmpProjects = 5 * countOfProjects;
            var countOfReports = 25000;

            var listOfGenerators = new List<IDataGenerator>
            {
                new DepartmentDataGenerator(random, dbContext, countOfDepartments),
                new EmployeeDataGenerator(random, dbContext, countOfEmployees),
                new ProjectDataGenerator(random, dbContext, countOfProjects),
                new EmployeesProjectsDataGenerator(random, dbContext, countOfEmpProjects),
                new ReportsDataGenerator(random, dbContext, countOfReports)
            };

            foreach (var generator in listOfGenerators)
            {
                generator.Generate();
                dbContext.SaveChanges();
            }
        }
    }
}
