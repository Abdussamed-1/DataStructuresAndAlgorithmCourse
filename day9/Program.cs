// LeetCode problem and solving code
using System;
using System.Collections.Generic;

namespace day9;

public static class Kata
{
    public static string Likes(string[] name)
    {
        if (name == null || name.Length == 0)
            return "no one likes this";

        return name.Length switch
        {
            1 => $"{name[0]} likes this",
            2 => $"{name[0]} and {name[1]} like this",
            3 => $"{name[0]}, {name[1]} and {name[2]} like this",
            _ => $"{name[0]}, {name[1]} and {name.Length - 2} others like this"
        };
    }
}

public class Solution
{
    // C++ -> C# conversion: intToRoman
    public string IntToRoman(int num)
    {
        var val = new (int Value, string Symbol)[]
        {
            (1000, "M"), (900, "CM"), (500, "D"), (400, "CD"),
            (100, "C"), (90, "XC"), (50, "L"), (40, "XL"),
            (10, "X"), (9, "IX"), (5, "V"), (4, "IV"),
            (1, "I"),
        };

        var res = new System.Text.StringBuilder();
        foreach (var (v, s) in val)
        {
            while (num >= v)
            {
                num -= v;
                res.Append(s);
            }
        }
        return res.ToString();
    }

    // C++ -> C# conversion: maxArea
    public int MaxArea(int[] height)
    {
        int left = 0;
        int right = height.Length - 1;
        int maxArea = 0;

        while (left < right)
        {
            int width = right - left;
            int h = Math.Min(height[left], height[right]);
            int area = width * h;
            if (area > maxArea) maxArea = area;

            if (height[left] < height[right]) left++;
            else right--;
        }

        return maxArea;
    }

    // C++ -> C# conversion: isMatch (regex matching with '.' and '*')
    public bool IsMatch(string s, string p)
    {
        if (p.Length == 0) return s.Length == 0;

        bool firstMatch = s.Length != 0 && (s[0] == p[0] || p[0] == '.');

        if (p.Length >= 2 && p[1] == '*')
        {
            return IsMatch(s, p.Substring(2)) || (firstMatch && IsMatch(s.Substring(1), p));
        }

        return firstMatch && IsMatch(s.Substring(1), p.Substring(1));
    }

    public bool IsPalindrome(int x)
    {
        if (x < 0) return false;
        int original = x;
        int reversed = 0;
        while (x != 0)
        {
            int digit = x % 10;
            reversed = reversed * 10 + digit;
            x /= 10;
        }
        return original == reversed;
    }

    public int MyAtoi(string s)
    {
        int i = 0, sign = 1;
        long result = 0;

        while (i < s.Length && s[i] == ' ') i++;

        if (i < s.Length && (s[i] == '+' || s[i] == '-'))
        {
            sign = (s[i] == '-') ? -1 : 1;
            i++;
        }

        while (i < s.Length && char.IsDigit(s[i]))
        {
            result = result * 10 + (s[i] - '0');

            if (sign == 1 && result > int.MaxValue) return int.MaxValue;
            if (sign == -1 && -result < int.MinValue) return int.MinValue;

            i++;
        }

        return (int)(sign * result);
    }

    public int Reverse(int x)
    {
        long rev = 0;
        while (x != 0)
        {
            int pop = x % 10;
            x /= 10;
            rev = rev * 10 + pop;
            if (rev > int.MaxValue || rev < int.MinValue) return 0;
        }
        return (int)rev;
    }

    public string Convert(string s, int numRows)
    {
        if (numRows == 1 || numRows >= s.Length) return s;

        var rows = new List<System.Text.StringBuilder>(Math.Min(numRows, s.Length));
        for (int i = 0; i < Math.Min(numRows, s.Length); i++)
            rows.Add(new System.Text.StringBuilder());

        int curRow = 0;
        bool goingDown = false;

        foreach (char c in s)
        {
            rows[curRow].Append(c);
            if (curRow == 0 || curRow == numRows - 1) goingDown = !goingDown;
            curRow += goingDown ? 1 : -1;
        }

        var ret = new System.Text.StringBuilder();
        foreach (var row in rows) ret.Append(row);
        return ret.ToString();
    }

    public string LongestPalindrome(string s)
    {
        int start = 0, end = 0;
        for (int i = 0; i < s.Length; i++)
        {
            int len1 = ExpandAroundCenter(s, i, i);
            int len2 = ExpandAroundCenter(s, i, i + 1);
            int len = Math.Max(len1, len2);
            if (len > end - start)
            {
                start = i - (len - 1) / 2;
                end = i + len / 2;
            }
        }
        return s.Substring(start, end - start + 1);
    }

    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        int m = nums1.Length;
        int n = nums2.Length;
        int[] merged = new int[m + n];
        int i = 0, j = 0, k = 0;

        while (i < m && j < n)
            merged[k++] = (nums1[i] < nums2[j]) ? nums1[i++] : nums2[j++];

        while (i < m) merged[k++] = nums1[i++];
        while (j < n) merged[k++] = nums2[j++];

        int total = m + n;
        if (total % 2 == 0)
            return (merged[total / 2 - 1] + merged[total / 2]) / 2.0;

        return merged[total / 2];
    }

    public static int LengthOfLongestSubstring(string s) => WordLength(s);

    private static int WordLength(string s)
    {
        int n = s.Length;
        int ans = 0;
        int[] index = new int[128];

        for (int j = 0, i = 0; j < n; j++)
        {
            i = Math.Max(index[s[j]], i);
            ans = Math.Max(ans, j - i + 1);
            index[s[j]] = j + 1;
        }

        return ans;
    }

    private static int ExpandAroundCenter(string s, int left, int right)
    {
        while (left >= 0 && right < s.Length && s[left] == s[right])
        {
            left--;
            right++;
        }
        return right - left - 1;
    }
}