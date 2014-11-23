using StudentSystem.Data;
using StudentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace StudentSystem.ConsoleClient
{
    public class Program
    {
        public static void Main()
        {
            var dataContext = new StudentSystemDbContext();

            Course oop = new Course();
            oop.Name = "OOP";
            oop.Description = "asdasdad";

            Course jsapps = new Course();
            jsapps.Name = "JSAPPS";
            jsapps.Description = "asdfds";

            Student gogo = new Student();
            gogo.Name = "Gogo lozanov";
            gogo.Age = 15;
            gogo.Courses.Add(oop);
            gogo.Courses.Add(jsapps);

            dataContext.Students.Add(gogo);

            dataContext.SaveChanges();

            //dataContext.Students.Add(new Student
            //{
            //    Name = "Pesho Peshev",
            //    Age = 22,
            //    Number = 12354364
            //});

            //var course = new Course
            //{
            //    Name = "OOP",
            //    Description = "bla bla bla"
            //};

            //dataContext.Courses.Add(course);

            //dataContext.SaveChanges();

            //var students = dataContext.Students.ToList();

            //Console.WriteLine(students.Count);
        }
    }
}
