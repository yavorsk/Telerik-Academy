using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourses
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, SortedSet<string>> dict = new SortedDictionary<string, SortedSet<string>>();

            string filePath = @"..\..\Students.txt";

            StreamReader reader = new StreamReader(filePath);

            using (reader)
            {
                string currentLine = reader.ReadLine();

                while (currentLine != null)
                {
                    string[] splittedLine = currentLine.Split('|');

                    string studentName = splittedLine[0].Trim() + " " + splittedLine[1].Trim();
                    string course = splittedLine[2].Trim();

                    if (!dict.ContainsKey(course))
                    {
                        dict[course] = new SortedSet<string>();
                    }

                    dict[course].Add(studentName);

                    currentLine = reader.ReadLine();
                }

                foreach (var course in dict.Keys)
                {
                    Console.Write("{0}: ", course);
                    Console.Write(string.Join(", ", dict[course]));
                    Console.WriteLine();
                }
            }
        }
    }
}
