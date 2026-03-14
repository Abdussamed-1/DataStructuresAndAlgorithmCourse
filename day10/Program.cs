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
/*
class Result
{
     * Complete the 'reverseArray' function below.
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY a as parameter.
     
    public static List<int> reverseArray(List<int> a)
    {
        a.Reverse();
        return a;
    }
}*/
namespace day10
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    public class Solution
    {

        public int SearchInsert(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                    return mid;
                else if (nums[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return left; // Left is the insertion point
        }

        public int[] SearchRange(int[] nums, int target)
        {
            int[] result = new int[2] { -1, -1 };
            int left = 0, right = nums.Length - 1;
            // Find the leftmost index
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            if (left >= nums.Length || nums[left] != target)
                return result; // Target not found
            result[0] = left;
            // Find the rightmost index
            right = nums.Length - 1; // Reset right pointer
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] > target)
                    right = mid - 1;
                else
                    left = mid + 1;
            }
            result[1] = right;
            return result;
        }
        public int[] SearchRange(int[] nums, int target)
        {
            int[] result = new int[2] { -1, -1 };
            int left = 0, right = nums.Length - 1;
            // Find the leftmost index
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            if (left >= nums.Length || nums[left] != target)
                return result; // Target not found
            result[0] = left;
            // Find the rightmost index
            right = nums.Length - 1; // Reset right pointer
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] > target)
                    right = mid - 1;
                else
                    left = mid + 1;
            }
            result[1] = right;
            return result;
        }
        public int Search(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                    return mid;
                if (nums[left] <= nums[mid]) // Left half is sorted
                {
                    if (nums[left] <= target && target < nums[mid])
                        right = mid - 1; // Target is in the left half
                    else
                        left = mid + 1; // Target is in the right half
                }
                else // Right half is sorted
                {
                    if (nums[mid] < target && target <= nums[right])
                        left = mid + 1; // Target is in the right half
                    else
                        right = mid - 1; // Target is in the left half
                }
            }
            return -1; // Target not found
        }
        public int LongestValidParentheses(string s)
        {
            int maxLength = 0;
            Stack<int> stack = new Stack<int>();
            stack.Push(-1); // Base index for valid parentheses
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(i); // Push the index of '('
                }
                else
                {
                    stack.Pop(); // Pop the last '(' index
                    if (stack.Count == 0)
                    {
                        stack.Push(i); // Push the current index as base for future valid parentheses
                    }
                    else
                    {
                        maxLength = Math.Max(maxLength, i - stack.Peek());
                    }
                }
            }
            return maxLength;
        }
        public void NextPermutation(int[] nums)
        {
            if (nums == null || nums.Length <= 1) return;

            int i = nums.Length - 2;
            while (i >= 0 && nums[i] >= nums[i + 1])
                i--;

            if (i >= 0)
            {
                int j = nums.Length - 1;
                while (nums[j] <= nums[i])
                    j--;
                Swap(nums, i, j);
            }

            Reverse(nums, i + 1);
        }

        private void Swap(int[] nums, int i, int j)
        {
            int tmp = nums[i];
            nums[i] = nums[j];
            nums[j] = tmp;
        }

        private void Reverse(int[] nums, int start)
        {
            int i = start, j = nums.Length - 1;
            while (i < j)
            {
                Swap(nums, i, j);
                i++;
                j--;
            }
        }

        public IList<int> FindSubstring(string s, string[] words)
        {
            IList<int> result = new List<int>();
            if (string.IsNullOrEmpty(s) || words == null || words.Length == 0)
                return result;

            int wordLength = words[0].Length;
            int totalWordsLength = wordLength * words.Length;
            int wordsCount = words.Length;

            if (s.Length < totalWordsLength)
                return result;

            // Count frequency of each word
            var wordCount = new Dictionary<string, int>();
            foreach (var word in words)
            {
                wordCount[word] = wordCount.GetValueOrDefault(word, 0) + 1;
            }

            // Try each possible starting offset (0 to wordLength-1)
            for (int offset = 0; offset < wordLength; offset++)
            {
                var seenWords = new Dictionary<string, int>();
                int left = offset;
                int matchedWords = 0;

                // Sliding window approach
                for (int right = offset; right <= s.Length - wordLength; right += wordLength)
                {
                    string word = s.Substring(right, wordLength);

                    if (wordCount.ContainsKey(word))
                    {
                        seenWords[word] = seenWords.GetValueOrDefault(word, 0) + 1;
                        matchedWords++;

                        // If we have too many of this word, shrink window from left
                        while (seenWords[word] > wordCount[word])
                        {
                            string leftWord = s.Substring(left, wordLength);
                            seenWords[leftWord]--;
                            if (seenWords[leftWord] == 0)
                                seenWords.Remove(leftWord);
                            matchedWords--;
                            left += wordLength;
                        }

                        // If we have exactly the right number of words, we found a match
                        if (matchedWords == wordsCount)
                        {
                            result.Add(left);

                            // Move left pointer to start looking for next match
                            string leftWord = s.Substring(left, wordLength);
                            seenWords[leftWord]--;
                            if (seenWords[leftWord] == 0)
                                seenWords.Remove(leftWord);
                            matchedWords--;
                            left += wordLength;
                        }
                    }
                    else
                    {
                        // Reset everything if we encounter a word not in our list
                        seenWords.Clear();
                        matchedWords = 0;
                        left = right + wordLength;
                    }
                }
            }
            return result;
        }
        public int Divide(int dividend, int divisor)
        { 
            if (divisor == 0) throw new DivideByZeroException();
            if (dividend == int.MinValue && divisor == -1) return int.MaxValue;
            int sign = ((dividend < 0) ^ (divisor < 0)) ? -1 : 1;
            long dividendL = Math.Abs((long)dividend);
            long divisorL = Math.Abs((long)divisor);
            long quotient = 0;
            while (dividendL >= divisorL)
            {
                long tempDivisor = divisorL, multiple = 1;
                while (dividendL >= (tempDivisor << 1))
                {
                    tempDivisor <<= 1;
                    multiple <<= 1;
                }
                dividendL -= tempDivisor;
                quotient += multiple;
            }
            return (int)(sign * quotient);
        }
        public int StrStr(string haystack, string needle)
        {
            if (string.IsNullOrEmpty(needle))
                return 0;
            for (int i = 0; i <= haystack.Length - needle.Length; i++)
            {
                if (haystack.Substring(i, needle.Length) == needle)
                    return i;
            }
            return -1; 
        }
        public int RemoveElement(int[] nums, int val)
        {
            int newLength = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    nums[newLength] = nums[i];
                    newLength++;
                }
            }
            return newLength;
        }
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0) return 0;
            int uniqueCount = 1; // Start with the first element as unique
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != nums[uniqueCount - 1])
                {
                    nums[uniqueCount] = nums[i];
                    uniqueCount++;
                }
            }
            return uniqueCount;

        }
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            if (head == null || k <= 1)
                return head;
            var dummy = new ListNode(0);
            dummy.next = head;
            var prevGroupEnd = dummy;
            while (true)
            {
                var kthNode = GetKthNode(prevGroupEnd, k);
                if (kthNode == null)
                    break;
                var groupStart = prevGroupEnd.next;
                var nextGroupStart = kthNode.next;
                // Reverse the current group
                var prev = nextGroupStart;
                var current = groupStart;
                while (current != nextGroupStart)
                {
                    var tempNext = current.next;
                    current.next = prev;
                    prev = current;
                    current = tempNext;
                }
                // Connect the previous group with the reversed current group
                prevGroupEnd.next = kthNode;
                prevGroupEnd = groupStart; // Move to the end of the reversed group
            }
            return dummy.next;

        }
        private ListNode GetKthNode(ListNode start, int k)
        {
            var current = start;
            while (current != null && k > 0)
            {
                current = current.next;
                k--;
            }
            return current;
        }
        public ListNode SwapPairs(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            var first = head;
            var second = head.next;
            first.next = SwapPairs(second.next);
            second.next = first;
            return second;
        }
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0) return null;

            var pq = new PriorityQueue<ListNode, int>();

            for (int i = 0; i < lists.Length; i++)
            {
                if (lists[i] != null)
                    pq.Enqueue(lists[i], lists[i].val);
            }

            var dummy = new ListNode(0);
            var tail = dummy;

            while (pq.Count > 0)
            {
                var node = pq.Dequeue();
                tail.next = node;
                tail = node;

                if (node.next != null)
                    pq.Enqueue(node.next, node.next.val);
            }

            tail.next = null;
            return dummy.next;
        }
        public IList<string> GenerateParenthesis(int n)
        {
            IList<string> result = new List<string>();
            GenerateParenthesisHelper(result, "", 0, 0, n);
            return result;
        }
        private void GenerateParenthesisHelper(IList<string> result, string current, int open, int close, int n)
        {
            if (current.Length == 2 * n)
            {
                result.Add(current);
                return;
            }

            if (open < n)
                GenerateParenthesisHelper(result, current + "(", open + 1, close, n);

            if (close < open)
                GenerateParenthesisHelper(result, current + ")", open, close + 1, n);
        }
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            if (list1 == null)
                return list2;
            if (list2 == null)
                return list1;
            if (list1.val < list2.val)
            {
                list1.next = MergeTwoLists(list1.next, list2);
                return list1;
            }
            else
            {
                list2.next = MergeTwoLists(list1, list2.next);
                return list2;
            }
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            int sayac = 1;
            while (sayac <= 10)
            {
                Console.WriteLine("{0,-3} {1,-3}", sayac, sayac * sayac);
                sayac += 1;
            }

            Console.ReadKey();
        }
    }
}