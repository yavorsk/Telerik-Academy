﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CableCompany
{
    class Program
    {
        // just used Prim's algo from the demo . . .

        public static void Main()
        {
            var priority = new SortedSet<Edge>();
            const int numberOfNodes = 11;
            var used = new bool[numberOfNodes + 1];
            var mpdNodes = new List<Edge>();
            var edges = new List<Edge>();
            InitializeGraph(edges);

            // adding edges that connect the node 1 with all the others - 2, 3, 4
            foreach (Edge edge in edges)
            {
                if (edge.StartNode == edges[0].StartNode)
                {
                    priority.Add(edge);
                }
            }

            used[edges[0].StartNode] = true;

            FindMinimumSpanningTree(used, priority, mpdNodes, edges);

            PrintMinimumSpanningTree(mpdNodes);
        }

        private static void PrintMinimumSpanningTree(IEnumerable<Edge> mpdNodes)
        {
            foreach (Edge edge in mpdNodes)
            {
                Console.WriteLine("{0}", edge);
            }
        }

        private static void FindMinimumSpanningTree(bool[] used, SortedSet<Edge> priority, List<Edge> mpdEdges, List<Edge> edges)
        {
            while (priority.Count > 0)
            {
                Edge edge = priority.Min;
                priority.Remove(edge);

                if (!used[edge.EndNode])
                {
                    used[edge.EndNode] = true; // we "visit" this node
                    mpdEdges.Add(edge);
                    AddEdges(edge, edges, mpdEdges, priority, used);
                }
            }
        }

        private static void AddEdges(Edge edge, List<Edge> edges, List<Edge> mpd, SortedSet<Edge> priority, bool[] used)
        {
            for (int i = 0; i < edges.Count; i++)
            {
                if (!mpd.Contains(edges[i]))
                {
                    if (edge.EndNode == edges[i].StartNode && !used[edges[i].EndNode])
                    {
                        priority.Add(edges[i]);
                    }
                }
            }
        }

        private static void InitializeGraph(List<Edge> edges)
        {
            edges.Add(new Edge(1, 3, 5));
            edges.Add(new Edge(1, 2, 4));
            edges.Add(new Edge(1, 4, 9));
            edges.Add(new Edge(2, 4, 2));
            edges.Add(new Edge(3, 4, 20));
            edges.Add(new Edge(3, 5, 7));
            edges.Add(new Edge(4, 5, 8));
            edges.Add(new Edge(5, 6, 12));
            edges.Add(new Edge(5, 7, 3));
            edges.Add(new Edge(5, 8, 10));
            edges.Add(new Edge(6, 8, 5));
            edges.Add(new Edge(7, 8, 16));
            edges.Add(new Edge(2, 9, 13));
            edges.Add(new Edge(4, 9, 10));
            edges.Add(new Edge(4, 10, 16));
            edges.Add(new Edge(4, 11, 22));
            edges.Add(new Edge(6, 11, 4));
            edges.Add(new Edge(9, 10, 7));
            edges.Add(new Edge(10, 11, 10));
            edges.Add(new Edge(8, 11, 9));
        }
    }
}
