/*
while (condition) 
{
  // code block to be executed
}
*/
using System;
namespace day6
{
    class Program
    {
        static void Main(string[] args)
        {
            //whileloop();
            /*do
            {
                // code block to be executed
            }
            while (condition);
            */
            int i = 0;
            do
            {
                Console.WriteLine(i);
                i++;
            }
            while (i < 6);
        }

        private static void whileloop()
        {
            int i = 0;
            while (i < 5)
            {
                Console.WriteLine(i);
                i++;
            }
        }
    }
}