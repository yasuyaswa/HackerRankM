using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;
 
public class Solution
{
    int md = 1000000007;
    int[,] ways = new int[1001, 1001];
    int[,] waysRestrict = new int[1001, 1001];
 
    public Solution()
    {
        for (int i = 0; i < 1001; i++)
        {
            for (int j = 0; j < 1001; j++)
            {
                ways[i, j] = -1;
                waysRestrict[i, j] = -1;
            }
        }
    }
 
    public int Solve(int n, int m)
    {
        if (ways[n, m] != -1)
            return ways[n, m];
 
        long ans;
 
        if (m == 1)
            ans = 1;
        else if (n == 1)
        {
            if (m <= 4)
            {
                ans = 2 * Solve(1, m - 1);
            }
            else
            {
                ans = Solve(1, m - 1);
                ans = (ans + Solve(1, m - 2)) % md;
                ans = (ans + Solve(1, m - 3)) % md;
                ans = (ans + Solve(1, m - 4)) % md;
            }
        }
        else
        {
            ans = 1;
            int one = Solve(1, m);
 
            for (int i = 0; i < n; i++)
            {
                ans = (ans * one) % md;
            }
        }
 
        ways[n, m] = (int)ans;
        return ways[n, m];
    }
 
    public int SolveRestrict(int n, int m)
    {
        if (waysRestrict[n, m] != -1)
            return waysRestrict[n, m];
 
        long ans;
 
        if (m == 1)
            ans = 1;
        else
        {
            ans = Solve(n, m);
 
            for (int i = 1; i < m; i++)
            {
                long a = Solve(n, i);
                a = (a * SolveRestrict(n, m - i)) % md;
                ans -= a;
 
                if (ans < 0)
                    ans += md;
            }
        }
 
        waysRestrict[n, m] = (int)ans;
        return waysRestrict[n, m];
    }
 
    public static void Main(string[] args)
    {
        Solution o = new Solution();
        int n = Convert.ToInt32(Console.ReadLine());
 
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            int a = Convert.ToInt32(input[0]);
            int b = Convert.ToInt32(input[1]);
 
            Console.WriteLine(o.SolveRestrict(a, b));
        }
    }
}
