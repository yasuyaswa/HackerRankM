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
 
