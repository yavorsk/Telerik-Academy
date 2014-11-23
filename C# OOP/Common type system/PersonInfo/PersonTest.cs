using System;

class PersonTest
{
    static void Main()
    {
        Person first = new Person("Pesho", 26);
        Person second = new Person("Joro");

        Console.WriteLine(first.ToString());
        Console.WriteLine();
        Console.WriteLine(second.ToString());
    }
}
