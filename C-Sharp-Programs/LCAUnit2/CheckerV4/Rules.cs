using System;
using System.Collections.Generic;
using System.Text;

namespace CheckerV4
{
    class Rules
    {
        public static void Display()
        {
            Console.Clear();
            Console.WriteLine("OBJECT");
            Console.WriteLine("Remove all of your opponent's checkers from the gameboard by capturing them.\n");
            Console.WriteLine("MOVEMENT RULES");
            Console.WriteLine("1. Always move your checker diagonally forward, toward your opponent's side of the gameboard.");
            Console.WriteLine("   Note: After a checker becomes a King, it can move diagonally forward or backward.");
            Console.WriteLine("2. Move your checker one space diagonally, to an open adjacent square; or jump one or more checkers diagonally to an open square adjacent to the checker you jumped.When you jump over an opponent's checker, you capture it.");
            Console.WriteLine("3. If all squares adjacent to your checker are occupied, your checker is blocked and cannot move.\n");
            Console.WriteLine("CAPTURING AN OPPONENTS CHECKER");
            Console.WriteLine("If you jump an opponent's checker, you capture it. Remove it from the gameboard and place it in front of you.");
            Console.WriteLine("BECOMING A KING");
            Console.WriteLine("As soon as one of your checkers reaches the first row on your opponent's side of the gameboard, it becomes a King. Now this checker can move forward or backward on the gameboard.\n");
            Console.WriteLine("HOW TO WIN");
            Console.WriteLine("The first player to capture all opposing checkers from the gameboard wins the game!\n");
        }
    }
}
