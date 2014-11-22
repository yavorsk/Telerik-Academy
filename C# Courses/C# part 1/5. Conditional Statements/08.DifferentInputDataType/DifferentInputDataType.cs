//Write a program that, depending on the user's choice inputs int, double or string variable. If the variable is integer or double, increases it with 1. If the variable is string, appends "*" at its end. The program must show the value of that variable as a console output. Use switch statement.
using System;

class DifferentInputDataType
{
    static void Main()
    {
        Console.Write("Please enter real or integer number or string: ");
        string input = Console.ReadLine();
        double num;
        switch (double.TryParse(input, out num))
        {
            case true:
                num += 1;
                Console.WriteLine("Variable's new value: {0}", num); break;
            case false:
                Console.WriteLine("Variable's new value: {0}*", input); break;
        }

    }
}
