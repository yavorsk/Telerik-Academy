using System;
using System.Linq;

class students
{
    static void Main()
    {
        var arrOfStudents = new[] 
        {
            new { firstName = "Pesho", lastName = "Georgiev", age = 22 },
            new { firstName = "Georgi", lastName = "Dimitrov", age = 25 },
            new { firstName = "Pavel", lastName = "Stoyanov", age = 16 },
            new { firstName = "Pavel", lastName = "Hinov", age = 23 },
            new {firstName = "Blagoy", lastName = "Petrov", age = 20 },
            new {firstName = "Atanas", lastName = "Pramatarov", age = 19 }
        };

        // 3. Write a method that from a given array of students finds all 
        // students whose first name is before its last name alphabetically. Use LINQ query operators.

        //LINQ
        var queryStudents =
            from student in arrOfStudents
            where student.firstName.CompareTo(student.lastName) < 0
            select student;
        foreach (var student in queryStudents)
        {
            Console.WriteLine("{0} {1}",student.firstName, student.lastName);
        }

        //lambda expression
        var lambdaStudents = arrOfStudents.Where(student => student.firstName.CompareTo(student.lastName) < 0);
        foreach (var student in lambdaStudents) 
        {
            Console.WriteLine("{0} {1}", student.firstName, student.lastName);
        }
        Console.WriteLine();

        // 4. Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.
        
        //LINQ
        var queryStudents2 =
            from student in arrOfStudents
            where 18 <= student.age && student.age <= 24
            select new { first = student.firstName, last = student.lastName };
        foreach (var student in queryStudents2)
        {
            Console.WriteLine("{0} {1}", student.first, student.last);
        }
        Console.WriteLine();

        //lambda
        var lambdaStudents2 = arrOfStudents.Where(student => 18 <= student.age && student.age <= 24);
        foreach (var item in lambdaStudents2)
        {
            Console.WriteLine("{0} {1}", item.firstName, item.lastName);
        }
        Console.WriteLine();

        // 5. Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students 
        // by first name and last name in descending order. Rewrite the same with LINQ.

        var sortedArrOfStudents = arrOfStudents.OrderByDescending(student => student.firstName).ThenByDescending(student => student.lastName);
        foreach (var item in sortedArrOfStudents)
        {
            Console.WriteLine("{0} {1}", item.firstName, item.lastName);
        }
        Console.WriteLine();

        var sortedArrOfStudentsLinq =
            from student in arrOfStudents
            orderby student.firstName descending, student.lastName descending
            select student;
        foreach (var item in sortedArrOfStudentsLinq)
        {
            Console.WriteLine("{0} {1}", item.firstName, item.lastName);
        }

    }
}
