using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp
{
    class Colors
    {
        public enum Color { Blue = 1, Red = 2, Green = 3, Black = 4 }
        public static void Change(Color item)//use to change console text color
        {
            string color = Enum.GetName(typeof(Color), item);
            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color);
        }
    }
}
