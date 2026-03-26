using System;

class Program
{
    public static void Main(string[] args)
    {
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