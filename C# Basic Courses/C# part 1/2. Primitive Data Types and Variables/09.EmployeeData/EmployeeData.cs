using System;

class EmployeeData
{
    static void Main()
    {
        string firstName = "Jack";
        string familyName = "Reacher";
        byte age = 42;
        char gender = 'm';
        long iDN = 7109101248;
        int uEN = 27563456;
        Console.WriteLine("First name: {0}\nFamily name: {1}\nAge: {2}\nGender: {3}\nID number: {4}\nUnique employee number: {5}",
                            firstName, familyName, age, gender, iDN, uEN);
    }
}
