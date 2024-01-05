using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
 
class Solution
{
    static int[] Size;
    static int[] Parent;
 
    static int Find(int a)
    {
        if (a == Parent[a]) return a;
        return Parent[a] = Find(Parent[a]);
    }
 
    static void Group(int a, int b)
    {
        a = Find(a);
        b = Find(b);
        if (a == b) return;
        if (Size[a] < Size[b]) Swap(ref a, ref b);
        Parent[b] = a;
        Size[a] += Size[b];
    }
 
    static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
 
    static long RoadsAndLibraries(int n, int c_lib, int c_road, List<List<int>> cities)
    {
        if (c_lib <= c_road)
            return (long)n * c_lib;
 
        Size = new int[n + 1];
        Parent = new int[n + 1];
 
        for (int i = 1; i <= n; i++)
        {
            Size[i] = 1;
            Parent[i] = i;
        }
 
        foreach (var c in cities)
        {
            Group(c[0], c[1]);
        }
 
        Dictionary<int, bool> umap = new Dictionary<int, bool>();
        long cost = 0;
 
        for (int i = 1; i <= n; i++)
        {
            int p = Find(i);
            if (umap.ContainsKey(p)) continue;
            cost += c_lib;
            cost += (Size[p] - 1) * c_road;
            umap[p] = true;
        }
 
        return cost;
    }
 
    static void Main(string[] args)
    {
        TextWriter fout = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
 
        int q = Convert.ToInt32(Console.ReadLine().Trim());
 
        for (int qItr = 0; qItr < q; qItr++)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
 
            int n = Convert.ToInt32(firstMultipleInput[0]);
            int m = Convert.ToInt32(firstMultipleInput[1]);
            int c_lib = Convert.ToInt32(firstMultipleInput[2]);
            int c_road = Convert.ToInt32(firstMultipleInput[3]);
 
            List<List<int>> cities = new List<List<int>>();
 
            for (int i = 0; i < m; i++)
            {
                cities.Add(Console.ReadLine().TrimEnd().Split(' ').Select(citiesTemp => Convert.ToInt32(citiesTemp)).ToList());
            }
 
            long result = RoadsAndLibraries(n, c_lib, c_road, cities);
 
            fout.WriteLine(result);
        }
 
        fout.Flush();
        fout.Close();
    }
}
