using System;

class GenericsTest
{
    static void Main(string[] args)
    {
        GenericList<int> arr = new GenericList<int>(2);
        arr.Add(5);
        arr.Add(2);
        arr.Add(3);
        arr.Add(22);

        arr.InsertAt(-15, 2);

        arr.RemoveAt(1);

        int temp = arr[2];

        Console.WriteLine(arr.ToString());

        arr.Clear();
    }
}