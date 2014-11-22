using System;

class Program
{
    static void Main()
    {
        char first =  Convert.ToChar(Console.ReadLine());
        char second = Convert.ToChar(Console.ReadLine());
        int indFirst = (int)first - 65;
        int indSecond = (int)second - 65;

        int indThird = (indFirst + 1 + indSecond + 1 <= 26) ? indFirst + 1 + indSecond : (((indFirst + 1 + indSecond + 1) % 26) - 1);
        //Console.WriteLine(indFirst);
        //Console.WriteLine(indSecond);
        int l = int.Parse(Console.ReadLine());

        char[] codes = new char[26] {'A', 'B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};
        //int a = (int) first;
        //int b = (int)'B';
        //Console.WriteLine(a);
        //Console.WriteLine(b);

        // read first second number from members from the console
        // read number l from the console
        // array of chars
        // get input chars indexs ofrom our array
        // callculate next member of the sequence
        // draw on the console
        Console.WriteLine(codes[indFirst]);
        if (l>1)
        {
            Console.WriteLine("{0}{1}", codes[indSecond], codes[indThird]);
            if (l>2)
            {
                int line = 3;
                while (line <= l)
                {
                    indSecond = (indThird + 1 + indSecond + 1 <= 26) ? indThird + 1 + indSecond : (((indThird + 1 + indSecond + 1) % 26) - 1);
                    indThird = (indThird + 1 + indSecond + 1 <= 26) ? indThird + 1 + indSecond : (((indThird + 1 + indSecond + 1) % 26) - 1);
                    Console.Write(codes[indSecond]);
                    Console.WriteLine(codes[indThird].ToString().PadLeft(line - 1));
                    line++;
                }                    
            }       
        }
    }
}
