using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.CountWordsFromFile
{
    // 3. Write a program that counts how many times each word from given text file words.txt appears in it.
    // The character casing differences should be ignored.
    // The result words should be ordered by their number of occurrences in the text. Example:
    //    This is the TEXT. Text, text, text – THIS TEXT! Is this the text?
    // is  2
    // the  2
    // this  3
    // text  6

    class CountWordsFromFile
    {
        static IDictionary<string, int> resultDict = new Dictionary<string, int>();

        static void Main()
        {
            var filePath = @"..\..\txtFile.txt";

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    ProccessLine(line);

                    line = reader.ReadLine();
                }
            }
            
            foreach (var pair in resultDict.OrderBy(x => x.Value))
            {
                Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
            }
        }

        private static void ProccessLine(string line)
        {
            var words = line.Split(new char[] { ' ', ',', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words)
            {
                var wordLower = word.ToLower();

                if (resultDict.ContainsKey(wordLower))
                {
                    resultDict[wordLower]++;
                }
                else
                {
                    resultDict[wordLower] = 1;
                }
            }
        }
    }
}
