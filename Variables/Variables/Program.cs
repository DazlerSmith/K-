using System;

namespace Variables
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            Console.WriteLine(" Please eneter your name ");
            name = Console.ReadLine();
            Console.WriteLine(" Hello " + name + " Nice to meet you!");
            Console.ReadLine();
            string film;
            int number;
            Console.WriteLine(" What is your favourite film? ");
            film = Console.ReadLine();
            Console.WriteLine(" How many times have you watched it? ");
            number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" Your favourite film is " + film + " and you have watched it " + number + " times ");
            Console.ReadLine();
        }
    }
}
