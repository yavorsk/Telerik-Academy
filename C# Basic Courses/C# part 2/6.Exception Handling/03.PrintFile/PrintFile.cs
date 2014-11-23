// Write a program that enters file name along with its full file path (e.g. C:\WINDOWS\win.ini), 
// reads its contents and prints it on the console. 
// Find in MSDN how to use System.IO.File.ReadAllText(…). 
// Be sure to catch all possible exceptions and print user-friendly error messages.

using System;
using System.IO;

class PrintFile
{
    static void Main()
    {
        try
        {
            string path = "C:\\WINDOWS\\win.ini";
            Console.WriteLine(File.ReadAllText(path));
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine("Invalid path! " + ae.Message);
        }
        catch (PathTooLongException ptle)
        {
            Console.WriteLine("Path or file name too long! " + ptle.Message);
        }
        catch (DirectoryNotFoundException dtfe)
        {
            Console.WriteLine("Invalid path! " + dtfe.Message);
        }
        catch (UnauthorizedAccessException uae)
        {
            Console.WriteLine("Invalid path! " + uae.Message);
        }
        catch (FileNotFoundException fnfe)
        {
            Console.WriteLine("File not found! " + fnfe.Message);
        }
        catch (NotSupportedException nse)
        {
            Console.WriteLine("Invalid path! " + nse.Message);
        }
    }
}
