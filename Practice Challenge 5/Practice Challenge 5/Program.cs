using System;

namespace Practice_Challenge_5
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dob = new DateTime(2004, 07, 08);

            TimeSpan life = DateTime.Now - dob;

            double seconds = life.TotalSeconds;

            Console.WriteLine(seconds + " seconds you have lived for " );

            Console.ReadLine();
        }
    }
}
