using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

internal class loop
{
    static void Main(string[] args)
    {
        int i = 0;
        while (i < 10)
        {
            Console.WriteLine("{0,-3} {1,-3}", i);
            i++;
        }
        Console.WriteLine("Döngü Sonu!");
        Console.ReadKey();
    }

}

/*
class Result
{
    * Complete the 'reverseArray' function below.
    * The function is expected to return an INTEGER_ARRAY.
    * The function accepts INTEGER_ARRAY a as parameter.

   public static List<int> reverseArray(List<int> a)
   {
       a.Reverse();
       return a;
   }
}*/

class Program : loop
{
    static void Main(string[] args)
    {
        int sayac = 1;
        while (sayac < 10)
        {
            Console.WriteLine("{0,-3} {1,-3}", sayac, sayac*sayac);
            sayac++;
        }
        Console.ReadKey();
    }
}