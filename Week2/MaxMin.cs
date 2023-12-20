using System;
using System.Collections.Generic;
using System.IO;

class Result
{
    /*
     * Complete the 'maxMin' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER k
     *  2. INTEGER_ARRAY arr
     */

    public static int maxMin(int k, List<int> arr)
    {
        // Sort the array in ascending order
        arr.Sort();

        // Initialize the minimum unfairness value
        int minUnfairness = int.MaxValue;

        // Iterate through the array to find the minimum unfairness
        for (int i = 0; i <= arr.Count - k; i++)
        {
            int currentUnfairness = arr[i + k - 1] - arr[i];
            minUnfairness = Math.Min(minUnfairness, currentUnfairness);
        }

        return minUnfairness;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        int k = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = new List<int>();

        for (int i = 0; i < n; i++)
        {
            int arrItem = Convert.ToInt32(Console.ReadLine().Trim());
            arr.Add(arrItem);
        }

        int result = Result.maxMin(k, arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
