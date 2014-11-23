using System;

class ThirdDigitCheck
{
    static void Main()
    {
        Console.Write("Please enter random int number: ");
        int num = int.Parse(Console.ReadLine());
        bool check = ((num / 100) - 7) % 10 == 0;
        Console.WriteLine("The third digit from right to left of {0} is 7? ---> {1}", num, check);
    }
}
