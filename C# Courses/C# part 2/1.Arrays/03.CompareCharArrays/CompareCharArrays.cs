//Write a program that compares two char arrays lexicographically (letter by letter).
using System;

class CompareCharArrays
{
    static void Main()
    {
        char[] cArr1 = new char[4] {'a','A','&','/'};
        char[] cArr2 = new char[4] { 'a', 'p', '&', '/' };
        bool elemetEq = false;
        bool arrayEq = true;

        for (int i = 0; i < cArr1.Length; i++)
        {
            if (cArr1[i]==cArr2[i])
            {
                elemetEq = true;
            }
            else if (cArr1[i]!=cArr2[i])
            {
                elemetEq = false;
                arrayEq = false;
            }
            Console.Write("The elements with index {0} are '{1}' and '{2}'", i, cArr1[i], cArr2[i]);
            Console.WriteLine(" Equal? --------> {0}", elemetEq);
        }
        Console.WriteLine("Arrays are Equal? --------> {0}", arrayEq);
    }
}
