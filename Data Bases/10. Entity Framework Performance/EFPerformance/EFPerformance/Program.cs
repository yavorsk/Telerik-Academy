using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPerformance
{
    class Program
    {
        static void Main()
        {
            TelerikAcademyEntities dbContext = new TelerikAcademyEntities();

            // 1. Using Entity Framework write a SQL query to select all employees from the Telerik Academy database 
            // and later print their name, department and town. Try the both variants: with and without .Include(…). 
            // Compare the number of executed SQL statements and the performance.

            Stopwatch sw = new Stopwatch();

            sw.Start();
            foreach (var employee in dbContext.Employees)
            {
                Console.WriteLine("Name: {0}, Department: {1}, Town: {2}", employee.FirstName,
                                       employee.Department.Name, employee.Address.Town.Name);
            }
            sw.Stop();

            var timeWithoutInclude = sw.Elapsed;

            sw.Reset();

            Console.WriteLine("-----------------------------------");

            sw.Start();
            foreach (var employee in dbContext.Employees.Include("Address")) //.Include("Departments")
            {
                Console.WriteLine("Name: {0}, Department: {1}, Town: {2}", employee.FirstName,
                                      employee.Department.Name, employee.Address.Town.Name);
            }
            sw.Stop();

            var timeWithInclude = sw.Elapsed;

            sw.Reset();

            Console.WriteLine("-----------------------------------");

            var searchedData = dbContext.Employees.Select(employee =>
                new
                {
                    Name = employee.FirstName,
                    Department = employee.Department.Name,
                    Town = employee.Address.Town.Name
                });

            sw.Start();
            foreach (var data in searchedData)
            {
                Console.WriteLine("Name: {0}, Department: {1}, Town: {2}", data.Name,data.Department, data.Town);
            }
            sw.Stop();

            var timeForNikiWay = sw.Elapsed;

            sw.Reset();

            Console.WriteLine("Elapsed Time without using include: {0}", timeWithoutInclude);
            Console.WriteLine("Elapsed Time with using include: {0}", timeWithInclude);
            Console.WriteLine("Elapsed Time using Niki's way: {0}", timeForNikiWay);

            // 2. Using Entity Framework write a query that selects all employees from the Telerik Academy database,
            // then invokes ToList(), then selects their addresses, then invokes ToList(),
            // then selects their towns, then invokes ToList() and finally checks whether the town is "Sofia".
            // Rewrite the same in more optimized way and compare the performance.

            sw.Start();
            var stupidQuery = dbContext.Employees.ToList()
                .Select(e => e.Address).ToList()
                .Select(a => a.Town).ToList()
                .Where(t => t.Name == "Sofia");
            sw.Stop();

            var timeElapsedForStupidQuery = sw.Elapsed;

            sw.Reset();

            sw.Start();
            var query = dbContext.Employees
                .Select(e => e.Address)
                .Select(a => a.Town)
                .Where(t => t.Name == "Sofia");
            sw.Stop();
            sw.Stop();

            var timeElapsedForQuery = sw.Elapsed;

            Console.WriteLine("Time for stupid query: {0}", timeElapsedForStupidQuery);
            Console.WriteLine("Time for smarter query: {0}", timeElapsedForQuery);
        }
    }
}
