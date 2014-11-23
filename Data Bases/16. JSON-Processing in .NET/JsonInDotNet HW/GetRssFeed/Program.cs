using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GetRssFeed
{
    class Program
    {
        static void Main()
        {
            string rssUrl = @"http://forums.academy.telerik.com/feed/qa.rss";
            string fileName = @"..\..\qa.rss";

            //DownloadFile(rssUrl, fileName);

            XDocument doc = XDocument.Load(fileName);

            string jsonStringFromXml = JsonConvert.SerializeXNode(doc);

            Console.WriteLine(jsonStringFromXml);

            var jsonObj = JObject.Parse(jsonStringFromXml);

            var titles = jsonObj["rss"]["channel"]["item"].Select(item => item["title"]);

            // print all titles
            //foreach (var title in titles)
            //{
            //    Console.WriteLine(title);
            //}

            // Parse json to POCO
            Root rssObject = JsonConvert.DeserializeObject<Root>(jsonStringFromXml);

            //Create html

            StringBuilder htmlString = new StringBuilder();
            htmlString.AppendLine(@"<!DOCTYPE html>");
            htmlString.AppendLine("<html lang=\"en\" xmlns=\"http://www.w3.org/1999/xhtml\">");
            htmlString.AppendLine("<head>");
            htmlString.AppendLine("<title>Forum Questions</title>");
            htmlString.AppendLine("</head>");
            htmlString.AppendLine("<body>");
            htmlString.AppendLine("<ul>");

            foreach (var item in rssObject.Rss.Channel.Item)
            {
                string title = item.Title;
                string category = item.Category;
                string link = item.Link;

                htmlString.Append("<li>");
                htmlString.Append("<a href=\"" + link + "\">" + title + "</a><span> Category:" + category + "</span>");
                htmlString.Append("</li>");
                htmlString.AppendLine();
            }

            htmlString.AppendLine("</ul>");
            htmlString.AppendLine("</body>");
            htmlString.AppendLine("</html>");

            string htmlFile = "..\\..\\ForumQA.html";
            StreamWriter writer = new StreamWriter(htmlFile);

            using (writer)
            {
                writer.Write(htmlString.ToString());
            }
        }

        public static void DownloadFile(string sourceUrl, string filePath)
        {
            WebClient webClient = new WebClient();

            webClient.DownloadFile(sourceUrl, filePath);
        }
    }
}
