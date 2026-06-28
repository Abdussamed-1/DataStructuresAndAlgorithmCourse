using System;
using System.Collections.Generic;
using System.Linq;

namespace Datastructuredpaths
{
    public class arrays
    {
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            int maxCount = 0, count = 0;
            foreach (int num in nums)
            {
                if (num == 1)
                {
                    count++;
                    maxCount = Math.Max(maxCount, count);
                }
                else
                {
                    count = 0;
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
    }
    public class arrays2
    {
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
                    result[0] = index + 1;
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
                    result[1] = i + 1;
                    break;
                }
            }
            return result;
        }
    }
    public class stacks
    {

        public int[] ExclusiveTime(int n, IList<string> logs)
        {
            int[] result = new int[n];
            Stack<int> stack = new Stack<int>();
            int prevTime = 0;

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
                        result[stack.Peek()] += time - prevTime;
                    }
                    stack.Push(id);
                    prevTime = time;
                }
                else
                {
                    result[stack.Pop()] += time - prevTime + 1;
                    prevTime = time + 1;
                }
            }

            return result;
        }
        public IList<string> BuildArray(int[] target, int n)
        {
            IList<string> result = new List<string>();
            int j = 0;
            for (int i = 1; i <= n && j < target.Length; i++)
            {
                result.Add("Push");
                if (target[j] == i)
                {
                    j++;
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
                if (int.TryParse(token, out int num))
                {
                    stack.Push(num);
                }
                else
                {
                    int b = stack.Pop();
                    int a = stack.Pop();
                    switch (token)
                    {
                        case "+":
                            stack.Push(a + b);
                            break;
                        case "-":
                            stack.Push(a - b);
                            break;
                        case "*":
                            stack.Push(a * b);
                            break;
                        case "/":
                            stack.Push(a / b);
                            break;
                    }
                }
            }
            return stack.Pop();
        }
    }
    public class monotonicstack
    {
        public int LargestRectangleArea(int[] heights)
        {
            int n = heights.Length;
            Stack<int> stack = new Stack<int>();
            int maxArea = 0;
            for (int i = 0; i <= n; i++)
            {
                int h = (i == n) ? 0 : heights[i];
                while (stack.Count > 0 && h < heights[stack.Peek()])
                {
                    int height = heights[stack.Pop()];
                    int width = stack.Count == 0 ? i : i - stack.Peek() - 1;
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
                result[i] = stack.Count == 0 ? 0 : stack.Peek() - i;
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
                result[i] = stack.Count == 0 ? prices[i] : prices[i] - stack.Peek();
                stack.Push(prices[i]);
            }
            return result;
        }
    }
    public class queue
    {
        public int CountStudents(int[] students, int[] sandwiches)
        {
            int n = students.Length;
            int count0 = students.Count(s => s == 0);
            int count1 = n - count0;
            foreach (int sandwich in sandwiches)
            {
                if (sandwich == 0)
                {
                    if (count0 == 0) break;
                    count0--;
                }
                else
                {
                    if (count1 == 0) break;
                    count1--;
                }
            }
            return count0 + count1;
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
        public MyQueue()
        {

        }

        public void Push(int x)
        {

        }

        public int Pop()
        {

        }

        public int Peek()
        {

        }

        public bool Empty()
        {

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
            if (n < 3) return false;
            int i = 0;
            while (i + 1 < n && arr[i] < arr[i + 1]) i++;
            if (i == 0 || i == n - 1) return false;
            while (i + 1 < n && arr[i] > arr[i + 1]) i++;
            return i == n - 1;
        }

        public int MaximalRectangle(char[][] matrix)
        {
            int m = matrix.Length;
            if (m == 0) return 0;

            int n = matrix[0].Length;
            int[] heights = new int[n];
            int maxArea = 0;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    heights[j] = matrix[i][j] == '1'
                        ? heights[j] + 1
                        : 0;
                }

                maxArea = Math.Max(maxArea, LargestRectangleArea(heights));
            }

            return maxArea;
        }

        private int LargestRectangleArea(int[] heights)
        {
            int n = heights.Length;
            Stack<int> stack = new Stack<int>();
            int maxArea = 0;

            for (int i = 0; i <= n; i++)
            {
                int h = (i == n) ? 0 : heights[i];

                while (stack.Count > 0 && h < heights[stack.Peek()])
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
            // Kelimenin tamamı bulundu
            if (index == word.Length)
            {
                return true;
            }

            // Sınır kontrolü ve karakter eşleşmesi
            if (row < 0 || row >= board.Length ||
                col < 0 || col >= board[0].Length ||
                board[row][col] != word[index])
            {
                return false;
            }

            char currentChar = board[row][col];
            board[row][col] = '#'; // ziyaret edildi olarak işaretle

            bool exists =
                Search(board, word, row + 1, col, index + 1) ||
                Search(board, word, row - 1, col, index + 1) ||
                Search(board, word, row, col + 1, index + 1) ||
                Search(board, word, row, col - 1, index + 1);

            board[row][col] = currentChar; // geri al (backtracking)

            return exists;
        }

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
            after.next = null; // son düğümü null yap
            before.next = afterHead.next; // iki listeyi birleştir
            return beforeHead.next; // yeni baş düğümü döndür
        }

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
            after.next = null; // son düğümü null yap
            before.next = afterHead.next; // iki listeyi birleştir
            return beforeHead.next; // yeni baş düğümü döndür
        }

        public bool IsScramble(string s1, string s2)
        {
            if (s1.Length != s2.Length) return false;
            if (s1 == s2) return true;
            int[] count = new int[26];
            for (int i = 0; i < s1.Length; i++)
            {
                count[s1[i] - 'a']++;
                count[s2[i] - 'a']--;
            }
            foreach (int c in count)
            {
                if (c != 0) return false;
            }
            for (int i = 1; i < s1.Length; i++)
            {
                if ((IsScramble(s1.Substring(0, i), s2.Substring(0, i)) &&
                     IsScramble(s1.Substring(i), s2.Substring(i))) ||
                    (IsScramble(s1.Substring(0, i), s2.Substring(s2.Length - i)) &&
                     IsScramble(s1.Substring(i), s2.Substring(0, s2.Length - i))))
                {
                    return true;
                }
            }
            return false;
        }
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int i = m - 1, j = n - 1, k = m + n - 1;
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

        public IList<int> GrayCode(int n)
        {
            IList<int> result = new List<int>();
            int numCodes = 1 << n; // 2^n
            for (int i = 0; i < numCodes; i++)
            {
                result.Add(i ^ (i >> 1)); // Gray code formula
            }
            return result;
        }
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            Array.Sort(nums); // Duplicate değerleri yönetmek için sıralıyoruz

            IList<IList<int>> result = new List<IList<int>>();

            Backtrack(result, new List<int>(), nums, 0);

            return result;
        }

        private void Backtrack(
            IList<IList<int>> result,
            List<int> currentSubset,
            int[] nums,
            int startIndex)
        {
            result.Add(new List<int>(currentSubset));

            for (int i = startIndex; i < nums.Length; i++)
            {
                // Aynı seviyede tekrar eden elemanları atlıyoruz
                if (i > startIndex && nums[i] == nums[i - 1])
                {
                    continue;
                }

                currentSubset.Add(nums[i]);

                Backtrack(result, currentSubset, nums, i + 1);

                currentSubset.RemoveAt(currentSubset.Count - 1);
            }
        }
    }
    
    public int NumDecodings(string s)
        {
            if (string.IsNullOrEmpty(s) || s[0] == '0') return 0;
            int n = s.Length;
            int[] dp = new int[n + 1];
            dp[0] = 1; // Boş string için bir yol
            dp[1] = 1; // İlk karakter için bir yol
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

    }