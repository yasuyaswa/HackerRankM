using System;
 
class Node
{
    public int info;
    public Node left;
    public Node right;
 
    public Node(int info)
    {
        this.info = info;
        this.left = null;
        this.right = null;
    }
 
    public override string ToString()
    {
        return info.ToString();
    }
}
 
class BinarySearchTree
{
    public Node root;
 
    public BinarySearchTree()
    {
        this.root = null;
    }
 
    public void Create(int val)
    {
        if (this.root == null)
        {
            this.root = new Node(val);
        }
        else
        {
            Node current = this.root;
 
            while (true)
            {
                if (val < current.info)
                {
                    if (current.left != null)
                    {
                        current = current.left;
                    }
                    else
                    {
                        current.left = new Node(val);
                        break;
                    }
                }
                else if (val > current.info)
                {
                    if (current.right != null)
                    {
                        current = current.right;
                    }
                    else
                    {
                        current.right = new Node(val);
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
}
 
class Solution
{
    public static Node Lca(Node root, int v1, int v2)
    {
        if ((root.info < v1 && root.info > v2) || (root.info > v1 && root.info < v2))
        {
            return root;
        }
        else if (root.info < v1 && root.info < v2)
        {
            return Lca(root.right, v1, v2);
        }
        else if (root.info > v1 && root.info > v2)
        {
            return Lca(root.left, v1, v2);
        }
        else if (root.info == v1 || root.info == v2)
        {
            return root;
        }
 
        return null; // Default return statement
    }
 
    static void Main(string[] args)
    {
        BinarySearchTree tree = new BinarySearchTree();
        int t = Convert.ToInt32(Console.ReadLine());
 
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
 
        for (int i = 0; i < t; i++)
        {
            tree.Create(arr[i]);
        }
 
        int[] v = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
 
        Node ans = Lca(tree.root, v[0], v[1]);
        Console.WriteLine(ans.info);
    }
}
