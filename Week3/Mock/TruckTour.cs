using System;
using System.Collections.Generic;

class Result
{
    /*
     * Complete the 'truckTour' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY petrolpumps as a parameter.
     */

    public static int truckTour(List<List<int>> petrolpumps)
    {
        int n = petrolpumps.Count;

        int start = 0;
        int petrolLeft = 0;
        int petrolRequired = 0;

        for (int i = 0; i < n; i++)
        {
            int petrol = petrolpumps[i][0];
            int distance = petrolpumps[i][1];

            petrolLeft += petrol - distance;

            if (petrolLeft < 0)
            {
                // If petrolLeft becomes negative, reset and try starting from the next pump
                petrolLeft = 0;
                start = i + 1;
                petrolRequired += petrolLeft; // Add the negative petrolLeft to petrolRequired
            }
        }

        // If the total petrolLeft is greater than or equal to petrolRequired, a solution is possible
        return (petrolLeft + petrolRequired >= 0) ? start : -1;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<int>> petrolpumps = new List<List<int>>();

        for (int i = 0; i < n; i++)
        {
            petrolpumps.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(petrolpumpsTemp => Convert.ToInt32(petrolpumpsTemp)).ToList());
        }

        int result = Result.truckTour(petrolpumps);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
