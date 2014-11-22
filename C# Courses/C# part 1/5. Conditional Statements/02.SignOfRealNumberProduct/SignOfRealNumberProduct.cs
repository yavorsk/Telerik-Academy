// Write a program that shows the sign (+ or -) of the product of three real numbers without calculating it. Use a sequence of if statements.
using System;

class SignOfRealNumberProduct
{
    static void Main()
    {
        Console.Write("Enter 1st real number: ");
        double num1 = double.Parse(Console.ReadLine());
        Console.Write("Enter 2nd real number: ");
        double num2 = double.Parse(Console.ReadLine());
        Console.Write("Enter 3rd real number: ");
        double num3 = double.Parse(Console.ReadLine());
        if (num1==0 || num2==0 || num3==0)
        {
            Console.WriteLine("The the product of the three numbers is 0");            
        }
        else
        {
            if (num1 < 0 && num2 > 0 && num3 > 0)
            {
                Console.WriteLine("The sign of the product of the three numbers is \"-\"");
            }
            else if (num1 > 0 && num2 < 0 && num3 > 0)
            {
                Console.WriteLine("The sign of the product of the three numbers is \"-\"");
            }
            else if (num1 > 0 && num2 > 0 && num3 < 0)
            {
                Console.WriteLine("The sign of the product of the three numbers is \"-\"");
            }
            else if (num1 < 0 && num2 < 0 && num3 < 0)
            {
                Console.WriteLine("The sign of the product of the three numbers is \"-\"");
            }
            else
            {
                Console.WriteLine("The sign of the product of the three numbers is \"+\"");
            }
        }
    }
}
