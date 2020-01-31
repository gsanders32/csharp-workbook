using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace scratchpad
{
    class test
    {
		static void Main(string[] args)
		{
			int[] unsortedScores = new int[] { 37, 89, 41, 65, 91, 53, 13, 100 };
			int test = 1;
			while (test < unsortedScores.Length)
			{
				for (int i = 0; i < unsortedScores.Length - 1; i++)
				{
					if (unsortedScores[i] < unsortedScores[i + 1])
					{
						int one = unsortedScores[i];
						int two = unsortedScores[i + 1];
						unsortedScores[i] = two;
						unsortedScores[i + 1] = one;
						foreach (var item in unsortedScores)
						{
							Console.Write($"{item},");
						}
						Console.WriteLine("\n");
					}
				};
				test += 1;
			}
			Console.ReadKey();
		}
	}

}
