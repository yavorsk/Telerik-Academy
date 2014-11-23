//Write a program that finds the biggest of three integers using nested if statements.
using System;

class TheBiggestOfThree
{
    static void Main()
    {
        Console.Write("Enter 1st integer number: ");
        int num1 = int.Parse(Console.ReadLine());
        Console.Write("Enter 2nd integer number: ");
        int num2 = int.Parse(Console.ReadLine());
        Console.Write("Enter 3rd integer number: ");
        int num3 = int.Parse(Console.ReadLine());
        if (num1>num2)
        {
            if (num1>num3)
            {
                Console.WriteLine("{0} is thebiggest.",num1);
            }
            else
            {
                if (num3>num2)
                {
                    Console.WriteLine("{0} is the biggest.",num3);                    
                }
            }
        }
        else
        {
            if (num2>num3)
            {
                    Console.WriteLine("{0} is thebiggest.",num2);                           
            }
            else
            {
                Console.WriteLine("{0} is thebiggest.", num3);     
            }
        }
    }
}
