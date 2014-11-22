using System;

// 24. Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.

class SortListOfWords
{
    static void Main()
    {
        string inputString = "beach alphabet coctail east west whiskey"; //Console.ReadLine();

        string[] words = inputString.Split(' ');

        Array.Sort(words);

        foreach (var word in words)
        {
            Console.WriteLine(word);
        }
    }
}
