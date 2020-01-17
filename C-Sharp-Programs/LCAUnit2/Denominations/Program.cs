using System;

namespace Denominations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Denominations";

            string amount = "65496.92";

            string[] arrayOfAmount = amount.Split('.');
            int amountBills;
            int amountCoins;

            Console.WriteLine("Amount: $" + amount);
            Console.WriteLine("\nDenominations:\n");           

            if (int.TryParse(arrayOfAmount[0], out amountBills))
            {
                BillCounter(amountBills);
            }

            if (arrayOfAmount.Length >1)
            {
                if (int.TryParse(arrayOfAmount[1], out amountCoins))
                {
                    CoinCounter(amountCoins);
                }                
            }

            Console.ReadKey();
        }

        static void BillCounter(int amountBills)
        {
            int[] bills = new int[] { 100, 50, 20, 10, 5, 2, 1 };          
            int[] billCounter = new int[7];

            for (int i = 0; i < 7; i++)
            {
                if (amountBills >= bills[i])
                {
                    billCounter[i] = amountBills / bills[i];
                    amountBills = amountBills - billCounter[i] * bills[i];
                }
            }
       
            for (int i = 0; i < 7; i++)
            {
                if (billCounter[i] != 0)
                {
                    Console.WriteLine(billCounter[i] + "x $" + bills[i]);
                }
            }
        }

        static void CoinCounter(int amountCoins)
        {
            int[] coins = new int[] {50, 25, 10, 5, 1 };
            string[] coinName = new string[] { "Half Dollar", "Quarter(s)", "Dime(s)", "nickle(s)", "penny(-ies)" };
            int[] coinCounter = new int[5];

            for (int i = 0; i < 5; i++)
            {
                if (amountCoins >= coins[i])
                {
                    coinCounter[i] = amountCoins / coins[i];
                    amountCoins = amountCoins - coinCounter[i] * coins[i];
                }
            }
            
            for (int i = 0; i < 5; i++)
            {
                if (coinCounter[i] != 0)
                {
                    Console.WriteLine(coinCounter[i] + "x " + coinName[i]);
                }
            }
        }
    }
}
