using System;

class SuitableDataTypes
{
    static void Main()
    {
        //For exercise 1:
        ushort var1 = 52130;
        sbyte var2 = -115;
        uint var3 = 4825932;
        byte var4 = 97;
        short var5 = -10000;
        Console.WriteLine("A suitable data type for the value {0} is {1}.", var1, var1.GetTypeCode());
        Console.WriteLine("A suitable data type for the value {0} is {1}.", var2, var2.GetTypeCode());
        Console.WriteLine("A suitable data type for the value {0} is {1}.", var3, var3.GetTypeCode());
        Console.WriteLine("A suitable data type for the value {0} is {1}.", var4, var4.GetTypeCode());
        Console.WriteLine("A suitable data type for the value {0} is {1}.", var5, var5.GetTypeCode());

        //For exercise 2:
        double var6 = 34.567839023;
        float var7 = 12.345f;
        double var8 = 8923.1234857;
        float var9 = 3456.091f;
        Console.WriteLine("A suitable data type for the value {0} is {1}.", var6, var6.GetTypeCode());
        Console.WriteLine("A suitable data type for the value {0} is {1}.", var7, var7.GetTypeCode());
        Console.WriteLine("A suitable data type for the value {0} is {1}.", var8, var8.GetTypeCode());
        Console.WriteLine("A suitable data type for the value {0} is {1}.", var9, var9.GetTypeCode());
    }
}
