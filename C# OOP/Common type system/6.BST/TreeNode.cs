using System;

public class TreeNode<T> : IComparable<TreeNode<T>>
    where T: IComparable<T>
{
    public T Value { get; set; }
    public TreeNode<T> LeftChild {get; set; }
    public TreeNode<T> RightChild { get; set; }
    public TreeNode<T> Parent { get; set; }

    public TreeNode(T value, TreeNode<T> leftChild, TreeNode<T> rightChild, TreeNode<T> parent)
    {
        this.Value = value;
        this.LeftChild = leftChild;
        this.RightChild = rightChild;
        this.Parent = parent;
    }

    public override string ToString()
    {
        return this.Value.ToString();
    }

    public override int GetHashCode()
    {
        return this.Value.GetHashCode();
    }

    public override bool Equals(object other)
    {
        TreeNode<T> otherNode = other as TreeNode<T>;

        if (otherNode == null)
	    {
		     return false;
	    }

        return this.Value.CompareTo(otherNode.Value) == 0;
    }

    public int CompareTo(TreeNode<T> other)
    {
        return this.Value.CompareTo(other.Value);
    }
}
