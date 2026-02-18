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
    public class Solution
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0)
                return null;
            while (lists.Length > 1)
            {
                List<ListNode> mergedLists = new List<ListNode>();
                for (int i = 0; i < lists.Length; i += 2)
                {
                    if (i + 1 < lists.Length)
                        mergedLists.Add(MergeTwoLists(lists[i], lists[i + 1]));
                    else
                        mergedLists.Add(lists[i]);
                }
                lists = mergedLists.ToArray();
            }
            return lists[0];
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