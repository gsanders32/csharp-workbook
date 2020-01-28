using System;
using System.Linq;

namespace UnsortedScores
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] unsortedScores = new int[] { 37, 89, 41, 65, 91, 53 };
            int[] sortedScores = unsortedScores.OrderByDescending(i => i).ToArray();
            foreach (var item in sortedScores)
            {
                Console.Write(item + ", ");
            }
            Console.ReadKey();
        }
    }
}
