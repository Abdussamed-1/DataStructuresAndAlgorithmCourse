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
            Stack<(int id, int time)> stack = new Stack<(int id, int time)>();
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
                        var (prevId, prevTime) = stack.Peek();
                        result[prevId] += time - prevTime;
                    }
                    stack.Push((id, time));
                }
                else
                {
                    var (prevId, prevTime) = stack.Pop();
                    result[prevId] += time - prevTime + 1;
                    if (stack.Count > 0)
                    {
                        stack.Push((stack.Peek().id, time + 1));
                    }
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
}