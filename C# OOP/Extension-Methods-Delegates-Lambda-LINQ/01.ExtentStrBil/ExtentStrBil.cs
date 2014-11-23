using System;
using System.Linq;
using System.Text;

// 1. Implement an extension method Substring(int index, int length) for the class 
// StringBuilder that returns new StringBuilder and has the same 
// functionality as Substring in the class String.

static class ExtentStrBil
{
    public static StringBuilder SubStringBuild(this StringBuilder str, int index, int length)
    {
        if (index < 0 || index >= str.Length)
        {
            throw new ArgumentOutOfRangeException();
        }
        if (index+length >= str.Length)
        {
            throw new ArgumentOutOfRangeException();
        }

        string resultString = str.ToString().Substring(index, length);
        StringBuilder result = new StringBuilder(resultString);
        return result;
    }

    static void Main()
    {
        StringBuilder echoes = new StringBuilder("Overhead the albatross hangs motionless upon the air");

        Console.WriteLine(echoes.SubStringBuild(9,13));
    }
}
