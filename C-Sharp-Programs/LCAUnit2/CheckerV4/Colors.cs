using System;
using System.Collections.Generic;
using System.Text;

namespace CheckerV4
{
    public class Colors
    {
        public enum Color { Blue = 1, Red = 2, Green = 3, White = 4 }
        public static void Change(Color item)
        {
            string color = Enum.GetName(typeof(Color), item);
            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color);
        }
        public static void CurrentTeamColor(string item)
        {
            string color = item == "Red" ? "Red" : "Blue";
            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color);
        }
    }
}
