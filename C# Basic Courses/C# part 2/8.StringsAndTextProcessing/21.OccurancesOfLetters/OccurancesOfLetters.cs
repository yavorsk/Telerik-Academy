using System;

// 21. Write a program that reads a string from the console and prints all different letters in the string 
// along with information how many times each letter is found. 

class OccurancesOfLetters
{
    static void Main()
    {
        string inputString = Console.ReadLine();

        char[] alphabet = new char[] {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        int[] lettersCount = new int[26];

        for (int i = 0; i < inputString.Length; i++)
        {
            if (Char.IsLetter(inputString[i]))
            {
                int indexInAlphabet = Array.IndexOf(alphabet, inputString[i]);
                lettersCount[indexInAlphabet]++;
            }
        }

        for (int i = 0; i < alphabet.Length; i++)
        {
            if (lettersCount[i] > 0)
            {
                Console.WriteLine(alphabet[i] + " - " + lettersCount[i]);
            }
        }
    }
}
