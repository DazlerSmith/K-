using System;

namespace Math_Functions
{
    class Program
    {
        static void Main(string[] args)
        {
            //Must be using systems too work.
            //Trigonometry (Identifying angles)

            Console.WriteLine("Enter the side you are missing (Easier for me to get angle)");
            string missing = Console.ReadLine();
            missing = missing.ToLower();  //This is so i get 2 angles

            if (missing == "hypotenuse")
            {
                Console.WriteLine(" In cm ");
                Console.WriteLine(" Enter the opposite ");  //Getting results of sides
                decimal opposite = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine(" Enter the adjacent ");
                decimal adjacent = Convert.ToDecimal(Console.ReadLine());
            }
            else if (missing == "adjacent")
            {
                Console.WriteLine(" In cm ");
                Console.WriteLine(" Enter the hypotenuse ");
                decimal hypotenuse = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine(" Enter the opposite ");
                decimal opposite = Convert.ToDecimal(Console.ReadLine());
            }
            else if (missing == "opposite") 
            {
                Console.WriteLine(" In cm ");
                Console.WriteLine(" Enter the hypotenuse ");
                decimal hypotenuse = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine(" Enter the opposite ");
                decimal adjacent = Convert.ToDecimal(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Spell properly :)");
            }
            
           
            // Powers Table
            Console.WriteLine("Enter a number");
            int number = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < 21; i++)
            {

                Console.WriteLine(number + " to the power of " + i + " = " + Math.Pow(number, i));
            }
            Console.ReadLine();
        }
    }
}
