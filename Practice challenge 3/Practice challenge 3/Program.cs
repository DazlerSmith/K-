using System;

namespace Practice_challenge_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("What is the length of the rectangle in cm");
            int length = Convert.ToInt32(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("What is the width of the rectangle cm");
            int width = Convert.ToInt32(Console.ReadLine());

            int area = length * width;

            Console.ForegroundColor = ConsoleColor.DarkRed; 
            Console.WriteLine(" The area of the rectangle is " + area + " cm ");
            Console.ReadLine();

            // volume can also be easily created.


        }
    }
}
