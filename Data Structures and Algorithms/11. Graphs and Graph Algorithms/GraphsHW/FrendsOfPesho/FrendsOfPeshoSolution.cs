using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrendsOfPesho
{
    class FrendsOfPeshoSolution
    {
        static void Main()
        {
            // this solution gets 40 points in BgCoder
            string firstLine = Console.ReadLine();

            string[] firstLineArr = firstLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int N = int.Parse(firstLineArr[0]);  // count of hospitals + houses
            int M = int.Parse(firstLineArr[1]);  // count of streets
            int H = int.Parse(firstLineArr[2]);  // count of hospitals

            string[] hospitalsStrings = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] hospitals = new int[hospitalsStrings.Length]; // hospitals
            for (int i = 0; i < hospitalsStrings.Length; i++)
            {
                hospitals[i] = int.Parse(hospitalsStrings[i]);
            }

            int[,] graph = new int[N, N];

            for (int i = 0; i < M; i++)
            {
                string[] currentLineArr = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int[] currentInput = new int[currentLineArr.Length];
                for (int j = 0; j < currentLineArr.Length; j++)
                {
                    currentInput[j] = int.Parse(currentLineArr[j]);
                }

                graph[currentInput[0] - 1, currentInput[1] - 1] = currentInput[2];
                graph[currentInput[1] - 1, currentInput[0] - 1] = currentInput[2];
            }

            //PrintMatrix(graph);
            int minSumOfPaths = int.MaxValue;

            for (int i = 0; i < hospitals.Length; i++)
            {
                int currentHospital = hospitals[i];
                int sumOfPathsFromCurrentHospital = 0;

                for (int j = 1; j <= graph.GetLength(0); j++)
                {
                    if (hospitals.Contains(j))
                    {
                        continue;
                    }

                    int currentHouse = j;

                    sumOfPathsFromCurrentHospital += Dijkstra(graph, currentHospital - 1, currentHouse - 1);
                }

                if (minSumOfPaths > sumOfPathsFromCurrentHospital)
                {
                    minSumOfPaths = sumOfPathsFromCurrentHospital;
                }
            }

            Console.WriteLine(minSumOfPaths);
        }

        public static int Dijkstra(int[,] graph, int sourceNode, int toNode)
        {
            int[] Distance = new int[graph.GetLength(0)];
            int?[] Previous = new int?[graph.GetLength(0)];
            HashSet<int> SetOfNodes = new HashSet<int>();

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                Distance[i] = int.MaxValue;     // assign infinity for distances to all nodes; i - number of the node
                Previous[i] = null;     // ?
                SetOfNodes.Add(i);      // add all nodes to a hash set
            }

            Distance[sourceNode] = 0;     // assign 0 distance for the source node (the node from which we measure distances)

            while (SetOfNodes.Count != 0)
            {
                int minNode = int.MaxValue;

                foreach (var node in SetOfNodes)
                {
                    if (minNode > Distance[node])
                    {
                        minNode = node;
                    }
                }

                SetOfNodes.Remove(minNode);

                if (minNode == int.MaxValue)
                {
                    break;
                }

                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    if (graph[minNode, i] > 0)
                    {
                        int potentialDistance = Distance[minNode] + graph[minNode, i];
                        if (potentialDistance < Distance[i])
                        {
                            Distance[i] = potentialDistance;
                            Previous[i] = minNode;
                        }
                    }
                }
            }

            return Distance[toNode];
        }

        static void PrintMatrix(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + "  ");
                }

                Console.WriteLine();
            }
        }
    }
}
