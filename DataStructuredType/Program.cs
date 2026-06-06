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
    public class stacks {

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
    public class monotonicstack {
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
    public class queue {
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
    }

}