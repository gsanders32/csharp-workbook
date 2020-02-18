using System;
using System.Collections.Generic;
using System.Text;

namespace BookInventory
{
    class Colors
    {
        public enum Color { Red, Green, White, Yellow }
        public static void Change(Color item)
        {
            string color = Enum.GetName(typeof(Color), item);
            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color);
        }
    }
}
