using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salaries
{
    class Program
    {
        static void Main()
        {
            int numberOfEmployees = int.Parse(Console.ReadLine());

            List<Node> graph = new List<Node>();

            for (int i = 0; i < numberOfEmployees; i++)
            {
                string currentLine = Console.ReadLine();

                Node currentNode = new Node();
                currentNode.NodeInitialIndex = i;
                for (int j = 0; j < currentLine.Length; j++)
                {
                    if (currentLine[j] == 'Y')
                    {
                        currentNode.IndexesOfEmps.Add(j);
                        currentNode.CountOfIncomingConnections++;
                    }
                }

                graph.Add(currentNode);
            }

            foreach (var node in graph)
            {
                foreach (var index in node.IndexesOfEmps)
                {
                    Node currentEmployeeNode = graph[index];

                    node.DirectEmployees.Add(currentEmployeeNode);
                    currentEmployeeNode.Connections.Add(new Connection(node));
                }
            }

            var sortedGraph = ToplogicalSort(graph);

            //foreach (var node in sorted)
            //{
            //    Console.WriteLine(node.NodeInitialIndex+1);
            //}

            long salarySum = 0;

            foreach (var node in sortedGraph)
            {
                if (node.DirectEmployees.Count == 0)
                {
                    node.Salary = 1;
                }
                else
                {
                    foreach (var empNode in node.DirectEmployees)
                    {
                        node.Salary += empNode.Salary;
                    }
                }

                salarySum += node.Salary;
            }

            Console.WriteLine(salarySum);
        }

        static List<Node> ToplogicalSort(List<Node> graph)
        {
            List<Node> sortedList = new List<Node>();

            List<Node> nodesWithNoIncomingConnections = graph.Where(n => n.DirectEmployees.Count == 0).ToList();

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

    //public class Connection
    //{
    //    public Connection(Node node)
    //    {
    //        this.Node = node;
    //    }

    //    public Node Node { get; set; }
    //}

    //public class Node
    //{
    //    public List<int> IndexesOfEmps { get; set; }

    //    public List<Node> DirectEmployees { get; set; }

    //    public List<Connection> Connections { get; set; }

    //    public Node()
    //    {
    //        this.IndexesOfEmps = new List<int>();
    //        this.DirectEmployees = new List<Node>();
    //        this.Connections = new List<Connection>();
    //        this.CountOfIncomingConnections = 0;
    //    }

    //    public long Salary { get; set; }
    //    public int NodeInitialIndex { get; set; }
    //    public int CountOfIncomingConnections { get; set; }
    //}

}
