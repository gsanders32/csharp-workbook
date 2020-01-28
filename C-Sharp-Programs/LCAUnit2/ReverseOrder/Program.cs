using System;
using System.Linq;

namespace ReverseOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] reverseOrder = new int[] { 1, 2, 3, 4, 5 };
            foreach (var item in reverseOrder)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine("\n");
            foreach (var item in reverseOrder.Reverse())
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine("\n");
            int[] dup = new int[reverseOrder.Length * 2];

            int count = 0;
            for (int i = 0; i < 2; i++)
            {
                
                foreach (var item in reverseOrder)
                {
                    dup[count] = item;
                    count += 1;
                }
            }
            foreach (var item in dup)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine("\n");
        }
    }
}
