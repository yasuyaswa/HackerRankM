using System;
using System.Collections.Generic;

class Solution
{
    static void Main(String[] args)
    {
        int Q = Convert.ToInt32(Console.ReadLine().Trim());

        // Stack to keep track of the editor's state after each operation
        Stack<string> editorStates = new Stack<string>();
        // Initial state is an empty string
        editorStates.Push("");

        for (int i = 0; i < Q; i++)
        {
            string[] query = Console.ReadLine().Trim().Split(' ');
            int type = Convert.ToInt32(query[0]);

            switch (type)
            {
                case 1:
                    // Append operation
                    string strToAppend = query[1];
                    editorStates.Push(editorStates.Peek() + strToAppend);
                    break;

                case 2:
                    // Delete operation
                    int k = Convert.ToInt32(query[1]);
                    string currentString = editorStates.Peek();
                    editorStates.Push(currentString.Substring(0, currentString.Length - k));
                    break;

                case 3:
                    // Print operation
                    int j = Convert.ToInt32(query[1]);
                    Console.WriteLine(editorStates.Peek()[j - 1]);
                    break;

                case 4:
                    // Undo operation
                    editorStates.Pop();
                    break;
            }
        }
    }
}
