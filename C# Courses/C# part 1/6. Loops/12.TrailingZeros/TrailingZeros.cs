//  Write a program that calculates for given N how many trailing zeros present at the end of the number N!. Examples:
//	N = 10  N! = 3628800  2
//	N = 20  N! = 2432902008176640000  4
//	Does your program work for N = 50 000?

using System;

class TrailingZeros
{
    static void Main()
    {
        Console.Write("Please enter positive integer: ");
        int n = int.Parse(Console.ReadLine());
        int power = 1;
        int countOfZeros = 0;
        while (Math.Pow(5,power) < n)
        {
            countOfZeros += n / ((int)Math.Pow(5, power));
            power++;
        }
        Console.WriteLine(countOfZeros);
    }
}
