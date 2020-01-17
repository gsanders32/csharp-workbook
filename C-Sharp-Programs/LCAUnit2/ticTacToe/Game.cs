/*using System;
using System.Collections.Generic;
using System.Text;

namespace ticTacToe
{
    class Game
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Lets play Tic Tac Toe");
            TicTacToeGame();
        }

        public static void TicTacToeGame()
        {
            Console.WriteLine("Would you like to play as X or O?");
            string user = Console.ReadLine().ToLower();

            int x = 0;
            string userMarker = "";
            string pcMarker = "";

            while (x == 0)
            {
                if (user.Length >= 1)
                {
                    if (user == "x" || user == "1")
                    {
                        x++;
                        userMarker = "X";
                        pcMarker = "O";
                    }
                    else if (user == "o" || user == "2")
                    {
                        x++;
                        userMarker = "O";
                        pcMarker = "X";
                    }
                    else
                    {
                        Console.WriteLine("You did not select X or O");
                        Console.WriteLine("Would you like to play as X or O ?");
                        user = Console.ReadLine().ToLower();
                    }
                }
                else
                {
                    Console.WriteLine("You did not select X or O");
                    Console.WriteLine("Would you like to play as X or O ?");
                    user = Console.ReadLine().ToLower();
                }
            }



            int i = 0;
            while (i == 0)
            {

                GameBoard(userMarker);
                i++;
            }


        }

        public static void GameBoard(string userMarker)
        {

            string[] plays = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            //create board
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("     |     |");
            Console.WriteLine("  " + plays[0] + "  |  " + plays[1] + "  |  " + plays[2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |");
            Console.WriteLine("  " + plays[3] + "  |  " + plays[4] + "  |  " + plays[5]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |");
            Console.WriteLine("  " + plays[6] + "  |  " + plays[7] + "  |  " + plays[8]);
            Console.WriteLine("     |     |");

            Console.WriteLine("Enter the number where you want to play");
            string userPlay = Console.ReadLine();



            int square;
            if (int.TryParse(userPlay, out square))
            {
                GamePlay(square, userMarker, plays);
            }
        }

        public static string[] GamePlay(int square, string userMarker, string[] plays)
        {
            Console.WriteLine(plays[square]);
            plays[square - 1] = userMarker;
            Console.WriteLine(plays[square]);
            Console.Clear();
            GameBoard(userMarker);
            return plays;
        }

    }
}
*/