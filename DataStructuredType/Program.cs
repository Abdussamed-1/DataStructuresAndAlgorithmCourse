using System;
using System.Collections.Generic;
using System.Linq;

namespace Datastructuredpaths
{
    // Linked list soruları için temel node sınıfı.
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

    public class ArrayProblems
    {
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            int maxCount = 0;
            int currentCount = 0;

            foreach (int num in nums)
            {
                if (num == 1)
                {
                    currentCount++;
                    maxCount = Math.Max(maxCount, currentCount);
                }
                else
                {
                    currentCount = 0;
                }
            }

            return maxCount;
        }

        public int[] Shuffle(int[] nums, int n)
        {
            int[] result = new int[2 * n];

            for (int i = 0; i < n; i++)
            {
                result[2 * i] = nums[i];
                result[2 * i + 1] = nums[i + n];
            }

            return result;
        }

        public int[] GetConcatenation(int[] nums)
        {
            int n = nums.Length;
            int[] result = new int[2 * n];

            for (int i = 0; i < n; i++)
            {
                result[i] = nums[i];
                result[i + n] = nums[i];
            }

            return result;
        }

        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            int n = nums.Length;
            IList<int> result = new List<int>();

            for (int i = 0; i < n; i++)
            {
                int index = Math.Abs(nums[i]) - 1;

                if (nums[index] > 0)
                {
                    nums[index] = -nums[index];
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (nums[i] > 0)
                {
                    result.Add(i + 1);
                }
            }

            return result;
        }

        public int[] SmallerNumbersThanCurrent(int[] nums)
        {
            int n = nums.Length;
            int[] result = new int[n];

            for (int i = 0; i < n; i++)
            {
                int count = 0;

                for (int j = 0; j < n; j++)
                {
                    if (nums[j] < nums[i])
                    {
                        count++;
                    }
                }

                result[i] = count;
            }

            return result;
        }

