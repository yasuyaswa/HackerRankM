using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;
 
class Result
{
    /*
     * Complete the 'maxSubarray' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */
 
    public static List<int> maxSubarray(List<int> arr)
    {
        int maxSubarraySum = int.MinValue;
        int currentSubarraySum = 0;
 
        int maxSubsequenceSum = 0;
 
        bool allNegative = true;
        int maxNegative = int.MinValue;
 
        foreach (int num in arr)
        {
            // Find maximum subarray sum using Kadane's algorithm
            currentSubarraySum = Math.Max(num, currentSubarraySum + num);
            maxSubarraySum = Math.Max(maxSubarraySum, currentSubarraySum);
 
            // Find maximum subsequence sum
            if (num > 0)
            {
                maxSubsequenceSum += num;
                allNegative = false;
            }
            
            // Track the maximum negative number
            if (num < 0)
            {
                maxNegative = Math.Max(maxNegative, num);
            }
        }
 
        // If all numbers are negative, the maximum subsequence sum is the maximum negative number
        if (allNegative)
        {
            maxSubsequenceSum = maxNegative;
        }
 
        return new List<int> { maxSubarraySum, maxSubsequenceSum };
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
            int n = Convert.ToInt32(Console.ReadLine().Trim());
 
            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
 
            List<int> result = Result.maxSubarray(arr);
 
            textWriter.WriteLine(String.Join(" ", result));
        }
 
        textWriter.Flush();
        textWriter.Close();
    }
}
 
