using System;

namespace Switch_Case
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a number from 1 to 3");
            int x = Convert.ToInt32(Console.ReadLine());    //user enters a number between 1 and 3

            switch (x)
            {
                case 1:
                    Console.WriteLine("You have chose number 1");
                    break;
                case 2:
                    Console.WriteLine("You have chose number 2");     //Rather than going through all conditions the switch just makes it more efficient rather than writing them all out
                    break;
                case 3:
                    Console.WriteLine("You have chose number 3");
                    break;
                default:
                    Console.WriteLine("You have entered an invalid entry :(");
                    break;
                    //The default acts as an else in an if statement for everything else

            }
            Console.ReadLine();

            Console.WriteLine("Enter a letter from A-E");
            string letter = Console.ReadLine();

            switch (letter)
            {
                case "A":
                case "a":  //Capital letters matter

                    Console.WriteLine("A is for Apple");
                    break;
                case "B":
                case "b":

                    Console.WriteLine("B is for Banana");
                    break;
                case "C":
                case "c":

                    Console.WriteLine("C is for Carrot");
                    break;
                case "D":
                case "d":

                    Console.WriteLine("D is for Dinner");
                    break;
                case "E":
                case "e":

                    Console.WriteLine("E is for Edible");
                    break;
                default:
                    Console.WriteLine("Sorry, you appear to have made an invalid entry");
                    break;





            }
            Console.ReadLine();

            Console.WriteLine("Please enter a country (England, Wales, Scotland, North Ireland");
            string country = Console.ReadLine();

            switch (country)
            {
                case "England":
                case "england":
                    Console.WriteLine("The capital city of England is London");
                    break;
                case "Nothern Ireland":
                case "northern ireland":
                case "northern Ireland":
                case "Northern ireland":
                    Console.WriteLine("The capital city of Northern Ireland is Belfast");
                    break;
                case "Scotland":
                case "scotland":
                    Console.WriteLine("The capital city of Scotland is Edinburgh");
                    break;
                case "Wales":
                case "wales":
                    Console.WriteLine("The capital city of Wales is Cardiff");
                    break;
                default:
                    Console.WriteLine("Sorry, you have entered an invalid entry");
                    break;
            }
            Console.ReadLine();
        }

    }
}