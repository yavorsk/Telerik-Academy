//5.You are given an array of strings. 
//Write a method that sorts the array by the length of its elements (the number of characters composing them).

using System;

class SortStrings
{
    static void StringSort(string[] strArr)
    {
        int[] wordLengths = new int[strArr.Length];
        for (int i = 0; i < strArr.Length; i++)
        {
            wordLengths[i] = strArr[i].Length;
        }
        Array.Sort(wordLengths,strArr);
    }
    static void Main()
    {
        string[] arr = { "addsf", "nhh", "pp", "eqrjjg", "rukfghk", "yeerherth", "ht", "t", "werewrg", "", "kuyr" };
        StringSort(arr);

        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine(arr[i]);
        }
    }
}
