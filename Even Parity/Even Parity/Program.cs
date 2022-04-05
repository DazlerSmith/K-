using System;

namespace Even_Parity
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Odd or Even Parity");
            String parity = Console.ReadLine();
            Console.WriteLine("Enter your binary pattern");
            String number = Convert.ToString(Console.ReadLine());

            int length = number.Length;
            int counter = 0;


            if (parity == "Even")
            {
                for (int i = 0; i < length; i++)
                {
                    if (number[i] == '1')
                    {
                        counter++;
                    }
                }
                if (counter % 2 == 0)
                {
                    Console.WriteLine(" The binary patternn is valid ");
                }
                else
                {
                    Console.WriteLine(" The binary pattern is invalid ");
                }
                Console.ReadLine();
            }
            else 
            {
                for (int i = 0; i < length; i++)
                {
                    if (number[i] == '1')
                    {
                        counter++;
                    }
                }
                if (counter % 2 == 1)
                {
                    Console.WriteLine(" The binary patternn is valid ");
                }
                else
                {
                    Console.WriteLine(" The binary pattern is invalid ");
                }
                Console.ReadLine();
            }
           
            
            




        }
    }
}    
