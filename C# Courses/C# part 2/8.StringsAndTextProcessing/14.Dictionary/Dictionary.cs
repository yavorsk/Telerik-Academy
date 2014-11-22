using System;

// 14. A dictionary is stored as a sequence of text lines containing words and their explanations. 
// Write a program that enters a word and translates it by using the dictionary. Sample dictionary:
//  .NET – platform for applications from Microsoft
//  CLR – managed execution environment for .NET
//  namespace – hierarchical organization of classes


class Dictionary
{
    static void Main()
    {
        string dictionary = ".NET – platform for applications from Microsoft\nCLR – managed execution environment for .NET\nnamespace – hierarchical organization of classes ";

        string wordTosearch = Console.ReadLine();

        try
        {
            Console.WriteLine(DefinitionOf(wordTosearch, dictionary));
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("There is no such word int the dictionary!");
        }
    }

    static string DefinitionOf(string word, string dictionary)
    {
        string[] dictArray = dictionary.Split('\n');

        string definition = string.Empty;
        bool foundDefinition = false;

        for (int i = 0; i < dictArray.Length; i++)
        {
            if (dictArray[i].IndexOf(word)==0)
            {
                definition = dictArray[i].Substring(word.Length + 3, dictArray[i].Length - word.Length - 3);
                foundDefinition = true;
                break;
            }
        }
        if (!foundDefinition)
        {
            throw new ArgumentOutOfRangeException();
        }
        return definition;
    }
}
