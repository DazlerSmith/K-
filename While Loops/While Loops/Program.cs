using System;

namespace While_Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number");
            int multiple = Convert.ToInt32(Console.ReadLine());
            int x = 1;

            while ((x*multiple) < 5000)  //This will show all the multiples of the number the user enterd until it gets to 5000
            {
                Console.WriteLine(x*multiple);
                x++;  //This adds one so 1st multiple of #, 2nd, 3rd, 4th
            }
            Console.ReadLine();
        }
    }
}
