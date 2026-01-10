// LeetCode problem and solving code
using System;
namespace day9;

public class Solution
{
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
        {
            if (nums1[i] < nums2[j])
            {
                merged[k++] = nums1[i++];
            }
            else
            {
                merged[k++] = nums2[j++];
            }
        }
        while (i < m)
        {
            merged[k++] = nums1[i++];
        }
        while (j < n)
        {
            merged[k++] = nums2[j++];
        }
        if ((m + n) % 2 == 0)
        {
            return (merged[(m + n) / 2 - 1] + merged[(m + n) / 2]) / 2.0;
        }
        else
        {
            return merged[(m + n) / 2];
        }
    }

    public static int LengthOfLongestSubstring(string s)
    {
        return wordlength(s);
    }

    private static int wordlength(string s)
    {
        int n = s.Length;
        int ans = 0;
        int[] index = new int[128]; // current index of character
        for (int j = 0, i = 0; j < n; j++)
        {
            i = Math.Max(index[s[j]], i);
            ans = Math.Max(ans, j - i + 1);
            index[s[j]] = j + 1;
        }
        return ans;
    }

    private int ExpandAroundCenter(string s, int left, int right)
    {
        while (left >= 0 && right < s.Length && s[left] == s[right])
        {
            left--;
            right++;
        }
        // after loop, right and left are one step beyond the palindrome bounds
        return right - left - 1;
    }
}






