/* Write a program that converts a number in the range [0...999] to a text corresponding to its English pronunciation. Examples:
	0  "Zero"
	273 -> "Two hundred seventy three"
	400 -> "Four hundred"
	501 -> "Five hundred and one"
	711 -> "Seven hundred and eleven" */

using System;

class NumberToWords
{
    static void Main()
    {
        int number;
        int ones;
        int tens;
        int hundreds;
        string onesText = "";
        string tensText = "";
        string hundredsText = "";
        string space = "";

        Console.Write("Please enter a number in the range [0,999]: ");
        number = int.Parse(Console.ReadLine());
        ones = number % 10;
        tens = (number % 100) / 10;
        hundreds = number / 100;

        switch (hundreds)
        {
            case 0: hundredsText = ""; break;
            case 1: hundredsText = "one hundred"; break;
            case 2: hundredsText = "two hundred"; break;
            case 3: hundredsText = "three hundred"; break;
            case 4: hundredsText = "four hundred"; break;
            case 5: hundredsText = "five hundred"; break;
            case 6: hundredsText = "six hundred"; break;
            case 7: hundredsText = "seven hundred"; break;
            case 8: hundredsText = "eight hundred"; break;
            case 9: hundredsText = "nine hundred"; break;
        }

        if (number == 0)
        {
            onesText = "zero";
        }
        if (tens == 0 && ones != 0)
        {
            if (hundreds == 0)
            {
            tensText = "";                
            }
            else
            {
                tensText = "and";
                space = " ";
            }
            switch (ones)
            {
                case 1: onesText = "one"; break;
                case 2: onesText = "two"; break;
                case 3: onesText = "three"; break;
                case 4: onesText = "four"; break;
                case 5: onesText = "five"; break;
                case 6: onesText = "six"; break;
                case 7: onesText = "seven"; break;
                case 8: onesText = "eight"; break;
                case 9: onesText = "nine"; break;
            }
        }
        else if (tens == 1)
        {
            if (hundreds == 0)
            {
                tensText = "";
            }
            else
            {
                tensText = "and";
                space = " ";
            }
            switch (ones)
            {
                case 0: onesText = "ten"; break;
                case 1: onesText = "eleven"; break;
                case 2: onesText = "twelve"; break;
                case 3: onesText = "thirteen"; break;
                case 4: onesText = "fourteen"; break;
                case 5: onesText = "fifteen"; break;
                case 6: onesText = "sixteen"; break;
                case 7: onesText = "seventeen"; break;
                case 8: onesText = "eighteen"; break;
                case 9: onesText = "nineteen"; break;
            }
        }
        else if (tens > 1)
        {
            space = " ";
            switch (tens)
            {
                case 2: tensText = "twenty"; break;
                case 3: tensText = "thirty"; break;
                case 4: tensText = "fourty"; break;
                case 5: tensText = "fifty"; break;
                case 6: tensText = "sixty"; break;
                case 7: tensText = "seventy"; break;
                case 8: tensText = "eighty"; break;
                case 9: tensText = "ninety"; break;
            }
            switch (ones)
            {
                case 1: onesText = "one"; break;
                case 2: onesText = "two"; break;
                case 3: onesText = "three"; break;
                case 4: onesText = "four"; break;
                case 5: onesText = "five"; break;
                case 6: onesText = "six"; break;
                case 7: onesText = "seven"; break;
                case 8: onesText = "eight"; break;
                case 9: onesText = "nine"; break;
            }
        }
        Console.WriteLine("{0}{3}{1}{3}{2}", hundredsText, tensText, onesText, space);
    }
}
