using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

// 6.* Define the data structure binary search tree with operations for "adding new element", "searching element" and "deleting elements". 
// It is not necessary to keep the tree balanced. Implement the standard methods from System.Object – ToString(), Equals(…), 
// GetHashCode() and the operators for comparison  == and !=. Add and implement the ICloneable interface for deep copy of the tree. 
// Remark: Use two types – structure BinarySearchTree (for the tree) and class TreeNode (for the tree elements). 
// Implement IEnumerable<T> to traverse the tree.
//
// Rescources: Nakov, Dobrinkov - Programming++Algorithms; Telerik Academy Forum

public class BinarySearchTree<T> : ICloneable, IEnumerable<TreeNode<T>>
    where T : IComparable<T>
{
    private TreeNode<T> root = null;

    public TreeNode<T> Search(T data) //search the entire tree by given key/data
    {
        return Search(this.root, data);
    }

    private TreeNode<T> Search(TreeNode<T> node, T data) //search a subtree by given subtree root node and key/data
    {
        if (data.CompareTo(node.Value) == 0)
        {
            return node;
        }
        if (data.CompareTo(node.Value) < 0)
        {
            if (node.LeftChild != null)
            {
                return Search(node.LeftChild, data);
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }
        else
        {
            if (node.RightChild != null)
            {
                return Search(node.RightChild, data);
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }
    }

    public void AddNode(T newNodeValue)
    {
        TreeNode<T> newNode = new TreeNode<T>(newNodeValue,null, null, null);
        InsertNode(newNode);
    }

    private void InsertNode(TreeNode<T> newNode) // Insert Node
    {
        TreeNode<T> currentNode = this.root;
        TreeNode<T> parentNode = null;

        while (currentNode != null)
        {
            parentNode = currentNode;

            if (newNode.Value.CompareTo(currentNode.Value) < 0)
            {
                currentNode = currentNode.LeftChild;
            }
            else if (newNode.Value.CompareTo(currentNode.Value) > 0)
            {
                currentNode = currentNode.RightChild;
            }
            else if (newNode.Value.CompareTo(currentNode.Value) == 0)
            {
                parentNode = currentNode.Parent;
                break;
            }
        }

        if (currentNode != null)
        {
        }
        else if (parentNode == null)
        {
            this.root = newNode;
        }
        else if (newNode.Value.CompareTo(parentNode.Value) < 0)
        {
            parentNode.LeftChild = newNode;
            newNode.Parent = parentNode;
        }
        else if (newNode.Value.CompareTo(parentNode.Value) > 0)
        {
            parentNode.RightChild = newNode;
            newNode.Parent = parentNode;
        }
    }

    public void RemoveNode(T key)
    {
        try
        {
            TreeNode<T> nodeToRemove = Search(this.root, key);

            if (nodeToRemove.RightChild != null && nodeToRemove.LeftChild != null)
            {
                TreeNode<T> nodeToReplace = nodeToRemove.RightChild;

                while (nodeToReplace.LeftChild != null)
                {
                    nodeToReplace = nodeToReplace.LeftChild;
                }

                nodeToRemove.Value = nodeToReplace.Value;
                nodeToRemove = nodeToReplace;
            }

            if (nodeToRemove.RightChild == null && nodeToRemove.LeftChild == null)
            {
                if (nodeToRemove == null)
                {
                    this.root = null;
                }
                else
                {
                    if (nodeToRemove.Parent.RightChild == nodeToRemove)
                    {
                        nodeToRemove.Parent.RightChild = null;
                    }
                    else
                    {
                        nodeToRemove.Parent.LeftChild = null;
                    }
                    nodeToRemove = null;
                }
            }

            if (nodeToRemove.LeftChild != null ^ nodeToRemove.RightChild != null)
            {
                if (nodeToRemove.LeftChild != null)
                {
                    nodeToRemove.LeftChild.Parent = nodeToRemove.Parent;

                    if (nodeToRemove.Parent == null) // nodeToRemove is this.root
                    {
                        this.root = nodeToRemove.LeftChild;
                    }
                    else
                    {
                        if (nodeToRemove.Parent.LeftChild == nodeToRemove)
                        {
                            nodeToRemove.Parent.LeftChild = nodeToRemove.LeftChild;
                        }
                        else
                        {
                            nodeToRemove.Parent.RightChild = nodeToRemove.LeftChild;
                        }
                    }

                    nodeToRemove = null;
                }

                else
                {
                    nodeToRemove.RightChild.Parent = nodeToRemove.Parent;

                    if (nodeToRemove.Parent == null) // nodeToRemove is this.root
                    {
                        this.root = nodeToRemove.RightChild;
                    }
                    else
                    {
                        if (nodeToRemove.Parent.RightChild == nodeToRemove)
                        {
                            nodeToRemove.Parent.RightChild = nodeToRemove.RightChild;
                        }
                        else
                        {
                            nodeToRemove.Parent.LeftChild = nodeToRemove.RightChild;
                        }
                    }
                }
            }
        }
        catch (KeyNotFoundException e)
        {
            throw new KeyNotFoundException(e.Message);
        }
    }

    public override bool Equals(object other)
    {
        BinarySearchTree<T> otherTree = other as BinarySearchTree<T>;

        if (otherTree == null)
        {
            return false;
        }

        bool result = true;

        CompareNodes(this.root, otherTree.root, ref result);

        return result;
    }

    private void CompareNodes(TreeNode<T> treeNode1, TreeNode<T> treeNode2, ref bool result)
    {
        if (treeNode1 == null && treeNode2 == null)
        {
            return;
        }
        else if ((treeNode1 == null || treeNode2 == null) || !treeNode1.Equals(treeNode2))
        {
            result = false;
            return;
        }
        else
        {
            CompareNodes(treeNode1.LeftChild, treeNode2.LeftChild, ref result);
            CompareNodes(treeNode1.RightChild, treeNode2.RightChild, ref result);
        }
    }

    public override int GetHashCode()
    {
        int hash = 13;

        foreach (var node in this)
        {
            hash ^= node.Value.GetHashCode();
        }

        return hash;
    }

    public static bool operator ==(BinarySearchTree<T> tree1, BinarySearchTree<T> tree2)
    {
        return object.Equals(tree1,tree2);
    }

    public static bool operator !=(BinarySearchTree<T> tree1, BinarySearchTree<T> tree2)
    {
        return !tree1.Equals(tree2);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public IEnumerator<TreeNode<T>> GetEnumerator()
    {
        List<TreeNode<T>> nodes = new List<TreeNode<T>>();
        GetNodesPreorder(this.root, ref nodes);

        foreach (var node in nodes)
        {
            yield return node;
        }
    }

    private void GetNodesPreorder(TreeNode<T> treeNode, ref List<TreeNode<T>> nodes)
    {
        if (treeNode == null)
        {
            return;
        }

        nodes.Add(treeNode);
        GetNodesPreorder(treeNode.LeftChild, ref nodes);
        GetNodesPreorder(treeNode.RightChild, ref nodes);
    }

    public override string ToString()
    {
        StringBuilder stringedTree = new StringBuilder();

        stringedTree.Append("{ ");

        foreach (var node in this)
        {
            stringedTree.Append(node.Value);
            stringedTree.Append(" ");
        }

        stringedTree.Append("}");

        return stringedTree.ToString();
    }

    public BinarySearchTree<T> Clone()
    {
        BinarySearchTree<T> clonedTree = new BinarySearchTree<T>();

        foreach (var node in this)
        {
            clonedTree.AddNode(node.Value);
        }

        return clonedTree;
    }

    object ICloneable.Clone()
    {
        return this.Clone();
    }
}
