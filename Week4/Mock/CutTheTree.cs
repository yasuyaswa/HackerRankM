using System;
using System.Collections.Generic;

class Result
{
    /*
     * Complete the 'cutTheTree' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY data
     *  2. 2D_INTEGER_ARRAY edges
     */

    public static int cutTheTree(List<int> data, List<List<int>> edges)
    {
        int n = data.Count;
        int[] subtreeSum = new int[n];
        int totalSum = 0;

        // Calculate the total sum and initialize subtree sums
        foreach (int value in data)
            totalSum += value;

        Dictionary<int, List<int>> graph = BuildGraph(edges);

        // Perform DFS to calculate subtree sums
        DFS(0, graph, data, subtreeSum);

        int minDiff = int.MaxValue;

        // Calculate the absolute difference between total sum and 2 * subtree sum
        for (int i = 1; i < n; i++)
        {
            int currentDiff = Math.Abs(totalSum - 2 * subtreeSum[i]);
            minDiff = Math.Min(minDiff, currentDiff);
        }

        return minDiff;
    }

    private static void DFS(int node, Dictionary<int, List<int>> graph, List<int> data, int[] subtreeSum)
    {
        subtreeSum[node] = data[node];

        foreach (int neighbor in graph[node])
        {
            if (subtreeSum[neighbor] == 0)
            {
                DFS(neighbor, graph, data, subtreeSum);
                subtreeSum[node] += subtreeSum[neighbor];
            }
        }
    }

    private static Dictionary<int, List<int>> BuildGraph(List<List<int>> edges)
    {
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

        foreach (List<int> edge in edges)
        {
            int a = edge[0] - 1;
            int b = edge[1] - 1;

            if (!graph.ContainsKey(a))
                graph[a] = new List<int>();

            if (!graph.ContainsKey(b))
                graph[b] = new List<int>();

            graph[a].Add(b);
            graph[b].Add(a);
        }

        return graph;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> data = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(dataTemp => Convert.ToInt32(dataTemp)).ToList();

        List<List<int>> edges = new List<List<int>>();

        for (int i = 0; i < n - 1; i++)
        {
            edges.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(edgesTemp => Convert.ToInt32(edgesTemp)).ToList());
        }

        int result = Result.cutTheTree(data, edges);

        Console.WriteLine(result);
    }
}
