using System;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How far do I count?");
            int maximum = Convert.ToInt32(Console.ReadLine());
            while (maximum < 1)
            {
                Console.WriteLine(" Invalid number! Please try again ");  //Have to enter a valid number to carry on
                Console.WriteLine("How far do I count?");
                Console.ReadLine();
            }
            for (int i = 0; i <= maximum; i++)
            {
                if ( i % 3 == 0 && i % 5 == 0)  // The percentage means divide and the && means AND
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if ( i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if ( i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }
              
            }
            Console.ReadLine();
        }

    }
}
