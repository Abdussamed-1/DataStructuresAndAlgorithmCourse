using System;
class Program
{
    enum Operators
    {
        Add,
        Subtract,
        Multiply,
        Divide
    }
    static void Main(string[] args)
    {
        int A = 10; 
        int B = 20;
        Operators opp = (Operators)(new Random().Next(0,3));
        switch (opp)
        {
            case Operators.Add:
                Console.WriteLine($"{A} + {B} = {A+B}");
                break;
            case Operators.Subtract:
                Console.WriteLine($"{A} - {B} = {A - B}");
                break;
            case Operators.Multiply:
                Console.WriteLine($"{A} x {B} = {A * B}");
                break;
            case Operators.Divide:
                Console.WriteLine($"{A} / {B} = {A / B}");
                break;
            default:
                Console.WriteLine("\a Invalid Operator");
                break;
        }
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