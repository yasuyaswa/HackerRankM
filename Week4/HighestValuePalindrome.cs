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
     * Complete the 'highestValuePalindrome' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. STRING s
     *  2. INTEGER n
     *  3. INTEGER k
     */
 
    public static string highestValuePalindrome(string s, int n, int k)
    {
         var sb = new StringBuilder(s);
        var diff = new Dictionary<int, bool>();
 
        for (var i = 0; i < n / 2; ++i)
        {
            if (k < 0) break;
            if (sb[i] != sb[n - 1 - i])
            {
                var m = Math.Max((int)sb[i], (int)sb[n - 1 - i]);
                sb[i] = Convert.ToChar(m);
                sb[n - 1 - i] = Convert.ToChar(m);
                diff[i] = true;
                --k;
            }
        }
 
        if (k < 0) return "-1";
 
        if (k > 0)
        {
            for (var i = 0; i < n / 2; ++i)
            {
                if (k == 0) break;
                if (sb[i] != '9')
                {
                    if (diff.ContainsKey(i))
                    {
                        sb[i] = '9';
                        sb[n - 1 - i] = '9';
                        --k;
                    }
                    else if (k > 1)
                    {
                        sb[i] = '9';
                        sb[n - 1 - i] = '9';
                        k -= 2;
                    }
                }
            }
        }
 
        if (k >= 1 && n % 2 == 1)
            sb[n / 2] = '9';
 
        return sb.ToString();
 
    }
 
}
 
class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
 
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
 
        int n = Convert.ToInt32(firstMultipleInput[0]);
 
        int k = Convert.ToInt32(firstMultipleInput[1]);
 
        string s = Console.ReadLine();
 
        string result = Result.highestValuePalindrome(s, n, k);
 
        textWriter.WriteLine(result);
 
        textWriter.Flush();
        textWriter.Close();
    }
}
 
