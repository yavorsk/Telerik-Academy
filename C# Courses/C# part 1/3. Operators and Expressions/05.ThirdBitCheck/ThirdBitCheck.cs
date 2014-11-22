using System;

class ThirdBitCheck
{
    static void Main()
    {
        Console.Write("Please enter random int number: ");
        int num = int.Parse(Console.ReadLine());
        bool check = ((num >> 3) & 1) == 1;
        if (check==true)
        {
            Console.WriteLine("The third bit from right to left of {0} is 1.", num);
        }
        else
        {
            Console.WriteLine("The third bit from right to left of {0} is 0.", num);
        }
    }
}
