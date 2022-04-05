using System;

class Program
{
    static int Factorial(int n)
    {
     if (n == 0)
	{
        return 1;  //Not factorial method
        
     }
        return n * Factorial(n - 1);
    }

    static void Main()
    {
        // Call recursive method with two parameters.
        int total = Factorial(5);
        // Write the result from the method calls and the count.
        Console.WriteLine(total);
        //Console.WriteLine(count);
        Console.WriteLine();
        Console.ReadLine();
    }
}
