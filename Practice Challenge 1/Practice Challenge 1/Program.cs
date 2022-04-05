using System;

namespace Practice_Challenge_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ask a joke and don't say the punchline till the user enters the enter key.
            Console.WriteLine("What is E.T short for?");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkRed; //changes colour red
            Console.WriteLine("Because he's only got little legs");
            Console.ReadLine();
        }
    }
}
