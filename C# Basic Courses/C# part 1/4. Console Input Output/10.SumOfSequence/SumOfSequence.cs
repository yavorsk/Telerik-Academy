using System;

class SumOfSequence
{
    static void Main()
    {
        double sum = 1;
        double sumPrev = 0;
        double member = 1;
        int i = 2;
        while (Math.Round(sum, 3) != Math.Round(sumPrev, 3))
        {
                member = (1 / (double)i) * Math.Pow(-1, i);
                sum = sum + member;
                sumPrev = sum - member;
                i++;      
        }
        Console.WriteLine(Math.Round(sum, 3));      
    }
}
