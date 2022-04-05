using System;
using System.IO;

namespace Reading_and_Writing_Text_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create an instance of StreamWriter to write text to a file
            //The 'using' statement also closes the StreamWriter at the end.
            using (StreamWriter sw = new StreamWriter("TextFile.txt"))
            {
                // Add some text to the file
                sw.WriteLine("Hello world!");
                sw.WriteLine("------------");
                sw.WriteLine("Now I can have a permanent record of my achievement!");
                //Now we've finished using the file, it is closed.
            }

            using (StreamReader sr = new StreamReader("TextFile.txt"))
            {
                if (File.Exists("TextFile.txt"))  // It is capital letter sensitive
                {
                    Console.WriteLine("File exists");
                }

                String line;
                // Read and display lines from the file until the end of
                // the file is reached
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
                Console.ReadLine();






                // Times table exercise

                Console.WriteLine(" Enter a number ");
                int i = Convert.ToInt32(Console.ReadLine());

                try
                {
                    i = Convert.ToInt32("one");
                }
                catch (Exception e)
                {
                    Console.WriteLine(" Invalid Entry ");
                    Console.WriteLine(e.Message);
                    
                }
                using (StreamWriter sw = new StreamWriter("TimesTableFile.txt"))
                {

                }




            }
        }
    }
}
