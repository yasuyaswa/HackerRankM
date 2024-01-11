using System;
using System.Collections.Generic;

class GraphNode
{
    public int SumNodes;
    public List<LinkedList<int>> AdjList;

    public GraphNode(int numNodes)
    {
        SumNodes = numNodes;
        AdjList = new List<LinkedList<int>>();
        for (int i = 0; i < numNodes; i++)
        {
            AdjList.Add(new LinkedList<int>());
        }
    }

    public void AddEdge(int a, int b)
    {
        AdjList[a].AddLast(b);
        AdjList[b].AddLast(a);
    }
}

public class Solution
{
    public static void GetDistance(List<LinkedList<int>> adjList, int[] results, int s)
    {
        Queue<int> q = new Queue<int>();
        bool[] isVisited = new bool[adjList.Count];
        q.Enqueue(s);
        isVisited[s] = true;
        int count = 0;

        while (q.Count > 0)
        {
            int qSize = q.Count;
            for (int i = 0; i < qSize; i++)
            {
                int removed = q.Dequeue();
                results[removed] = count;
                foreach (int x in adjList[removed])
                {
                    if (!isVisited[x])
                    {
                        q.Enqueue(x);
                        isVisited[x] = true;
                    }
                }
            }
            count += 6;
        }
    }

    public static void Main(string[] args)
    {
        int q = int.Parse(Console.ReadLine());

        for (int i = 1; i <= q; i++)
        {
            string[] nm = Console.ReadLine().Split();
            int n = int.Parse(nm[0]);
            int m = int.Parse(nm[1]);

            GraphNode g = new GraphNode(n);

            for (int j = 1; j <= m; j++)
            {
                string[] ab = Console.ReadLine().Split();
                int a = int.Parse(ab[0]) - 1;
                int b = int.Parse(ab[1]) - 1;
                g.AddEdge(a, b);
            }

            int s = int.Parse(Console.ReadLine());
            int[] results = new int[n];
            Array.Fill(results, -1);
            GetDistance(g.AdjList, results, s - 1);

            for (int k = 0; k < n; k++)
            {
                if (k != s - 1)
                    Console.Write(results[k] + " ");
            }

            Console.WriteLine();
        }
    }
}
