using System;
using System.Collections.Generic;
 
class Result
{
    public static string isBalanced(string s)
    {
        // Check for null string
        if (s == null)
        {
            return "NO";
        }
 
        // Create a stack to store opening brackets
        Stack<char> stack = new Stack<char>();
 
        // Define a dictionary to store matching brackets
        Dictionary<char, char> bracketPairs = new Dictionary<char, char>
        {
            { '(', ')' },
            { '{', '}' },
            { '[', ']' }
        };
 
        // Iterate through each character in the string
        foreach (char bracket in s)
        {
            // If the bracket is an opening bracket, push it onto the stack
            if (bracketPairs.ContainsKey(bracket))
            {
                stack.Push(bracket);
            }
            // If the bracket is a closing bracket
            else
            {
                // If the stack is empty or the last opening bracket doesn't match the current closing bracket
                if (stack.Count == 0 || bracket != bracketPairs[stack.Pop()])
                {
                    return "NO"; // Unbalanced
                }
            }
        }
 
        // If the stack is empty, all brackets are matched
        return stack.Count == 0 ? "YES" : "NO";
    }
}
 
class Solution
{
    public static void Main(string[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine().Trim());
 
        for (int tItr = 0; tItr < t; tItr++)
        {
            string s = Console.ReadLine();
 
            string result = Result.isBalanced(s);
 
            Console.WriteLine(result);
        }
    }
}
