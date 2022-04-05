using System;

namespace Marking_IF_Statements
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the mark you have got out of 100:");
            int Mark = Convert.ToInt32(Console.ReadLine());

            if (Mark >= 60) //If the mark is greater than or equal to 60 
            {
                Console.WriteLine(" You have passed ");
            }
            else // otherwise use this one
            {
                Console.WriteLine(" You have failed ");
            }
            Console.ReadLine();
        }
    }
}
