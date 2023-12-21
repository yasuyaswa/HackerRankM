using System;
using System.Collections.Generic;
using System.Linq;

class Result
{
    /*
     * Complete the 'getTotalX' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY a
     *  2. INTEGER_ARRAY b
     */

    public static int getTotalX(List<int> a, List<int> b)
    {
        int count = 0;

        for (int x = a.Max(); x <= b.Min(); x++)
        {
            if (IsFactorOfArray(x, a) && IsFactorForArray(x, b))
            {
                count++;
            }
        }

        return count;
    }

    private static bool IsFactorOfArray(int x, List<int> arr)
    {
        return arr.All(num => x % num == 0);
    }

    private static bool IsFactorForArray(int x, List<int> arr)
    {
        return arr.All(num => num % x == 0);
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

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
        List<int> brr = Console.ReadLine().TrimEnd().Split(' ').Select(brrTemp => Convert.ToInt32(brrTemp)).ToList();

        int total = Result.getTotalX(arr, brr);

        textWriter.WriteLine(total);

        textWriter.Flush();
        textWriter.Close();
    }
}
