using System;
using System.Collections.Generic;

namespace Dictionary_Practical
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

            Dictionary<string, string> phonebook = new Dictionary<string, string>();

            phonebook.Add("John", 07713945861);

            Console.WriteLine("What phone number would you like to test for");

            if (phonebook.ContainsKey(Console.ReadLine("")))
            {
                Console.writeline("This phone number does exist and belongs to ");
                Console.ReadLine();
            }

        }
    }
}
