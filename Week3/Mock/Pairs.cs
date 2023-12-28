using System;
using System.Collections.Generic;

class Result
{
    /*
     * Complete the 'pairs' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER k
     *  2. INTEGER_ARRAY arr
     */

    public static int pairs(int k, List<int> arr)
    {
        HashSet<int> set = new HashSet<int>(arr);
        int count = 0;

        foreach (int num in arr)
        {
            int complement = num - k;

            if (set.Contains(complement))
            {
                count++;
            }
        }

        return count;
    }
}
