using System;
class Program
{
    static void Main(string[] args)
    {
        //Evenoroddnumber();
        //absolutevalue();
        //variabletypes();

    }

    private static void variabletypes()
    {
        var k = (char)Console.Read();
        if (char.IsDigit(k))
        {
            Console.WriteLine("It is number");
        }
        else if (char.IsUpper(k))
        {
            Console.WriteLine("Uppercase Letter");
        }
        else if (char.IsLower(k))
        {
            Console.WriteLine("Lowercase Letter");
        }
        else
        {
            Console.WriteLine("Special Character");
        }
    }

    private static void absolutevalue()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        if (n < 0)
        {
            Console.WriteLine($"|{n}| = {n * -1}");
        }

        else
        {
            Console.WriteLine($"|{n}| = {n}");
        }

        Console.ReadKey();
    }

    private static void Evenoroddnumber()
    {
        //Tek / Çift
        Console.WriteLine("Enter a number: ");
        int num = Convert.ToInt32(Console.ReadLine());
        if (num % 2 == 0)
        {
            Console.WriteLine($"{num} is even number");
        }
        else
        {
            Console.WriteLine($"{num} is odd number");
        }
    }
}