/*
What is OOP?
OOP stands for Object-Oriented Programming.
Procedural programming is about writing procedures or methods that perform operationson the data, 
while object-oriented programming is about creating objects that contain both data and methods.
 */

using System;

namespace MyApplication
{
    class Car
    {
        string color = "red";

        static void Main(string[] args)
        {
            Car myObj1 = new Car();
            Car myObj2 = new Car();
            Console.WriteLine(myObj1.color);
            Console.WriteLine(myObj2.color);
        }
    }
}