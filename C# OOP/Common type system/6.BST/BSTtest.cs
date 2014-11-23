using System;
using System.Linq;

class BSTtest
{
    static void Main()
    {
        BinarySearchTree<int> tree = new BinarySearchTree<int>();
        tree.AddNode(6);
        tree.AddNode(5);
        tree.AddNode(3);
        tree.AddNode(1);
        tree.AddNode(10);
        tree.AddNode(8);
        tree.AddNode(13);
        tree.AddNode(7);
        tree.AddNode(11);
        tree.AddNode(14);
        tree.AddNode(12);

        Console.WriteLine(tree.ToString());
        Console.WriteLine();

        tree.RemoveNode(5);

        Console.WriteLine(tree.ToString());
        Console.WriteLine();

        BinarySearchTree<int> clonedTree = tree.Clone();
        Console.WriteLine(tree.Equals(clonedTree));
        Console.WriteLine();

        tree.RemoveNode(11);

        Console.WriteLine(tree.ToString());
        Console.WriteLine();

        Console.WriteLine(tree == clonedTree);
        Console.WriteLine(tree != clonedTree);
    }
}