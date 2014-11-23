using System;

// 8. Write a program that extracts from a given text all sentences containing given word.
// Example: The word is "in". The text is:
//          We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. 
//          So we are drinking all the day. We will move out of it in 5 days.
// The expected result is:
//          We are living in a yellow submarine.
//          We will move out of it in 5 days.
// Consider that the sentences are separated by "." and the words – by non-letter symbols.

class ExtractSentances
{
    static void Main()
    {
        string inputText = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        string word = "submarine";

        string[] sentances = inputText.Split(new char[] {'.'}, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < sentances.Length; i++)
        {
            sentances[i] = sentances[i].Trim() + ".";

            int index = 0;
            string wordSeparators = " .,!?-()";

            while (index < sentances[i].Length)
            {
                index = sentances[i].ToLower().IndexOf(word, index);
                if (index == -1)
                {
                    break;
                }
                if (((index == 0) || wordSeparators.Contains(sentances[i][index - 1].ToString())) &&
                    ((index == sentances[i].Length - 1) || wordSeparators.Contains(sentances[i][index + word.Length].ToString())))
                {
                    Console.WriteLine(sentances[i]);
                    break;
                }
                index += word.Length;
            }            
        }
    }
}
