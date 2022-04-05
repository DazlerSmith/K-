using System;

namespace Own_program
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Select a theme ");
            Console.WriteLine(" Candy Cane ");
            Console.WriteLine(" Rainbow ");
            String theme = Console.ReadLine();

            switch (theme)
            {
               case "Candy Cane":
               case "candy cane":
                
               Console.WriteLine(" You have chosen Candy Cane ");
               break;

                case "Rainbow":
                case "rainbow":

               Console.WriteLine(" You have chosen Rainbow ");
                    break;
            }
            Console.ReadLine();
        }
    }
}
