using System;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            bool check = false;

            while (check == false) // Allows for the user to enter vales for i over and over till it is correct.
            {


                try
                {
                    
                    i = Convert.ToInt32(Console.ReadLine());
                    int b = 5 / i;
                    check = true;
                }
                catch (FormatException e) // Not the correct format (letters instead of integers)
                {

                    Console.WriteLine("invalid Entry");
                    Console.WriteLine(e.Message);
                }
                catch (DivideByZeroException e)  // Just putting exception targets all exceptions
                { //but targeting specific exceptions allows for specific texts.

                    Console.WriteLine("invalid Entry"); 
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.Source);  // all these are different things that can be added on the end of an exception error.
                    Console.WriteLine(e.Data);
                    Console.WriteLine(e.HResult);


                }
            }
            
            
        }
    }
}
