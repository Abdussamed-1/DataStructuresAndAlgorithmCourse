// LeetCode problem and solving code
using System;
namespace day9;

public class Solution
{
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
        // return wordlength(s);


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
}






