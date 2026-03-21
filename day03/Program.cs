using System;

namespace day3;

class Program
{
    static void Main(string[] args)
    {
        // Variables
        // type variableName = value;

        // string variable type 
        string name = "John";

        // integer variable type    
        // other way 
        int myNum = 5;
        myNum = 10;

        double myDoubleNum = 5.99D; // floating point number
        char myLetter = 'D';        // character
        bool myBool = true;         // boolean

        // const int myNum = 15;
        // myNum = 20;

        // name is already defined above → here we only use it
        Console.WriteLine("Hello " + name);

        string firstName = "John ";
        string lastName = "Doe";
        string fullName = firstName + lastName;
        //Console.WriteLine(fullName);

        int x = 5;
        int y = 6;
        Console.WriteLine(x + y); // Print the value of x + y

        Console.ReadKey();
    }
}
