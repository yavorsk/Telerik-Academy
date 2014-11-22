using System;
using System.Collections.Generic;


class Program
{
    static void Main()
    {
        ulong input = ulong.Parse(Console.ReadLine());

        ulong remainder = 0;
        ulong divResult = input;

        List<int> kaspNum = new List<int>();
        string[] kaspEdinici = new string[] {"A", "B", "C", "D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};
        string[] kaspDesetici = new string[] {"","a","b","c","d","e","f","g","h","i",};
        do
        {
            remainder = divResult % 256;
            divResult = divResult / 256;
            kaspNum.Add((int)remainder);
        }
        while (divResult > 0);

        kaspNum.Reverse();

        for (int i = 0; i < kaspNum.Count; i++)
        {
            int rem1 = kaspNum[i] % 26;
            int divRes = kaspNum[i] / 26;
            int rem2 = divRes % 26;
            Console.Write(kaspDesetici[rem2] + "" + kaspEdinici[rem1]);            
        }
        Console.WriteLine();
    }
}
