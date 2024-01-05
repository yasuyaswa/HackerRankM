using System;
using System.Collections.Generic;
 
class Result
{
    private static readonly int[][] DIRS = { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 } };
 
    public static int bfs(List<string> grid, int startX, int startY, int goalX, int goalY)
    {
        int N = grid.Count;
        bool[,] visited = new bool[N, N];
        Queue<int[]> queue = new Queue<int[]>();
        queue.Enqueue(new int[] { startX, startY });
        int moves = 0;
 
        while (queue.Count > 0)
        {
            int size = queue.Count;
            moves++;
 
            for (int i = 0; i < size; i++)
            {
                int[] pair = queue.Dequeue();
                int x = pair[0], y = pair[1];
 
                foreach (int[] dir in DIRS)
                {
                    int nextX = x;
                    int nextY = y;
 
                    while (true)
                    {
                        nextX += dir[0];
                        nextY += dir[1];
 
                        if (nextX < 0 || nextX >= N || nextY < 0 || nextY >= N || grid[nextX][nextY] == 'X')
                            break;
 
                        if (nextX == goalX && nextY == goalY)
                        {
                            return moves;
                        }
                        else if (!visited[nextX, nextY])
                        {
                            visited[nextX, nextY] = true;
                            queue.Enqueue(new int[] { nextX, nextY });
                        }
                    }
                }
            }
        }
 
        return -1;
    }
}
 
class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());
 
        List<string> grid = new List<string>();
 
        for (int i = 0; i < n; i++)
        {
            string gridItem = Console.ReadLine();
            grid.Add(gridItem);
        }
 
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
 
        int startX = Convert.ToInt32(firstMultipleInput[0]);
        int startY = Convert.ToInt32(firstMultipleInput[1]);
        int goalX = Convert.ToInt32(firstMultipleInput[2]);
        int goalY = Convert.ToInt32(firstMultipleInput[3]);
 
        int result = Result.bfs(grid, startX, startY, goalX, goalY);
 
        Console.WriteLine(result);
    }
}
