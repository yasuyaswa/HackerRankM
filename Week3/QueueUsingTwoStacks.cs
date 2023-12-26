using System;
using System.Collections.Generic;
using System.IO;

class Solution
{
    static void Main(String[] args)
    {
        int q = Convert.ToInt32(Console.ReadLine().Trim());

        // Using two stacks to implement a queue
        Stack<int> enqueueStack = new Stack<int>();
        Stack<int> dequeueStack = new Stack<int>();

        for (int i = 0; i < q; i++)
        {
            string[] query = Console.ReadLine().Trim().Split(' ');
            int type = Convert.ToInt32(query[0]);

            switch (type)
            {
                case 1:
                    // Enqueue operation
                    int x = Convert.ToInt32(query[1]);
                    enqueueStack.Push(x);
                    break;

                case 2:
                    // Dequeue operation
                    if (dequeueStack.Count == 0)
                    {
                        // Transfer elements from enqueueStack to dequeueStack
                        while (enqueueStack.Count > 0)
                        {
                            dequeueStack.Push(enqueueStack.Pop());
                        }
                    }
                    // Pop the front element from dequeueStack
                    if (dequeueStack.Count > 0)
                    {
                        dequeueStack.Pop();
                    }
                    break;

                case 3:
                    // Print the element at the front of the queue
                    if (dequeueStack.Count == 0)
                    {
                        // Transfer elements from enqueueStack to dequeueStack
                        while (enqueueStack.Count > 0)
                        {
                            dequeueStack.Push(enqueueStack.Pop());
                        }
                    }
                    // Print the front element without popping
                    if (dequeueStack.Count > 0)
                    {
                        Console.WriteLine(dequeueStack.Peek());
                    }
                    break;
            }
        }
    }
}
