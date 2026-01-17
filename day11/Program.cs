// Create a method inside the Program class:

/*
 * Syntax
using System;

class Program
{
    static void MyMethod()
    {
        /*
         * Example Explained
         MyMethod() is the name of the method
         static means that the method belongs to the Program class and not an object of the Program class. You will learn more about objects and how to access methods through objects later in this tutorial.
         void means that this method does not have a return value. You will learn more about return values later in this chapter
          
    }
}
*/

/*
 * 
Example
Inside Main(), call the myMethod() method:
*/

using System;

namespace day11
{
    class Program
    {
        static void MyMethod()
        {
            Console.WriteLine("I just got executed!");
        }

        static void ConsoleMethod(string fname)
        {
            Console.WriteLine(fname + " Refsnes");
        }

        static void Main(string[] args)
        {
            MyMethod();

            ConsoleMethod("Liam");
            ConsoleMethod("Jenny");
            ConsoleMethod("Anja");
        }
    }
}