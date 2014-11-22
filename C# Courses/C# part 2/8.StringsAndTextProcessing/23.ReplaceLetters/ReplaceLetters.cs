using System;
using System.Text;

// 23. Write a program that reads a string from the console and replaces all series of consecutive identical letters with a single one. 
// Example: "aaaaabbbbbcdddeeeedssaa"  "abcdedsa".


class ReplaceLetters
{
    static void Main()
    {
        string inputString = "aaaaabbbbbcdddeeeedssaa aass"; //Console.ReadLine();

        StringBuilder input = new StringBuilder(inputString);

        for (int i = 0; i < input.Length; i++)
        {
            for (int j = i+1; j < input.Length; j++)
            {
                if (j == input.Length || input[j] != input[i])
                {
                    break;
                }
                else
                {
                    input.Remove(j, 1);
                    j--;
                }
            }
        }

        Console.WriteLine(input.ToString());
    }
}
