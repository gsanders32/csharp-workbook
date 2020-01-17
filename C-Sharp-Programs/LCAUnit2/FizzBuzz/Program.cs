using System;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.Title = "FizzBuzz";
            //int i = 1;
            for (int i = 1; i <= 100; i++)
            //while (i <= 100)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine(i + " = FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine(i + " = Fizz");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine(i + " = Buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }
                //i++;
            }
            Console.ReadKey();
        }
    }
}