        public int[] FindErrorNums(int[] nums)
        {
            int n = nums.Length;
            int[] result = new int[2];

            for (int i = 0; i < n; i++)
            {
                int index = Math.Abs(nums[i]) - 1;

                if (nums[index] < 0)
                {
                    result[0] = index + 1; // tekrar eden sayı
                }
                else
                {
                    nums[index] = -nums[index];
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (nums[i] > 0)
                {
                    result[1] = i + 1; // eksik sayı
                    break;
                }
            }

            return result;
        }

        public int[] PlusOne(int[] digits)
        {
            int n = digits.Length;

            for (int i = n - 1; i >= 0; i--)
            {
                if (digits[i] < 9)
                {
                    digits[i]++;
                    return digits;
                }

                digits[i] = 0;
            }

            int[] result = new int[n + 1];
            result[0] = 1;

            return result;
        }

        public bool ValidMountainArray(int[] arr)
        {
            int n = arr.Length;

            if (n < 3)
            {
                return false;
            }

            int i = 0;

            while (i + 1 < n && arr[i] < arr[i + 1])
            {
                i++;
            }

            if (i == 0 || i == n - 1)
            {
                return false;
            }

            while (i + 1 < n && arr[i] > arr[i + 1])
            {
                i++;
            }

            return i == n - 1;
        }

        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int i = m - 1;
            int j = n - 1;
            int k = m + n - 1;

            while (i >= 0 && j >= 0)
            {
                if (nums1[i] > nums2[j])
                {
                    nums1[k--] = nums1[i--];
                }
                else
                {
                    nums1[k--] = nums2[j--];
                }
            }

            while (j >= 0)
            {
                nums1[k--] = nums2[j--];
            }
        }
    }

    public class StackProblems
    {
        public int[] ExclusiveTime(int n, IList<string> logs)
        {
            int[] result = new int[n];
            Stack<int> stack = new Stack<int>();
            int previousTime = 0;

            foreach (string log in logs)
            {
                string[] parts = log.Split(':');

                int id = int.Parse(parts[0]);
                string type = parts[1];
                int time = int.Parse(parts[2]);

                if (type == "start")
                {
                    if (stack.Count > 0)
                    {
                        result[stack.Peek()] += time - previousTime;
                    }

                    stack.Push(id);
                    previousTime = time;
                }
                else
                {
                    result[stack.Pop()] += time - previousTime + 1;
                    previousTime = time + 1;
                }
            }

            return result;
        }

        public IList<string> BuildArray(int[] target, int n)
        {
            IList<string> result = new List<string>();
            int targetIndex = 0;

            for (int number = 1; number <= n && targetIndex < target.Length; number++)
            {
                result.Add("Push");

                if (target[targetIndex] == number)
                {
                    targetIndex++;
                }
                else
                {
                    result.Add("Pop");
                }
            }

            return result;
        }

        public int EvalRPN(string[] tokens)
        {
            Stack<int> stack = new Stack<int>();

            foreach (string token in tokens)
            {
                if (int.TryParse(token, out int number))
                {
                    stack.Push(number);
                    continue;
                }

                int right = stack.Pop();
                int left = stack.Pop();

                switch (token)
                {
                    case "+":
                        stack.Push(left + right);
                        break;

                    case "-":
                        stack.Push(left - right);
                        break;

                    case "*":
                        stack.Push(left * right);
                        break;

                    case "/":
                        stack.Push(left / right);
                        break;

                    default:
                        throw new ArgumentException($"Geçersiz operatör: {token}");
                }
            }

            return stack.Pop();
        }
    }

    public class MonotonicStackProblems
    {
        public int LargestRectangleArea(int[] heights)
        {
            int n = heights.Length;
            Stack<int> stack = new Stack<int>();
            int maxArea = 0;

            for (int i = 0; i <= n; i++)
            {
                int currentHeight = i == n ? 0 : heights[i];

                while (stack.Count > 0 && currentHeight < heights[stack.Peek()])
                {
                    int height = heights[stack.Pop()];
                    int width = stack.Count == 0
                        ? i
                        : i - stack.Peek() - 1;

                    maxArea = Math.Max(maxArea, height * width);
                }

                stack.Push(i);
            }

            return maxArea;
        }

        public int[] DailyTemperatures(int[] temperatures)
        {
            int n = temperatures.Length;
            int[] result = new int[n];
            Stack<int> stack = new Stack<int>();

            for (int i = n - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && temperatures[stack.Peek()] <= temperatures[i])
                {
                    stack.Pop();
                }

                result[i] = stack.Count == 0
                    ? 0
                    : stack.Peek() - i;

                stack.Push(i);
            }

            return result;
        }

        public int[] FinalPrices(int[] prices)
        {
            int n = prices.Length;
            int[] result = new int[n];
            Stack<int> stack = new Stack<int>();

            for (int i = n - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && stack.Peek() > prices[i])
                {
                    stack.Pop();
                }

                result[i] = stack.Count == 0
                    ? prices[i]
                    : prices[i] - stack.Peek();

                stack.Push(prices[i]);
            }

            return result;
        }

        public int MaximalRectangle(char[][] matrix)
        {
            if (matrix.Length == 0)
            {
                return 0;
            }

            int columns = matrix[0].Length;
            int[] heights = new int[columns];
            int maxArea = 0;

            foreach (char[] row in matrix)
            {
                for (int col = 0; col < columns; col++)
                {
                    heights[col] = row[col] == '1'
                        ? heights[col] + 1
                        : 0;
                }

                maxArea = Math.Max(maxArea, LargestRectangleArea(heights));
            }

            return maxArea;
        }
    }

    public class QueueProblems
    {
        public int CountStudents(int[] students, int[] sandwiches)
        {
            int countZero = students.Count(student => student == 0);
            int countOne = students.Length - countZero;

            foreach (int sandwich in sandwiches)
            {
                if (sandwich == 0)
                {
                    if (countZero == 0)
                    {
                        break;
                    }

                    countZero--;
                }
                else
                {
                    if (countOne == 0)
                    {
                        break;
                    }

                    countOne--;
                }
            }

            return countZero + countOne;
        }

        public int TimeRequiredToBuy(int[] tickets, int k)
        {
            int time = 0;

            for (int i = 0; i < tickets.Length; i++)
            {
                if (i <= k)
                {
                    time += Math.Min(tickets[i], tickets[k]);
                }
                else
                {
                    time += Math.Min(tickets[i], tickets[k] - 1);
                }
            }

            return time;
        }
    }

    // LeetCode 232: Implement Queue using Stacks
    public class MyQueue
    {
        private readonly Stack<int> inputStack;
        private readonly Stack<int> outputStack;

        public MyQueue()
        {
            inputStack = new Stack<int>();
            outputStack = new Stack<int>();
        }

        public void Push(int x)
        {
            inputStack.Push(x);
        }

        public int Pop()
        {
            MoveInputToOutputIfNeeded();
            return outputStack.Pop();
        }

        public int Peek()
        {
            MoveInputToOutputIfNeeded();
            return outputStack.Peek();
        }

        public bool Empty()
        {
            return inputStack.Count == 0 && outputStack.Count == 0;
        }

        private void MoveInputToOutputIfNeeded()
        {
            if (outputStack.Count > 0)
            {
                return;
            }

            while (inputStack.Count > 0)
            {
                outputStack.Push(inputStack.Pop());
            }
        }
    }

    public class BacktrackingProblems
    {
        public bool Exist(char[][] board, string word)
        {
            int rows = board.Length;
            int cols = board[0].Length;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (Search(board, word, row, col, 0))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool Search(char[][] board, string word, int row, int col, int index)
        {
            if (index == word.Length)
            {
                return true;
            }

            bool isOutOfBounds =
                row < 0 ||
                row >= board.Length ||
                col < 0 ||
                col >= board[0].Length;

            if (isOutOfBounds || board[row][col] != word[index])
            {
                return false;
            }

            char originalChar = board[row][col];
            board[row][col] = '#';

            bool found =
                Search(board, word, row + 1, col, index + 1) ||
                Search(board, word, row - 1, col, index + 1) ||
                Search(board, word, row, col + 1, index + 1) ||
                Search(board, word, row, col - 1, index + 1);

            board[row][col] = originalChar;

            return found;
        }

        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            Array.Sort(nums);

            IList<IList<int>> result = new List<IList<int>>();
            BacktrackSubsets(result, new List<int>(), nums, 0);

            return result;
        }

        private void BacktrackSubsets(
            IList<IList<int>> result,
            List<int> currentSubset,
            int[] nums,
            int startIndex)
        {
            result.Add(new List<int>(currentSubset));

            for (int i = startIndex; i < nums.Length; i++)
            {
                if (i > startIndex && nums[i] == nums[i - 1])
                {
                    continue;
                }

                currentSubset.Add(nums[i]);
                BacktrackSubsets(result, currentSubset, nums, i + 1);
                currentSubset.RemoveAt(currentSubset.Count - 1);
            }
        }
    }

    public class LinkedListProblems
    {
        public ListNode Partition(ListNode head, int x)
        {
            ListNode beforeHead = new ListNode(0);
            ListNode before = beforeHead;

            ListNode afterHead = new ListNode(0);
            ListNode after = afterHead;

            while (head != null)
            {
                if (head.val < x)
                {
                    before.next = head;
                    before = before.next;
                }
                else
                {
                    after.next = head;
                    after = after.next;
                }

                head = head.next;
            }

            after.next = null;
            before.next = afterHead.next;

            return beforeHead.next;
        }
    }

    public class DynamicProgrammingProblems
    {
        public int NumDecodings(string s)
        {
            if (string.IsNullOrEmpty(s) || s[0] == '0')
            {
                return 0;
            }

            int n = s.Length;
            int[] dp = new int[n + 1];

            dp[0] = 1;
            dp[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                int oneDigit = int.Parse(s.Substring(i - 1, 1));
                int twoDigits = int.Parse(s.Substring(i - 2, 2));

                if (oneDigit >= 1)
                {
                    dp[i] += dp[i - 1];
                }

                if (twoDigits >= 10 && twoDigits <= 26)
                {
                    dp[i] += dp[i - 2];
                }
            }

            return dp[n];
        }

        public bool IsScramble(string s1, string s2)
        {
            Dictionary<string, bool> memo = new Dictionary<string, bool>();
            return IsScramble(s1, s2, memo);
        }

        private bool IsScramble(string s1, string s2, Dictionary<string, bool> memo)
        {
            string key = $"{s1}|{s2}";

            if (memo.ContainsKey(key))
            {
                return memo[key];
            }

            if (s1.Length != s2.Length)
            {
                memo[key] = false;
                return false;
            }

            if (s1 == s2)
            {
                memo[key] = true;
                return true;
            }

            int[] count = new int[26];

            for (int i = 0; i < s1.Length; i++)
            {
                count[s1[i] - 'a']++;
                count[s2[i] - 'a']--;
            }

            foreach (int value in count)
            {
                if (value != 0)
                {
                    memo[key] = false;
                    return false;
                }
            }

            for (int split = 1; split < s1.Length; split++)
            {
                bool withoutSwap =
                    IsScramble(s1.Substring(0, split), s2.Substring(0, split), memo) &&
                    IsScramble(s1.Substring(split), s2.Substring(split), memo);

                bool withSwap =
                    IsScramble(s1.Substring(0, split), s2.Substring(s2.Length - split), memo) &&
                    IsScramble(s1.Substring(split), s2.Substring(0, s2.Length - split), memo);

                if (withoutSwap || withSwap)
                {
                    memo[key] = true;
                    return true;
                }
            }

            memo[key] = false;
            return false;
        }
    }

    public class BitManipulationProblems
    {
        public IList<int> GrayCode(int n)
        {
            IList<int> result = new List<int>();
            int numberOfCodes = 1 << n;

            for (int i = 0; i < numberOfCodes; i++)
            {
                result.Add(i ^ (i >> 1));
            }

            return result;
        }
    }
}
