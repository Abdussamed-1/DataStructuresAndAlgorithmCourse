using System;
using System.Diagnostics.CodeAnalysis;

class Program
{
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