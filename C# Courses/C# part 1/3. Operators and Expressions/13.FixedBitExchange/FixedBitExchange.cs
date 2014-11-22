using System;

class FixedBitExchange
{
    static void Main()
    {
        Console.Write("Please enter random int number: ");
        int num = int.Parse(Console.ReadLine());
        int bit3 = ((num >> 3) & 1) == 1 ? 1 : 0;   //gets value of bit 3;
        int bit4 = ((num >> 4) & 1) == 1 ? 1 : 0;   //gets value of bit 4;
        int bit5 = ((num >> 5) & 1) == 1 ? 1 : 0;   //gets value of bit 5;
        int bit24 = ((num >> 24) & 1) == 1 ? 1 : 0; //gets value of bit 24;
        int bit25 = ((num >> 25) & 1) == 1 ? 1 : 0; //gets value of bit 25;
        int bit26 = ((num >> 26) & 1) == 1 ? 1 : 0; //gets value of bit 26;

        num = bit3 == 1 ? num | (bit3 << 24) : num & (~(1 << 24));  //replaces the value of bit 24 with the value of bit 3;
        num = bit4 == 1 ? num | (bit4 << 25) : num & (~(1 << 25));  //replaces the value of bit 25 with the value of bit 4;
        num = bit5 == 1 ? num | (bit5 << 26) : num & (~(1 << 26));  //replaces the value of bit 26 with the value of bit 5;
        num = bit24 == 1 ? num | (bit24 << 3) : num & (~(1 << 3));  //replaces the value of bit 3 with the value of bit 24;
        num = bit25 == 1 ? num | (bit25 << 4) : num & (~(1 << 4));  //replaces the value of bit 4 with the value of bit 25;
        num = bit26 == 1 ? num | (bit26 << 5) : num & (~(1 << 5));  //replaces the value of bit 5 with the value of bit 26;

        Console.WriteLine(num);
    }
}
