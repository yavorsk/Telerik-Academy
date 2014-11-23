using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 2. Write a program that reads N integers from the console and reverses them using a stack. 
// Use the Stack<int> class.

class ReverseNumsWithStack
{
    static void Main()
    {

        Console.WriteLine("Enter number of integers N: ");
        int n = int.Parse(Console.ReadLine());

        Stack<int> numbers = new Stack<int>();

        Console.WriteLine("Enter numbers:");

        for (int i = 0; i < n; i++)
        {
            int currentNum = int.Parse(Console.ReadLine());
            numbers.Push(currentNum);
        }

        Console.WriteLine("Reversed sequence:");

        while (numbers.Count > 0)
        {
            Console.WriteLine(numbers.Pop());
        }
    }
}
