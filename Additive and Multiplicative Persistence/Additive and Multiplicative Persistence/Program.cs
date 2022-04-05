using System;

namespace Additive_and_Multiplicative_Persistence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number between 0-99");
            int value = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What operation? Addititive or Multiplicative (a or m)");
            string operation = Console.ReadLine();

           

            int count = 0;
            while (value > 9)
            {
                if (operation == "a")
                {
                    value = (value / 10) + (value % 10);
                }
                else
                {
                    value = (value / 10) * (value % 10);
                }
                count = count++;
            }
            Console.WriteLine("The persistence is: ");
            Console.Write(count);
            Console.ReadLine();
        
        }  
    }
}
