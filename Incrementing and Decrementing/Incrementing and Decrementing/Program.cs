using System;

namespace Incrementing_and_Decrementing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Number A:");
            int a = Convert.ToInt32(Console.ReadLine());
            a++; //This adds 1 to the number a 
            Console.WriteLine("Plus one is " + a);
            Console.ReadLine();

            Console.WriteLine("Enter Number B:");
            int b = Convert.ToInt32(Console.ReadLine());
            b--;  //This minuses 1 to the number b
            Console.WriteLine("Minus one is " + b);
            Console.ReadLine();
        } 
    }
}
