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
        public int TotalNQueens(int n)
        {
            int count = 0;
            char[][] board = new char[n][];
            for (int i = 0; i < n; i++)
                board[i] = new string('.', n).ToCharArray();
            bool[] cols = new bool[n];
            bool[] diag1 = new bool[2 * n - 1]; // row - col + (n - 1)
            bool[] diag2 = new bool[2 * n - 1]; // row + col
            TotalNQueensHelper(0, n, board, cols, diag1, diag2, ref count);
            return count;
        }
        public IList<IList<string>> SolveNQueens(int n)
        {
            IList<IList<string>> result = new List<IList<string>>();
            char[][] board = new char[n][];

            for (int i = 0; i < n; i++)
                board[i] = new string('.', n).ToCharArray();

            bool[] cols = new bool[n];
            bool[] diag1 = new bool[2 * n - 1]; // row - col + (n - 1)
            bool[] diag2 = new bool[2 * n - 1]; // row + col

            SolveNQueensHelper(0, n, board, cols, diag1, diag2, result);
            return result;
        }

        private void SolveNQueensHelper(
            int row,
            int n,
            char[][] board,
            bool[] cols,
            bool[] diag1,
            bool[] diag2,
            IList<IList<string>> result)
        {
            if (row == n)
            {
                var solution = new List<string>(n);
                for (int i = 0; i < n; i++)
                    solution.Add(new string(board[i]));
                result.Add(solution);
                return;
            }

            for (int col = 0; col < n; col++)
            {
                int d1 = row - col + n - 1;
                int d2 = row + col;

                if (cols[col] || diag1[d1] || diag2[d2])
                    continue;

                board[row][col] = 'Q';
                cols[col] = diag1[d1] = diag2[d2] = true;
                    
                SolveNQueensHelper(row + 1, n, board, cols, diag1, diag2, result);

                board[row][col] = '.';
                cols[col] = diag1[d1] = diag2[d2] = false;
            }
        }
        public double MyPow(double x, int n)
        {
            if (n == 0) return 1;
            
            long N = n;
            if (N < 0)
            {
                x = 1 / x;
                N = -N;
            }
            
            return PowHelper(x, N);
        }

        private double PowHelper(double x, long n)
        {
            if (n == 0) return 1;
            double half = PowHelper(x, n / 2);
            return n % 2 == 0 ? half * half : half * half * x;
        }
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var anagramGroups = new Dictionary<string, List<string>>();
            foreach (var str in strs)
            {
                var charArray = str.ToCharArray();
                Array.Sort(charArray);
                var key = new string(charArray);
                if (!anagramGroups.ContainsKey(key))
                {
                    anagramGroups[key] = new List<string>();
                }
                anagramGroups[key].Add(str);
            }
            return anagramGroups.Values.ToList<IList<string>>();
        }
        public void Rotate(int[][] matrix)
        {
            int n = matrix.Length;
            for (int i = 0; i < n / 2; i++)
            {
                for (int j = i; j < n - 1 - i; j++)
                {
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[n - 1 - j][i];
                    matrix[n - 1 - j][i] = matrix[n - 1 - i][n - 1 - j];
                    matrix[n - 1 - i][n - 1 - j] = matrix[j][n - 1 - i];
                    matrix[j][n - 1 - i] = temp;
                }
            }
        }
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Array.Sort(nums); // Sort to handle duplicates
            bool[] used = new bool[nums.Length];
            
            // Inline backtracking logic
            void Backtrack(List<int> current)
            {
                if (current.Count == nums.Length)
                {
                    result.Add(new List<int>(current));
                    return;
                }

                for (int i = 0; i < nums.Length; i++)
                {
                    // Skip if already used
                    if (used[i])
                        continue;

                    // Skip duplicates: if current number equals previous and previous is not used
                    if (i > 0 && nums[i] == nums[i - 1] && !used[i - 1])
                        continue;

                    // Choose
                    current.Add(nums[i]);
                    used[i] = true;

                    // Recurse
                    Backtrack(current);

                    // Unchoose
                    current.RemoveAt(current.Count - 1);
                    used[i] = false;
                }
            }

            Backtrack(new List<int>());
            return result;
        }
        public IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            BacktrackPermute(nums, new List<int>(), new bool[nums.Length], result);
            return result;
        }

        private void BacktrackPermute(int[] nums, List<int> current, bool[] used, IList<IList<int>> result)
        {
            // Base case: if we've used all numbers, add the permutation to result
            if (current.Count == nums.Length)
            {
                result.Add(new List<int>(current));
                return;
            }

            // Try each number as the next element
            for (int i = 0; i < nums.Length; i++)
            {
                // Skip if this number is already used
                if (used[i])
                    continue;

                // Choose the number
                current.Add(nums[i]);
                used[i] = true;

                // Recursively build the rest of the permutation
                BacktrackPermute(nums, current, used, result);

                // Backtrack: undo the choice
                current.RemoveAt(current.Count - 1);
                used[i] = false;
            }
        }
        public int Jump(int[] nums)
        {
            int jumps = 0;
            int currentMaxReach = 0;
            int nextMaxReach = 0;

            // We don't need to jump from the last index
            for (int i = 0; i < nums.Length - 1; i++)
            {
                // Update the farthest we can reach from current position
                nextMaxReach = Math.Max(nextMaxReach, i + nums[i]);

                // If we've reached the end of current jump range
                if (i == currentMaxReach)
                {
                    jumps++;
                    currentMaxReach = nextMaxReach;

                    // If we can already reach the last index, break early
                    if (currentMaxReach >= nums.Length - 1)
                        break;
                }
            }

            return jumps;
        }
        public bool IsMatch(string s, string p)
        {
            int m = s.Length, n = p.Length;
            bool[,] dp = new bool[m + 1, n + 1];
            dp[0, 0] = true;
            for (int j = 1; j <= n; j++)
            {
                if (p[j - 1] == '*')
                    dp[0, j] = dp[0, j - 2];
            }
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (p[j - 1] == '.' || p[j - 1] == s[i - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else if (p[j - 1] == '*')
                    {
                        dp[i, j] = dp[i, j - 2]; // Zero occurrence
                        if (p[j - 2] == '.' || p[j - 2] == s[i - 1])
                        {
                            dp[i, j] |= dp[i - 1, j]; // One or more occurrences
                        }
                    }
                }
            }
            return dp[m, n];
        }
        public string Multiply(string num1, string num2)
        {
            if (num1 == "0" || num2 == "0") return "0";
            int m = num1.Length, n = num2.Length;
            int[] result = new int[m + n];
            for (int i = m - 1; i >= 0; i--)
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    int mul = (num1[i] - '0') * (num2[j] - '0');
                    int sum = mul + result[i + j + 1];
                    result[i + j + 1] = sum % 10;
                    result[i + j] += sum / 10;
                }
            }
            StringBuilder sb = new StringBuilder();
            foreach (var digit in result)
            {
                if (!(sb.Length == 0 && digit == 0)) // Skip leading zeros
                    sb.Append(digit);
            }
            return sb.Length == 0 ? "0" : sb.ToString();
        }
        public int Trap(int[] height)
        {

            int left = 0, right = height.Length - 1;
            int leftMax = 0, rightMax = 0;
            int trappedWater = 0;
            while (left < right)
            {
                if (height[left] < height[right])
                {
                    leftMax = Math.Max(leftMax, height[left]);
                    trappedWater += leftMax - height[left];
                    left++;
                }
                else
                {
                    rightMax = Math.Max(rightMax, height[right]);
                    trappedWater += rightMax - height[right];
                    right--;
                }
            }
            return trappedWater;
        }

        public int FirstMissingPositive(int[] nums)
        {
            int n = nums.Length;
            for (int i = 0; i < n; i++)
            {
                while (nums[i] > 0 && nums[i] <= n && nums[nums[i] - 1] != nums[i])
                {
                    // Swap nums[i] with nums[nums[i] - 1]
                    int temp = nums[nums[i] - 1];
                    nums[nums[i] - 1] = nums[i];
                    nums[i] = temp;
                }
            }
            for (int i = 0; i < n; i++)
            {
                if (nums[i] != i + 1)
                    return i + 1;
            }
            return n + 1;
        }
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
            {
                IList<IList<int>> result = new List<IList<int>>();
                Array.Sort(candidates); // Sort to help with pruning and skipping duplicates
                Backtrack(candidates, target, 0, new List<int>(), result);
                return result;
            }

        private void Backtrack(int[] candidates, int target, int start, List<int> current, IList<IList<int>> result)
        {
            // Base case: if target becomes 0, we found a valid combination
            if (target == 0)
            {
                result.Add(new List<int>(current));
                return;
            }

            // If target becomes negative, stop exploring this path
            if (target < 0)
                return;

            // Explore all candidates starting from 'start' index
            for (int i = start; i < candidates.Length; i++)
            {
                // Skip duplicates: if current candidate equals previous and we're not at start
                if (i > start && candidates[i] == candidates[i - 1])
                    continue;

                // Pruning: if candidate is greater than target, stop (array is sorted)
                if (candidates[i] > target)
                    break;

                // Choose the candidate
                current.Add(candidates[i]);

                // Recursively explore with the next index (each number used only once)
                Backtrack(candidates, target - candidates[i], i + 1, current, result);

                // Unchoose the candidate (backtrack)
                current.RemoveAt(current.Count - 1);
            }
        }
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Array.Sort(candidates); // Sort to help with pruning
            Backtrack(candidates, target, 0, new List<int>(), result);
            return result;
        }

        private void Backtrack(int[] candidates, int target, int start, List<int> current, IList<IList<int>> result)
        {
            // Base case: if target becomes 0, we found a valid combination
            if (target == 0)
            {
                result.Add(new List<int>(current));
                return;
            }

            // If target becomes negative, stop exploring this path
            if (target < 0)
                return;

            // Explore all candidates starting from 'start' index
            for (int i = start; i < candidates.Length; i++)
            {
                // Pruning: if candidate is greater than target, stop (array is sorted)
                if (candidates[i] > target)
                    break;

                // Choose the candidate
                current.Add(candidates[i]);

                // Recursively explore with the same start index (allowing reuse)
                Backtrack(candidates, target - candidates[i], i, current, result);

                // Unchoose the candidate (backtrack)
                current.RemoveAt(current.Count - 1);
            }
        }
        public string CountAndSay(int n)
        {   if (n == 1) return "1";
            string prev = CountAndSay(n - 1);
            StringBuilder sb = new StringBuilder();
            int count = 1;
            for (int i = 1; i < prev.Length; i++)
            {
                if (prev[i] == prev[i - 1])
                {
                    count++;
                }
                else
                {
                    sb.Append(count).Append(prev[i - 1]);
                    count = 1;
                }
            }
            sb.Append(count).Append(prev[prev.Length - 1]);
            return sb.ToString();
        }
        public void SolveSudoku(char[][] board)
        {
            Solve(board);
        }
        public bool IsValidSudoku(char[][] board)
        {
            HashSet<string> seen = new HashSet<string>();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    char number = board[i][j];
                    if (number != '.')
                    {
                        string rowKey = $"row{i}-{number}";
                        string colKey = $"col{j}-{number}";
                        string boxKey = $"box{i / 3}-{j / 3}-{number}";
                        if (seen.Contains(rowKey) || seen.Contains(colKey) || seen.Contains(boxKey))
                            return false;
                        seen.Add(rowKey);
                        seen.Add(colKey);
                        seen.Add(boxKey);
                    }
                }
            }
            return true;
        }
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
        private bool Solve(char[][] board)
        {
            const int N = 9;
            int[] rows = new int[N], cols = new int[N], boxes = new int[N];
            var empties = new List<(int r, int c)>();

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (board[i][j] == '.')
                    {
                        empties.Add((i, j));
                    }
                    else
                    {
                        int v = board[i][j] - '1'; // 0..8
                        int mask = 1 << v;
                        rows[i] |= mask;
                        cols[j] |= mask;
                        boxes[(i / 3) * 3 + (j / 3)] |= mask;
                    }
                }
            }

            bool Dfs(int idx)
            {
                if (idx == empties.Count) return true;
                var (r, c) = empties[idx];
                int b = (r / 3) * 3 + (c / 3);
                int used = rows[r] | cols[c] | boxes[b];

                for (int d = 0; d < 9; d++)
                {
                    int mask = 1 << d;
                    if ((used & mask) != 0) continue;
                    // place digit
                    rows[r] |= mask;
                    cols[c] |= mask;
                    boxes[b] |= mask;
                    board[r][c] = (char)('1' + d);

                    if (Dfs(idx + 1)) return true;

                    // undo
                    board[r][c] = '.';
                    rows[r] &= ~mask;
                    cols[c] &= ~mask;
                    boxes[b] &= ~mask;
                }
                return false;
            }

            Dfs(0);
            return true;
        }
        private void TotalNQueensHelper(
            int row,
            int n,
            char[][] board,
            bool[] cols,
            bool[] diag1,
            bool[] diag2,
            ref int count)
        {
            if (row == n)
            {
                count++;
                return;
            }

            for (int col = 0; col < n; col++)
            {
                int d1 = row - col + n - 1;
                int d2 = row + col;

                if (cols[col] || diag1[d1] || diag2[d2])
                    continue;

                board[row][col] = 'Q';
                cols[col] = diag1[d1] = diag2[d2] = true;

                TotalNQueensHelper(row + 1, n, board, cols, diag1, diag2, ref count);

                board[row][col] = '.';
                cols[col] = diag1[d1] = diag2[d2] = false;
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