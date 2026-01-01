using System;

namespace day4;

class Program
{
    static void Main(string[] args)
    {
        long myNum = 15000000000L;
        Console.WriteLine(myNum);

        int x = 5, y = 6, z = 50;
        Console.WriteLine(x + y + z);

        int a, b, c;
        a = b = c = 50;
        Console.WriteLine(a + b + c);

        // Good
        int minutesPerHour = 60;

        // OK, but not so easy to understand what m actually is
        int m = 60;

        int l = 100000;
        Console.WriteLine(l);

        // Convertions
        int myInt = 10;
        double myDouble = 5.25;
        bool myBool = true;

        Console.WriteLine(Convert.ToString(myInt));    // Convert int to string
        Console.WriteLine(Convert.ToDouble(myInt));    // Convert int to double
        Console.WriteLine(Convert.ToInt32(myDouble));  // Convert double to int
        Console.WriteLine(Convert.ToString(myBool));   // Convert bool to string

        // Type your username and press enter
        Console.WriteLine("Enter username: ");
        // Create a string variable and get user input from the keyboard and store it in the variable
        string userName = Console.ReadLine();
        // Print the value of the variable (userName), which will display the input value
        Console.WriteLine("Username is: " + userName);

        Console.WriteLine("Enter your age:");
        int age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Your age is: " + age);
    }
}
