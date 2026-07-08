using System;
namespace day14
{
    public class Program
    {
         static void Main(string[] args)
        {
            Console.WriteLine("Dizi Boyutunu giriniz:");
            int boyut = Convert.ToInt32(Console.ReadLine());
            int[] sayilar = new int[boyut];
            var r = new Random();
            for (int i = 0; i < sayilar.Length; i++)
            {
                sayilar[i] = r.Next(1, 10);
            }
            foreach (int s in sayilar)
            {
                Console.WriteLine(s);
            }

            Console.ReadKey();
        }

        private static void Main(string[] args)
        {
            // Tanımlama & Başlatma
            int[] numaralar = new int[3];

            // Değer atama
            numaralar[0] = 3;
            numaralar[1] = 5;
            numaralar[2] = 7;

            for (int i = 0; i < numaralar.Length; i++)
            {
                Console.WriteLine(numaralar[i]);
            }

            Console.ReadKey();
        }
    }
    
    public bool Search(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                {
                    return true;
                }
                if (nums[left] == nums[mid] && nums[mid] == nums[right])
                {
                    left++;
                    right--;
                }
                else if (nums[left] <= nums[mid])
                {
                    if (nums[left] <= target && target < nums[mid])
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                else
                {
                    if (nums[mid] < target && target <= nums[right])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
            }
            return false;
        }
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
        public IList<TreeNode> GenerateTrees(int n)
        {
            if (n == 0)
            {
                return new List<TreeNode>();
            }

            return GenerateTreesHelper(1, n);
        }

        private IList<TreeNode> GenerateTreesHelper(int start, int end)
        {
            IList<TreeNode> allTrees = new List<TreeNode>();

            if (start > end)
            {
                allTrees.Add(null);
                return allTrees;
            }

            for (int rootValue = start; rootValue <= end; rootValue++)
            {
                IList<TreeNode> leftTrees = GenerateTreesHelper(start, rootValue - 1);
                IList<TreeNode> rightTrees = GenerateTreesHelper(rootValue + 1, end);

                foreach (TreeNode leftTree in leftTrees)
                {
                    foreach (TreeNode rightTree in rightTrees)
                    {
                        TreeNode root = new TreeNode(rootValue);

                        root.left = leftTree;
                        root.right = rightTree;

                        allTrees.Add(root);
                    }
                }
            }

            return allTrees;
        }
        public bool IsValidBST(TreeNode root)
        {   
            return IsValidBSTHelper(root, long.MinValue, long.MaxValue);
        }
    }
}
