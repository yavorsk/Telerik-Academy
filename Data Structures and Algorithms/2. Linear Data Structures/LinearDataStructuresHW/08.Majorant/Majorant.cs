using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Majorant
{
    // 8* The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times. 
    // Write a program to find the majorant of given array (if exists). Example:
    // {2, 2, 3, 3, 2, 3, 4, 3, 3}  3

    static void Main()
    {
        int[] arr = new int[] { 3, 2, 3, 2, 3, 3, 4, 3, 3 };

        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < arr.Length; i++)
        {
            int currentElement = arr[i];

            if (stack.Count == 0)
            {
                stack.Push(currentElement);
            }
            else
            {
                if (stack.Peek() == currentElement)
                {
                    stack.Push(currentElement);
                }
                else
                {
                    stack.Pop();
                }
            }
        }

        

        if (stack.Count == 0)
        {
            Console.WriteLine("There is no majorant number.");
        }
        else
        {
            int mostFrequent = stack.Peek();
            int countOfMostFrequent = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == mostFrequent)
                {
                    countOfMostFrequent++;
                }
            }

            if (countOfMostFrequent > arr.Length / 2 + 1)
            {
                Console.WriteLine("The majorant number is {0}", mostFrequent);
            }
            else
            {
                Console.WriteLine("There is no majorant number.");
            }
        }
    }
}
