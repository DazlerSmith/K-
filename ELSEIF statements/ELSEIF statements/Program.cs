using System;

namespace ELSEIF_statements
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number A:");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter number B:");  //Telling the user to enter 2 numbers (a and b)
            int b = Convert.ToInt32(Console.ReadLine());

            if (a > b) 
            {
                Console.WriteLine("A is greater than B");
            }
            else if (a == b) 
            {
                Console.WriteLine("A is equal to B");   //These are the 3 conditions for the number that will ne entered.
            }
            else 
            {
                Console.WriteLine("B is greater than A");
            }
            Console.ReadLine();
           

        }
    }
}
