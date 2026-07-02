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
    }
