using System;

public class Program
{
    static void Main(string[] args)
    {
        int sayac = 0;
        while (sayac <= 10)
        {
            Console.WriteLine("{0,-3} {1,-3}", sayac, sayac * sayac);
            sayac += 1;
        }
        Console.ReadKey();
    }
}