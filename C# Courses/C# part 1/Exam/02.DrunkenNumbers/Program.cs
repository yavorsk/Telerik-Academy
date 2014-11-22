using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int scoreM = 0;
        int scoreV = 0;

        for (int i = 0; i < n; i++)
        {
            int inputNum = int.Parse(Console.ReadLine());
            string numStr = inputNum.ToString();
            int digitCount = numStr.Length;
            numStr.ToCharArray();

            if (digitCount % 2 == 0)
            {
                for (int j = 0; j < numStr.Length/2; j++)
                {
                    scoreM += int.Parse(numStr[j].ToString());
                }
                for (int j = numStr.Length/2; j < numStr.Length; j++)
                {
                    scoreV += int.Parse(numStr[j].ToString());
                }
            }

            if (digitCount% 2 !=0)
            {
                for (int j = 0; j <= numStr.Length/2; j++)
                {
                    scoreM += int.Parse(numStr[j].ToString());
                }
                for (int j = numStr.Length / 2 ; j < numStr.Length; j++)
                {
                    scoreV += int.Parse(numStr[j].ToString());
                }
            }
        }
        if (scoreM>scoreV)
        {
            Console.WriteLine("M {0}", scoreM - scoreV);
        }
        else if (scoreV>scoreM)
        {
            Console.WriteLine("V {0}", scoreV - scoreM);
        }
        else if (scoreM==scoreV)
        {
            Console.WriteLine("No {0}", scoreV + scoreM);
        }
    }
}
