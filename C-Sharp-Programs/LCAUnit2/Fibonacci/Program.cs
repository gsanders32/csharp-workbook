using System;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int temp1 = 1;
            int temp2 = 1;
            int sum = 0;
            Console.WriteLine(temp1);
            for (int i = 0; i <= 4000000; i++)
            {
                int temp3 = temp1 + temp2;
                if (temp3 % 2 == 0 && temp3 <= 4000000)
                {
                    sum += temp3;

                }
                else if (temp3 >= 4000000)
                {
                    Console.WriteLine($"Sum: {sum}");
                    break;
                }                
                Console.WriteLine(temp3);
                temp1 = temp2;
                temp2 = temp3;
            }
        }
    }
}
