// Write an if statement that examines two integer variables and exchanges their values if the first one is greater than the second one.
using System;

class ExchangeValuesIf
{
    static void Main()
    {
        Console.Write("Enter 1st number: ");
        int num1 = int.Parse(Console.ReadLine());
        Console.Write("Enter 2nd number: ");
        int num2 = int.Parse(Console.ReadLine());
        if (num1 > num2)
        {
            num1 = num1 + num2;
            num2 = num1 - num2;
            num1 = num1 - num2;
            Console.WriteLine("1st numer: {0}\n2nd number: {1}", num1, num2);
        }
        else
        {
            Console.WriteLine("1st numer: {0}\n2nd number: {1}", num1, num2);                
        }
    }
}
