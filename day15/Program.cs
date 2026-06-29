using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

class Program
{
    public int MinPathSum(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        for (int i = 1; i < m; i++)
        {
            grid[i][0] += grid[i - 1][0];
        }
        for (int j = 1; j < n; j++)
        {
            grid[0][j] += grid[0][j - 1];
        }
        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                grid[i][j] += Math.Min(grid[i - 1][j], grid[i][j - 1]);
            }
        }
        return grid[m - 1][n - 1];
    }
    public static void Main(string[] args)
    {
       for (int i = 0; i < 50; i+=1)
        {
            Console.WriteLine(i);
        }

        Console.WriteLine("Can you input number:");
        int n = Convert.ToInt32(Console.ReadLine());
        
        int i = 2;
        do
        {
            Console.WriteLine(i);
            i += 2; // i = i + 2;
        } while (i <= n);

        // 0'dan 10'a kadar
        int sayac = 0;
        while (sayac <= 10)
        {
            Console.WriteLine("{0,-3} {1,-3}", sayac, sayac * sayac);
            sayac++;
        }

        Console.WriteLine("----------");

        // 10'dan 0'a kadar
        sayac = 10;
        while (sayac >= 0)
        {
            Console.WriteLine("{0,-3} {1,-3}", sayac, sayac * sayac);
            sayac--;
        }

        Console.ReadKey();
    }

    public ListNode ReverseBetween(ListNode head, int left, int right)
    {
        if (head == null || left == right)
            return head;
        ListNode dummy = new ListNode(0);
        dummy.next = head;
        ListNode prev = dummy;
        for (int i = 1; i < left; i++)
            prev = prev.next;
        ListNode current = prev.next;
        ListNode next = null;
        for (int i = 0; i < right - left; i++)
        {
            next = current.next;
            current.next = next.next;
            next.next = prev.next;
            prev.next = next;
        }
        return dummy.next;
    }
    public bool IsScramble(string s1, string s2)
    {
        if (s1.Length != s2.Length)
            return false;

        var memo = new System.Collections.Generic.Dictionary<string, bool>();

        System.Func<string, string, bool> dfs = null;
        dfs = (a, b) =>
        {
            string key = a + "#" + b;
            if (memo.TryGetValue(key, out bool cached))
                return cached;

            if (a.Equals(b))
            {
                memo[key] = true;
                return true;
            }

            int n = a.Length;
            int[] count = new int[26];
            for (int i = 0; i < n; i++)
            {
                count[a[i] - 'a']++;
                count[b[i] - 'a']--;
            }
            for (int i = 0; i < 26; i++)
            {
                if (count[i] != 0)
                {
                    memo[key] = false;
                    return false;
                }
            }

            for (int i = 1; i < n; i++)
            {
                // no swap
                if (dfs(a.Substring(0, i), b.Substring(0, i)) && dfs(a.Substring(i), b.Substring(i)))
                {
                    memo[key] = true;
                    return true;
                }
                // swap
                if (dfs(a.Substring(0, i), b.Substring(n - i)) && dfs(a.Substring(i), b.Substring(0, n - i)))
                {
                    memo[key] = true;
                    return true;
                }
            }

            memo[key] = false;
            return false;
        };

        return dfs(s1, s2);
    }
}