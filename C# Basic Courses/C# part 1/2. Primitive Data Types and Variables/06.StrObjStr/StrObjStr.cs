using System;

class StrObjStr
{
    static void Main()
    {
        string hello = "Hello";
        string world = "World!";
        object objConcatenation = hello + " " + world;
        Console.WriteLine(objConcatenation);
        string strConcatenation = (string) objConcatenation;
        Console.WriteLine(strConcatenation);
    }
}
