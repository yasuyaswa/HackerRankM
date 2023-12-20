using System;
using System.IO;

class Result
{
    public static long sumXor(long n)
    {
        long countZeroes = 0;
        while (n > 0)
        {
            if ((n & 1) == 0)
            {
                countZeroes++;
            }
            n >>= 1;
        }
        return 1L << (int)countZeroes;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        long n = Convert.ToInt64(Console.ReadLine().Trim());

        long result = Result.sumXor(n);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
