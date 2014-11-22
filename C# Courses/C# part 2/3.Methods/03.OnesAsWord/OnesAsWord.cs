//Write a method GetMax() with two parameters that returns the bigger of two integers. 
//Write a program that reads 3 integers from the console and prints the biggest of them using the method GetMax().
using System;

class OnesAsWord
{
    static string PrintOnes(int num)
    {
        int ones = num % 10;
        switch (ones)
        {
            case 0: return "zero";
            case 1: return "one";
            case 2: return "two"; 
            case 3: return "three"; 
            case 4: return "four"; 
            case 5: return "five"; 
            case 6: return "six"; 
            case 7: return "seven"; 
            case 8: return "eight"; 
            case 9: return "nine";
            default: return "";
        }
    }
    static void Main()
    {
        int input = int.Parse(Console.ReadLine());
        Console.WriteLine(PrintOnes(input));
    }
}
