using System;
using System.Collections.Generic;
using System.Linq;

// 2. Define abstract class Human with first name and last name. 
// Define new class Student which is derived from Human and has new field – grade. 
// Define class Worker derived from Human with new property WeekSalary and WorkHoursPerDay and method 
// MoneyPerHour() that returns money earned by hour by the worker. Define the proper constructors and properties for this hierarchy. 
// Initialize a list of 10 students and sort them by grade in ascending order (use LINQ or OrderBy() extension method). 
// Initialize a list of 10 workers and sort them by money per hour in descending order. 
// Merge the lists and sort them by first name and last name.

class Program
{
    static void Main()
    {
        List<Student> tenStudents = new List<Student> 
        {
            new Student("Pesho", "Petev", 4),
            new Student("Parvan", "Siderov", 1),
            new Student("Atanas", "Shanov", 3),
            new Student("Maria", "Sapunjieva", 4),
            new Student("Koko", "Stoinov", 12),
            new Student("Yana", "Bakalova", 8),
            new Student("Samuil", "Stoychev", 7),
            new Student("Evgenia", "Belejkova", 10),
            new Student("Shaban", "Shaulich", 9),
            new Student("Zoza", "Puleva", 6)
        };

        //LINQ:
        //var sortedStudents =
        //    from student in tenStudents
        //    orderby student.Grade
        //    select student;

        //Lambda expression:
        var sortedStudents = tenStudents.OrderBy(student => student.Grade);

        foreach (var student in sortedStudents)
        {
            Console.WriteLine(student.FirstName + ' ' + student.LastName + ' ' + student.Grade);
        }
        Console.WriteLine();

        List<Worker> tenWorkers = new List<Worker>
        {
            new Worker("Panayot", "Vachkov", 200, 8),
            new Worker("Rumiana", "Jeleva", 400, 10),
            new Worker("Hristo", "Monov", 200, 6.8),
            new Worker("Delian", "Peevski", 100, 12), //OSTAVKA
            new Worker("Sergei", "Stanishev", 120.55M, 15), //OSTAVKA
            new Worker("Liutfi", "Mestan", 123.33M, 13), //OSTAVKA
            new Worker("Georgi", "Gospodinov", 625.125M, 5),
            new Worker("Stoyan", "Radev", 145, 8),
            new Worker("Patrik", "Slavchev", 366, 9.6),
            new Worker("Assen", "Borisov", 222, 8),
        };

        //LINQ:
        var sortedWorkers =
            from worker in tenWorkers
            orderby worker.MoneyPerHour() descending
            select worker;

        //Lambda expression:
        //var sortedWorkers = tenWorkers.OrderByDescending(worker => worker.MoneyPerHour());

        foreach (var worker in sortedWorkers)
        {
            Console.WriteLine("{0} {1} earns {2:0.00} $ per hour.", worker.FirstName, worker.LastName, worker.MoneyPerHour());
        }
        Console.WriteLine();

        List<Human> mergedList = tenStudents.Concat<Human>(tenWorkers).ToList<Human>();

        //Lambda expression:
        //var sortedMergedList = mergedList.OrderBy(human => human.FirstName).ThenBy(human => human.LastName);

        //LINQ:
        var sortedMergedList =
            from human in mergedList
            orderby human.FirstName, human.LastName
            select human;

        foreach (var human in sortedMergedList)
        {
            Console.WriteLine("{0} {1}", human.FirstName, human.LastName);
        }
    }
}