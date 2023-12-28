using System;
using System.Collections.Generic;

class Result
{
    /*
     * Complete the 'bigSorting' function below.
     *
     * The function is expected to return a STRING_ARRAY.
     * The function accepts STRING_ARRAY unsorted as a parameter.
     */

    public static List<string> bigSorting(List<string> unsorted)
    {
        // Custom comparer to sort strings based on numeric value
        unsorted.Sort((x, y) =>
        {
            if (x.Length != y.Length)
                return x.Length - y.Length;

            return string.CompareOrdinal(x, y);
        });

        return unsorted;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<string> unsorted = new List<string>();

        for (int i = 0; i < n; i++)
        {
            string unsortedItem = Console.ReadLine();
            unsorted.Add(unsortedItem);
        }

        List<string> result = Result.bigSorting(unsorted);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
