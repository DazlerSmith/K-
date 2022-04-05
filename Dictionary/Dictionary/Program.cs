using System;
using System.Collections.Generic;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, int> inventory = new Dictionary<string, int>();
            //The first input is the value and the second is the key.

            inventory.Add("Apple", 3);
            inventory.Add("Orange", 5);
            inventory.Add("Banana", 2);








            Dictionary<string, long> phonebook = new Dictionary<string, long>();

            phonebook.Add("John",07713945861);

            Console.WriteLine("What phone number would you like to test for");

            // This is to check if a phone number does exist
            if (phonebook.ContainsKey(Console.ReadLine()))
            {
                Console.WriteLine(" This phone number does exist ");
                
            }
            else
            {
                Console.WriteLine("This phone number does not exist");
                
            }
            Console.ReadLine();

            // This will allow the user to add a new phone number
            Console.WriteLine("Would you like to add a new ")

        }
    }
}