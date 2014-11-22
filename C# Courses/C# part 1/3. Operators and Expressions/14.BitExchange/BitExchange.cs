using System;

class BitExchange
{
    static void Main()
    {
        Console.Write("Please enter random int number: ");
        int num = int.Parse(Console.ReadLine());
        Console.Write("Please enter bit number of the first member of the first group: ");
        int p = int.Parse(Console.ReadLine());
        Console.Write("Please enter bit number of the first member of the second group: ");
        int q = int.Parse(Console.ReadLine());
        Console.Write("Please enter the number of bits in each group: ");
        int k = int.Parse(Console.ReadLine());
        Console.WriteLine(Convert.ToString(num, 2));
        for (int i = 0; i < k; i++)
        {
            int pBit = ((num >> (p+i)) & 1) == 1 ? 1 : 0;   //gets value of bit p;
            int qBit = ((num >> (q+i)) & 1) == 1 ? 1 : 0;   //gets value of bit q;
            num = pBit == 1 ? num | (pBit << (q + i)) : num & (~(1 << (q + i)));
            num = qBit == 1 ? num | (qBit << (p + i)) : num & (~(1 << (p + i)));
        }
        Console.WriteLine(num);
        Console.WriteLine(Convert.ToString(num, 2));
    }
}
