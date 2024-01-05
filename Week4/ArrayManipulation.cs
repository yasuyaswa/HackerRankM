using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
 
class Result
{
    public static long arrayManipulation(int n, List<List<int>> queries)
    {
        long[] arr = new long[n + 1];
 
        foreach (List<int> query in queries)
        {
            int a = query[0];
            int b = query[1];
            int k = query[2];
 
            arr[a - 1] += k;
            arr[b] -= k;
        }
 
        long max = 0;
        long sum = 0;
 
        foreach (long val in arr)
        {
            sum += val;
            max = Math.Max(max, sum);
        }
 
        return max;
    }
}
 
class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
 
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
 
        int n = Convert.ToInt32(firstMultipleInput[0]);
        int m = Convert.ToInt32(firstMultipleInput[1]);
 
        List<List<int>> queries = new List<List<int>>();
 
        for (int i = 0; i < m; i++)
        {
            queries.Add(Console.ReadLine().TrimEnd().Split(' ').Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
        }
 
        long result = Result.arrayManipulation(n, queries);
 
        textWriter.WriteLine(result);
 
        textWriter.Flush();
        textWriter.Close();
    }
}
