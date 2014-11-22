using System;

class DivisionBy5BetwTwoNum
{
    static void Main()
    {
        Console.Write("Please enter first number (undigned integer): ");
        uint num1 = uint.Parse(Console.ReadLine());    
        Console.Write("Please enter scond number (undigned integer): ");
        uint num2 = uint.Parse(Console.ReadLine());
        uint p = 0;
        for (uint i = Math.Min(num1, num2); i <= Math.Max(num1, num2); i++)
        {
            p = i % 5 == 0 ? ++p : p;
        }
        Console.WriteLine("There are {0} numbers between {1} and {2} inclusively that divide by 5 without a remainder.", p, num1, num2);
    }
}