using System;

namespace Incrementing_and_Decrementing_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Enter Number A: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" A = " + a);
            Console.WriteLine(" Enter Number B: ");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" B = " + b);
            Console.WriteLine(" Enter Number C: ");
            int c = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" C = " + c);

            int d = a * b * c;

            Console.WriteLine(a + " Multiplied by " + b + " Multiplied  by " + c + " = " + d);
            Console.ReadLine();
        }      
    }
}
