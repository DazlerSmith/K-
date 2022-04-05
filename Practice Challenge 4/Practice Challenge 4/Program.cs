using System;

namespace Practice_Challenge_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Enter the average speed (mph) ");
            int speed = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" Enter the time spent (hours) ");
            int time = Convert.ToInt32(Console.ReadLine());

            int distance = speed * time;

            Console.WriteLine(" The distance travelled is " + distance + " miles " );
            Console.ReadLine();
        }
    }
}
