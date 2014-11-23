using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class First50OfSeqence
{
    //  We are given the following sequence:
    //    S1 = N;
    //    S2 = S1 + 1;
    //    S3 = 2*S1 + 1;
    //    S4 = S1 + 2;
    //    S5 = S2 + 1;
    //    S6 = 2*S2 + 1;
    //    S7 = S2 + 2;
    //    ...
    //    Using the Queue<T> class write a program to print its first 50 members for given N.
    //    Example: N=2  2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...

    static void Main()
    {
        int N = 2;

        Queue<int> seq = new Queue<int>();
        seq.Enqueue(N);

        List<int> resultList = new List<int>();
        resultList.Add(N);

        while (true)
        {
            int current = seq.Dequeue();

            int s1 = current + 1;
            int s2 = 2 * current + 1;
            int s3 = current + 2;

            seq.Enqueue(s1);
            seq.Enqueue(s2);
            seq.Enqueue(s3);

            resultList.Add(s1);
            if (resultList.Count >= 50) break;

            resultList.Add(s2);
            if (resultList.Count >= 50) break;

            resultList.Add(s3);
            if (resultList.Count >= 50) break;
        }

        Console.WriteLine(string.Join(", ", resultList));
    }
}
