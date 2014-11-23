namespace StudentSystem.Data.Migrations
{
    using StudentSystem.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "StudentSystem.Data.StudentSystemDbContext";
        }

        protected override void Seed(StudentSystemDbContext context)
        {
            this.SeedCourses(context);
            this.SeedStudents(context);
        }

        private void SeedStudents(StudentSystemDbContext context)
        {
            if (context.Students.Any())
            {
                return;
            }

            context.Students.Add(new Student
            {
                Name = "Pesho Peshev",
                Age = 33,
                Number = 11111
            });

            context.Students.Add(new Student
            {
                Name = "Vanio Vaniov",
                Age = 22,
                Number = 22222
            }); context.Students.Add(new Student

            {
                Name = "Gosho Goshev",
                Age = 26,
                Number = 33333
            });
        }

        private void SeedCourses(StudentSystemDbContext context)
        {
            if (context.Courses.Any())
            {
                return;
            }

            context.Courses.Add(new Course
            {
                Name = "OOP",
                Description = "Bla bla"
            });

            context.Courses.Add(new Course
            {
                Name = "JS Apps",
                Description = "asdfdsf afg fadg"
            });
        }
    }
}
