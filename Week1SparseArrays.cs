using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Result
{
    /*
     * Complete the 'matchingStrings' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. STRING_ARRAY strings
     *  2. STRING_ARRAY queries
     */

    public static List<int> matchingStrings(List<string> strings, List<string> queries)
    {
        Dictionary<string, int> stringCount = new Dictionary<string, int>();

        // Count occurrences of each string in the 'strings' list
        foreach (string str in strings)
        {
            if (stringCount.ContainsKey(str))
            {
                stringCount[str]++;
            }
            else
            {
                stringCount[str] = 1;
            }
        }

        // Create a list to store the results
        List<int> results = new List<int>();

        // Count occurrences of each query in the 'queries' list
        foreach (string query in queries)
        {
            if (stringCount.ContainsKey(query))
            {
                results.Add(stringCount[query]);
            }
            else
            {
                results.Add(0);
            }
        }

        return results;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int stringsCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<string> strings = new List<string>();

        for (int i = 0; i < stringsCount; i++)
        {
            string stringsItem = Console.ReadLine();
            strings.Add(stringsItem);
        }

        int queriesCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<string> queries = new List<string>();

        for (int i = 0; i < queriesCount; i++)
        {
            string queriesItem = Console.ReadLine();
            queries.Add(queriesItem);
        }

        List<int> res = Result.matchingStrings(strings, queries);

        textWriter.WriteLine(String.Join("\n", res));

        textWriter.Flush();
        textWriter.Close();
    }
}
