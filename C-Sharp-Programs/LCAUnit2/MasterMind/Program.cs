using System;

namespace MasterMind
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "MasterMind";
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Hello Let's play MasterMind");
            Console.WriteLine("\nHow to play:");
            Console.WriteLine("\nThe Player will try and guess the two colors the computer picked in order");
            Console.WriteLine("\nThe computer will select 2 colors at random from (Red, Yellow and Blue). The colors can repeat.");
            Console.WriteLine("\nYou will get hints to help you pick the right colors and order");
            GameHints();
            ComputerPicks();
            GamePlay();
        }

        static string[] UserColorArray = new string[2];
        static string[] ComputerColorArray = new string[2];
        static readonly string[] colors = new string[3] { "Red", "Yellow", "Blue" };

        static void GameHints()
        {
            Console.WriteLine("0 - 0 You did not guess the correct colors at all");
            Console.WriteLine("1 - 0 You guessed one of the colors correctly but not at the correct position");
            Console.WriteLine("0 - 1 You guessed one of the colors correctly at the correct position");
            Console.WriteLine("2 - 0 You guessed both colors correctly but at the wrong positions");
        }
        static void ComputerPicks()
        {
            //create pc move
            Random rand = new Random();
            
            int color1 = rand.Next(colors.Length); //pick random number
            int color2 = rand.Next(colors.Length); //pick random number

            ComputerColorArray[0] = colors[color1]; //get the color
            ComputerColorArray[1] = colors[color2]; //get the color
        }
        static bool UserPicks(string userColor, int position)
        {
            if (userColor == "r" || userColor == "y" || userColor == "b")//test input
            {
                switch (userColor)//set user color
                {
                    case "r":
                        UserColorArray[position] = "Red";
                        break;
                    case "y":
                        UserColorArray[position] = "Yellow";
                        break;
                    case "b":
                        UserColorArray[position] = "Blue";
                        break;
                }
                return true;
            }
            else
            {
                ColorError();
                Console.WriteLine("\nYou did not pick a vaild Color try again!");
                ColorError();
                return false;
            }
        }
        static void GamePlay()
        {
            string color;
            do
            {
                Console.WriteLine("\nSelect your First color R = Red, Y = Yellow, and B = Blue");
                color = Console.ReadLine().ToLower().Trim();
            } while (!UserPicks(color, 0));

            do
            {
                Console.WriteLine("\nSelect your Second color R = Red, Y= Yellow, and B=Blue");
                color = Console.ReadLine().ToLower().Trim();
            } while (!UserPicks(color, 1));

            //Testing
            /*ComputerColorArray[0] = "Red";
            ComputerColorArray[1] = "Blue";*/
            if (UserColorArray[0] == ComputerColorArray[0] && UserColorArray[1] == ComputerColorArray[1]) // both colors guessed
            {
                ColorWin();
                Console.WriteLine("\nGreat job you guested both colors!!");
                Console.WriteLine("\nWould you like to play again? Y/N");
                ColorWin();
                string again = Console.ReadLine().ToLower();
                if(again == "y" || again == "yes")
                {
                    Console.Clear();
                    ComputerPicks();
                    GameHints();
                    GamePlay();
                }
            }
            else if (UserColorArray[0] == ComputerColorArray[1] && UserColorArray[1] == ComputerColorArray[0]) //guessed both wrong order
            {
                Console.WriteLine("2 - 0 You guessed both colors correctly but at the wrong positions");
                GamePlay();
            }
            else if (UserColorArray[0] == ComputerColorArray[0] || UserColorArray[0] == ComputerColorArray[1] || UserColorArray[1] == ComputerColorArray[0] || UserColorArray[1] == ComputerColorArray[1]) // guessed one color
            {
                if (UserColorArray[0] == ComputerColorArray[0] || UserColorArray[1] == ComputerColorArray[1])
                {
                    Console.WriteLine("0 - 1 You guessed one of the colors correctly at the correct position"); //one in right position
                    GamePlay();
                }
                else
                {
                    Console.WriteLine("1 - 0 You guessed one of the colors correctly but not at the correct position"); //none in right position
                    GamePlay();
                }
            }
            else
            {
                Console.WriteLine("0 - 0 You did not guess any of the colors"); // no colors guessed
                GamePlay();
            }
        }
        static void ColorError() //change color to white or red
        {
            Console.ForegroundColor = Console.ForegroundColor == ConsoleColor.White ? ConsoleColor.Red : ConsoleColor.White;
        }
        static void ColorWin() //change color to white or red
        {
            Console.ForegroundColor = Console.ForegroundColor == ConsoleColor.White ? ConsoleColor.Green : ConsoleColor.White;
        }
    }
}
