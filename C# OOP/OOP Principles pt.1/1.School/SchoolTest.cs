using System;
using System.Linq;

//1. We are given a school. In the school there are classes of students. Each class has a set of teachers. 
// Each teacher teaches a set of disciplines. Students have name and unique class number. 
// Classes have unique text identifier. Teachers have name. Disciplines have name, number of lectures and number of exercises.
// Both teachers and students are people. Students, classes, teachers and disciplines could have optional comments (free text block).
// Your task is to identify the classes (in terms of  OOP) and their attributes and operations, 
// encapsulate their fields, define the class hierarchy and create a class diagram with Visual Studio.

class SchoolTest
{
    static void Main()
    {
        Teacher dani = new Teacher("Daniela");

        Discipline math = new Discipline("mathematics", 10, 5);
        Discipline bio = new Discipline("biology", 6, 3);
        Discipline hist = new Discipline("history", 8, 5);

        dani.TeacharsDisciplines.Add(math);
        dani.TeacharsDisciplines.Add(bio);
        //dani.TeacharsDisciplines.Remove(math);

        Student pesho = new Student("Pesho", 1);
        Student gogo = new Student("Gogo", 2);
        Student tsetso = new Student("Tsetso", 3);

        Class a6 = new Class("6A");
        a6.Students.Add(pesho);
        a6.Students.Add(gogo);
        a6.Students.Add(tsetso);
        a6.Teachers.Add(dani);

        a6.Comments.Add("some comment");

        Console.WriteLine(a6.Students[1].Name);
    }
}
