// 1.Write a program that reads an integer number and calculates and prints its square root. 
// If the number is invalid or negative, print "Invalid number". In all cases finally print "Good bye". 
// Use try-catch-finally.

using System;

class SquareRoot
{
    static void Main()
    {
        try
        {
            Console.Write("Enter positive integer number: ");
            string input = Console.ReadLine();
            uint inputInt = uint.Parse(input);
            double result = Math.Sqrt(inputInt);
            Console.WriteLine("The square root of {0} is {1}.", inputInt, result);
        }
        catch (FormatException fe)
        {
            Console.WriteLine("Ivalid number! " + fe.Message);
        }
        catch (OverflowException oe)
        {
            Console.WriteLine("Ivalid number! " + oe.Message);
        }
        finally
        {
            Console.WriteLine("Good bye!");
        }
    }
}
