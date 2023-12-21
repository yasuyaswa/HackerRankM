using System;
 
class Result
{
    /*
     * Complete the 'counterGame' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts LONG_INTEGER n as parameter.
     */
 
    public static string counterGame(long n)
    {
        int turns = 0;
 
        // Continue the game until n becomes 1
        while (n > 1)
        {
            // If n is not a power of 2, reduce it to the next lower power of 2
            if ((n & (n - 1)) != 0)
            {
                // Find the largest power of 2 less than n
                long powerOfTwo = 1;
                while (powerOfTwo * 2 < n)
                {
                    powerOfTwo *= 2;
                }
 
                // Reduce n by the powerOfTwo
                n -= powerOfTwo;
            }
            else
            {
                // If n is a power of 2, divide it by 2
                n /= 2;
            }
 
            // Toggle turns between Louise and Richard
            turns++;
        }
 
        // If the number of turns is even, Richard wins; otherwise, Louise wins
        return (turns % 2 == 0) ? "Richard" : "Louise";
    }
}
 
class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
 
        int t = Convert.ToInt32(Console.ReadLine().Trim());
 
        for (int tItr = 0; tItr < t; tItr++)
        {
            long n = Convert.ToInt64(Console.ReadLine().Trim());
 
            string result = Result.counterGame(n);
 
            textWriter.WriteLine(result);
        }
 
        textWriter.Flush();
        textWriter.Close();
    }
}
