using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that reads a sequence of integers (List<int>) ending with an empty line 
//and sorts them in an increasing order.

class SortIncreasingList
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

        numbers.Sort();
        //numbers.Sort((num1, num2) => el1.CompareTo(el2));
        //List<int> orderedNums = numbers.OrderBy(nunm => num).ToList();

        Console.WriteLine("Sorted numbers:");

        Console.WriteLine(string.Join(", ", numbers));
    }
}
