using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.TreeTasks
{
    class TreeTasks
    {
        static void Main()
        {
            var N = int.Parse(Console.ReadLine());

            var nodes = new TreeNode<int>[N];

            for (int i = 0; i < N; i++)
			{
                nodes[i] = new TreeNode<int>(i);
			}

            for (int i = 1; i < N; i++)
			{
			    string ribAsString = Console.ReadLine();
                string[] connectedNodes = ribAsString.Split(' ');

                int parentId = int.Parse(connectedNodes[0]);
                int childId = int.Parse(connectedNodes[1]);

                nodes[parentId].Children.Add(nodes[childId]);
                nodes[childId].HasParent = true;
			}

            // a). Find the root
            TreeNode<int> root = FindRoot(nodes);
            Console.WriteLine("The root of the tree is {0}.", root.Value);

            // b). Find all leafs
            List<TreeNode<int>> leafs = FindAllLafs(nodes);
            foreach (var leaf in leafs)
            {
                Console.Write("{0}, ", leaf.Value);
            }
            Console.WriteLine();

            // c). Find all middle nodes
            List<TreeNode<int>> middleNodes = FindAllMiddleNodes(nodes);
            foreach (var middleNode in middleNodes)
            {
                Console.Write("{0}, ", middleNode.Value);
            }
            Console.WriteLine();

            // d). Find the longest path in the tree
            int longestPath = FindLongestPath(FindRoot(nodes));
            Console.WriteLine("Number of levels: {0}", longestPath + 1);

            // f). Find all subtrees with given sum S of their nodes
            int searchedSum = 12;
            List<TreeNode<int>> subtrees = FIndSubtreesForGivenSum(searchedSum, nodes);
            Console.WriteLine("Searched nodes: ");
            foreach (var rootOfSubtree in subtrees)
            {
                Console.Write("{0}  ", rootOfSubtree.Value);
            }
            Console.WriteLine();
        }

        private static List<TreeNode<int>> FIndSubtreesForGivenSum(int searchedSum, TreeNode<int>[] nodes)
        {
            List<TreeNode<int>> searchedSubtrees = new List<TreeNode<int>>();

            foreach (var node in nodes)
            {
                if (SumOfNodesOfTree(node) == searchedSum)
                {
                    searchedSubtrees.Add(node);
                }
            }

            return searchedSubtrees;
        }

        private static int SumOfNodesOfTree(TreeNode<int> root)
        {
            if (root.Children.Count == null)
            {
                return root.Value;
            }

            int sum = root.Value;

            foreach (var nodes in root.Children)
            {
                sum += SumOfNodesOfTree(nodes);
            }

            return sum;
        }

        private static int FindLongestPath(TreeNode<int> root)
        {
            if (root.Children.Count == null)
            {
                return 0;
            }

            int maxPath = 0;

            foreach (var node in root.Children)
            {
                maxPath = Math.Max(maxPath, FindLongestPath(node));
            }

            return maxPath + 1;
        }

        private static List<TreeNode<int>> FindAllMiddleNodes(TreeNode<int>[] nodes)
        {
            List<TreeNode<int>> middleNodes = new List<TreeNode<int>>();

            foreach (var node in nodes)
            {
                if (node.Children.Count != 0 && node.HasParent == true)
                {
                    middleNodes.Add(node);
                }
            }

            return middleNodes;
        }

        private static List<TreeNode<int>> FindAllLafs(TreeNode<int>[] nodes)
        {
            List<TreeNode<int>> leafs = new List<TreeNode<int>>();

            foreach (var node in nodes)
            {
                if (node.Children.Count == 0)
                {
                    leafs.Add(node);
                }
            }

            return leafs;
        }

        private static TreeNode<int> FindRoot(TreeNode<int>[] nodes)
        {
            foreach (var node in nodes)
            {
                if (node.HasParent == false)
                {
                    return node;
                }
            }

            throw new ArgumentException("The tree has no root.");
        }
    }
}
