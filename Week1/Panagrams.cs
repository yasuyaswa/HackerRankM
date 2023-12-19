using System;
using System.IO;
using System.Linq;

class Result
{
    /*
     * Complete the 'pangrams' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as a parameter.
     */

    public static string pangrams(string s)
    {
        // Convert the string to lowercase and remove spaces
        s = s.ToLower().Replace(" ", "");

        // Use LINQ to check if all letters of the alphabet are present
        bool isPangram = Enumerable.Range('a', 26).All(letter => s.Contains((char)letter));

        return isPangram ? "pangram" : "not pangram";
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = Result.pangrams(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
