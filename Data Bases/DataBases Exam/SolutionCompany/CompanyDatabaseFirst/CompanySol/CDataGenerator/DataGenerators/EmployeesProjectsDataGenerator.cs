using Company.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDataGenerator.DataGenerators
{
    public class EmployeesProjectsDataGenerator : IDataGenerator
    {
        private IRandomDataGenerator random;
        private CompanyEntities db;
        private int count;

        public EmployeesProjectsDataGenerator(IRandomDataGenerator randomDataGenerator, CompanyEntities dbContext, int countToGenerate)
        {
            this.random = randomDataGenerator;
            this.db = dbContext;
            this.count = countToGenerate;
        }

        public void Generate()
        {
            var employeeIds = this.db.Employees.Select(e => e.Id).ToList();
            var projectIds = this.db.Projects.Select(p => p.id).ToList();

            var usedPairs = new List<Tuple<int, int>>();

            var emplProjectsToBeAdded = new List<EmployeesProject>();


            for (int i = 0; i < 2; i++)
            {
                foreach (var projectId in projectIds)
                {
                    var employeeIdIndex = this.random.GetRandomNumber(0, employeeIds.Count - 1);
                    var toBreak = false;

                    foreach (var pair in usedPairs)
                    {
                        if (pair.Item1 == employeeIds[employeeIdIndex] && pair.Item2 == projectId)
                        {
                            toBreak = true;
                            break;
                        }
                    }

                    if (toBreak)
                    {
                        toBreak = false;
                        break;
                    }

                    usedPairs.Add(new Tuple<int, int>(employeeIds[employeeIdIndex], projectId));

                    var newEmpProject = new EmployeesProject
                    {
                        EmployeeId = employeeIds[employeeIdIndex],
                        ProjectId = projectId,
                        StartingDate = this.GenerateRandomStartDate(),
                        EndingDate = this.GenerateRandomEndDate()
                    };

                    emplProjectsToBeAdded.Add(newEmpProject);

                }
            }

            while (emplProjectsToBeAdded.Count == this.count)
            {
                var currentEmpIdIndex = this.random.GetRandomNumber(0, employeeIds.Count - 1);
                var currentPrIdIndex = this.random.GetRandomNumber(0, projectIds.Count - 1);

                var toBreak = false;

                foreach (var pair in usedPairs)
                {
                    if (pair.Item1 == employeeIds[currentEmpIdIndex] && pair.Item2 == projectIds[currentPrIdIndex])
                    {
                        toBreak = true;
                        break;
                    }
                }

                if (toBreak)
                {
                    toBreak = false;
                    break;
                }

                usedPairs.Add(new Tuple<int, int>(employeeIds[currentEmpIdIndex], projectIds[currentPrIdIndex]));

                var newEmpProject = new EmployeesProject
                     {
                         EmployeeId = employeeIds[currentEmpIdIndex],
                         ProjectId = projectIds[currentPrIdIndex],
                         StartingDate = this.GenerateRandomStartDate(),
                         EndingDate = this.GenerateRandomEndDate()
                     };

                emplProjectsToBeAdded.Add(newEmpProject);
            }

            int index = 0;
            Console.WriteLine("Adding Employees-Projects entries");
            foreach (var emplProj in emplProjectsToBeAdded)
            {
                this.db.EmployeesProjects.Add(emplProj);
                index++;

                if (index % 100 == 0)
                {
                    Console.Write(".");
                    db.SaveChanges();
                }
            }

            Console.WriteLine();
            Console.WriteLine("Employees-Projects entries added");
        }

        private DateTime GenerateRandomStartDate()
        {
            DateTime result = DateTime.Now.AddDays(-this.random.GetRandomNumber(5, 15))
                                        .AddHours(-this.random.GetRandomNumber(0, 48));

            return result;
        }

        private DateTime GenerateRandomEndDate()
        {
            DateTime result = DateTime.Now.AddDays(-this.random.GetRandomNumber(0, 4))
                                        .AddDays(this.random.GetRandomNumber(0, 14))
                                        .AddHours(this.random.GetRandomNumber(0, 48));

            return result;
        }
    }
}
