using System;
using System.Linq;
 
class Solution
{
    static void Main(string[] args)
    {
        int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int n = input[0];
        int k = input[1];
 
        int[] x = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        Array.Sort(x);
 
        int total = 0;
        for (int i = 0; i < x.Length; i++)
        {
            int current = x[i];
            for (int j = i + 1; j < x.Length && x[j] <= current + k; j++)
            {
                i++;
            }
            current = x[i];
            total++;
            for (int j = i + 1; j < x.Length && x[j] <= current + k; j++)
            {
                i++;
            }
        }
 
        Console.WriteLine(total);
    }
}
 
[2:23 PM] Mondal, Santanu
using System;
using System.Collections.Generic;
using System.Linq;
 
class Result
{
    /*
     * Complete the 'solve' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY arr
     *  2. INTEGER_ARRAY queries
     */
 
    public static List<int> solve(List<int> arr, List<int> queries)
    {
        List<int> result = new List<int>();
 
        foreach (int query in queries)
        {
            int minMax = FindMinMax(arr, query);
            result.Add(minMax);
        }
 
        return result;
    }
 
    private static int FindMinMax(List<int> arr, int query)
    {
        int n = arr.Count;
        List<int> minMaxValues = new List<int>();
        LinkedList<int> deque = new LinkedList<int>();
 
        for (int i = 0; i < n; i++)
        {
            while (deque.Count > 0 && deque.First.Value < i - query + 1)
            {
                deque.RemoveFirst();
            }
 
            while (deque.Count > 0 && arr[deque.Last.Value] < arr[i])
            {
                deque.RemoveLast();
            }
 
            deque.AddLast(i);
 
            if (i >= query - 1)
            {
                minMaxValues.Add(arr[deque.First.Value]);
            }
        }
 
        return minMaxValues.Min();
    }
}
 
class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
 
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
 
        int n = Convert.ToInt32(firstMultipleInput[0]);
 
        int q = Convert.ToInt32(firstMultipleInput[1]);
 
        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
 
        List<int> queries = new List<int>();
 
        for (int i = 0; i < q; i++)
        {
            int queriesItem = Convert.ToInt32(Console.ReadLine().Trim());
            queries.Add(queriesItem);
        }
 
        List<int> result = Result.solve(arr, queries);
 
        textWriter.WriteLine(String.Join("\n", result));
 
        textWriter.Flush();
        textWriter.Close();
    }
}
 
