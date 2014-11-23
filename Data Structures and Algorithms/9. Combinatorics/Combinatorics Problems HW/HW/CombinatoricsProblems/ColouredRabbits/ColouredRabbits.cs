using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColouredRabbits
{
    class ColouredRabbits
    {
        static void Main()
        {
            int numberOfAskedRabbits = int.Parse(Console.ReadLine());

            int[] answers = new int[numberOfAskedRabbits];

            for (int i = 0; i < numberOfAskedRabbits; i++)
            {
                int currentAnswer = int.Parse(Console.ReadLine());
                answers[i] = currentAnswer;
            }

            var differentAnswers = new Dictionary<int, int>();

            foreach (var answer in answers)
            {
                if (differentAnswers.ContainsKey(answer))
                {
                    differentAnswers[answer]++;
                }
                else
                {
                    differentAnswers.Add(answer, 1);
                }
            }

            var minSumOfRabbits = 0;

            foreach (var pair in differentAnswers)
            {
                if (pair.Key + 1 < pair.Value )
                {
                    if (pair.Value % (pair.Key + 1) == 0)
                    {
                        minSumOfRabbits+= (pair.Key + 1) * (pair.Value / (pair.Key + 1));
                    }
                    else
                    {
                        minSumOfRabbits += (pair.Key + 1) * (pair.Value / (pair.Key + 1) + 1);
                    }
                }
                else
                {
                    minSumOfRabbits += pair.Key + 1;
                }
            }

            Console.WriteLine(minSumOfRabbits);
        }
    }
}
