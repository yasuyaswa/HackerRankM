using System;
using System.Collections.Generic;
 
class Node : IComparable<Node>
{
    public int freq;
    public char data;
    public Node left, right;
    private static int cntr = 0;
    private readonly int _count;
 
    public Node(int freq, char data)
    {
        this.freq = freq;
        this.data = data;
        left = right = null;
        _count = cntr++;
    }
 
    public int CompareTo(Node other)
    {
        if (freq != other.freq)
            return freq.CompareTo(other.freq);
        return _count.CompareTo(other._count);
    }
}
 
class Huffman
{
    public static Node BuildTree(Dictionary<char, int> freq)
    {
        PriorityQueue<Node> q = new PriorityQueue<Node>();
 
        foreach (var key in freq.Keys)
        {
            q.Enqueue(new Node(freq[key], key));
        }
 
        while (q.Count != 1)
        {
            var a = q.Dequeue();
            var b = q.Dequeue();
            var obj = new Node(a.freq + b.freq, '\0');
            obj.left = a;
            obj.right = b;
            q.Enqueue(obj);
        }
 
        var root = q.Dequeue();
        return root;
    }
 
    public static Dictionary<char, string> CodeHidden = new Dictionary<char, string>();
 
    public static void DfsHidden(Node obj, string already)
    {
        if (obj == null)
            return;
 
        if (obj.data != '\0')
        {
            CodeHidden[obj.data] = already;
        }
 
        DfsHidden(obj.right, already + "1");
        DfsHidden(obj.left, already + "0");
    }
}
 
class PriorityQueue<T> where T : IComparable<T>
{
    private List<T> heap;
 
    public int Count => heap.Count;
 
    public PriorityQueue()
    {
        heap = new List<T>();
    }
 
    public void Enqueue(T item)
    {
        heap.Add(item);
        int i = heap.Count - 1;
        while (i > 0)
        {
            int parent = (i - 1) / 2;
            if (heap[parent].CompareTo(heap[i]) <= 0)
                break;
 
            Swap(parent, i);
            i = parent;
        }
    }
 
    public T Dequeue()
    {
        if (heap.Count == 0)
            throw new InvalidOperationException("Priority queue is empty.");
 
        T root = heap[0];
        int last = heap.Count - 1;
        heap[0] = heap[last];
        heap.RemoveAt(last);
 
        int i = 0;
        while (true)
        {
            int leftChild = 2 * i + 1;
            if (leftChild >= heap.Count)
                break;
 
            int rightChild = leftChild + 1;
            int minChild = leftChild;
            if (rightChild < heap.Count && heap[rightChild].CompareTo(heap[leftChild]) < 0)
                minChild = rightChild;
 
            if (heap[i].CompareTo(heap[minChild]) <= 0)
                break;
 
            Swap(i, minChild);
            i = minChild;
        }
 
        return root;
    }
 
    private void Swap(int i, int j)
    {
        T temp = heap[i];
        heap[i] = heap[j];
        heap[j] = temp;
    }
}
 
class Solution
{
    static void DecodeHuff(Node root, string s)
    {
        Node cur = root;
        List<char> charArray = new List<char>();
 
        foreach (char c in s)
        {
            if (c == '0' && cur.left != null)
                cur = cur.left;
            else if (cur.right != null)
                cur = cur.right;
 
            if (cur.left == null && cur.right == null)
            {
                charArray.Add(cur.data);
                cur = root;
            }
        }
 
        Console.WriteLine(string.Join("", charArray));
    }
 
    static void Main()
    {
        //Console.WriteLine("Enter a test string:");
        string input = Console.ReadLine();
        Dictionary<char, int> frequency = new Dictionary<char, int>();
 
        foreach (char ch in input)
        {
            if (frequency.ContainsKey(ch))
                frequency[ch]++;
            else
                frequency[ch] = 1;
        }
 
        Node root = Huffman.BuildTree(frequency);
        Huffman.DfsHidden(root, "");
 
        string toBeDecoded = "";
 
        foreach (char ch in input)
        {
            toBeDecoded += Huffman.CodeHidden[ch];
        }
 
        DecodeHuff(root, toBeDecoded);
    }
}
