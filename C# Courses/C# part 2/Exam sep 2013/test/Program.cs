using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Cypher
{
    class Program
    {
        static void Main(string[] args)
        {
            string codedMessage = Console.ReadLine();
            StringBuilder codedText = new StringBuilder(codedMessage);

            int index = codedMessage.Length - 1;
            StringBuilder cypherLengthString = new StringBuilder();

            while (Char.IsDigit(codedMessage[index]))
            {
                cypherLengthString.Insert(0, codedMessage[index]);
                index--;
            }
            index++;

            int cypherLength = int.Parse(cypherLengthString.ToString());

            codedText.Remove(index, codedText.Length - index);

            for (int i = 0; i < codedText.Length; i++)
            {
                int repeatance = 0;
                if (char.IsDigit(codedText[i]))       ///!!!!!!
                {
                    repeatance = int.Parse(codedText[i].ToString());
                    string replacement = new string(codedText[i + 1], repeatance - 1);

                    codedText.Replace(codedText[i].ToString(), replacement);
                }
            }

            StringBuilder cypher = new StringBuilder();
            for (int i = 0; i < cypherLength; i++)
            {
                cypher.Insert(0, codedText[codedText.Length - 1 - i]);
            }

            codedText.Remove(codedText.Length - cypherLength, cypherLength);

            StringBuilder result = new StringBuilder();

            if (codedText.Length >= cypher.Length)
            {
                for (int i = 0; i < codedText.Length; i++)
                {
                    char character = (char)(((int)(codedText[i] - 65) ^ (int)(cypher[i % cypher.Length]) - 65) + 65);
                    result.Append(character);
                }
            }

            else
            {
                for (int i = 0; i < cypher.Length; i++)
                {
                    char character = (char)(((int)(codedText[i % codedText.Length] - 65) ^ (int)(cypher[i]) - 65) + 65);
                }
            }








            //Console.WriteLine(cypherLength);
            //Console.WriteLine(index);
            //Console.WriteLine(codedText.ToString());
            //Console.WriteLine(cypher.ToString());
            Console.WriteLine(result);

        }
    }
}
