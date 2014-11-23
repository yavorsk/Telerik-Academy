using System;

//1.Write a program that reads a string, reverses it and prints the result at the console.
// Example: "sample"  "elpmas".

class ReverseAString
{
    static void Main()
    {
        string text = "sample text";
        string reversedText = ReverseText(text);
        Console.WriteLine(reversedText);
    }

    static string ReverseText(string inputText)
    {
        string result = string.Empty;
        int countOfChars = inputText.Length;

        for (int i = countOfChars - 1; i >=0; i--)
        {
            result += inputText[i];
        }

        return result;
    }
}
