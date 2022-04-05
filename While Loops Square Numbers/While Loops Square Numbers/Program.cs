using System;

namespace While_Loops_Square_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 1;  //Square Numbers
            while ((x*x) < 5000 )
            {
                Console.WriteLine(x * x);
                x++;
            }
            Console.ReadLine();


        }
    }
}
