using System;
using System.Collections.Generic;

class Result
{
    /*
     * Complete the 'minimumBribes' function below.
     *
     * The function accepts INTEGER_ARRAY q as a parameter.
     */

    public static void minimumBribes(List<int> q)
    {
        int bribes = 0;
        for (int i = q.Count - 1; i >= 0; i--)
        {
            // Check if the person moved more than two positions forward
            if (q[i] - (i + 1) > 2)
            {
                Console.WriteLine("Too chaotic");
                return;
            }

            // Count the number of bribes for the current person
            for (int j = Math.Max(0, q[i] - 2); j < i; j++)
            {
                if (q[j] > q[i])
                {
                    bribes++;
                }
            }
        }

        Console.WriteLine(bribes);
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> q = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(qTemp => Convert.ToInt32(qTemp)).ToList();

            Result.minimumBribes(q);
        }
    }
}
