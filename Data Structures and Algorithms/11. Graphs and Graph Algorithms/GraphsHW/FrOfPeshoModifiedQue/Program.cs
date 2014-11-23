using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendsOfPeshoPriorityQ
{
    class Program
    {
        // this solution gets 90 points in BgCoder

        static void Main()
        {
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

            var graph = new Dictionary<Node, List<Connection>>();

            for (int i = 1; i <= N; i++)
            {
                graph.Add(new Node(i), new List<Connection>());
            }

            for (int i = 0; i < M; i++)
            {
                string[] currentLineArr = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int[] currentInput = new int[currentLineArr.Length];
                for (int j = 0; j < currentLineArr.Length; j++)
                {
                    currentInput[j] = int.Parse(currentLineArr[j]);
                }

                var fromNode = graph.Keys.First(n => n.Id == currentInput[0]);
                var toNode = graph.Keys.First(n => n.Id == currentInput[1]);

                graph[fromNode].Add(new Connection(toNode, currentInput[2]));
                graph[toNode].Add(new Connection(fromNode, currentInput[2]));
            }

            int minSumOfPaths = int.MaxValue;

            for (int i = 0; i < hospitals.Length; i++)
            {
                var currentHospital = graph.Keys.First(n => n.Id == hospitals[i]);

                DijkstraAlgorithm(graph, currentHospital);

                double sumOfPathsFromCurrentHospital = 0;

                foreach (var node in graph.Keys)
                {
                    if (hospitals.Contains(node.Id))
                    {
                        continue;
                    }

                    sumOfPathsFromCurrentHospital += node.DijkstraDistance;
                }

                if (minSumOfPaths > (int)sumOfPathsFromCurrentHospital)
                {
                    minSumOfPaths = (int)sumOfPathsFromCurrentHospital;
                }
            }

            Console.WriteLine(minSumOfPaths);
        }

        public static void DijkstraAlgorithm(Dictionary<Node, List<Connection>> graph, Node source)
        {
            var queue = new PriorityQueue<Node>();

            foreach (var node in graph)
            {
                node.Key.DijkstraDistance = double.PositiveInfinity;
            }

            source.DijkstraDistance = 0.0d;
            queue.Enqueue(source);

            while (queue.Count != 0)
            {
                var currentNode = queue.Dequeue();

                if (double.IsPositiveInfinity(currentNode.DijkstraDistance))
                {
                    break;
                }

                foreach (var neighbor in graph[currentNode])
                {
                    var potDistance = currentNode.DijkstraDistance + neighbor.Distance;
                    if (potDistance < neighbor.Node.DijkstraDistance)
                    {
                        neighbor.Node.DijkstraDistance = potDistance;
                        if (!queue.Contains(neighbor.Node))
                        {
                            queue.Enqueue(neighbor.Node);
                        }
                    }
                }
            }
        }
    }

    public class Connection
    {
        public Connection(Node node, double distance)
        {
            this.Node = node;
            this.Distance = distance;
        }

        public Node Node { get; set; }

        public double Distance { get; set; }
    }

    public class Node : IComparable
    {
        public Node(int id)
        {
            this.Id = id;
        }

        public int Id { get; private set; }

        public double DijkstraDistance { get; set; }

        public int CompareTo(object obj)
        {
            if (!(obj is Node))
            {
                return -1;
            }

            return this.DijkstraDistance.CompareTo((obj as Node).DijkstraDistance);
        }
    }

    public class PriorityQueue<T> where T : IComparable
    {
        private T[] heap;
        private int index;

        public PriorityQueue()
        {
            this.heap = new T[16];
            this.index = 1;
        }

        public int Count
        {
            get
            {
                return this.index - 1;
            }
        }

        public bool Contains(T element)
        {
            return heap.Contains(element);
        }

        public void Enqueue(T element)
        {
            if (this.index >= this.heap.Length)
            {
                this.IncreaseArray();
            }

            this.heap[this.index] = element;

            int childIndex = this.index;
            int parentIndex = childIndex / 2;
            this.index++;

            while (parentIndex >= 1 && this.heap[childIndex].CompareTo(this.heap[parentIndex]) < 0)
            {
                T swapValue = this.heap[parentIndex];
                this.heap[parentIndex] = this.heap[childIndex];
                this.heap[childIndex] = swapValue;

                childIndex = parentIndex;
                parentIndex = childIndex / 2;
            }
        }

        public T Dequeue()
        {
            T result = this.heap[1];

            this.heap[1] = this.heap[this.Count];
            this.index--;

            int rootIndex = 1;

            while (true)
            {
                int leftChildIndex = rootIndex * 2;
                int rightChildIndex = (rootIndex * 2) + 1;

                if (leftChildIndex > this.index)
                {
                    break;
                }

                int minChild;
                if (rightChildIndex > this.index)
                {
                    minChild = leftChildIndex;
                }
                else
                {
                    if (this.heap[leftChildIndex].CompareTo(this.heap[rightChildIndex]) < 0)
                    {
                        minChild = leftChildIndex;
                    }
                    else
                    {
                        minChild = rightChildIndex;
                    }
                }

                if (this.heap[minChild].CompareTo(this.heap[rootIndex]) < 0)
                {
                    T swapValue = this.heap[rootIndex];
                    this.heap[rootIndex] = this.heap[minChild];
                    this.heap[minChild] = swapValue;

                    rootIndex = minChild;
                }
                else
                {
                    break;
                }
            }

            return result;
        }

        public T Peek()
        {
            return this.heap[1];
        }

        private void IncreaseArray()
        {
            var copiedHeap = new T[this.heap.Length * 2];

            for (int i = 0; i < this.heap.Length; i++)
            {
                copiedHeap[i] = this.heap[i];
            }

            this.heap = copiedHeap;
        }
    }
}
