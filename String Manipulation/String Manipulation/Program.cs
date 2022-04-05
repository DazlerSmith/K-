using System;

namespace String_Manipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            //Concanetation
            String greeting = "Hello";
            String name = "Bob";
            String full = greeting + " " + name;  //This puts the two original strings into the same string
            Console.WriteLine(full);

            //Length:
            String sample = "supercalifragilisticexpialidocious";   
            int size = sample.Length;   //This finds how many characters are in the string 'sample'
            Console.WriteLine("supercalifragilisticexpialidocious is " + size + " letters long");
            Console.ReadLine();

            Console.WriteLine(" Enter the first name ");
            String name1 = Console.ReadLine();
            Console.WriteLine(" Enter the second name");
            String name2 = Console.ReadLine();

            int size1 = name1.Length;
            int size2 = name2.Length;

            if (size1 > size2)
            {
                Console.WriteLine(" The person with the longer name is " + name1 + " with " + size1 + " letters ");
            }
            else if (size2 > size1)
            {
                Console.WriteLine(" The person with the longer name is " + name2 + " with " + size2 + " letters ");
            }
            else
            {
                Console.WriteLine(" You both have the same amount of letters in your names with " + size1 + " letters ");   
            }
            Console.ReadLine();

            //Upper and lower case
            String test = "HELLO this is a test sequence";
            test = test.ToLower();  //Changes the sentence to all lower case, can change to capitals with toupper
            Console.WriteLine(test);
            Console.ReadLine();

            //Substring 
            //This extracts a chunk of a sentence starts at 0 and the second number is how many characters it takes.
            String sentence = "Hello Bob";
            String extract = sentence.Substring(3, 4);
            Console.WriteLine(extract);
            Console.ReadLine();

            
            
        }
    }
}
