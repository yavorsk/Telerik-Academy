//12. Write a program that creates an array containing all letters from the alphabet (A-Z). 
//Read a word from the console and print the index of each of its letters in the array.
using System;

class WordIndexes
{
    static void Main()
    {
        char[] alphabet = new char[26] {'A', 'B', 'C', 'D', 'E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T', 'U','V','W','X','Y','Z' };
        Console.Write("Please enter a word with capital letters: ");
        char[] word = Console.ReadLine().ToCharArray();

        for (int i = 0; i < word.Length; i++)
        {
            int startIndex = 0;
            int endIndex = alphabet.Length - 1;
            while (startIndex <= endIndex)
            {
                int middleIndex = (startIndex + endIndex) / 2;
                if (alphabet[middleIndex] == word[i])
                {
                    Console.WriteLine("The index of letter {0} is {1}.", word[i], middleIndex);
                    break;
                }
                else if (alphabet[middleIndex] > word[i])
                {
                    endIndex = middleIndex-1;
                }
                else if (alphabet[middleIndex] < word[i])
                {
                    startIndex = middleIndex+1;
                }                         
            }
        }
    }
}
