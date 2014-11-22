using System;

class CopyrightTriangle
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        char cr = (char)0xA9;
        Console.WriteLine(@" 
  {0} 
 {0} {0}
{0} {0} {0}
                            ", cr);
        //or: Console.WriteLine("  {0}  \n {0} {0} \n{0} {0} {0}", cr);
    }
}
