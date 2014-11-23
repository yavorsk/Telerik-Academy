using System;

class DivisionBy5and7
{
    static void Main()
    {
        Console.Write("Please enter a int number: ");
        int num = int.Parse(Console.ReadLine());
        Console.WriteLine(num % 5 == 0 && num % 7 == 0 ? "The number can be divided by 5 and 7 without a remainder." 
                                                       : "The number can not be divided by 5 and 7 without a remainder.");
    }
}
