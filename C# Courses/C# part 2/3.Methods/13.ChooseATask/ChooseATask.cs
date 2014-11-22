//Write a program that can solve these tasks:
//Reverses the digits of a number
//Calculates the average of a sequence of integers
//Solves a linear equation a * x + b = 0
//		Create appropriate methods.
//		Provide a simple text-based menu for the user to choose which task to solve.
//		Validate the input data:
//The decimal number should be non-negative
//The sequence should not be empty
//a should not be equal to 0

using System;

class ChooseATask
{
    static void Main()
    {
        Console.WriteLine("Welcome!");
        Console.WriteLine("If you want to reverse the digits of a positive number, please enter '1';");
        Console.WriteLine("If you want to calculate the average of a sequence of integers, please enter '2';");
        Console.WriteLine("If you want to solve a linear equation, please enter '3';");
        Console.Write("What is your choise? ");

        int choise = int.Parse(Console.ReadLine());

        switch (choise)
        {
            case 1: ReveerseDigits(); break;
            case 2: CalculateAverage(); break;
            case 3: LinearEquation(); break;
            default: Console.WriteLine("Wrong input!"); break;
        }
    }

    static void LinearEquation()
    {
        double a, b;
        while (true)
        {
            Console.Write("Please enter coefficient a:");
            a = double.Parse(Console.ReadLine());
            if (a==0)
            {
                Console.WriteLine("Coefficient a should be not equal to 0!");
                continue;
            }
            else
            {
                break;
            }
        }
        Console.Write("Please enter coefficient b:");
        b = double.Parse(Console.ReadLine());

        double x = b * (-1) / a;
        Console.WriteLine("x = {0}", x);
    }

    private static void CalculateAverage()
    {
        int seqLength = 0;
        while (true)
        {
            Console.Write("Please enter number of elements in the seqence: ");
            seqLength = int.Parse(Console.ReadLine());
            if (seqLength ==0)
            {
                Console.WriteLine("The sequence should not be empty!");
                continue;                
            }
            else
            {
                break;
            }
        }
        double sum = 0;
        for (int i = 0; i < seqLength; i++)
        {
            Console.Write("Enter sequence element {0}: ", i);
            double element = double.Parse(Console.ReadLine());
            sum += element;
        }
        double average = sum / seqLength;
        Console.WriteLine("The average of the sequence is {0}.", average);
    }
  
    private static void ReveerseDigits()
    {
        decimal input = 0;
        while (true)
        {
            Console.Write("Please enter a non negative number: ");
            input = decimal.Parse(Console.ReadLine());
            if (input<0)
            {
                Console.WriteLine("The number should be non negative!");
                continue;
            }
            else
            {
                break;
            }
        }
        char[] inputChar = input.ToString().ToCharArray();
        Array.Reverse(inputChar);
        Console.WriteLine(new string (inputChar));      
    }
}
