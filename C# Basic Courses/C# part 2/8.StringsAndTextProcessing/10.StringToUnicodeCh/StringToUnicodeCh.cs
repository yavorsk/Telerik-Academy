﻿using System;
using System.Text;

// 10. Write a program that converts a string to a sequence of C# Unicode character literals. Use format strings. Sample input:
//      Hi!
// Expected output:
//      \u0048\u0069\u0021

class StringToUnicodeCh
{
    static void Main()
    {
        string inputText = "Hi!";

        StringBuilder unicode = new StringBuilder();

        foreach (var ch in inputText)
        {
            unicode.AppendFormat("\\u{0:X4}", (int)ch);
        }

        Console.WriteLine(unicode.ToString());
    }
}