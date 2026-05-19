public class Solution
{

    // Generic Template: Array Operations
    public T[] ReverseArray<T>(T[] arr)
    {
        Array.Reverse(arr);
        return arr;
    }

    // Generic Template: List Operations
    public List<T> RemoveDuplicates<T>(List<T> list)
    {
        return list.Distinct().ToList();
    }

    // Generic Template: Dictionary Operations
    public Dictionary<TKey, TValue> MergeDictionaries<TKey, TValue>(
        Dictionary<TKey, TValue> dict1,
        Dictionary<TKey, TValue> dict2)
    {
        var result = new Dictionary<TKey, TValue>(dict1);
        foreach (var kvp in dict2)
        {
            result[kvp.Key] = kvp.Value;
        }
        return result;
    }

    // Template: Sorting with Comparison
    public IList<IList<T>> ThreeSum<T>(T[] nums) where T : IComparable<T>
    {
        int n = nums.Length;
        Array.Sort(nums);
        var result = new List<IList<T>>();

        for (int i = 0; i < n - 2; i++)
        {
            if (i > 0 && nums[i].CompareTo(nums[i - 1]) == 0) continue;
            int left = i + 1;
            int right = n - 1;

            while (left < right)
            {
                left++;
                right--;
            }
        }
        return result;
    }

    // Concrete Implementation: ThreeSum for integers
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        int n = nums.Length;
        Array.Sort(nums);
        var result = new List<IList<int>>();

        for (int i = 0; i < n - 2; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1]) continue;
            int left = i + 1;
            int right = n - 1;

            while (left < right)
            {
                int sum = nums[i] + nums[left] + nums[right];
                if (sum == 0)
                {
                    result.Add(new List<int> { nums[i], nums[left], nums[right] });
                    while (left < right && nums[left] == nums[left + 1]) left++;
                    while (left < right && nums[right] == nums[right - 1]) right--;
                    left++;
                    right--;
                }
                else if (sum < 0)
                    left++;
                else
                    right--;
            }
        }
        return result;
    }

    public int MySqrt(int x)
    {
        if (x < 2) return x;
        int left = 1, right = x / 2;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            long square = (long)mid * mid;
            if (square == x)
                return mid;
            else if (square < x)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return right;
    }
}