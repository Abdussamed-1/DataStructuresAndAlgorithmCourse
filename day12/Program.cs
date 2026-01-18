/*
What is OOP?
OOP stands for Object-Oriented Programming.
Procedural programming is about writing procedures or methods that perform operations on the data,
while object-oriented programming is about creating objects that contain both data and methods.
*/

using System;

namespace day12
{
    class Car
    {
        public string Color = "red";
        public int MaxSpeed = 200;
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Car myObj1 = new Car();
            Car myObj2 = new Car();

            Console.WriteLine(myObj1.Color);
            Console.WriteLine(myObj2.Color);

            Car myObj = new Car();
            Console.WriteLine(myObj.Color);
            Console.WriteLine(myObj.MaxSpeed);
        }
    }
}