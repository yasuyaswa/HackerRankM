using System;
using System.Collections.Generic;
using System.Linq;
 
class Result
{
    public static string isValid(string s)
    {
        Dictionary<char, int> charFrequency = new Dictionary<char, int>();
 
        // Count the frequency of each character in the string
        foreach (char c in s)
        {
            if (charFrequency.ContainsKey(c))
                charFrequency[c]++;
            else
                charFrequency[c] = 1;
        }
 
        // Count the frequency occurrences
        Dictionary<int, int> frequencyCount = new Dictionary<int, int>();
        foreach (var item in charFrequency)
        {
            if (frequencyCount.ContainsKey(item.Value))
                frequencyCount[item.Value]++;
            else
                frequencyCount[item.Value] = 1;
        }
 
        // If all characters occur with the same frequency, it's already valid
        if (frequencyCount.Count == 1)
            return "YES";
 
        // If there are exactly two frequencies
        if (frequencyCount.Count == 2)
        {
            var frequencies = frequencyCount.Keys.ToList();
            var counts = frequencyCount.Values.ToList();
 
            if ((counts[0] == 1 && (frequencies[0] == 1 || frequencies[0] - frequencies[1] == 1))
                || (counts[1] == 1 && (frequencies[1] == 1 || frequencies[1] - frequencies[0] == 1)))
                return "YES";
        }
 
        return "NO";
    }
}
 
class Solution
{
    public static void Main(string[] args)
    {
        string s = Console.ReadLine();
 
        string result = Result.isValid(s);
 
        Console.WriteLine(result);
    }
}
