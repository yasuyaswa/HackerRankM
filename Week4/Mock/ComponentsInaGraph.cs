using System;
using System.Collections.Generic;

class Result
{
    /*
     * Complete the 'componentsInGraph' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts 2D_INTEGER_ARRAY gb as a parameter.
     */

    public static List<int> componentsInGraph(List<List<int>> gb)
    {
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

        // Build the undirected graph
        foreach (List<int> edge in gb)
        {
            int node1 = edge[0];
            int node2 = edge[1];

            if (!graph.ContainsKey(node1))
                graph[node1] = new List<int>();

            if (!graph.ContainsKey(node2))
                graph[node2] = new List<int>();

            graph[node1].Add(node2);
            graph[node2].Add(node1);
        }

        int minSize = int.MaxValue;
        int maxSize = int.MinValue;
        HashSet<int> visited = new HashSet<int>();

        // Explore connected components and find the minimum and maximum sizes
        foreach (int node in graph.Keys)
        {
            if (!visited.Contains(node))
            {
                int componentSize = ExploreComponent(graph, node, visited);
                minSize = Math.Min(minSize, componentSize);
                maxSize = Math.Max(maxSize, componentSize);
            }
        }

        List<int> result = new List<int> { minSize, maxSize };
        return result;
    }

    private static int ExploreComponent(Dictionary<int, List<int>> graph, int node, HashSet<int> visited)
    {
        int componentSize = 0;
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(node);
        visited.Add(node);

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();
            componentSize++;

            foreach (int neighbor in graph[current])
            {
                if (!visited.Contains(neighbor))
                {
                    queue.Enqueue(neighbor);
                    visited.Add(neighbor);
                }
            }
        }

        return componentSize;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<int>> gb = new List<List<int>>();

        for (int i = 0; i < n; i++)
        {
            gb.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(gbTemp => Convert.ToInt32(gbTemp)).ToList());
        }

        List<int> result = Result.componentsInGraph(gb);

        Console.WriteLine(String.Join(" ", result));
    }
}
