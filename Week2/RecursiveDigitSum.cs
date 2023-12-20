using System;
using System.IO;

class Result
{

    /*
     * Complete the 'superDigit' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. STRING n
     *  2. INTEGER k
     */

    public static int superDigit(string n, int k)
    {
        // Calculate the sum of digits of the initial number
        long sum = 0;
        foreach (char digit in n)
        {
            sum += Convert.ToInt64(digit.ToString());
        }

        // Multiply the sum by k
        long multipliedSum = sum * k;

        // Call the recursive helper function to find the super digit
        return CalculateSuperDigit(multipliedSum);
    }

    private static int CalculateSuperDigit(long num)
    {
        // If the number has only one digit, return that digit
        if (num < 10)
        {
            return (int)num;
        }

        // Otherwise, calculate the sum of digits recursively
        long sum = 0;
        while (num > 0)
        {
            sum += num % 10;
            num /= 10;
        }

        // Call the helper function recursively with the new sum
        return CalculateSuperDigit(sum);
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        string n = firstMultipleInput[0];

        int k = Convert.ToInt32(firstMultipleInput[1]);

        int result = Result.superDigit(n, k);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
