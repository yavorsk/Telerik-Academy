using System;

class GreaterOfTwoInts
{
    static void Main()
    {
        Console.Write("Please enter first number: ");
        int num1 = int.Parse(Console.ReadLine());
        Console.Write("Please enter scond number: ");
        int num2 = int.Parse(Console.ReadLine());
        Console.WriteLine(Math.Max(num1, num2));
    }
}
