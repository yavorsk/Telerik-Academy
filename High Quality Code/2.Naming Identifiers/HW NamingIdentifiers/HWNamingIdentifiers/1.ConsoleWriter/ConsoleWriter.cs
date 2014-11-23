using System;

public class ConsoleWriter
{
    private const int MAX_COUNT = 6;

    public static void EntryMethod()
    {
        BoolWriter myBoolWriter = new BoolWriter();
        myBoolWriter.WriteBoolean(true);
    }

    internal class BoolWriter
    {
        internal void WriteBoolean(bool inputBoolean)
        {
            string inputToString = inputBoolean.ToString();
            Console.WriteLine(inputToString);
        }
    }
}