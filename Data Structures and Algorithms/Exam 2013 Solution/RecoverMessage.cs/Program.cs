using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoverMessage.cs
{
    class Program
    {
        static void Main()
        {
            int countOfMessages = int.Parse(Console.ReadLine());

            List<Node> graph = new List<Node>();
            List<char> listOfUsedValues = new List<char>();

            for (int i = 0; i < countOfMessages; i++)
            {
                string currentMessage = Console.ReadLine();

                if (!listOfUsedValues.Contains(currentMessage[0]))
                {
                    graph.Add(new Node(currentMessage[0]));
                    listOfUsedValues.Add(currentMessage[0]);
                }

                for (int j = 1; j < currentMessage.Length; j++)
                {
                    if (!listOfUsedValues.Contains(currentMessage[j]))
                    {
                        graph.Add(new Node(currentMessage[j]));
                        listOfUsedValues.Add(currentMessage[j]);
                    }

                    var currenNode = graph.First(n => n.Value == currentMessage[j]);
                    var previousNode = graph.First(n => n.Value == currentMessage[j-1]);

                    previousNode.Connections.Add(new Connection(currenNode));
                    currenNode.IncommingConnections.Add(previousNode);
                    currenNode.CountOfIncomingConnections++;
                }
            }

            var sorted = ToplogicalSort(graph);

            string result = "";

            for (int i = 0; i < sorted.Count - 1; i++)
            {
                result += sorted[i].Value;
            }

            result += sorted.Last().Value;

            Console.WriteLine(result);
        }

        static List<Node> ToplogicalSort(List<Node> graph)
        {
            List<Node> sortedList = new List<Node>();

            List<Node> nodesWithNoIncomingConnections = graph.Where(n => n.CountOfIncomingConnections == 0).ToList();

            while (nodesWithNoIncomingConnections.Count > 0)
            {
                var currentNode = nodesWithNoIncomingConnections[0];

                nodesWithNoIncomingConnections.Remove(currentNode);
                sortedList.Add(currentNode);

                foreach (var connection in currentNode.Connections)
                {
                    connection.Node.CountOfIncomingConnections--;

                    if (connection.Node.CountOfIncomingConnections == 0)
                    {
                        nodesWithNoIncomingConnections.Add(connection.Node);
                    }
                }
            }

            return sortedList;
        }
    }

    public class Node
    {
        public HashSet<Node> IncommingConnections { get; set; }

        public HashSet<Connection> Connections { get; set; }

        public Node(char value)
        {
            this.Value = value;
            this.IncommingConnections = new HashSet<Node>();
            this.Connections = new HashSet<Connection>();
            this.CountOfIncomingConnections = 0;
        }

        public char Value { get; set; }
        public int NodeInitialIndex { get; set; }
        public int CountOfIncomingConnections { get; set; }
    }

    public class Connection
    {
        public Connection(Node node)
        {
            this.Node = node;
        }

        public Node Node { get; set; }
    }
}
