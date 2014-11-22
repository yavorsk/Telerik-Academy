using System;

class EscSequences
{
    static void Main()
    {
        string quotedString = @"The ""use"" of quotations causes difficulties.";
        Console.WriteLine(quotedString);
        string escString = "The \"use\" of quotations causes difficulties.";
        Console.WriteLine(escString);
    }
}
