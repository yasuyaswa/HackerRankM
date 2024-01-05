using System;
using System.Collections.Generic;

class Result
{
    /*
     * Complete the 'noPrefix' function below.
     *
     * The function accepts STRING_ARRAY words as parameter.
     */

    public static void noPrefix(List<string> words)
    {
        TrieNode root = new TrieNode();

        foreach (var word in words)
        {
            if (!InsertWord(root, word))
            {
                Console.WriteLine("BAD SET");
                Console.WriteLine(word);
                return;
            }
        }

        Console.WriteLine("GOOD SET");
    }

    private static bool InsertWord(TrieNode root, string word)
    {
        TrieNode current = root;

        for (int i = 0; i < word.Length; i++)
        {
            char ch = word[i];

            if (current.Children[ch - 'a'] == null)
            {
                current.Children[ch - 'a'] = new TrieNode();
            }
            else if (current.Children[ch - 'a'].IsEnd)
            {
                return false;  // Word is a prefix of another word
            }

            current = current.Children[ch - 'a'];
        }

        current.IsEnd = true;

        return true;
    }
}

class TrieNode
{
    public TrieNode[] Children { get; } = new TrieNode[26];
    public bool IsEnd { get; set; }
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

        Result.noPrefix(words);
    }
}
