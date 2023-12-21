using System;
using System.Collections.Generic;

class Result
{
    /*
     * Complete the 'anagram' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING s as parameter.
     */

    public static int anagram(string s)
    {
        if (s.Length % 2 != 0)
        {
            return -1; // An anagram must have an even length
        }

        int[] frequency = new int[26]; // Assuming the string contains only lowercase English letters

        // Count the frequency of each character in the first half of the string
        for (int i = 0; i < s.Length / 2; i++)
        {
            frequency[s[i] - 'a']++;
        }

        // Count the frequency of each character in the second half of the string
        for (int i = s.Length / 2; i < s.Length; i++)
        {
            frequency[s[i] - 'a']--;
        }

        // Calculate the total number of deletions needed to make the string an anagram
        int deletions = 0;
        foreach (int count in frequency)
        {
            deletions += Math.Abs(count);
        }

        // Return half of the deletions (since you are removing characters from only one half)
        return deletions / 2;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string s = Console.ReadLine();

            int result = Result.anagram(s);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
