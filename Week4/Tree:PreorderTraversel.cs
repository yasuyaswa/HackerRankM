using System;
using System.Collections.Generic;
 
class Node_BST
{
    public int val;
    public Node_BST left, right;
 
    public Node_BST(int x)
    {
        val = x;
        left = right = null;
    }
}
 
class BinarySearchTree
{
    public Node_BST root;
 
    public BinarySearchTree()
    {
        root = null;
    }
 
    public void Insert(int key)
    {
        root = InsertRec(root, key);
    }
 
    private Node_BST InsertRec(Node_BST root, int key)
    {
        if (root == null)
        {
            root = new Node_BST(key);
            return root;
        }
 
        if (key < root.val)
            root.left = InsertRec(root.left, key);
        else if (key > root.val)
            root.right = InsertRec(root.right, key);
 
        return root;
    }
 
    public void Preorder()
    {
        PreorderRec(root);
    }
 
    private void PreorderRec(Node_BST root)
    {
        if (root != null)
        {
            Console.Write(root.val + " ");
            PreorderRec(root.left);
            PreorderRec(root.right);
        }
    }
}
class SolveProblems
{
    static void Main(string[] args)
{
    int n;
 
    while (!int.TryParse(Console.ReadLine(), out n))
    {
        Console.WriteLine("Invalid input. Please enter a valid number.");
    }
 
    List<int> arr = new List<int>();
 
    string[] elements = Console.ReadLine().Split(' ');
 
    foreach (var element in elements)
    {
        if (int.TryParse(element, out int value))
        {
            arr.Add(value);
        }
        else
        {
            Console.WriteLine($"Invalid input: {element}. Please enter valid integers.");
            return;
        }
    }
 
    BinarySearchTree tree = new BinarySearchTree();
    foreach (int element in arr)
    {
        tree.Insert(element);
    }
 
    tree.Preorder();
    Console.WriteLine();
}
 
}
