using System;
using System.Collections.Generic;

namespace NaturalNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[2] { 3, 5 };
            List<int> numsList = new List<int>();
            int sum = 0;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 1; j < 1000; j++)
                {
                    if (j * nums[i] < 1000)
                    {
                        numsList.Add(j * nums[i]);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            foreach (var item in numsList)
            {
                sum += item;
                Console.WriteLine(item);
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
