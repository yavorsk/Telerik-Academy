using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class StudentTest
{
    static void Main()
    {
        Studentt firstStudent = new Studentt("Pesho", "Peshev", "Peshev", 12394910, "ul. bogatica", 889123321, "abv@abv.bg", 2, University.UACEG, Specialty.Architecture, Faculty.Architecture);

        Console.WriteLine(firstStudent.ToString());

        Studentt secondStudent = (Studentt)firstStudent.Clone();

        Console.WriteLine(Studentt.Equals(firstStudent,secondStudent));
        Console.WriteLine();
        secondStudent.University = University.SofiaUniversity;
        Console.WriteLine(firstStudent.University);
        Console.WriteLine(secondStudent.University);
        Console.WriteLine();

        Studentt thirdStudent = new Studentt("Albena", "Peyova", "Peyova", 93258049, "ul. Cankov", 885324902, "yahoo@yahoo.com", 3, University.SofiaUniversity, Specialty.ComputerScience, Faculty.MathematicsAndInformatics);

        Console.WriteLine(Studentt.Equals(firstStudent,thirdStudent));
        Console.WriteLine();

        Studentt[] students = { firstStudent, secondStudent, thirdStudent };
        Array.Sort(students);
        foreach (var student in students)
        {
            Console.WriteLine("{0} {1} {2}", student.FirstName, student.MiddleName, student.LastName);
        }
    }
}
