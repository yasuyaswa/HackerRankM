using System;
using System.Collections.Generic;

class Result
{
    /*
     * Complete the 'icecreamParlor' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER m
     *  2. INTEGER_ARRAY arr
     */

    public static List<int> icecreamParlor(int m, List<int> arr)
    {
        List<int> result = new List<int>();

        // Create a dictionary to store the indices of flavors
        Dictionary<int, int> flavorIndices = new Dictionary<int, int>();

        for (int i = 0; i < arr.Count; i++)
        {
            int currentPrice = arr[i];
            int remainingPrice = m - currentPrice;

            // Check if the remaining price exists in the dictionary
            if (flavorIndices.ContainsKey(remainingPrice))
            {
                // Found a pair, add their indices to the result
                result.Add(flavorIndices[remainingPrice] + 1);
                result.Add(i + 1);
                break; // We only need to find one valid pair
            }

            // Store the index of the current flavor in the dictionary
            flavorIndices[currentPrice] = i;
        }

        return result;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int m = Convert.ToInt32(Console.ReadLine().Trim());
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            List<int> result = Result.icecreamParlor(m, arr);

            textWriter.WriteLine(String.Join(" ", result));
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
