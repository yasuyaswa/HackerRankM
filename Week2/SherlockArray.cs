using System;
using System.Collections.Generic;
using System.IO;

class Result
{

    /*
     * Complete the 'balancedSums' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts INTEGER_ARRAY arr as a parameter.
     */

    public static string balancedSums(List<int> arr)
    {
        int n = arr.Count;

        // Calculate the total sum of the array
        int totalSum = 0;
        foreach (int num in arr)
        {
            totalSum += num;
        }

        // Initialize left and right sums
        int leftSum = 0;
        int rightSum = totalSum;

        // Iterate through the array to find the equilibrium point
        for (int i = 0; i < n; i++)
        {
            rightSum -= arr[i]; // Update right sum
            if (leftSum == rightSum)
            {
                return "YES"; // Found equilibrium point
            }
            leftSum += arr[i]; // Update left sum
        }

        return "NO"; // No equilibrium point found
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int T = Convert.ToInt32(Console.ReadLine().Trim());

        for (int TItr = 0; TItr < T; TItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            string result = Result.balancedSums(arr);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
