using System;

namespace Doubles_And_Constants
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of centimetres:");
            int cm = Convert.ToInt32(Console.ReadLine());
            double feet;  //This declares the variable feet as a decimal
            feet = cm / 30.48;  //30.48 is a constant
            Console.WriteLine(cm + " centimetres is the same as " + feet + " feet. ");
            Console.ReadLine();


            Console.WriteLine("Enter Number");
            int number = Convert.ToInt32(Console.ReadLine());
            double third = number / 3;  //This is a different program where it finds a thid of the number entered
            Console.WriteLine("One third of " + number + " is " + third);
            Console.ReadLine();
        }
    }
}
