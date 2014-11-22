// 4.Write a program that downloads a file from Internet (e.g. http://www.devbg.org/img/Logo-BASD.jpg) 
// and stores it the current directory. 
// Find in Google how to download files in C#. 
// Be sure to catch all exceptions and to free any used resources in the finally block.

using System;
using System.IO;
using System.Net;

class DownloadAFile
{
    static void Main()
    {
        string url = "http://www.devbg.org/img/Logo-BASD.jpg";

        WebClient download = new WebClient();
        string downloadPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\logo.jpg";

        try
        {
            download.DownloadFile(url, downloadPath);
        }
        catch (WebException we)
        {
            Console.WriteLine("Invalid address or an error occured while downloading data! " + we.Message);
        }
        finally
        {
            download.Dispose();
        }
    }
}
