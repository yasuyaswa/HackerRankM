using System;
using System.Collections.Generic;
 
class Solution
{
    static void Main()
    {
        Stack<int> all = new Stack<int>();
        Stack<int> rem = new Stack<int>();
        Stack<int> divisible = new Stack<int>();
        List<int> reverse = new List<int>();
        List<int> print = new List<int>();
        List<int> primes = new List<int>();
 
        string[] firstLine = Console.ReadLine().Split();
        int n = Convert.ToInt32(firstLine[0]);
        int q = Convert.ToInt32(firstLine[1]);
        int k = q;
        int i, j = 3;
 
        string[] secondLine = Console.ReadLine().Split();
        for (i = 0; i < n; i++)
        {
            all.Push(Convert.ToInt32(secondLine[i]));
        }
 
        primes.Add(2);
        bool div = false;
 
        while (primes.Count < k)
        {
            div = false;
            for (i = 0; i < primes.Count && primes.Count < k; i++)
            {
                if (j % primes[i] == 0)
                {
                    div = true;
                    j++;
                    break;
                }
            }
 
            if (!div)
            {
                primes.Add(j);
                j++;
            }
        }
 
        for (i = 0; i < primes.Count; i++)
        {
            reverse.Clear();
            while (all.Count > 0)
            {
                if (all.Peek() % primes[i] == 0)
                {
                    reverse.Add(all.Pop());
                }
                else
                {
                    rem.Push(all.Pop());
                }
            }
 
            divisible.Clear();
            while (rem.Count > 0)
            {
                divisible.Push(rem.Pop());
            }
 
            while (divisible.Count > 0)
            {
                all.Push(divisible.Pop());
            }
 
            reverse.Reverse();
            print.AddRange(reverse);
        }
 
        if (all.Count > 0)
        {
            while (all.Count > 0)
            {
                print.Add(all.Pop());
            }
        }
 
        foreach (int number in print)
        {
            Console.WriteLine(number);
        }
    }
}
