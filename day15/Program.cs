using System;
using System.Diagnostics.CodeAnalysis;

class Program
{
    public int MinPathSum(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        for (int i = 1; i < m; i++)
        {
            grid[i][0] += grid[i - 1][0];
        }
        for (int j = 1; j < n; j++)
        {
            grid[0][j] += grid[0][j - 1];
        }
        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                grid[i][j] += Math.Min(grid[i - 1][j], grid[i][j - 1]);
            }
        }
        return grid[m - 1][n - 1];
    }
    public static void Main(string[] args)
    {
       for (int i = 0; i < 50; i+=1)
        {
            Console.WriteLine(i);
        }

        Console.WriteLine("Can you input number:");
        int n = Convert.ToInt32(Console.ReadLine());
        
        int i = 2;
        do
        {
            Console.WriteLine(i);
            i += 2; // i = i + 2;
        } while (i <= n);

        // 0'dan 10'a kadar
        int sayac = 0;
        while (sayac <= 10)
        {
            Console.WriteLine("{0,-3} {1,-3}", sayac, sayac * sayac);
            sayac++;
        }

        Console.WriteLine("----------");

        // 10'dan 0'a kadar
        sayac = 10;
        while (sayac >= 0)
        {
            Console.WriteLine("{0,-3} {1,-3}", sayac, sayac * sayac);
            sayac--;
        }

        Console.ReadKey();
    }
}