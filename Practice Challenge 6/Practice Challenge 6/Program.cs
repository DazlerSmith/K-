using System;

namespace Practice_Challenge_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" The timer will begin when enter is pressed,the next time you press enter is when 10 seconds has past and the goal is to get as close to ten seconds ");
            Console.ReadLine(); //Opening rules

            DateTime a = DateTime.Now; //keeps track of beginning time

            Console.WriteLine("The timer has begun, press enter when you think it has been 10 seconds");
            Console.ReadLine(); //game has started

            DateTime b = DateTime.Now;
            TimeSpan userenter = b - a; //get the result when enetr is pressed, works out total duration

            double seconds = userenter.TotalSeconds;
            double closetime = seconds - 10; //this gets how close the user was to 10 

            Console.WriteLine(" You pressed enter after  " + (b - a) + " had passed " );
            Console.ReadLine(); //outputs duration

            Console.WriteLine(" You were " + closetime + " away from ten ");
            Console.ReadLine();  //outputs accuracy
            
        }
    }
}
