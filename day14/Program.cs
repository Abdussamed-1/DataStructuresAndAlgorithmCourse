using System;
namespace day14
{
    class Program
    {
       static void Main(string[] args)
        {
            // Tanımlama & Başlatma
            int[] numaralar = new int[3];

            // Değer atama
            numaralar[0] = 3;
            numaralar[1] = 5;
            numaralar[2] = 7;

            for (int i = 0; i < numaralar.Length; i++)
            {
                Console.WriteLine(numaralar[i]);
            }

            Console.ReadKey();
        }
    }
}
