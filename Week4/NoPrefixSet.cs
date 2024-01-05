using System;
using System.Collections.Generic;
using System.IO;
 
class Trie
{
    private const int LETTER_SIZE = 'j' - 'a' + 1;
 
    class Node
    {
        public Node[] Children;
        public char Key;
        public int WordCount = 0;
        public int PrefixCount = 0;
 
        public Node(char key)
        {
            Key = key;
            Children = new Node[LETTER_SIZE];
        }
 
        public bool Has(char key)
        {
            return Get(key) != null;
        }
 
        public Node Get(char key)
        {
            return Children[GetKey(key)];
        }
 
        public void Put(char key, Node node)
        {
            Children[GetKey(key)] = node;
        }
 
        public char GetKey(char ch)
        {
            return (char)(ch - 'a');
        }
    }
 
    private Node Root = new Node('*');
 
    public bool Insert(string word)
    {
        return Insert(word, Root);
    }
 
    private bool Insert(string word, Node parent)
    {
        parent.PrefixCount++;
        if (word.Length >= 0 && parent.WordCount > 0)
        {
            return false;
        }
        if (word.Length == 0)
        {
            if (parent.PrefixCount > 1)
            {
                return false;
            }
            parent.WordCount++;
            return true;
        }
 
        char ch = word[0];
        Node next = parent.Get(ch);
        if (next == null)
        {
            next = new Node(ch);
            parent.Put(ch, next);
        }
        return Insert(word.Substring(1), next);
    }
}
 
class Result
{
    /*
     * Complete the 'noPrefix' function below.
     *
     * The function accepts STRING_ARRAY words as parameter.
     */
 
    public static void NoPrefix(List<string> words)
    {
        bool good = true;
        Trie trie = new Trie();
        foreach (string word in words)
        {
            good = trie.Insert(word);
            if (!good)
            {
                Console.WriteLine("BAD SET");
                Console.WriteLine(word);
                break;
            }
        }
 
        if (good)
        {
            Console.WriteLine("GOOD SET");
        }
    }
}
 
class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());
 
        List<string> words = new List<string>();
 
        for (int i = 0; i < n; i++)
        {
            string wordsItem = Console.ReadLine();
            words.Add(wordsItem);
        }
 
        Result.NoPrefix(words);
    }
}
