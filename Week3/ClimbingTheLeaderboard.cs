using System;
using System.Collections.Generic;
using System.Linq;
 
class Result
{
    public static List<int> climbingLeaderboard(List<int> ranked, List<int> player)
    {
        ranked = ranked.Distinct().ToList(); // Remove duplicates from the ranked list
        List<int> result = new List<int>();
 
        int rankedIndex = ranked.Count - 1; // Start at the end of the ranked list
        foreach (var score in player)
        {
            // Move backward in the ranked list until finding the proper position for the player's score
            while (rankedIndex >= 0 && score >= ranked[rankedIndex])
            {
                rankedIndex--;
            }
 
            // Add the rank to the result
            result.Add(rankedIndex + 2); // Add 2 because of 0-based index and ranking starts from 1
        }
 
        return result;
    }
}
 
class Solution
{
    public static void Main(string[] args)
    {
        int rankedCount = Convert.ToInt32(Console.ReadLine().Trim());
 
        List<int> ranked = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(rankedTemp => Convert.ToInt32(rankedTemp)).ToList();
 
        int playerCount = Convert.ToInt32(Console.ReadLine().Trim());
 
        List<int> player = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(playerTemp => Convert.ToInt32(playerTemp)).ToList();
 
        List<int> result = Result.climbingLeaderboard(ranked, player);
 
        Console.WriteLine(String.Join("\n", result));
    }
}
