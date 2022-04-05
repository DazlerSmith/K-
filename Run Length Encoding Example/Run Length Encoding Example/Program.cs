using System;

namespace Run_Length_Encoding_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Char current = ' ';
            int count = 1;
            Console.WriteLine(" Please enter a character number "); //This is what the charcters are
            string value = Console.ReadLine();
            current = value[0];

            for (int i = 1; i < value.Length; i++)
            {
                if (value[i] == current) //If the charcter is = to the next
                {
                    count++; //Add 1 on the count for the character
                }
                else
                {
                    Console.Write(current);
                    Console.Write(count); //Displays it
                    current = value[i];
                    count = 1;
                }

            }
            if (count > 1)  //Allows the program to be stopped as the spaces would keep getting counted without it.
            {
                Console.Write(current);
                Console.Write(count);
            }
            Console.ReadLine();

        }
    } 
}
