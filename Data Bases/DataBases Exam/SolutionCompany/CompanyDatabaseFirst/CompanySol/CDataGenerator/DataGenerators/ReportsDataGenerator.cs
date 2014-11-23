using Company.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDataGenerator.DataGenerators
{
    public class ReportsDataGenerator : IDataGenerator
    {
        private IRandomDataGenerator random;
        private CompanyEntities db;
        private int count;

        public ReportsDataGenerator(IRandomDataGenerator randomDataGenerator, CompanyEntities dbContext, int countToGenerate)
        {
            this.random = randomDataGenerator;
            this.db = dbContext;
            this.count = countToGenerate;
        }

        public void Generate()
        {
            var employeeIds = this.db.Employees.Select(e => e.Id).ToList();

            var reportsToBeAdded = new List<Report>();

            foreach (var employeeId in employeeIds)
            {
                var newReport = new Report
                {
                    EmployeeId = employeeId,
                    TimeOfReport = this.GenerateRandomDate()
                };

                reportsToBeAdded.Add(newReport);
            }

            while (reportsToBeAdded.Count == this.count)
            {
                var newReport = new Report
                {
                    EmployeeId = this.random.GetRandomNumber(0, employeeIds.Count - 1),
                    TimeOfReport = this.GenerateRandomDate()
                };

                reportsToBeAdded.Add(newReport);
            }

            int index = 0;
            Console.WriteLine("Adding reports");
            foreach (var report in reportsToBeAdded)
            {
                this.db.Reports.Add(report);
                index++;

                if (index % 100 == 0)
                {
                    Console.Write(".");
                    db.SaveChanges();
                }
            }

            Console.WriteLine();
            Console.WriteLine("Reports added");
        }

        private DateTime GenerateRandomDate()
        {
            DateTime result = DateTime.Now.AddDays(-this.random.GetRandomNumber(0, 15))
                                        .AddDays(this.random.GetRandomNumber(0, 15))
                                        .AddHours(this.random.GetRandomNumber(0, 48))
                                        .AddHours(-this.random.GetRandomNumber(0, 48));

            return result;
        }
    }
}
