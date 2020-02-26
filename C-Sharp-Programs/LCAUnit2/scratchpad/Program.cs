using System;
using System.IO;
using System.Linq;

namespace scratchpad
{
    public class Program
    {
        public static void Main()
        {
            int[] arrtest = new int[] { 1, 9, 6, 7, 5, 9 };

            for (int i = 0; i < arrtest.Length; i++)
            {
                for (int j = 0; j < arrtest.Length; j++)
                {
                    if (arrtest[i] < arrtest[j])
                    {
                        int temp = arrtest[i];
                        arrtest[i] = arrtest[j];
                        arrtest[j] = temp;

                    }
                }
            }
            foreach (int item in arrtest)
            {
                Console.Write(item + " ");
            }
            Console.Read();
        }
    }
}
