using System;
namespace DataStructuredType
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the Person struct
            Person person1 = new Person("Alice", 30);
            Console.WriteLine($"Name: {person1.Name}, Age: {person1.Age}");
            // Create another instance of the Person struct
            Person person2 = new Person("Bob", 25);
            Console.WriteLine($"Name: {person2.Name}, Age: {person2.Age}");
        }
    }
    // Define a struct to represent a person
    struct Person
    {
        public string Name { get; }
        public int Age { get; }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}


