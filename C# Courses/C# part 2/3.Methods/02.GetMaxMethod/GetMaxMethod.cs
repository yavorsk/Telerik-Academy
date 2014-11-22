//Write a method GetMax() with two parameters that returns the bigger of two integers. 
//Write a program that reads 3 integers from the console and prints the biggest of them using the method GetMax().
using System;

class GetMaxMethod
{
    static int GetMax(int num1, int num2) 
    {
        if (num1 >= num2)
        {
            return num1;
        }
        else
        {
            return num2;
        }
    }
    static void Main()
    {
        Console.WriteLine("Please enter three integers each followed by enter:");
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());
        Console.WriteLine("The biggest of the three is {0}.", GetMax(a,GetMax(b,c)));
    }
}
