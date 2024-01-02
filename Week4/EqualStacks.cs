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
     * Complete the 'equalStacks' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY h1
     *  2. INTEGER_ARRAY h2
     *  3. INTEGER_ARRAY h3
     */
 
    public static int equalStacks(List<int> h1, List<int> h2, List<int> h3)
    {
        int sum1 = h1.Sum();
        int sum2 = h2.Sum();
        int sum3 = h3.Sum();
 
        while (!(sum1 == sum2 && sum2 == sum3))
        {
            int minSum = Math.Min(Math.Min(sum1, sum2), sum3);
 
            while (sum1 > minSum)
            {
                sum1 -= h1[0];
                h1.RemoveAt(0);
            }
 
            while (sum2 > minSum)
            {
                sum2 -= h2[0];
                h2.RemoveAt(0);
            }
 
            while (sum3 > minSum)
            {
                sum3 -= h3[0];
                h3.RemoveAt(0);
            }
        }
 
        return sum1;
 
    }
 
}
 
class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
 
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
 
        int n1 = Convert.ToInt32(firstMultipleInput[0]);
 
        int n2 = Convert.ToInt32(firstMultipleInput[1]);
 
        int n3 = Convert.ToInt32(firstMultipleInput[2]);
 
        List<int> h1 = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(h1Temp => Convert.ToInt32(h1Temp)).ToList();
 
        List<int> h2 = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(h2Temp => Convert.ToInt32(h2Temp)).ToList();
 
        List<int> h3 = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(h3Temp => Convert.ToInt32(h3Temp)).ToList();
 
        int result = Result.equalStacks(h1, h2, h3);
 
        textWriter.WriteLine(result);
 
        textWriter.Flush();
        textWriter.Close();
    }
}
