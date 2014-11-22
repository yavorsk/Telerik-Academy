//6.You are given a sequence of positive integer values written into a string, separated by spaces. 
// Write a function that reads these values from given string and calculates their sum. Example:
//		string = "43 68 9 23 318"  result = 461

using System;

class SumIntsInString
{
    static int SumOfIntsInString(string strInput)
    {
        string[] strArr = strInput.Split(' ');
        int resultSum = 0;

        for (int i = 0; i < strArr.Length; i++)
        {
            resultSum += int.Parse(strArr[i]);
        }

        return resultSum;
    }

    static void Main()
    {
        string input = "43 68 9 23 318";

        Console.WriteLine(SumOfIntsInString(input));
    }
}
