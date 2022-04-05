using System;

namespace ISBN_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Please enter the ISBN number without the final check digit :) ");
            String value = (Console.ReadLine());
            int length = value.Length;
            int Total = 0;

            for (int i = 0; i < length; i++)
            {
                if (i % 2 == 0)
                {
                    Total = Total + Convert.ToInt32(value[i].ToString());
                    Console.WriteLine(value[i].ToString());
                }
                else
                {
                    Total = Total + (Convert.ToInt32(value[i].ToString())* 3);
                    Console.WriteLine(Convert.ToInt32(value[i].ToString()) * 3);
                }
            }
            Console.WriteLine(" Your total = " + Total);
            int Remain = Total % 10;
            int Digit = 10 - Remain;
            Console.WriteLine(" Your check digit is " + Digit);
            Console.ReadLine();
            Console.WriteLine("Your final ISBN number is " + value + Digit );
            Console.ReadLine();
        }
    }
}
