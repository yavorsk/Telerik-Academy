using System;
using System.Collections.Generic;
using System.Linq;

// Write a program that reads from the console a sequence of positive integer numbers. 
// The sequence ends when empty line is entered. 
// Calculate and print the sum and average of the elements of the sequence. 
// Keep the sequence in List<int>.

namespace _01.AvgAndSum
{
    class AvgAndSum
    {
        static void Main()
        {
            List<int> numbers = new List<int>();

            Console.WriteLine("Enter numbers:");

            string currentLine = Console.ReadLine();

            while (currentLine.Trim() != string.Empty)
            {
                int currentNum = int.Parse(currentLine);
                numbers.Add(currentNum);

                currentLine = Console.ReadLine();
            }

            Console.WriteLine("The sum is: {0}", numbers.Sum());
            Console.WriteLine("The average of the numbers is {0}", numbers.Average());
        }
    }
}
