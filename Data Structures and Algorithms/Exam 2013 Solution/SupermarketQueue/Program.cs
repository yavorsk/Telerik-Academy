using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace SupermarketQueue
{
    class Program
    {
        static BigList<string> queue = new BigList<string>();
        static StringBuilder result = new StringBuilder();
        static Bag<string> names = new Bag<string>();

        static void Main()
        {
            string inputLine = Console.ReadLine();

            while (inputLine != "End")
            {
                string[] commandInput = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                switch (commandInput[0])
                {
                    case "Append": Append(commandInput[1]); break;
                    case "Insert": Insert(int.Parse(commandInput[1]), commandInput[2]); break;
                    case "Find": Find(commandInput[1]); break;
                    case "Serve": Serve(int.Parse(commandInput[1])); break;
                }

                inputLine = Console.ReadLine();
            }

            Console.Write(result.ToString());
        }

        private static void Serve(int count)
        {
            if (count > queue.Count)
            {
                result.AppendLine("Error");
            }
            else
            {
                List<string> toServe = queue.Range(0, count).ToList();
                result.AppendLine(string.Join(" ", toServe));
                queue.RemoveRange(0, count);
                names.RemoveMany(toServe);
            }
        }

        private static void Find(string name)
        {
            int personsWithName = names.NumberOfCopies(name);
            result.AppendLine(personsWithName.ToString());
        }

        private static void Insert(int position, string name)
        {
            if (position < 0 || position > queue.Count)
            {
                result.AppendLine("Error");
            }
            else
            {
                if (position == queue.Count)
                {
                    queue.Add(name);
                }
                else
                {
                    queue.Insert(position, name);
                }

                names.Add(name);
                result.AppendLine("OK");
            }
        }

        private static void Append(string name)
        {
            queue.Add(name);
            names.Add(name);
            result.AppendLine("OK");
        }
    }
}
