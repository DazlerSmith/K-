using System;

namespace Iteration___For_Loops__
{
    class Program
    {
        static void Main(string[] args)
        {

            // Program to print line of *s
            Console.WriteLine("Enter a number:"); // the user can enter the amount of times * is entered
            int number = Convert.ToInt32(Console.ReadLine());
            String stars = "";

            for (int i = 0; i < number; i++)
            {
                stars = stars + "*"; // adds another *
            }
            Console.WriteLine(stars); //Displays the line

            Console.ReadLine();
        }
    }
}
