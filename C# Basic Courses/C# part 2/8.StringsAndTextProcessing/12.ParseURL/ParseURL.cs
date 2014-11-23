using System;

// 12. Write a program that parses an URL address given in the format:
//          [protocol]://[server]/[resource]
//		and extracts from it the [protocol], [server] and [resource] elements. 
//      For example from the URL http://www.devbg.org/forum/index.php the following information should be extracted:
//		[protocol] = "http"
//		[server] = "www.devbg.org"
//		[resource] = "/forum/index.php"


class ParseURL
{
    static void Main()
    {
        string inputUrl = "http://www.devbg.org/forum/index.php";

        int indexDots = inputUrl.IndexOf("://");
        int indexSlash = inputUrl.IndexOf("/", indexDots + 3);
        string protocol = inputUrl.Substring(0, indexDots);
        string server = inputUrl.Substring(indexDots + 3, indexSlash - indexDots - 3);
        string resource = inputUrl.Substring(indexSlash, inputUrl.Length - indexSlash);
    }
}
