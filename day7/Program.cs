/*
 * for (statement 1; statement 2; statement 3) 
{
  // code block to be executed
}
*/
using System;

namespace day7
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i <= 10; i = i + 2)
            {
                Console.WriteLine(i);
            }
        }
    }
}