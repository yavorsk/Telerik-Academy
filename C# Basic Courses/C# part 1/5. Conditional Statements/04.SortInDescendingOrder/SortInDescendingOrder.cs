// Sort 3 real values in descending order using nested if statements.
using System;

class SortInDescendingOrder
{
    static void Main()
    {
        Console.Write("Enter 1st real number: ");
        double num1 = double.Parse(Console.ReadLine());
        Console.Write("Enter 2nd real number: ");
        double num2 = double.Parse(Console.ReadLine());
        Console.Write("Enter 3rd real number: ");
        double num3 = double.Parse(Console.ReadLine());
        if (num1 >= num2)
        {
            if (num2 >= num3)
            {
                Console.WriteLine("{0}\n{1}\n{2}", num1, num2, num3);
            }
            else
            {
                if (num3 <= num1)
                {
                    Console.WriteLine("{0}\n{2}\n{1}", num1, num2, num3);
                }
                else
                {
                    Console.WriteLine("{2}\n{0}\n{1}", num1, num2, num3);
                }
            }
        }
        else
        {
            if (num2 <= num3)
            {
                Console.WriteLine("{2}\n{1}\n{0}", num1, num2, num3);
            }
            else
            {
                if (num3 <= num1)
                {
                Console.WriteLine("{1}\n{0}\n{2}", num1, num2, num3);                    
                }
                else
                {
                    Console.WriteLine("{1}\n{2}\n{0}", num1, num2, num3);    
                }
            }

        }
    }
}
