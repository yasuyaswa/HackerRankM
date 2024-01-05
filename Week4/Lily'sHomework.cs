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
     * Complete the 'lilysHomework' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */
 
    static int Swap(
List<int> arr, Dictionary<int, int> dic, int ele, int i)
{
    if (arr[i] != ele)
    {
        var indexF = dic[arr[i]];
        var indexL = dic[ele];
 
        dic[arr[i]] = indexL;
        dic[ele] = indexF;
 
        var temp = arr[indexF];
        arr[indexF] = arr[indexL];
        arr[indexL] = temp;
 
        return 1;
    }
 
    return 0;
}
 
public static int lilysHomework(List<int> arr)
{
    var len = arr.Count;
    var arrRep = new List<int>();
    var sorted = arr.OrderBy(x => x).ToList();
 
    var ascD = new Dictionary<int, int>();
    var descD = new Dictionary<int, int>();
 
    int ascTotal = 0, descTotal = 0;
    int ascMismatches = 0, descMismatches = 0;
 
    for (int i = 0; i < len; ++i)
    {
        if (arr[i] != sorted[i])
            ++ascMismatches;
        if (arr[i] != sorted[len - 1 - i])
            ++descMismatches;
 
        arrRep.Add(arr[i]);
        ascD.Add(arr[i], i);
        descD.Add(arr[i], i);
    }
 
    if (ascMismatches == 0 || descMismatches == 0)
        return 0;
 
    for (int i = 0; i < len; ++i)
    {
        ascTotal += Swap(arr, ascD, sorted[i], i);
        descTotal += Swap(arrRep, descD, sorted[len - 1 - i], i);
    }
 
    return Math.Min(ascTotal, descTotal);
}
 
}
 
class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
 
        int n = Convert.ToInt32(Console.ReadLine().Trim());
 
        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
 
        int result = Result.lilysHomework(arr);
 
        textWriter.WriteLine(result);
 
        textWriter.Flush();
        textWriter.Close();
    }
}
 
