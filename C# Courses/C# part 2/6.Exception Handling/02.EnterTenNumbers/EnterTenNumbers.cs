//Write a method ReadNumber(int start, int end) that enters an integer number in given range [start…end]. 
// If an invalid number or non-number text is entered, the method should throw an exception. 
// Using this method write a program that enters 10 numbers:
//			a1, a2, … a10, such that 1 < a1 < … < a10 < 100

using System;

class EnterTenNumbers
{
    public static int min = 1;

    static int ReadNumnber(int start, int end)
    {
        int number = int.Parse(Console.ReadLine());
        if (number <= start || number >= end)
        {
            throw new ArgumentOutOfRangeException();
        }
        min = number;
        return number;
    }

    static void Main()
    {
        for (int i = 0; i < 10; i++)
        {
            try
            {
                ReadNumnber(min, 100);
            }
            catch (ArgumentOutOfRangeException oor)
            {
                Console.WriteLine("Invalid number! " + oor.Message + "/nPlease enter number again");
                i--;
            }
            catch (FormatException fe)
            {
                Console.WriteLine("Invalid number! " + fe.Message + "/nPlease enter number again");
                i--;
            }
        }
    }
}
