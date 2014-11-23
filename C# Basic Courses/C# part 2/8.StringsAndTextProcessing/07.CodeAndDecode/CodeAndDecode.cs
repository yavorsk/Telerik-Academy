using System;
using System.Text;

// 7. Write a program that encodes and decodes a string using given encryption key (cipher). 
// The key consists of a sequence of characters. 
// The encoding/decoding is done by performing XOR (exclusive or) operation over the first letter 
// of the string with the first of the key, the second – with the second, etc. 
// When the last key character is reached, the next is the first.


class CodeAndDecode
{
    static void Main()
    {
        string text = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        string cypher = "mv[qerh62(^$12";

        string encodedText = EncodeText(text, cypher);

        string decodedText = EncodeText(encodedText, cypher);

        Console.WriteLine(text);
        Console.WriteLine();
        Console.WriteLine(encodedText);
        Console.WriteLine();
        Console.WriteLine(decodedText);
    }

    static string EncodeText(string inputText, string cypher)
    {
        StringBuilder encoded = new StringBuilder();
        int cyIndex = 0;

        for (int i = 0; i < inputText.Length; i++)
        {
            encoded.Append((char)(inputText[i]^cypher[cyIndex]));
            if (cyIndex == cypher.Length - 1)
            {
                cyIndex = -1;
            }
            cyIndex++;
        }

        return encoded.ToString();
    }
}
